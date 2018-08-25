// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList.Nodes;
using DevTool.Classes;
using DevTool.Controls;
using DevExpress.XtraEditors;
using DevTool.Properties;
using Microsoft.Test.Xbox.Profiles;
using Microsoft.Test.Xbox.XDRPC;
using XDevkit;
using DevExpress.XtraTreeList;
using DevExpress.XtraTab;
using DevExpress.XtraEditors.Controls;
using Timer = System.Threading.Timer;
using DevExpress.Utils.Taskbar.Core;
using System.Net.NetworkInformation;

namespace DevTool.Forms
{
    public sealed partial class MainForm : XtraForm
    {
        #region Fields and Constructors

        private XboxConsole console;
        private uint connection;
        private XboxManager manager;
        private readonly EndianIO xms;
        private TitleNameCache tnCache;
        private NeighborhoodDrives drives;
        private Timer tempTimer;
        private readonly XDKUtilities.DM_SYSTEM_INFO consoleInfo;
        private readonly ConsoleProfilesManager profileManager;
        private readonly PartyManager partyManager;
        private bool hasLoadedModuleLauncherList;
        private bool hasLoadedKeyboardHooks;
        private bool hasXamKeyboardBeenHooked;
        private bool hasLoadedNeighborhoodDrives;
        private ConsoleProfile signedinPlayer1;
        private IXboxSection quickSectionDumpSection;
        private string quickSectionDumpLocation;
        private object[] xUserInfo;

        private delegate void ModuleLoadUnloadDelegate(IXboxModule Module);

        public MainForm()
        {
            InitializeComponent();
            LookAndFeelHelper.ForceDefaultLookAndFeelChanged();
            SkinManager.EnableFormSkins();
            SkinManager.EnableMdiFormSkins();
            try
            {
                GlobalVariables.Skin = File.Exists("DefaultSkin.txt") ? File.ReadAllText("DefaultSkin.txt") : "Office 2013";
                SkinEdit.EditValue = GlobalVariables.Skin;
            }
            catch (Exception) { GlobalVariables.Skin = "Office 2013"; }
            if (XtraFunctions.FindProcess("DevTool") > 1)
            {
                XtraMessageBox.Show("There can only be 1 instance of DevTool open at a time. Close the conflicting instance and try again.", "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            Text += " - Version: " + GlobalVariables.ProgramVersion;
            try
            {
                manager = new XboxManager();
                try { console = manager.OpenConsole(File.Exists("OverrideConsoleName.txt") ? File.ReadAllText("OverrideConsoleName.txt") : manager.DefaultConsole); }
                catch (Exception) { console = manager.OpenConsole(manager.DefaultConsole); }
                connection = console.OpenConnection(null);
                if (!console.SupportsRPC())
                {
                    XtraMessageBox.Show(string.Format("DevTool cannot work without XDRPC, which {0} does not support.", console.Name), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                console.DebugTarget.ConnectAsDebugger("DevTool", XboxDebugConnectFlags.Force);
                xms = new EndianIO(new XboxMemoryStream(console.DebugTarget), EndianTypes.BigEndian);
                ReloadModules();
                console.OnStdNotify += HandleModuleLoadUnload;
                console.OnStdNotify += HandleDebugString;
                consoleInfo = XDKUtilities.DmGetSystemInfo(console);
                profileManager = console.CreateConsoleProfilesManager();
                partyManager = console.CreatePartyManager();
                var smcVerRequest = new byte[16];
                var smcVerResponse = new byte[16];
                smcVerRequest[0] = (byte)XDKUtilities.SMCCommands.SMC_QUERY_VERSION;
                XDKUtilities.HalSendSMCMessage(console, smcVerRequest, ref smcVerResponse);
                StatusText.Caption = string.Format("{0} [{1}, SMC: v{2}] :: Type: {3}, Supported Features: {4}", manager.DefaultConsole, consoleInfo, string.Format("{0}.{1}", smcVerResponse[2], smcVerResponse[3]), XDKUtilities.DmGetConsoleType(console).ToString().Replace("_", " "), XDKUtilities.DmGetConsoleFeatures(console).ToString().Replace("_", " "));
                XDKUtilities.XNotifyQueueUI(console, 0, XDKUtilities.XNotifyUITypes.XNOTIFYUI_TYPE_PREFERRED_REVIEW, XDKUtilities.XNotifyUIPriorities.XNOTIFYUI_PRIORITY_HIGH, string.Format("DevTool v{0} connected", GlobalVariables.ProgramVersion));
                var th = new Thread(UpdateCheck) { Name = "UPDCHK", IsBackground = true };
                th.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Failed to connect to {0}. Make sure {0} is powered on, responsive, and connected to the local network.{1}{2}", manager.DefaultConsole, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        #endregion

        #region Enumerations

        [Flags]
        private enum XboxSectionInfoFlags
        {
            None = 0,
            Loaded = 1,
            Readable = 2,
            Writeable = 4,
            Executable = 8,
            Uninitialized = 0x10
        }

        [Flags]
        private enum XboxModuleInfoFlags
        {
            None = 0,
            Main = 1,
            TLS = 2,
            Library = 4
        }

        #endregion

        #region Structures

        private struct TitleTag
        {
            public string Name { get; set; }

            public XDKUtilities.ExecutionID EID { get; set; }
        }

        #endregion

        #region Methods

        public void ShowWaitForm(string Caption = "", string Description = "")
        {
            if (SplashScreenManager.IsSplashFormVisible) return;
            SplashScreenManager.ShowWaitForm();
            SplashScreenManager.SetWaitFormCaption(Caption);
            SplashScreenManager.SetWaitFormDescription(Description);
        }

        public void SetWaitFormCaption(string Caption) { SplashScreenManager.SetWaitFormCaption(Caption); }

        public void SetWaitFormDescription(string Description) { SplashScreenManager.SetWaitFormDescription(Description); }

        public void CloseWaitForm()
        {
            if (!SplashScreenManager.IsSplashFormVisible) return;
            SplashScreenManager.CloseWaitForm();
        }

        private void CreateNode(IXboxModule Module)
        {
            ModuleTree.FocusedNode = null;
            var node = ModuleTree.AppendNode(null, null);
            string mn;
            int index;
            try
            {
                //These modules will throw an exception when getting the module name from them, so, to speed up things by a second, let's avoid that exception.
                switch (Module.ModuleInfo.Name)
                {
                    case "aac.xex":
                        {
                            index = 2;
                            mn = string.Empty;
                            break;
                        }
                    case "xboxkrnl.exe":
                        {
                            index = 0;
                            mn = string.Empty;
                            break;
                        }
                    default:
                        {
                            mn = Module.Executable.GetPEModuleName();
                            index = String.CompareOrdinal(Path.GetExtension(mn), ".exe") == 0 ? 0 : 1;
                            if (String.CompareOrdinal(mn, Module.ModuleInfo.Name) == 0) mn = string.Empty;
                            break;
                        }
                }
            }
            catch (Exception)
            {
                index = 2;
                mn = string.Empty;
            }
            node.Tag = Module;
            node.ImageIndex = index;
            node.StateImageIndex = index;
            node.SelectImageIndex = index;
            node.SetValue(ModuleTreeNameColumn, Module.ModuleInfo.Name + (string.IsNullOrEmpty(mn) ? string.Empty : string.Format(" ({0})", mn)));
            node.SetValue(ModuleTreeAddressColumn, XtraFunctions.ValueToHex(Module.ModuleInfo.BaseAddress));
            node.SetValue(ModuleTreeSizeColumn, string.Format("{0} ({1})", XtraFunctions.ValueToHex(Module.ModuleInfo.Size), XtraFunctions.FormatSize(Module.ModuleInfo.Size)));
            node.SetValue(ModuleTreeOccupiedMemoryColumn, string.Format("{0} - {1}", XtraFunctions.ValueToHex(Module.ModuleInfo.BaseAddress), XtraFunctions.ValueToHex(Module.ModuleInfo.BaseAddress + Module.ModuleInfo.Size)));
        }

        private void RemoveNode(IXboxModule Module)
        {
            ModuleTree.FocusedNode = null;
            foreach (var node in from TreeListNode node in ModuleTree.Nodes let tag = (IXboxModule)node.Tag where String.CompareOrdinal(Module.ModuleInfo.FullName, tag.ModuleInfo.FullName) == 0 select node)
            {
                ModuleTree.Nodes.Remove(node);
                break;
            }
        }

        private void UpdateDebugMemo(string DebugString)
        {
            if (string.IsNullOrWhiteSpace(DebugString)) return;
            foreach (var newS in DebugString.Split(Environment.NewLine.ToCharArray()).Where(newS => !string.IsNullOrWhiteSpace(newS)))
            {
                XtraFunctions.InvokeEx(DebugPrintingMemo, dpm => dpm.Text += string.Format("[{0}] {1}{2}", DateTime.Now, newS, Environment.NewLine));
                Application.DoEvents();
                XtraFunctions.InvokeEx(DebugPrintingMemo, dpm => dpm.SelectionStart = dpm.Text.Length);
                XtraFunctions.InvokeEx(DebugPrintingMemo, dpm => dpm.ScrollToCaret());
            }
        }

        private void SetupKeyboardHooking(uint Address)
        {
            console.DebugTarget.SetBreakpoint(Address);
            console.OnStdNotify += (EventType, EventInfo) =>
            {
                if (EventType != XboxDebugEventType.ExecutionBreak || EventInfo.Info.Address != Address) return;
                HandleKeyboardHook(EventInfo.Info);
            };
        }

        private void UpdateCheck()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return;
            //TODO
        }

        private void DumpMemory(uint Address, uint Length, string SaveLocation)
        {
            using (var io = new EndianIO(SaveLocation, EndianTypes.LittleEndian, FileMode.Create))
            {
                io.Stream.SetLength(Length);
                xms.SetPosition(Address);
                var sizeBuf = Length;
                while (sizeBuf > 0)
                {
                    var size = Math.Min(sizeBuf, 0x2000);
                    io.Writer.Write(xms.Reader.ReadBytes((int)size));
                    WindowsTaskbarHelper.SetProgressValue(Length - sizeBuf, Length);
                    SetWaitFormDescription((byte)XtraFunctions.ComputePercentage(Length - sizeBuf, Length) + "% complete");
                    sizeBuf -= size;
                }
            }
        }

        private void WriteMemory(uint Address, uint Length, string DumpLocation)
        {
            using (var io = new EndianIO(DumpLocation, EndianTypes.LittleEndian))
            {
                xms.SetPosition(Address);
                var sizeBuf = Length;
                while (sizeBuf > 0)
                {
                    var size = Math.Min(sizeBuf, 0x2000);
                    xms.Writer.Write(io.Reader.ReadBytes((int)size));
                    WindowsTaskbarHelper.SetProgressValue(Length - sizeBuf, Length);
                    SetWaitFormDescription((byte)XtraFunctions.ComputePercentage(Length - sizeBuf, Length) + "% complete");
                    sizeBuf -= size;
                }
            }
        }

        private void HandleKeyboardHook(XBOX_EVENT_INFO EventInfo)
        {
            try
            {
                long r5; //wseDefaultText
                long r6; //wszTitleText
                long r7; //wszDescriptionText
                long r9; //cchResultText
                var functionStack = EventInfo.Thread.TopOfStack;
                functionStack.GetRegister64(XboxRegisters64.r5, out r5);
                functionStack.GetRegister64(XboxRegisters64.r6, out r6);
                functionStack.GetRegister64(XboxRegisters64.r7, out r7);
                functionStack.GetRegister64(XboxRegisters64.r9, out r9);
                xms.SetPosition(r6);
                var title = xms.Reader.ReadString(-1, Encoding.BigEndianUnicode, true);
                xms.SetPosition(r7);
                var description = xms.Reader.ReadString(-1, Encoding.BigEndianUnicode, true);
                foreach (var hookControl in from object control in KeyboardHookingScroller.Controls where !(control is LabelControl) select (KeyboardHookControl)control into hookControl where String.CompareOrdinal(title, hookControl.TitleOrDescription) == 0 || String.CompareOrdinal(description, hookControl.TitleOrDescription) == 0 select hookControl)
                {
                    xms.SetPosition(r5);
                    xms.Writer.Write(hookControl.InsertText, Encoding.BigEndianUnicode, 1);
                    break;
                }
            }
            catch (Exception){}
            finally
            {
                if (Convert.ToBoolean(EventInfo.IsThreadStopped))
                {
                    bool flag2;
                    EventInfo.Thread.Continue(true);
                    console.DebugTarget.Go(out flag2);
                    console.DebugTarget.FreeEventInfo(EventInfo);
                }
            }
        }

        private void HandleDebugString(XboxDebugEventType EventCode, IXboxEventInfo EventInfo)
        {
            if (EventCode != XboxDebugEventType.DebugString) return;
            UpdateDebugMemo(EventInfo.Info.Message);
        }

        private void HandleModuleLoadUnload(XboxDebugEventType EventCode, IXboxEventInfo EventInfo)
        {
            if (EventCode == XboxDebugEventType.ModuleLoad)
            {
                ModuleTree.Invoke(new ModuleLoadUnloadDelegate(CreateNode), EventInfo.Info.Module);
                if (String.CompareOrdinal(Path.GetFileName(console.RunningProcessInfo.ProgramName), EventInfo.Info.Module.ModuleInfo.Name) == 0) SetTitleInfo();
            }
            else if (EventCode == XboxDebugEventType.ModuleUnload) ModuleTree.Invoke(new ModuleLoadUnloadDelegate(RemoveNode), EventInfo.Info.Module);
        }

        private void ReloadModules()
        {
            ModuleTree.BeginUnboundLoad();
            ModuleTree.Nodes.Clear();
            foreach (IXboxModule module in console.DebugTarget.Modules) CreateNode(module);
            ModuleTree.EndUnboundLoad();
            ModuleTree.FocusedColumn = ModuleTreeNameColumn;
            ModuleTree.BestFitColumns();
            ModuleTree.FocusedNode = null;
            SetTitleInfo();
        }

        //Thread this
        private void SetTileAvatarImage(ITileItem Tile, string Gamertag)
        {
            var image = Resources.Avatar_None;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                try { image = XtraFunctions.ResizeImage(Image.FromStream(WebRequest.Create(string.Format("http://avatar.xboxlive.com/avatar/{0}/avatar-body.png", Gamertag)).GetResponse().GetResponseStream()), 48, 96); }
                catch (Exception){}
            }
            Tile.Elements.Add(new TileItemElement { ImageAlignment = TileItemContentAlignment.Manual, ImageLocation = new Point(193, 15), Image = image });
        }

        private void SetTitleInfo()
        {
            try
            {
                var eid = XDKUtilities.XamGetExecutionId(console);
                var tn = GetTitleName(eid.TitleID, false);
                XtraFunctions.InvokeEx(CurrentTitleLabel, ctl => ctl.Tag = new TitleTag { Name = tn, EID = eid });
                XtraFunctions.InvokeEx(CurrentTitleLabel, ctl => ctl.Text = string.Format("Name: {0}, ID: {1}, Version: v{2}, Base Version: v{3}", tn, XtraFunctions.ValueToHex(eid.TitleID).Remove(0, 2).PadLeft(8, '0'), eid.Version, eid.BaseVersion));
            }
            catch (Exception ex)
            {
                XtraFunctions.InvokeEx(CurrentTitleLabel, ctl => ctl.Tag = null);
                XtraFunctions.InvokeEx(CurrentTitleLabel, ctl => ctl.Text = "Failed to retrieve title information: " + XDKUtilities.CreateExceptionMessage(ex, manager));
            }
            XtraFunctions.InvokeEx(CurrentTitleEdit, cte => cte.Text = console.RunningProcessInfo.ProgramName);
        }

        private Image GetFriendStatusImage(FriendStatus Status)
        {
            switch (Status)
            {
                case FriendStatus.Online: return Resources.Friend_Online;
                case FriendStatus.Offline: return Resources.Friend_Offline;
                case FriendStatus.Busy: return Resources.Friend_Busy;
                case FriendStatus.Away: return Resources.Friend_Away;
            }
            return null;
        }

        private string GetTitleName(uint TitleID, bool IDInUnknownGameString)
        {
            if (TitleID == 0) return IDInUnknownGameString ? "Unknown Game (00000000)" : "Unknown Game";
            if (tnCache == null) tnCache = new TitleNameCache("TitleNameCache.txt");
            var titleName = tnCache.TitleIDToTitleName(XtraFunctions.ValueToHex(TitleID).Remove(0, 2).PadLeft(8, '0'));
            if (String.CompareOrdinal(titleName, "(NOT FOUND)") == 0)
            {
                titleName = XDKUtilities.XamGetCachedTitleName(console, TitleID);
                if (string.IsNullOrWhiteSpace(titleName))
                {
                    titleName = "Unknown Game";
                    if (IDInUnknownGameString) titleName += string.Format(" ({0})", XtraFunctions.ValueToHex(TitleID).Remove(0, 2).PadLeft(8, '0'));
                }
                else tnCache.AddTitle(titleName, XtraFunctions.ValueToHex(TitleID).Remove(0, 2).PadLeft(8, '0'));
            }
            return titleName;
        }

        private void ReloadFriends()
        {
            FriendsTileControl.BeginUpdate();
            FriendsTileControl.Tag = (byte)0;
            FriendsTileGroup.Items.Clear();
            foreach (var friend in signedinPlayer1.Friends.EnumerateFriends())
            {
                var ti = new TileItem { ItemSize = TileItemSize.Large, Tag = friend, Name = friend.Gamertag + "Tile", Text = string.Format("<Color=\"black\"><b>{0}</b></Color>", friend.Gamertag) };
                ti.ItemClick += FriendTile_ItemClick;
                ti.RightItemClick += FriendTile_RightItemClick;
                ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 15), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"white\"><b>{0}</b></Color>", XtraFunctions.ValueToHex(friend.OnlineXuid.value).Remove(0, 2).PadLeft(16, '0')) });
                ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 30), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"white\"><b>{0}</b></Color>", friend.RequestStatus) });
                if (friend.FriendState != FriendStatus.Offline)
                {
                    ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 45), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"white\"><b>Playing: {0}</b></Color>", GetTitleName(friend.TitleId, true)) });
                    ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 60), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"white\"><b>{0}</b></Color>", friend.RichPresence) });
                }
                ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, friend.FriendState != FriendStatus.Offline ? 90 : 45), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"white\"><b>{0}</b></Color>", friend.FriendState) });
                ti.Elements.Add(new TileItemElement { ImageAlignment = TileItemContentAlignment.Manual, Image = GetFriendStatusImage(friend.FriendState), ImageLocation = new Point(205, -5) });
                var th = new Thread(() => SetTileAvatarImage(ti, friend.Gamertag)) { IsBackground = true, Name = "AVATILD" };
                th.Start();
                switch (friend.RequestStatus)
                {
                    case FriendRequestStatus.RequestSent:
                        {
                            ti.AppearanceItem.Normal.BackColor = Color.LightSeaGreen;
                            break;
                        }
                    case FriendRequestStatus.RequestReceived:
                        {
                            ti.AppearanceItem.Normal.BackColor = Color.Gold;
                            break;
                        }
                    case FriendRequestStatus.RequestAccepted:
                        {
                            ti.AppearanceItem.Normal.BackColor = Color.Green;
                            break;
                        }
                }
                FriendsTileGroup.Items.Add(ti);
            }
            FriendsTileControl.EndUpdate();
        }

        #endregion

        #region Events

        #region General

        private void SkinEdit_EditValueChanged(object sender, EventArgs e)
        {
            GlobalVariables.Skin = SkinEdit.EditValue.ToString();
            File.WriteAllText("DefaultSkin.txt", GlobalVariables.Skin);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                if (!string.IsNullOrWhiteSpace(quickSectionDumpLocation))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
                        ShowWaitForm(string.Format("Dumping {0}...", quickSectionDumpSection.SectionInfo.Name), "0% complete");
                        DumpMemory(quickSectionDumpSection.SectionInfo.BaseAddress, quickSectionDumpSection.SectionInfo.Size, quickSectionDumpLocation);
                        Cursor = Cursors.Default;
                        WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                        CloseWaitForm();
                        XtraMessageBox.Show(string.Format("Successfully dumped the {0} section.", quickSectionDumpSection.SectionInfo.Name), "Dump Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                        CloseWaitForm();
                        XtraMessageBox.Show(string.Format("Failed to dump the {0} section.{1}{2}", quickSectionDumpSection.SectionInfo.Name, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ForceReconnectButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                manager = new XboxManager();
                try { console = manager.OpenConsole(File.Exists("OverrideConsoleName.txt") ? File.ReadAllText("OverrideConsoleName.txt") : manager.DefaultConsole); }
                catch (Exception) { console = manager.OpenConsole(manager.DefaultConsole); }
                connection = console.OpenConnection(null);
                console.DebugTarget.ConnectAsDebugger("DevTool", XboxDebugConnectFlags.Force);
                foreach (var moduleControl in ModuleLauncherScroller.Controls.Cast<object>().Where(control => !(control is LabelControl)).Cast<ModuleLauncherControl>())
                {
                    moduleControl.Console = console;
                    moduleControl.Connection = connection;
                }
                //Rehook xam if we had it hooked before.
                if (hasXamKeyboardBeenHooked) SetupKeyboardHooking(XDKUtilities.XexGetProcedureAddress(console, XDKUtilities.XexGetModuleHandle(console, "xam.xex"), 705));
                XDKUtilities.XNotifyQueueUI(console, 0, XDKUtilities.XNotifyUITypes.XNOTIFYUI_TYPE_PREFERRED_REVIEW, XDKUtilities.XNotifyUIPriorities.XNOTIFYUI_PRIORITY_HIGH, string.Format("DevTool v{0} connected", GlobalVariables.ProgramVersion));
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to establish a new connection. The console may be in an unresponsive (crashed) state.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void AboutItem_ItemClick(object sender, ItemClickEventArgs e) { XtraMessageBox.Show(string.Format("Created by Eaton.{0}Version: v{1}{0}Special thanks to:{0}The FSD authors (SMC information){0}CLK (Neighborhood drive mapping information){0}{0}GitHub repository: https://github.com/EatonZ/DevTool", Environment.NewLine, GlobalVariables.ProgramVersion), "DevTool - About", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                console.DebugTarget.RemoveAllBreakpoints();
                console.DebugTarget.DisconnectAsDebugger();
                console.CloseConnection(connection);
            }
            catch (Exception){}
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            WindowsTaskbarHelper.MainWindowHandle = Handle;
            ModuleTree.FocusedNode = null;
            ActiveControl = null;
        }

        private void Tabs_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (tempTimer != null) tempTimer.Dispose();
            tempTimer = null;
            if (e.Page == MemoryTab)
            {
                try { ReloadModules(); }
                catch (Exception ex)
                {
                    ModuleTree.EndUnboundLoad();
                    XtraMessageBox.Show(string.Format("Failed to retrieve the list of modules from the console.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else if (e.Page == PatchingTab)
            {
                try { if (File.Exists("patches.s")) PatchText.Lines = File.ReadAllLines("patches.s"); }
                catch (Exception) { PatchText.Text = string.Empty; }
            }
            else if (e.Page == XBLCenterTab)
            {
                if (consoleInfo.KernelVersion.Version.Build < 14401)
                {
                    XtraMessageBox.Show(string.Format("XBL Center is disabled until you upgrade {0}'s flash to a newer version.", console.Name), "Recovery too old for XBL feature support", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                try
                {
                    xUserInfo = new object[2];
                    xUserInfo[0] = false;
                    var address = File.ReadAllLines("XUserFindUserAddress.txt");
                    if (Convert.ToUInt32(address[0]) == consoleInfo.KernelVersion.Version.Build)
                    {
                        xUserInfo[1] = (uint)XtraFunctions.ValueFromHex(address[1]);
                        xUserInfo[0] = true;
                    }
                }
                catch (Exception){}
                List<ConsoleProfile> siProfiles;
                List<ConsoleProfile> lcProfiles;
                try
                {
                    siProfiles = profileManager.GetSignedInUsers().ToList();
                    lcProfiles = profileManager.EnumerateConsoleProfiles().ToList();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Failed to load the signed in and local profiles.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                if (siProfiles.Count == 0)
                {
                    using (var sid = new SigninForm(this, lcProfiles, profileManager))
                    {
                        sid.ShowDialog();
                        signedinPlayer1 = sid.SignedInProfile;
                        if (signedinPlayer1 == null)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                else signedinPlayer1 = siProfiles[0];
                try
                {
                    FriendsTileControl.Text = signedinPlayer1.Gamertag + "'s Friends";
                    ReloadFriends();
                    FriendFunctionsGroup.Enabled = FriendsTileGroup.Items.Count > 0;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Failed to load {0}'s friends.{1}{2}", signedinPlayer1.Gamertag, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            else if (e.Page == KeyboardHookingTab && !hasLoadedKeyboardHooks)
            {
                hasLoadedKeyboardHooks = true;
                try
                {
                    SetupKeyboardHooking(XDKUtilities.XexGetProcedureAddress(console, XDKUtilities.XexGetModuleHandle(console, "xam.xex"), 705));
                    hasXamKeyboardBeenHooked = true;
                    if (!File.Exists("KeyboardHooks.txt")) return;
                    var hooks = File.ReadAllLines("KeyboardHooks.txt");
                    if (hooks.Length == 0 || hooks.Length % 3 != 0) return;
                    for (var i = hooks.Length - 1; i >= 0; i -= 3) KeyboardHookingScroller.Controls.Add(new KeyboardHookControl(hooks[i - 2], hooks[i - 1], hooks[i]) { Dock = DockStyle.Top });
                    HooksStatusLabel.Visible = false;
                }
                catch (Exception ex)
                {
                    AddKeyboardHookButton.Enabled = false;
                    SaveKeyboardHooksButton.Enabled = false;
                    KeyboardHookingScroller.Controls.Clear();
                    HooksStatusLabel.Visible = true;
                    HooksStatusLabel.Text = "Failed to load the keyboard hooks or hook the console function: " + XDKUtilities.CreateExceptionMessage(ex, manager);
                    KeyboardHookingScroller.Controls.Add(HooksStatusLabel);
                }
            }
            else if (e.Page == ModuleLauncherTab && !hasLoadedModuleLauncherList)
            {
                hasLoadedModuleLauncherList = true;
                try
                {
                    if (!File.Exists("ModuleLauncherConfig.txt")) return;
                    var modulePaths = File.ReadAllLines("ModuleLauncherConfig.txt");
                    if (modulePaths.Length == 0) return;
                    for (var i = modulePaths.Length - 1; i >= 0; i--) ModuleLauncherScroller.Controls.Add(new ModuleLauncherControl(console, connection, modulePaths[i]) { Dock = DockStyle.Top });
                    ModuleLauncherStatusLabel.Visible = false;
                }
                catch (Exception ex)
                {
                    AddModuleShortcutButton.Enabled = false;
                    SaveModulesButton.Enabled = false;
                    ModuleLauncherScroller.Controls.Clear();
                    ModuleLauncherStatusLabel.Visible = true;
                    ModuleLauncherStatusLabel.Text = "Failed to load the module launcher configuration: " + ex.Message;
                    ModuleLauncherScroller.Controls.Add(ModuleLauncherStatusLabel);
                }
            }
            else if (e.Page == TempControlTab)
            {
                tempTimer = new Timer(TemperatureCallback, null, 0, 2000);
            }
            else if (e.Page == NeighborhoodDrivesTab && !hasLoadedNeighborhoodDrives)
            {
                hasLoadedNeighborhoodDrives = true;
                try
                {
                    var addresses = File.ReadAllLines("NeighborhoodDrivesAddresses.txt");
                    if (Convert.ToUInt32(addresses[0]) != consoleInfo.KernelVersion.Version.Build)
                    {
                        NeighborhoodDrivesStatusLabel.Text = string.Format("NeighborhoodDrivesAddresses.txt needs to be updated for flash v{0} before you can use this feature.", consoleInfo.KernelVersion.Version.Build);
                        AddNeighborhoodDriveButton.Enabled = false;
                        SaveDrivesButton.Enabled = false;
                        return;
                    }
                    var xbdmRange = new uint[2];
                    foreach (var module in console.DebugTarget.Modules.Cast<IXboxModule>().Where(module => String.CompareOrdinal(module.ModuleInfo.Name, "xbdm.xex") == 0))
                    {
                        xbdmRange[0] = module.ModuleInfo.BaseAddress;
                        xbdmRange[1] = module.ModuleInfo.BaseAddress + module.ModuleInfo.Size;
                        break;
                    }
                    if (!File.Exists("NeighborhoodDrives.txt")) return;
                    var cdrives = File.ReadAllLines("NeighborhoodDrives.txt");
                    if (cdrives.Length == 0) return;
                    if (cdrives.Length > 42)
                    {
                        NeighborhoodDrivesStatusLabel.Text = "You have too many custom drives. The limit is 42.";
                        return;
                    }
                    drives = new NeighborhoodDrives(console, xms, (uint)XtraFunctions.ValueFromHex(addresses[1]), (uint)XtraFunctions.ValueFromHex(addresses[2]), (uint)XtraFunctions.ValueFromHex(addresses[3]), xbdmRange);
                    drives.Read();
                    drives.Drives.Clear();
                    for (var i = cdrives.Length - 1; i >= 0; i--)
                    {
                        var np = cdrives[i].Split(',');
                        drives.Drives.Add(new NeighborhoodDrives.DriveNameConversionTableEntry { IsBrowsable = true, NeighborhoodLocation = np[1], NeighborhoodName = np[0] });
                        NeighborhoodDrivesScroller.Controls.Add(new NeighborhoodDriveControl(cdrives[i]) { Dock = DockStyle.Top });
                    }
                    drives.Write();
                    NeighborhoodDrivesStatusLabel.Visible = false;
                }
                catch (Exception ex)
                {
                    AddNeighborhoodDriveButton.Enabled = false;
                    SaveDrivesButton.Enabled = false;
                    NeighborhoodDrivesScroller.Controls.Clear();
                    NeighborhoodDrivesStatusLabel.Visible = true;
                    NeighborhoodDrivesStatusLabel.Text = "Failed to load or set the Neighborhood drives: " + XDKUtilities.CreateExceptionMessage(ex, manager);
                    NeighborhoodDrivesScroller.Controls.Add(NeighborhoodDrivesStatusLabel);
                }
            }
            else if (e.Page == SettingsTab)
            {
                try { foreach (CheckedListBoxItem checkItem in XamFeatureChecks.Items) checkItem.CheckState = XDKUtilities.XamFeatureEnabled(console, (XDKUtilities.XamAppIDs)Convert.ToUInt32(checkItem.Value)) ? CheckState.Checked : CheckState.Unchecked; }
                catch (Exception ex)
                {
                    XamFeaturesInfoLabel.Text = "Failed to load xam features: " + XDKUtilities.CreateExceptionMessage(ex, manager);
                    XamFeatureChecks.Enabled = false;
                    SaveXamFeaturesButton.Enabled = false;
                }
            }
        }

        #endregion

        #region Memory/Module

        private void MemText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(MemAddressText.Text) || string.IsNullOrWhiteSpace(MemLengthText.Text)) return;
            MemGoButton_Click(null, null);
        }

        private void MemGoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!MemAddressText.Text.StartsWith("0x", StringComparison.Ordinal)) MemAddressText.Text = MemAddressText.Text.Insert(0, "0x");
                if (!MemLengthText.Text.StartsWith("0x", StringComparison.Ordinal)) MemLengthText.Text = MemLengthText.Text.Insert(0, "0x");
                var result = XtraMessageBox.Show(string.Format("Yes = Edit in your hex editor{0}No = Save to file", Environment.NewLine), "Memory Dump Options", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        {
                            #region Edit

                            if (!File.Exists(File.ReadAllText("HexEditorLocation.txt")))
                            {
                                XtraMessageBox.Show("Your specified hex editor executable does not exist. Put the path to your hex editor in HexEditorLocation.txt", "Hex Editor Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Cursor = Cursors.WaitCursor;
                            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
                            ShowWaitForm("Dumping memory...", "0% complete");
                            DumpMemory((uint)XtraFunctions.ValueFromHex(MemAddressText.Text), (uint)XtraFunctions.ValueFromHex(MemLengthText.Text), "memdmp.bin");
                            Cursor = Cursors.Default;
                            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                            CloseWaitForm();
                            Process.Start(File.ReadAllText("HexEditorLocation.txt"), string.Format("\"{0}\"", Application.StartupPath + "\\memdmp.bin"));
                            if (XtraMessageBox.Show("Successfully dumped memory. Write back?", "Write Back?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                            if (new FileInfo("memdmp.bin").Length != (int)XtraFunctions.ValueFromHex(MemLengthText.Text))
                            {
                                XtraMessageBox.Show("A file size change occurred - cannot write the data back.", "You're doing it wrong, noob", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            Cursor = Cursors.WaitCursor;
                            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
                            ShowWaitForm("Writing memory...", "0% complete");
                            WriteMemory((uint)XtraFunctions.ValueFromHex(MemAddressText.Text), (uint)XtraFunctions.ValueFromHex(MemLengthText.Text), "memdmp.bin");
                            Cursor = Cursors.Default;
                            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                            CloseWaitForm();
                            break;

                            #endregion
                        }
                    case DialogResult.No:
                        {
                            #region Dump

                            using (var svd = new SaveFileDialog { SupportMultiDottedExtensions = true, Title = "Select a place to save the memory dump.", FileName = "memdmp.bin", Filter = "Binary Dump .bin|*.bin|All Files (*.*)|*.*" })
                            {
                                if (svd.ShowDialog() != DialogResult.OK) return;
                                Cursor = Cursors.WaitCursor;
                                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
                                ShowWaitForm("Dumping memory...", "0% complete");
                                DumpMemory((uint)XtraFunctions.ValueFromHex(MemAddressText.Text), (uint)XtraFunctions.ValueFromHex(MemLengthText.Text), svd.FileName);
                                Cursor = Cursors.Default;
                                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                                CloseWaitForm();
                                XtraMessageBox.Show("Successfully dumped memory.", "Dump Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            break;

                            #endregion
                        }
                    default: return;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to read/write console memory.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        private void CurrentTitleLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            if (CurrentTitleLabel.Tag == null) return;
            var tag = (TitleTag)CurrentTitleLabel.Tag;
            CurrentTitleRightClickMenu.MenuCaption = tag.Name + " Options";
            CurrentTitleRightClickMenu.ShowPopup(MousePosition);
        }

        private void CurrentTileVisitItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TitleTag)CurrentTitleLabel.Tag;
            Process.Start(string.Format("http://marketplace.xbox.com/Product/66ACD000-77FE-1000-9115-D802{0}", XtraFunctions.ValueToHex(tag.EID.TitleID).Remove(0, 2).PadLeft(8, '0')));
        }

        private void ViewAllTitleInfoItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TitleTag)CurrentTitleLabel.Tag;
            XtraMessageBox.Show(string.Format("Media ID: {0}{1}Title ID: {2}{1}Save Game ID: {3}{1}Version: v{4}{1}Base Version: v{5}{1}Platform: {6}{1}Executable Type: {7}{1}Disc Number: {8}{1}Number of Discs: {9}", XtraFunctions.ValueToHex(tag.EID.MediaID).Remove(0, 2).PadLeft(8, '0'), Environment.NewLine, XtraFunctions.ValueToHex(tag.EID.TitleID).Remove(0, 2).PadLeft(8, '0'), XtraFunctions.ValueToHex(tag.EID.SaveGameID).Remove(0, 2).PadLeft(8, '0'), tag.EID.Version, tag.EID.BaseVersion, tag.EID.Platform, tag.EID.ExecutableType, tag.EID.DiscNum, tag.EID.DiscsInSet), tag.Name + " Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TitleUpdateSearchItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TitleTag)CurrentTitleLabel.Tag;
            Process.Start("http://www.xbuc.net/?searchString=" + tag.Name.Replace(" ", "+"));
        }

        private void CurrentTitleEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try { XDKUtilities.LaunchModule(console, connection, CurrentTitleEdit.Text); }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to launch {0}.{1}{2}", Path.GetFileName(CurrentTitleEdit.Text), Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CurrentTitleEdit_KeyPress(object sender, KeyPressEventArgs e) { if (e.KeyChar == (char)Keys.Enter) CurrentTitleEdit_ButtonClick(null, null); }

        private void ModuleTree_CompareNodeValues(object sender, CompareNodeValuesEventArgs e)
        {
            if (e.Node1.Tag == null || e.Node2.Tag == null) return;
            switch (e.Column.Name)
            {
                case "ModuleTreeAddressColumn":
                    {
                        var txt1 = e.Node1.GetDisplayText(e.Column);
                        if (string.IsNullOrWhiteSpace(txt1)) return;
                        var txt2 = e.Node2.GetDisplayText(e.Column);
                        if (string.IsNullOrWhiteSpace(txt2)) return;
                        var val1 = uint.Parse(XtraFunctions.ValueFromHex(txt1).ToString());
                        var val2 = uint.Parse(XtraFunctions.ValueFromHex(txt2).ToString());
                        if (val1 < val2) e.Result = -1;
                        else if (val1 > val2) e.Result = 1;
                        else if (val1 == val2) e.Result = 0;
                        break;
                    }
                case "ModuleTreeSizeColumn":
                    {
                        var txt1 = e.Node1.GetDisplayText(e.Column);
                        if (string.IsNullOrWhiteSpace(txt1)) return;
                        txt1 = txt1.Substring(0, txt1.IndexOf("(") - 1);
                        var txt2 = e.Node2.GetDisplayText(e.Column);
                        if (string.IsNullOrWhiteSpace(txt2)) return;
                        txt2 = txt2.Substring(0, txt2.IndexOf("(") - 1);
                        var val1 = uint.Parse(XtraFunctions.ValueFromHex(txt1).ToString());
                        var val2 = uint.Parse(XtraFunctions.ValueFromHex(txt2).ToString());
                        if (val1 < val2) e.Result = -1;
                        else if (val1 > val2) e.Result = 1;
                        else if (val1 == val2) e.Result = 0;
                        break;
                    }
                case "ModuleTreeOccupiedMemoryColumn":
                    {
                        var txt1 = e.Node1.GetDisplayText(e.Column);
                        if (string.IsNullOrWhiteSpace(txt1)) return;
                        var txt2 = e.Node2.GetDisplayText(e.Column);
                        if (string.IsNullOrWhiteSpace(txt2)) return;
                        var val1 = uint.Parse(XtraFunctions.ValueFromHex(txt1).ToString());
                        var val2 = uint.Parse(XtraFunctions.ValueFromHex(txt2).ToString());
                        if (val1 < val2) e.Result = -1;
                        else if (val1 > val2) e.Result = 1;
                        else if (val1 == val2) e.Result = 0;
                        break;
                    }
                default:
                    {
                        e.Result = XtraFunctions.StrCmpLogicalW(e.Node1.GetDisplayText(e.Column), e.Node2.GetDisplayText(e.Column));
                        break;
                    }
            }
        }

        private void ModuleTree_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = ModuleTree;
            var info = ModuleTree.CalcHitInfo(ModuleTree.PointToClient(MousePosition));
            ModuleTree.FocusedNode = info.Node;
            ModuleTree.FocusedColumn = info.Column;
            if (info.HitInfoType == HitInfoType.Cell && e.Button == MouseButtons.Right)
            {
                ModuleRightClickPopup.MenuCaption = info.Node.GetDisplayText(ModuleTreeNameColumn) + " Options";
                ModuleDumpSpecificSectionSubMenu.ItemLinks.Clear();
                var module = (IXboxModule)ModuleTree.FocusedNode.Tag;
                foreach (var item in from IXboxSection section in module.Sections select new BarButtonItem(BarManager, section.SectionInfo.Name) { Tag = section, Name = string.Format("ModuleDump{0}SectionItem", section.SectionInfo.Name.Remove(0, 1)) })
                {
                    item.ItemClick += ModuleSectionItem_ItemClick;
                    ModuleDumpSpecificSectionSubMenu.ItemLinks.Add(item);
                }
                ModuleRightClickPopup.ShowPopup(MousePosition);
            }
        }

        private void ModuleSectionItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var section = (IXboxSection)e.Item.Tag;
            try
            {
                using (var svd = new SaveFileDialog { SupportMultiDottedExtensions = true, Title = string.Format("Select a place to save the {0} section.", section.SectionInfo.Name), FileName = section.SectionInfo.Name + " Dump.bin", Filter = "Binary Dump .bin|*.bin|All Files (*.*)|*.*" })
                {
                    if (svd.ShowDialog() != DialogResult.OK) return;
                    Cursor = Cursors.WaitCursor;
                    WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
                    ShowWaitForm(string.Format("Dumping {0}...", section.SectionInfo.Name), "0% complete");
                    DumpMemory(section.SectionInfo.BaseAddress, section.SectionInfo.Size, svd.FileName);
                    Cursor = Cursors.Default;
                    WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                    CloseWaitForm();
                    quickSectionDumpSection = section;
                    quickSectionDumpLocation = svd.FileName;
                    XtraMessageBox.Show(string.Format("Successfully dumped the {0} section.", section.SectionInfo.Name), "Dump Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to dump the {0} section.{1}{2}", section.SectionInfo.Name, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        private void ModuleCopyValueItem_ItemClick(object sender, ItemClickEventArgs e) { Clipboard.SetText(ModuleTree.FocusedNode.GetDisplayText(ModuleTree.FocusedColumn)); }

        private void ModuleDumpEntireItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var module = (IXboxModule)ModuleTree.FocusedNode.Tag;
            string mn;
            try
            {
                switch (module.ModuleInfo.Name)
                {
                    case "aac.xex":
                    case "xboxkrnl.exe":
                        {
                            mn = module.ModuleInfo.Name;
                            break;
                        }
                    default:
                        {
                            mn = module.Executable.GetPEModuleName();
                            break;
                        }
                }
            }
            catch (Exception) { mn = module.ModuleInfo.Name; }
            try
            {
                using (var svd = new SaveFileDialog { SupportMultiDottedExtensions = true, Title = string.Format("Select a place to save {0}.", mn), FileName = mn, Filter = "Executable .exe|*.exe|Library .dll|*.dll|All Files (*.*)|*.*", FilterIndex = Path.GetExtension(mn) == ".exe" ? 1 : 2 })
                {
                    if (svd.ShowDialog() != DialogResult.OK) return;
                    Cursor = Cursors.WaitCursor;
                    WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
                    ShowWaitForm(string.Format("Dumping {0}...", mn), "0% complete");
                    DumpMemory(module.ModuleInfo.BaseAddress, module.ModuleInfo.Size, svd.FileName);
                    Cursor = Cursors.Default;
                    WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                    CloseWaitForm();
                    XtraMessageBox.Show(string.Format("Successfully dumped {0}.", mn), "Dump Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to dump {0}.{1}{2}", mn, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        private void ModuleViewInfoItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var module = (IXboxModule)ModuleTree.FocusedNode.Tag;
            var mn = "(Not available)";
            try
            {
                //These modules will throw an exception when getting the module name from them, so, to speed up things by a second, let's avoid that exception.
                switch (module.ModuleInfo.Name)
                {
                    case "aac.xex":
                    case "xboxkrnl.exe":
                        {
                            break;
                        }
                    default:
                        {
                            mn = module.Executable.GetPEModuleName();
                            if (String.CompareOrdinal(mn, module.ModuleInfo.Name) == 0) mn = string.Empty;
                            break;
                        }
                }
            }
            catch (Exception){}
            try
            {
                var sectionString = new StringBuilder();
                foreach (IXboxSection section in module.Sections)
                {
                    sectionString.AppendLine(section.SectionInfo.Name);
                    sectionString.AppendLine("   Address: " + XtraFunctions.ValueToHex(section.SectionInfo.BaseAddress));
                    sectionString.AppendLine(string.Format("   Size: {0} ({1})", XtraFunctions.ValueToHex(section.SectionInfo.Size), XtraFunctions.FormatSize(section.SectionInfo.Size)));
                    sectionString.AppendLine("   Flags: " + (XboxSectionInfoFlags)section.SectionInfo.Flags);
                }
                var eidString = new StringBuilder();
                try
                {
                    var eid = XDKUtilities.RtlImageXexHeaderField<XDKUtilities.ExecutionID>(console, module.ModuleInfo.Name, XDKUtilities.XexHeaderFieldIDs.ExecutionID, 0x24);
                    eidString.AppendLine("   Media ID: " + XtraFunctions.ValueToHex(eid.MediaID).Remove(0, 2).PadLeft(8, '0'));
                    eidString.AppendLine("   Title ID: " + XtraFunctions.ValueToHex(eid.TitleID).Remove(0, 2).PadLeft(8, '0'));
                    eidString.AppendLine("   Save Game ID: " + XtraFunctions.ValueToHex(eid.SaveGameID).Remove(0, 2).PadLeft(8, '0'));
                    eidString.AppendLine("   Version: v" + eid.Version);
                    eidString.AppendLine("   Base Version: v" + eid.BaseVersion);
                    eidString.AppendLine("   Platform: " + eid.Platform);
                    eidString.AppendLine("   Executable Type: " + eid.ExecutableType);
                    eidString.AppendLine("   Disc Number: " + eid.DiscNum);
                    eidString.AppendLine("   Number of Discs: " + eid.DiscsInSet);
                }
                catch (Exception ex)  { eidString.AppendLine(string.Format("   None or couldn't obtain ({0})", ex.Message)); }
                var finalSb = new StringBuilder();
                finalSb.Append(string.Format("Full Name: {0}{1}Name: {2}{1}PE Name: {3}{1}{1}Base Address: {4}{1}Entry Point: {5}{1}Size: {6} ({12}){1}Original Size: {13} ({14}){1}Checksum: {7}{1}Timestamp: {8} ({11}){1}Flags: {9}{1}{1}Execution ID{1}{15}{1}Sections{1}{10}", module.ModuleInfo.FullName, Environment.NewLine, module.ModuleInfo.Name, mn, XtraFunctions.ValueToHex(module.ModuleInfo.BaseAddress), XtraFunctions.ValueToHex(module.GetEntryPointAddress()), XtraFunctions.ValueToHex(module.ModuleInfo.Size), XtraFunctions.ValueToHex(module.ModuleInfo.CheckSum), (string.Format("{0} ({1})", XtraFunctions.ValueToHex(module.ModuleInfo.TimeStamp), XtraFunctions.UnixTime(module.ModuleInfo.TimeStamp))), (XboxModuleInfoFlags)module.ModuleInfo.Flags, sectionString, XtraFunctions.CreateTimePassedString(DateTime.Now - XtraFunctions.UnixTime(module.ModuleInfo.TimeStamp)), XtraFunctions.FormatSize(module.ModuleInfo.Size), XtraFunctions.ValueToHex(module.OriginalSize), XtraFunctions.FormatSize(module.OriginalSize), eidString));
                using (var txtdf = new TextDisplayForm(ModuleTree.FocusedNode.GetDisplayText(ModuleTreeNameColumn) + " Information", finalSb)) txtdf.ShowDialog();
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to display information about {2}. {2} may not support one or more queried fields.{0}{1}", Environment.NewLine, ex.Message, ModuleTree.FocusedNode.GetDisplayText(ModuleTreeNameColumn)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Patching

        private void PatchCompileWriteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(PatchText.Text))
                {
                    XtraMessageBox.Show("Patch text is empty.", "No Patches", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                File.WriteAllLines("patches.s", PatchText.Lines);
                using (var process = Process.Start(new ProcessStartInfo("build_patch.bat") { CreateNoWindow = true, UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true }))
                {
                    process.WaitForExit(5000);
                    using (var reader = process.StandardOutput)
                    {
                        var fi = new FileInfo("kxam.patch");
                        if (!fi.Exists || fi.Length == 0)
                        {
                            XtraMessageBox.Show("Patch build failed. Check your syntax.", "Build Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (XtraMessageBox.Show("Build successful. Write to memory?", "Write to memory?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                        var count = 0;
                        using (var patch = new XenonPatch("kxam.patch"))
                        {
                            patch.Read();
                            patch.Patches.ForEach(entry =>
                            {
                                xms.SetPosition(entry.Address);
                                xms.Writer.Write(entry.Data);
                                count++;
                            });
                        }
                        XDKUtilities.XNotifyQueueUI(console, 0, XDKUtilities.XNotifyUITypes.XNOTIFYUI_TYPE_PREFERRED_REVIEW, XDKUtilities.XNotifyUIPriorities.XNOTIFYUI_PRIORITY_HIGH, count + " patch(es) written to memory");
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to read/write patches.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Profiles/XBL

        private void FriendTile_ItemClick(object sender, TileItemEventArgs e)
        {
            e.Item.Checked = !e.Item.Checked;
            FriendsTileControl.Tag = e.Item.Checked ? (Convert.ToByte(FriendsTileControl.Tag) + 1) : (Convert.ToByte(FriendsTileControl.Tag) - 1);
            FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
        }

        #region Right Click Events

        private void FriendTile_RightItemClick(object sender, TileItemEventArgs e)
        {
            var friend = (Friend)e.Item.Tag;
            FriendRightClickMenu.MenuCaption = friend.Gamertag + " Options";
            if (friend.RequestStatus == FriendRequestStatus.RequestReceived)
            {
                AcceptDeclineFRItem.Visibility = BarItemVisibility.Always;
                RemoveFriendItem.Visibility = BarItemVisibility.Never;
            }
            else
            {
                AcceptDeclineFRItem.Visibility = BarItemVisibility.Never;
                RemoveFriendItem.Visibility = BarItemVisibility.Always;
            }
            FriendsTileGroup.Tag = e.Item;
            FriendRightClickMenu.ShowPopup(MousePosition);
        }

        private void AcceptDeclineFRItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                var tile = (TileItem)FriendsTileGroup.Tag;
                var friend = (Friend)tile.Tag;
                switch (XtraMessageBox.Show(string.Format("Would you like to be friends with {0}?", friend.Gamertag), "Want to be friends?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel: return;
                    case DialogResult.Yes:
                        {
                            Cursor = Cursors.WaitCursor;
                            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                            ShowWaitForm("Accepting friend request...");
                            signedinPlayer1.Friends.AcceptFriendRequest(friend);
                            friend.RequestStatus = FriendRequestStatus.RequestAccepted;
                            tile.Elements[2].Text = "<Color=\"white\"><b>RequestAccepted</b></Color>";
                            tile.AppearanceItem.Normal.BackColor = Color.Green;
                            break;
                        }
                    case DialogResult.No:
                        {
                            Cursor = Cursors.WaitCursor;
                            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                            ShowWaitForm("Declining friend request...");
                            signedinPlayer1.Friends.RejectFriendRequest(friend, BlockFriendCheck.Checked);
                            if (tile.Checked)
                            {
                                FriendsTileControl.Tag = (Convert.ToByte(FriendsTileControl.Tag) - 1);
                                FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
                            }
                            FriendsTileGroup.Items.Remove(tile);
                            break;
                        }
                }
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                CloseWaitForm();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to process the friend request.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            }
        }

        private void MessageFriendItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            var message = string.Empty;
            retry:
            try
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    using (var txtf = new TextInputForm("Enter your message to " + friend.Gamertag, 255))
                    {
                        txtf.ShowDialog();
                        if (string.IsNullOrWhiteSpace(txtf.Input)) return;
                        message = txtf.Input;
                    }
                }
                XDKUtilities.XamShowMessageComposeUI(console, 0, new[] { friend.OnlineXuid.value }, message);
            }
            catch (Exception ex)
            {
                if (ex is COMException)
                {
                    if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                    {
                        if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                        goto retry;
                    }
                }
                XtraMessageBox.Show(string.Format("Failed to send a message to the {0}.{1}{2}", friend.Gamertag, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InviteFriendItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            retry:
            try { XDKUtilities.XamShowGameInviteUI(console, 0, new[] { friend.OnlineXuid.value }); }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to send an invite to {0}.{1}{2}", friend.Gamertag, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void JoinPartyItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                ShowWaitForm(string.Format("Joining {0}'s party...", friend.Gamertag));
                partyManager.JoinParty(signedinPlayer1, friend);
                LeavePartyButton.Enabled = true;
                JoinSpecificPartyButton.Enabled = false;
                JoinPartyItem.Visibility = BarItemVisibility.Never;
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                CloseWaitForm();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to join {0}'s party.{1}{2}", friend.Gamertag, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            }
        }

        private void ShowGamercardItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            retry:
            try { XDKUtilities.XamShowGamerCardUIForXUID(console, 0, friend.OnlineXuid.value); }
            catch (Exception ex)
            {
                if (ex is COMException)
                {
                    if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                    {
                        if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                        goto retry;
                    }
                }
                XtraMessageBox.Show(string.Format("Failed to show {0}'s Gamercard UI.{1}{2}", friend.Gamertag, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewGamertagItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            try { Process.Start("https://live.xbox.com/en-US/Profile?gamertag=" + friend.Gamertag); }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to open the link.{0}{1}", Environment.NewLine, ex.Message), "FATXplorer Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ShowFoFItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            retry:
            try { XDKUtilities.XamShowFofUI(console, 0, friend.OnlineXuid.value, friend.Gamertag); }
            catch (Exception ex)
            {
                if (ex is COMException)
                {
                    if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                    {
                        if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                        goto retry;
                    }
                }
                XtraMessageBox.Show(string.Format("Failed to show {0}'s friends.{1}{2}", friend.Gamertag, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyOnlineXUIDItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var friend = (Friend)((TileItem)FriendsTileGroup.Tag).Tag;
            Clipboard.SetText(XtraFunctions.ValueToHex(friend.OnlineXuid.value).Remove(0, 2).PadLeft(16, '0'));
        }

        private void RemoveFriendItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tile = (TileItem)FriendsTileGroup.Tag;
            var friend = (Friend)tile.Tag;
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                ShowWaitForm(string.Format("Removing {0}...", friend.Gamertag));
                signedinPlayer1.Friends.RemoveFriend(friend);
                if (tile.Checked)
                {
                    FriendsTileControl.Tag = (Convert.ToByte(FriendsTileControl.Tag) - 1);
                    FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
                }
                FriendsTileGroup.Items.Remove(tile);
                FriendFunctionsGroup.Enabled = FriendsTileGroup.Items.Count > 0;
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                CloseWaitForm();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to remove{0}.{1}{2}", friend.Gamertag, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            }
        }

        #endregion

        private void SignOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                ShowWaitForm("Signing out...");
                signedinPlayer1.SignOut();
                signedinPlayer1 = null;
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                CloseWaitForm();
                MainTabs.SelectedTabPage = MemoryTab;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("{0} failed to sign out.{1}{2}", signedinPlayer1.Gamertag, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        private void SendFRButton_Click(object sender, EventArgs e)
        {
            if (!(bool)xUserInfo[0])
            {
                XtraMessageBox.Show(string.Format("XUserFindUserAddress.txt needs to be updated for flash v{0} before you can use this feature.", consoleInfo.KernelVersion.Version.Build), "Update Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (var txtf = new TextInputForm("Enter a Gamertag", 15))
                {
                    txtf.ShowDialog();
                    if (string.IsNullOrWhiteSpace(txtf.Input)) return;
                    var user = XDKUtilities.XUserFindUser(console, (uint)xUserInfo[1], signedinPlayer1.OnlineXuid.value, txtf.Input);
                    if (user.OnlineXUID == 0)
                    {
                        XtraMessageBox.Show("The Gamertag you specified does not exist on the service.", "Gamertag does not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    signedinPlayer1.Friends.SendFriendRequest(new Gamer(user.Gamertag, user.OnlineXUID));
                    XDKUtilities.XNotifyQueueUI(console, 0, XDKUtilities.XNotifyUITypes.XNOTIFYUI_TYPE_GENERIC, XDKUtilities.XNotifyUIPriorities.XNOTIFYUI_PRIORITY_HIGH, "Friend request sent to " + user.Gamertag);
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to send the friend request.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void JoinSpecificPartyButton_Click(object sender, EventArgs e)
        {
            if (!(bool)xUserInfo[0])
            {
                XtraMessageBox.Show(string.Format("XUserFindUserAddress.txt needs to be updated for flash v{0} before you can use this feature.", consoleInfo.KernelVersion.Version.Build), "Update Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var gt = string.Empty;
            try
            {
                ulong xuid;
                using (var txtf = new TextInputForm("Enter a Gamertag", 15))
                {
                    txtf.ShowDialog();
                    if (string.IsNullOrWhiteSpace(txtf.Input)) return;
                    gt = txtf.Input;
                    var user = XDKUtilities.XUserFindUser(console, (uint)xUserInfo[1], signedinPlayer1.OnlineXuid.value, txtf.Input);
                    if (user.OnlineXUID == 0)
                    {
                        XtraMessageBox.Show("The Gamertag you specified does not exist on the service.", "Gamertag does not exist", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    xuid = user.OnlineXUID;
                    gt = user.Gamertag;
                }
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                ShowWaitForm(string.Format("Joining {0}'s party...", gt));
                partyManager.JoinParty(signedinPlayer1, new Gamer(gt, xuid));
                LeavePartyButton.Enabled = true;
                JoinSpecificPartyButton.Enabled = false;
                JoinPartyItem.Visibility = BarItemVisibility.Never;
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                CloseWaitForm();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to join {0}'s party.{1}{2}", gt, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            }
        }

        private void LeavePartyButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                ShowWaitForm("Leaving party...");
                partyManager.LeaveParty();
                LeavePartyButton.Enabled = false;
                JoinSpecificPartyButton.Enabled = true;
                JoinPartyItem.Visibility = BarItemVisibility.Always;
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                CloseWaitForm();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to leave the party.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            }
        }

        private void ShowPartyUIButton_Click(object sender, EventArgs e)
        {
            retry:
            try { XDKUtilities.XamShowPartyUI(console, 0); }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to show the party UI.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowFriendsUIButton_Click(object sender, EventArgs e)
        {
            retry:
            try { XDKUtilities.XamShowFriendsUI(console, 0); }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to show the friends UI.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMessagesUIButton_Click(object sender, EventArgs e)
        {
            retry:
            try { XDKUtilities.XamShowMessagesUI(console, 0); }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to show the messages UI.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowPlayersUIButton_Click(object sender, EventArgs e)
        {
            retry:
            try { XDKUtilities.XamShowPlayersUI(console, 0); }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to show the players UI.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void XUIDGTConversionsButton_Click(object sender, EventArgs e)
        {
            if (!(bool)xUserInfo[0])
            {
                XtraMessageBox.Show(string.Format("XUserFindUserAddress.txt needs to be updated for flash v{0} before you can use this feature.", consoleInfo.KernelVersion.Version.Build), "Update Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var cf = new XUIDGTConversionForm(console, signedinPlayer1.OnlineXuid.value, (uint)xUserInfo[1])) cf.ShowDialog();
        }

        private void AcceptSelectedFRsButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToByte(FriendsTileControl.Tag) == 0) return;
            Cursor = Cursors.WaitCursor;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
            ShowWaitForm("Accepting selected friend requests...", "0 accepted, 0 failed");
            byte succeeded = 0;
            var failed = new StringBuilder();
            byte failedCount = 0;
            var tilesToAccept = (from TileItem tile in FriendsTileGroup.Items where tile.Checked let tag = (Friend)tile.Tag where tag.RequestStatus == FriendRequestStatus.RequestReceived select tile).ToList();
            for (var i = 0; i < tilesToAccept.Count;)
            {
                var friend = (Friend)tilesToAccept[i].Tag;
                try
                {
                    signedinPlayer1.Friends.AcceptFriendRequest(friend);
                    friend.RequestStatus = FriendRequestStatus.RequestAccepted;
                    tilesToAccept[i].Elements[2].Text = "<Color=\"white\"><b>RequestAccepted</b></Color>";
                    tilesToAccept[i].AppearanceItem.Normal.BackColor = Color.Green;
                    succeeded++;
                }
                catch (Exception ex)
                {
                    failedCount++;
                    failed.AppendLine(string.Format("{0} ({1})", friend.Gamertag, ex.Message));
                }
                SetWaitFormDescription(string.Format("{0} accepted, {1} failed", succeeded, failedCount));
                i++; //Odd, but don't judge me.
                WindowsTaskbarHelper.SetProgressValue(i, tilesToAccept.Count);
            }
            Cursor = Cursors.Default;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            CloseWaitForm();
            if (failedCount > 0) XtraMessageBox.Show(string.Format("Failed to add the following ({0}) friend(s):{1}{2}", failedCount, Environment.NewLine, failed), "Friend Request Accept Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void AcceptAllFRsButton_Click(object sender, EventArgs e)
        {
            if (FriendsTileGroup.Items.Count <= 0) return;
            Cursor = Cursors.WaitCursor;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
            ShowWaitForm("Accepting all friend requests...", "0 accepted, 0 failed");
            byte succeeded = 0;
            var failed = new StringBuilder();
            byte failedCount = 0;
            var tilesToAccept = (from TileItem tile in FriendsTileGroup.Items let tag = (Friend)tile.Tag where tag.RequestStatus == FriendRequestStatus.RequestReceived select tile).ToList();
            for (var i = 0; i < tilesToAccept.Count; )
            {
                var friend = (Friend)tilesToAccept[i].Tag;
                try
                {
                    signedinPlayer1.Friends.AcceptFriendRequest(friend);
                    friend.RequestStatus = FriendRequestStatus.RequestAccepted;
                    tilesToAccept[i].Elements[2].Text = "<Color=\"white\"><b>RequestAccepted</b></Color>";
                    tilesToAccept[i].AppearanceItem.Normal.BackColor = Color.Green;
                    succeeded++;
                }
                catch (Exception ex)
                {
                    failedCount++;
                    failed.AppendLine(string.Format("{0} ({1})", friend.Gamertag, ex.Message));
                }
                SetWaitFormDescription(string.Format("{0} accepted, {1} failed", succeeded, failedCount));
                i++; //Odd, but don't judge me.
                WindowsTaskbarHelper.SetProgressValue(i, tilesToAccept.Count);
            }
            Cursor = Cursors.Default;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            CloseWaitForm();
            if (failedCount > 0) XtraMessageBox.Show(string.Format("Failed to add the following ({0}) friend(s):{1}{2}", failedCount, Environment.NewLine, failed), "Friend Request Accept Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DeclineSelectedFRsButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToByte(FriendsTileControl.Tag) == 0) return;
            Cursor = Cursors.WaitCursor;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
            ShowWaitForm("Declining selected friend requests...", "0 declined, 0 failed");
            byte succeeded = 0;
            var failed = new StringBuilder();
            byte failedCount = 0;
            var tilesToDecline = (from TileItem tile in FriendsTileGroup.Items where tile.Checked let tag = (Friend)tile.Tag where tag.RequestStatus == FriendRequestStatus.RequestReceived select tile).ToList();
            for (var i = 0; i < tilesToDecline.Count; )
            {
                var friend = (Friend)tilesToDecline[i].Tag;
                try
                {
                    signedinPlayer1.Friends.RejectFriendRequest(friend, BlockFriendCheck.Checked);
                    if (tilesToDecline[i].Checked)
                    {
                        FriendsTileControl.Tag = (Convert.ToByte(FriendsTileControl.Tag) - 1);
                        FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
                    }
                    FriendsTileGroup.Items.Remove(tilesToDecline[i]);
                    succeeded++;
                }
                catch (Exception ex)
                {
                    failedCount++;
                    failed.AppendLine(string.Format("{0} ({1})", friend.Gamertag, ex.Message));
                }
                SetWaitFormDescription(string.Format("{0} declined, {1} failed", succeeded, failedCount));
                i++; //Odd, but don't judge me.
                WindowsTaskbarHelper.SetProgressValue(i, tilesToDecline.Count);
            }
            FriendFunctionsGroup.Enabled = FriendsTileGroup.Items.Count > 0;
            Cursor = Cursors.Default;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            CloseWaitForm();
            if (failedCount > 0) XtraMessageBox.Show(string.Format("Failed to decline the following ({0}) friend(s):{1}{2}", failedCount, Environment.NewLine, failed), "Friend Request Decline Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void DeclineAllFRsButton_Click(object sender, EventArgs e)
        {
            if (FriendsTileGroup.Items.Count <= 0) return;
            Cursor = Cursors.WaitCursor;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
            ShowWaitForm("Declining all friend requests...", "0 declined, 0 failed");
            byte succeeded = 0;
            var failed = new StringBuilder();
            byte failedCount = 0;
            var tilesToDecline = (from TileItem tile in FriendsTileGroup.Items let tag = (Friend)tile.Tag where tag.RequestStatus == FriendRequestStatus.RequestReceived select tile).ToList();
            for (var i = 0; i < tilesToDecline.Count; )
            {
                var friend = (Friend)tilesToDecline[i].Tag;
                try
                {
                    signedinPlayer1.Friends.RejectFriendRequest(friend, BlockFriendCheck.Checked);
                    if (tilesToDecline[i].Checked)
                    {
                        FriendsTileControl.Tag = (Convert.ToByte(FriendsTileControl.Tag) - 1);
                        FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
                    }
                    FriendsTileGroup.Items.Remove(tilesToDecline[i]);
                    succeeded++;
                }
                catch (Exception ex)
                {
                    failedCount++;
                    failed.AppendLine(string.Format("{0} ({1})", friend.Gamertag, ex.Message));
                }
                SetWaitFormDescription(string.Format("{0} declined, {1} failed", succeeded, failedCount));
                i++; //Odd, but don't judge me.
                WindowsTaskbarHelper.SetProgressValue(i, tilesToDecline.Count);
            }
            FriendFunctionsGroup.Enabled = FriendsTileGroup.Items.Count > 0;
            Cursor = Cursors.Default;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            CloseWaitForm();
            if (failedCount > 0) XtraMessageBox.Show(string.Format("Failed to decline the following ({0}) friend(s):{1}{2}", failedCount, Environment.NewLine, failed), "Friend Request Decline Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RemoveSelectedFriendsButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToByte(FriendsTileControl.Tag) == 0) return;
            Cursor = Cursors.WaitCursor;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
            ShowWaitForm("Removing selected friends...", "0 removed, 0 failed");
            byte succeeded = 0;
            var failed = new StringBuilder();
            byte failedCount = 0;
            var tilesToRemove = (from TileItem tile in FriendsTileGroup.Items where tile.Checked let tag = (Friend)tile.Tag where (tag.RequestStatus == FriendRequestStatus.RequestAccepted || tag.RequestStatus == FriendRequestStatus.RequestSent) select tile).ToList();
            for (var i = 0; i < tilesToRemove.Count; )
            {
                var friend = (Friend)tilesToRemove[i].Tag;
                try
                {
                    signedinPlayer1.Friends.RemoveFriend(friend);
                    if (tilesToRemove[i].Checked)
                    {
                        FriendsTileControl.Tag = (Convert.ToByte(FriendsTileControl.Tag) - 1);
                        FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
                    }
                    FriendsTileGroup.Items.Remove(tilesToRemove[i]);
                    succeeded++;
                }
                catch (Exception ex)
                {
                    failedCount++;
                    failed.AppendLine(string.Format("{0} ({1})", friend.Gamertag, ex.Message));
                }
                SetWaitFormDescription(string.Format("{0} removed, {1} failed", succeeded, failedCount));
                i++; //Odd, but don't judge me.
                WindowsTaskbarHelper.SetProgressValue(i, tilesToRemove.Count);
            }
            FriendFunctionsGroup.Enabled = FriendsTileGroup.Items.Count > 0;
            Cursor = Cursors.Default;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            CloseWaitForm();
            if (failedCount > 0) XtraMessageBox.Show(string.Format("Failed to remove the following ({0}) friend(s):{1}{2}", failedCount, Environment.NewLine, failed), "Friend Removal Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RemoveAllFriendsButton_Click(object sender, EventArgs e)
        {
            if (FriendsTileGroup.Items.Count <= 0) return;
            Cursor = Cursors.WaitCursor;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Normal);
            ShowWaitForm("Removing all friends...", "0 removed, 0 failed");
            byte succeeded = 0;
            var failed = new StringBuilder();
            byte failedCount = 0;
            var tilesToRemove = (from TileItem tile in FriendsTileGroup.Items let tag = (Friend)tile.Tag where tag.RequestStatus == FriendRequestStatus.RequestAccepted select tile).ToList();
            for (var i = 0; i < tilesToRemove.Count; )
            {
                var friend = (Friend)tilesToRemove[i].Tag;
                try
                {
                    signedinPlayer1.Friends.RemoveFriend(friend);
                    if (tilesToRemove[i].Checked)
                    {
                        FriendsTileControl.Tag = (Convert.ToByte(FriendsTileControl.Tag) - 1);
                        FriendsTileControl.Text = Convert.ToByte(FriendsTileControl.Tag) == 0 ? signedinPlayer1.Gamertag + "'s Friends" : string.Format("{0}'s Friends ({1} selected)", signedinPlayer1.Gamertag, FriendsTileControl.Tag);
                    }
                    FriendsTileGroup.Items.Remove(tilesToRemove[i]);
                    succeeded++;
                }
                catch (Exception ex)
                {
                    failedCount++;
                    failed.AppendLine(string.Format("{0} ({1})", friend.Gamertag, ex.Message));
                }
                SetWaitFormDescription(string.Format("{0} removed, {1} failed", succeeded, failedCount));
                i++; //Odd, but don't judge me.
                WindowsTaskbarHelper.SetProgressValue(i, tilesToRemove.Count);
            }
            FriendFunctionsGroup.Enabled = FriendsTileGroup.Items.Count > 0;
            Cursor = Cursors.Default;
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
            CloseWaitForm();
            if (failedCount > 0) XtraMessageBox.Show(string.Format("Failed to remove the following ({0}) friend(s):{1}{2}", failedCount, Environment.NewLine, failed), "Friend Removal Results", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void MessageSelectedFriendsButton_Click(object sender, EventArgs e)
        {
            if (!hasXamKeyboardBeenHooked)
            {
                XtraMessageBox.Show("You need to enable keyboard hooking to use this feature. To enable keyboard hooking, simply invoke the tab.", "Keyboard Hooking Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToByte(FriendsTileControl.Tag) == 0) return;
            var message = string.Empty;
            retry:
            try
            {
                using (var txtf = new TextInputForm("Enter your message to the selected friends", 255))
                {
                    txtf.ShowDialog();
                    if (string.IsNullOrWhiteSpace(txtf.Input)) return;
                    message = txtf.Input;
                }
                var found = false;
                foreach (var hookControl in from object control in KeyboardHookingScroller.Controls where !(control is LabelControl) select (KeyboardHookControl)control into hookControl where String.CompareOrdinal(hookControl.TitleOrDescription, "Enter your message.") == 0 select hookControl)
                {
                    hookControl.Enabled = true;
                    hookControl.InsertText = message;
                    found = true;
                    break;
                }
                if (!found)
                {
                    XtraMessageBox.Show("The messaging keyboard hook is missing.", "Keyboard Hook Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tilesToMessage = (from TileItem tile in FriendsTileGroup.Items where tile.Checked select tile).ToList();
                var xuids = new ulong[tilesToMessage.Count];
                for (var i = 0; i < tilesToMessage.Count; i++) xuids[i] = ((Friend)tilesToMessage[i].Tag).OnlineXuid.value;
                XDKUtilities.XamShowMessageComposeUI(console, 0, xuids, message);
            }
            catch (Exception ex)
            {
                if (ex is COMException)
                {
                    if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                    {
                        if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                        goto retry;
                    }
                }
                XtraMessageBox.Show(string.Format("Failed to send a message to the selected friends.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MessageAllFriendsButton_Click(object sender, EventArgs e)
        {
            if (!hasXamKeyboardBeenHooked)
            {
                XtraMessageBox.Show("You need to enable keyboard hooking to use this feature. To enable keyboard hooking, simply invoke the tab.", "Keyboard Hooking Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FriendsTileGroup.Items.Count <= 0) return;
            var message = string.Empty;
            retry:
            try
            {
                using (var txtf = new TextInputForm("Enter your message to all the friends", 255))
                {
                    txtf.ShowDialog();
                    if (string.IsNullOrWhiteSpace(txtf.Input)) return;
                    message = txtf.Input;
                }
                var found = false;
                foreach (var hookControl in from object control in KeyboardHookingScroller.Controls where !(control is LabelControl) select (KeyboardHookControl)control into hookControl where String.CompareOrdinal(hookControl.TitleOrDescription, "Enter your message.") == 0 select hookControl)
                {
                    hookControl.Enabled = true;
                    hookControl.InsertText = message;
                    found = true;
                    break;
                }
                if (!found)
                {
                    XtraMessageBox.Show("The messaging keyboard hook is missing.", "Keyboard Hook Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var tilesToMessage = (from TileItem tile in FriendsTileGroup.Items select tile).ToList();
                var xuids = new ulong[tilesToMessage.Count];
                for (var i = 0; i < tilesToMessage.Count; i++) xuids[i] = ((Friend)tilesToMessage[i].Tag).OnlineXuid.value;
                XDKUtilities.XamShowMessageComposeUI(console, 0, xuids, message);
            }
            catch (Exception ex)
            {
                if (ex is COMException)
                {
                    if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                    {
                        if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                        goto retry;
                    }
                }
                XtraMessageBox.Show(string.Format("Failed to send a message to all the friends.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InviteSelectedFriendsButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToByte(FriendsTileControl.Tag) == 0) return;
            retry:
            try
            {
                var tilesToInvite = (from TileItem tile in FriendsTileGroup.Items where tile.Checked select tile).ToList();
                var xuids = new ulong[tilesToInvite.Count];
                for (var i = 0; i < tilesToInvite.Count; i++) xuids[i] = ((Friend)tilesToInvite[i].Tag).OnlineXuid.value;
                XDKUtilities.XamShowGameInviteUI(console, 0, xuids);
            }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to send an invite to the selected friends.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InviteAllFriendsButton_Click(object sender, EventArgs e)
        {
            if (FriendsTileGroup.Items.Count <= 0) return;
            retry:
            try
            {
                var tilesToInvite = (from TileItem tile in FriendsTileGroup.Items select tile).ToList();
                var xuids = new ulong[tilesToInvite.Count];
                for (var i = 0; i < tilesToInvite.Count; i++) xuids[i] = ((Friend)tilesToInvite[i].Tag).OnlineXuid.value;
                XDKUtilities.XamShowGameInviteUI(console, 0, xuids);
            }
            catch (Exception ex)
            {
                if (((COMException)ex).ErrorCode == 5) //XDRPC returns 5 if the guide is open.
                {
                    if (XtraMessageBox.Show(string.Format("You currently have the Xbox Guide opened. Close it and then select OK.{0}If you do not have the guide opened, something else is wrong..", Environment.NewLine), "Guide Open", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK) return;
                    goto retry;
                }
                XtraMessageBox.Show(string.Format("Failed to send an invite to all the friends.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Keyboard Hooking

        private void AddKeyboardHookButton_Click(object sender, EventArgs e)
        {
            using (var akhf = new AddKeyboardHookForm())
            {
                akhf.ShowDialog();
                if (string.IsNullOrWhiteSpace(akhf.DisplayName)) return;
                KeyboardHookingScroller.Controls.Add(new KeyboardHookControl(akhf.DisplayName, akhf.TitleOrDescription, akhf.InsertText) { Dock = DockStyle.Top });
            }
            HooksStatusLabel.Visible = false;
        }

        private void SaveKeyboardHooksButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(new FileStream("KeyboardHooks.txt", FileMode.Create, FileAccess.Write, FileShare.Read)))
                {
                    foreach (var hookControl in from object control in KeyboardHookingScroller.Controls where !(control is LabelControl) select (KeyboardHookControl)control into hookControl select hookControl)
                    {
                        sw.WriteLine(hookControl.DisplayName);
                        sw.WriteLine(hookControl.TitleOrDescription);
                        sw.WriteLine(hookControl.InsertText);
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to save the keyboard hooks.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Commands

        private void RebootButton_Click(object sender, EventArgs e)
        {
            try
            {
                console.Reboot(null, null, null, XboxRebootFlags.Cold);
                XtraMessageBox.Show("Reboot succeeded, select OK to restart DevTool once you see the XDK Launcher.", "DevTool Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to reboot {0}.{1}{2}", console.Name, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ScreenShotButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                ShowWaitForm("Taking screenshot...");
                console.ScreenShot("Screenshot.bmp");
                Process.Start("Screenshot.bmp");
                Cursor = Cursors.Default;
                CloseWaitForm();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                CloseWaitForm();
                XtraMessageBox.Show(string.Format("Failed to take a screenshot.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        private void UnfreezeButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool ns;
                console.DebugTarget.Go(out ns);
                if (ns) XtraMessageBox.Show(console.Name + " not stopped.", "Not Stopped", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to unfreeze {0}.{1}{2}", console.Name, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void FreezeButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool ass;
                console.DebugTarget.Stop(out ass);
                if (ass) XtraMessageBox.Show(console.Name + " is already stopped.", "Already Stopped", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to freeze {0}.{1}{2}", console.Name, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void XDKLauncherButton_Click(object sender, EventArgs e)
        {
            try { XDKUtilities.LaunchModule(console, connection, "FLASH:\\xshell.xex"); }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to launch the XDK Launcher.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            try { XDKUtilities.LaunchModule(console, connection, "FLASH:\\dash.xex"); }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to launch the dashboard.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SendTextCommandButton_Click(object sender, EventArgs e)
        {
            try
            {
                string response;
                using (var txtf = new TextInputForm("Enter a text command"))
                {
                    txtf.ShowDialog();
                    if (string.IsNullOrWhiteSpace(txtf.Input)) return;
                    console.SendTextCommand(connection, txtf.Input, out response);
                }
                XtraMessageBox.Show(string.Format("Command succeeded.{0}Response:{0}{1}", Environment.NewLine, (string.IsNullOrWhiteSpace(response) ? "(No response)" : response)), "Command Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Command failed.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Module Launcher

        private void AddModuleShortcutButton_Click(object sender, EventArgs e)
        {
            using (var amsf = new AddModuleShortcutForm(new List<string>(console.Drives.Split(','))))
            {
                amsf.ShowDialog();
                if (string.IsNullOrWhiteSpace(amsf.DisplayName)) return;
                ModuleLauncherScroller.Controls.Add(new ModuleLauncherControl(console, connection, string.Format("{0},{1}", amsf.DisplayName, amsf.ModulePath)) { Dock = DockStyle.Top });
            }
            ModuleLauncherStatusLabel.Visible = false;
        }

        private void SaveModulesButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var sw = new StreamWriter(new FileStream("ModuleLauncherConfig.txt", FileMode.Create, FileAccess.Write, FileShare.Read)))
                {
                    foreach (var moduleControl in from object control in ModuleLauncherScroller.Controls where !(control is LabelControl) select (ModuleLauncherControl)control into moduleControl select moduleControl)
                    {
                        sw.WriteLine(moduleControl.JoinedLine);
                    }
                }
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to save the module shortcuts.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Temperature

        private void FanSpeedTrack_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var smcFanRequest = new byte[16];
                byte[] smcFanResponse = null;
                smcFanRequest[0] = (byte)XDKUtilities.SMCCommands.SMC_SET_FAN_SPEED_CPU;
                smcFanRequest[1] = (byte)(FanSpeedTrack.Value < 45 ? 0x7F : FanSpeedTrack.Value | 0x80);
                XDKUtilities.HalSendSMCMessage(console, smcFanRequest, ref smcFanResponse);
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to set the fan speed to {2}.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager), FanSpeedTrack.Value), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TemperatureCallback(object callback)
        {
            try
            {
                var smcTempRequest = new byte[16];
                var smcTempResponse = new byte[16];
                smcTempRequest[0] = (byte)XDKUtilities.SMCCommands.SMC_QUERY_SENSOR;
                XDKUtilities.HalSendSMCMessage(console, smcTempRequest, ref smcTempResponse);
                CPUTempGaugeActualScale.Value = (float)((smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.CPU * 2 + 1] | (smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.CPU * 2 + 2] << 8)) / 256.0);
                CPUTempGaugeCelsiusLabel.Text = Math.Round(CPUTempGaugeActualScale.ActualValue, 0).ToString();
                CPUTempGaugeFahrenheitLabel.Text = ((int)(((9.0 / 5.0) * CPUTempGaugeActualScale.ActualValue) + 32)).ToString();
                GPUTempGaugeActualScale.Value = (float)((smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.GPU * 2 + 1] | (smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.GPU * 2 + 2] << 8)) / 256.0);
                GPUTempGaugeCelsiusLabel.Text = Math.Round(GPUTempGaugeActualScale.ActualValue, 0).ToString();
                GPUTempGaugeFahrenheitLabel.Text = ((int)(((9.0 / 5.0) * GPUTempGaugeActualScale.ActualValue) + 32)).ToString();
                RAMTempGaugeActualScale.Value = (float)((smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.RAM * 2 + 1] | (smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.RAM * 2 + 2] << 8)) / 256.0);
                RAMTempGaugeCelsiusLabel.Text = Math.Round(RAMTempGaugeActualScale.ActualValue, 0).ToString();
                RAMTempGaugeFahrenheitLabel.Text = ((int)(((9.0 / 5.0) * RAMTempGaugeActualScale.ActualValue) + 32)).ToString();
                BoardTempGaugeActualScale.Value = (float)((smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.BOARD * 2 + 1] | (smcTempResponse[(byte)XDKUtilities.SMCTemperatureIndices.BOARD * 2 + 2] << 8)) / 256.0);
                BoardTempGaugeCelsiusLabel.Text = Math.Round(BoardTempGaugeActualScale.ActualValue, 0).ToString();
                BoardTempGaugeFahrenheitLabel.Text = ((int)(((9.0 / 5.0) * BoardTempGaugeActualScale.ActualValue) + 32)).ToString();
            }
            catch (Exception ex)
            {
                if (tempTimer != null) tempTimer.Dispose();
                tempTimer = null;
                XtraFunctions.InvokeEx(this, th => XtraMessageBox.Show(string.Format("Failed to retrieve temperature data. The refresh timer has been stopped.{0}{1}", Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, manager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error));
            }
        }

        #endregion

        #region Neighborhood Drives

        private void AddNeighborhoodDriveButton_Click(object sender, EventArgs e)
        {
            if (NeighborhoodDrivesScroller.Controls.Count == 42)
            {
                XtraMessageBox.Show("You have reached the allowed limit of 42 custom drives. You cannot add anymore unless you remove some.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var andf = new AddNeighborhoodDriveForm(this, drives, manager))
            {
                andf.ShowDialog();
                if (string.IsNullOrWhiteSpace(andf.DriveName)) return;
                NeighborhoodDrivesScroller.Controls.Add(new NeighborhoodDriveControl(string.Format("{0},{1}", andf.DriveName, andf.DrivePath)) { Dock = DockStyle.Top });
            }
            NeighborhoodDrivesStatusLabel.Visible = false;
        }

        private void SaveDrivesButton_Click(object sender, EventArgs e)
        {
            try
            {
                drives.Drives.Clear();
                using (var sw = new StreamWriter(new FileStream("NeighborhoodDrives.txt", FileMode.Create, FileAccess.Write, FileShare.Read)))
                {
                    foreach (var driveControl in from object control in NeighborhoodDrivesScroller.Controls where !(control is LabelControl) select (NeighborhoodDriveControl)control into driveControl select driveControl)
                    {
                        sw.WriteLine(driveControl.DriveName + "," + driveControl.DrivePath);
                        drives.Drives.Add(new NeighborhoodDrives.DriveNameConversionTableEntry { IsBrowsable = driveControl.Enabled, NeighborhoodLocation = driveControl.DrivePath, NeighborhoodName = driveControl.DriveName });
                    }
                }
                drives.Write();
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to save the Neighborhood drives.{0}{1}", Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #region Debug Printing

        private void DebugPrintingClearButton_Click(object sender, EventArgs e) { DebugPrintingMemo.Text = string.Empty; }

        #endregion

        #region Settings

        private void SaveXamFeaturesButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (CheckedListBoxItem checkItem in XamFeatureChecks.Items) XDKUtilities.XamFeatureEnableDisable(console, checkItem.CheckState == CheckState.Checked, (XDKUtilities.XamAppIDs)Convert.ToUInt32(checkItem.Value));
                if (XtraMessageBox.Show("A cold reboot is required after this change. Would you like to reboot now?", "Reboot Required", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    console.Reboot(null, null, null, XboxRebootFlags.Cold);
                    XtraMessageBox.Show("Reboot succeeded, select OK to restart DevTool once you see the XDK Launcher.", "DevTool Restart Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Failed to enable/disable xam features or reboot the console." + Environment.NewLine + XDKUtilities.CreateExceptionMessage(ex, manager), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion

        #endregion
    }
}