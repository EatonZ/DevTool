using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraBars;
using DevExpress.XtraTab;
using DevExpress.XtraEditors;
using DevExpress.XtraTreeList;
using DevExpress.Utils;
using DevExpress.XtraGauges.Win.Base;
using DevExpress.XtraGauges.Win.Gauges.Linear;
using DevExpress.XtraGauges.Win;

namespace DevTool.Forms
{
    sealed partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange33 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange34 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange35 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange36 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange37 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange38 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange39 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange40 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange41 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange42 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange43 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange44 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange45 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange46 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange47 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange48 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange49 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange50 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange51 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange52 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange53 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange54 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange55 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange56 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange57 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange58 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange59 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange60 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange61 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange62 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange63 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            DevExpress.XtraGauges.Core.Model.LinearScaleRange linearScaleRange64 = new DevExpress.XtraGauges.Core.Model.LinearScaleRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTabs = new DevExpress.XtraTab.XtraTabControl();
            this.MemoryTab = new DevExpress.XtraTab.XtraTabPage();
            this.ModuleTree = new DevExpress.XtraTreeList.TreeList();
            this.ModuleTreeNameColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ModuleTreeAddressColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ModuleTreeSizeColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ModuleTreeOccupiedMemoryColumn = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.StatusBar = new DevExpress.XtraBars.Bar();
            this.StatusText = new DevExpress.XtraBars.BarStaticItem();
            this.ForceReconnectButton = new DevExpress.XtraBars.BarButtonItem();
            this.SkinEdit = new DevExpress.XtraBars.BarEditItem();
            this.SkinEditRepo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.AboutItem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ModuleCopyValueItem = new DevExpress.XtraBars.BarButtonItem();
            this.ModuleDumpItem = new DevExpress.XtraBars.BarButtonItem();
            this.ModuleViewInfoItem = new DevExpress.XtraBars.BarButtonItem();
            this.JoinPartyItem = new DevExpress.XtraBars.BarButtonItem();
            this.AcceptDeclineFRItem = new DevExpress.XtraBars.BarButtonItem();
            this.RemoveFriendItem = new DevExpress.XtraBars.BarButtonItem();
            this.MessageFriendItem = new DevExpress.XtraBars.BarButtonItem();
            this.InviteFriendItem = new DevExpress.XtraBars.BarButtonItem();
            this.ShowGamercardItem = new DevExpress.XtraBars.BarButtonItem();
            this.ModuleDumpSubMenu = new DevExpress.XtraBars.BarSubItem();
            this.ModuleDumpEntireItem = new DevExpress.XtraBars.BarButtonItem();
            this.ModuleDumpSpecificSectionSubMenu = new DevExpress.XtraBars.BarSubItem();
            this.ViewGamertagItem = new DevExpress.XtraBars.BarButtonItem();
            this.CopyOnlineXUIDItem = new DevExpress.XtraBars.BarButtonItem();
            this.ShowFoFItem = new DevExpress.XtraBars.BarButtonItem();
            this.CurrentTileVisitItem = new DevExpress.XtraBars.BarButtonItem();
            this.ViewAllTitleInfoItem = new DevExpress.XtraBars.BarButtonItem();
            this.TitleUpdateSearchItem = new DevExpress.XtraBars.BarButtonItem();
            this.IMG16 = new DevExpress.Utils.ImageCollection(this.components);
            this.ToolTipController = new DevExpress.Utils.ToolTipController(this.components);
            this.CurrentTitleEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.CurrentTitleLabel = new DevExpress.XtraEditors.LabelControl();
            this.MemGoButton = new DevExpress.XtraEditors.SimpleButton();
            this.MemLengthText = new DevExpress.XtraEditors.TextEdit();
            this.MemAddressText = new DevExpress.XtraEditors.TextEdit();
            this.PatchingTab = new DevExpress.XtraTab.XtraTabPage();
            this.PatchText = new DevExpress.XtraEditors.MemoEdit();
            this.PatchCompileWriteButton = new DevExpress.XtraEditors.SimpleButton();
            this.XBLCenterTab = new DevExpress.XtraTab.XtraTabPage();
            this.FriendsTileControl = new DevExpress.XtraEditors.TileControl();
            this.FriendsTileGroup = new DevExpress.XtraEditors.TileGroup();
            this.XBLCenterFunctionsGroup = new DevExpress.XtraEditors.GroupControl();
            this.FriendFunctionsGroup = new DevExpress.XtraEditors.GroupControl();
            this.InviteAllFriendsButton = new DevExpress.XtraEditors.SimpleButton();
            this.InviteSelectedFriendsButton = new DevExpress.XtraEditors.SimpleButton();
            this.MessageAllFriendsButton = new DevExpress.XtraEditors.SimpleButton();
            this.MessageSelectedFriendsButton = new DevExpress.XtraEditors.SimpleButton();
            this.RemoveAllFriendsButton = new DevExpress.XtraEditors.SimpleButton();
            this.RemoveSelectedFriendsButton = new DevExpress.XtraEditors.SimpleButton();
            this.DeclineAllFRsButton = new DevExpress.XtraEditors.SimpleButton();
            this.DeclineSelectedFRsButton = new DevExpress.XtraEditors.SimpleButton();
            this.BlockFriendCheck = new DevExpress.XtraEditors.CheckEdit();
            this.AcceptAllFRsButton = new DevExpress.XtraEditors.SimpleButton();
            this.AcceptSelectedFRsButton = new DevExpress.XtraEditors.SimpleButton();
            this.XUIDGTConversionsButton = new DevExpress.XtraEditors.SimpleButton();
            this.ShowPlayersUIButton = new DevExpress.XtraEditors.SimpleButton();
            this.ShowMessagesUIButton = new DevExpress.XtraEditors.SimpleButton();
            this.ShowFriendsUIButton = new DevExpress.XtraEditors.SimpleButton();
            this.ShowPartyUIButton = new DevExpress.XtraEditors.SimpleButton();
            this.LeavePartyButton = new DevExpress.XtraEditors.SimpleButton();
            this.JoinSpecificPartyButton = new DevExpress.XtraEditors.SimpleButton();
            this.SendFRButton = new DevExpress.XtraEditors.SimpleButton();
            this.SignOutButton = new DevExpress.XtraEditors.SimpleButton();
            this.KeyboardHookingTab = new DevExpress.XtraTab.XtraTabPage();
            this.KeyboardHookingScroller = new DevExpress.XtraEditors.XtraScrollableControl();
            this.HooksStatusLabel = new DevExpress.XtraEditors.LabelControl();
            this.SaveKeyboardHooksButton = new DevExpress.XtraEditors.SimpleButton();
            this.AddKeyboardHookButton = new DevExpress.XtraEditors.SimpleButton();
            this.CommandsTab = new DevExpress.XtraTab.XtraTabPage();
            this.SendTextCommandButton = new DevExpress.XtraEditors.SimpleButton();
            this.DashboardButton = new DevExpress.XtraEditors.SimpleButton();
            this.XDKLauncherButton = new DevExpress.XtraEditors.SimpleButton();
            this.ScreenShotButton = new DevExpress.XtraEditors.SimpleButton();
            this.RebootButton = new DevExpress.XtraEditors.SimpleButton();
            this.UnfreezeButton = new DevExpress.XtraEditors.SimpleButton();
            this.FreezeButton = new DevExpress.XtraEditors.SimpleButton();
            this.ModuleLauncherTab = new DevExpress.XtraTab.XtraTabPage();
            this.ModuleLauncherScroller = new DevExpress.XtraEditors.XtraScrollableControl();
            this.ModuleLauncherStatusLabel = new DevExpress.XtraEditors.LabelControl();
            this.AddModuleShortcutButton = new DevExpress.XtraEditors.SimpleButton();
            this.SaveModulesButton = new DevExpress.XtraEditors.SimpleButton();
            this.TempControlTab = new DevExpress.XtraTab.XtraTabPage();
            this.TemperatureGauges = new DevExpress.XtraGauges.Win.GaugeControl();
            this.CPUTempGauge = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.CPUTempGaugeBackground = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.CPUTempGaugeCelsiusScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.CPUTempGaugeHeaderLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.CPUTempGaugeCelsiusLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.CPUTempGaugeFahrenheitLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.CPUTempGaugeActualScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.CPUTempGaugeFahrenheitScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.GPUTempGauge = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.GPUTempGaugeBackground = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.GPUTempGaugeCelsiusScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.GPUTempGaugeHeaderLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.GPUTempGaugeCelsiusLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.GPUTempGaugeFahrenheitLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.GPUTempGaugeActualScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.GPUTempGaugeFahrenheitScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.RAMTempGauge = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.RAMTempGaugeBackground = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.RAMTempGaugeCelsiusScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.RAMTempGaugeHeaderLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.RAMTempGaugeCelsiusLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.RAMTempGaugeFahrenheitLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.RAMTempGaugeActualScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.RAMTempGaugeFahrenheitScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.BoardTempGauge = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearGauge();
            this.BoardTempGaugeBackground = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent();
            this.BoardTempGaugeCelsiusScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.BoardTempGaugeHeaderLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.BoardTempGaugeCelsiusLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.BoardTempGaugeFahrenheitLabel = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.BoardTempGaugeActualScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent();
            this.BoardTempGaugeFahrenheitScale = new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent();
            this.ConsoleTempsWarningLabel = new DevExpress.XtraEditors.LabelControl();
            this.ConsoleTempsLabel = new DevExpress.XtraEditors.LabelControl();
            this.FanSpeedTrack = new DevExpress.XtraEditors.TrackBarControl();
            this.FanSpeedLabel = new DevExpress.XtraEditors.LabelControl();
            this.NeighborhoodDrivesTab = new DevExpress.XtraTab.XtraTabPage();
            this.NeighborhoodDrivesScroller = new DevExpress.XtraEditors.XtraScrollableControl();
            this.NeighborhoodDrivesStatusLabel = new DevExpress.XtraEditors.LabelControl();
            this.AddNeighborhoodDriveButton = new DevExpress.XtraEditors.SimpleButton();
            this.SaveDrivesButton = new DevExpress.XtraEditors.SimpleButton();
            this.DebugPrintingTab = new DevExpress.XtraTab.XtraTabPage();
            this.DebugPrintingMemo = new DevExpress.XtraEditors.MemoEdit();
            this.DebugPrintingClearButton = new DevExpress.XtraEditors.SimpleButton();
            this.SettingsTab = new DevExpress.XtraTab.XtraTabPage();
            this.XamFeaturesGroup = new DevExpress.XtraEditors.GroupControl();
            this.XamFeatureChecks = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.SaveXamFeaturesButton = new DevExpress.XtraEditors.SimpleButton();
            this.XamFeaturesInfoLabel = new DevExpress.XtraEditors.LabelControl();
            this.ModuleRightClickPopup = new DevExpress.XtraBars.PopupMenu(this.components);
            this.SplashScreenManager = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::DevTool.Forms.WaitForm1), true, true);
            this.FriendRightClickMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.CurrentTitleRightClickMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MainTabs)).BeginInit();
            this.MainTabs.SuspendLayout();
            this.MemoryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkinEditRepo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMG16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTitleEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemLengthText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemAddressText.Properties)).BeginInit();
            this.PatchingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PatchText.Properties)).BeginInit();
            this.XBLCenterTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XBLCenterFunctionsGroup)).BeginInit();
            this.XBLCenterFunctionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FriendFunctionsGroup)).BeginInit();
            this.FriendFunctionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlockFriendCheck.Properties)).BeginInit();
            this.KeyboardHookingTab.SuspendLayout();
            this.KeyboardHookingScroller.SuspendLayout();
            this.CommandsTab.SuspendLayout();
            this.ModuleLauncherTab.SuspendLayout();
            this.TempControlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeCelsiusScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeHeaderLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeCelsiusLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeFahrenheitLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeActualScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeFahrenheitScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeCelsiusScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeHeaderLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeCelsiusLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeFahrenheitLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeActualScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeFahrenheitScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeCelsiusScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeHeaderLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeCelsiusLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeFahrenheitLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeActualScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeFahrenheitScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeCelsiusScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeHeaderLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeCelsiusLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeFahrenheitLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeActualScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeFahrenheitScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FanSpeedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FanSpeedTrack.Properties)).BeginInit();
            this.NeighborhoodDrivesTab.SuspendLayout();
            this.NeighborhoodDrivesScroller.SuspendLayout();
            this.DebugPrintingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DebugPrintingMemo.Properties)).BeginInit();
            this.SettingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XamFeaturesGroup)).BeginInit();
            this.XamFeaturesGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XamFeatureChecks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleRightClickPopup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FriendRightClickMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTitleRightClickMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabs
            // 
            this.MainTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabs.Location = new System.Drawing.Point(0, 0);
            this.MainTabs.Name = "MainTabs";
            this.MainTabs.SelectedTabPage = this.MemoryTab;
            this.MainTabs.Size = new System.Drawing.Size(1067, 586);
            this.MainTabs.TabIndex = 0;
            this.MainTabs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.MemoryTab,
            this.PatchingTab,
            this.XBLCenterTab,
            this.KeyboardHookingTab,
            this.CommandsTab,
            this.ModuleLauncherTab,
            this.TempControlTab,
            this.NeighborhoodDrivesTab,
            this.DebugPrintingTab,
            this.SettingsTab});
            this.MainTabs.SelectedPageChanging += new DevExpress.XtraTab.TabPageChangingEventHandler(this.Tabs_SelectedPageChanging);
            // 
            // MemoryTab
            // 
            this.MemoryTab.Controls.Add(this.ModuleTree);
            this.MemoryTab.Controls.Add(this.CurrentTitleEdit);
            this.MemoryTab.Controls.Add(this.CurrentTitleLabel);
            this.MemoryTab.Controls.Add(this.MemGoButton);
            this.MemoryTab.Controls.Add(this.MemLengthText);
            this.MemoryTab.Controls.Add(this.MemAddressText);
            this.MemoryTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MemoryTab.ImageOptions.Image")));
            this.MemoryTab.Name = "MemoryTab";
            this.MemoryTab.Size = new System.Drawing.Size(1061, 555);
            this.MemoryTab.Text = "Memory";
            // 
            // ModuleTree
            // 
            this.ModuleTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ModuleTreeNameColumn,
            this.ModuleTreeAddressColumn,
            this.ModuleTreeSizeColumn,
            this.ModuleTreeOccupiedMemoryColumn});
            this.ModuleTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleTree.Location = new System.Drawing.Point(0, 106);
            this.ModuleTree.MenuManager = this.BarManager;
            this.ModuleTree.Name = "ModuleTree";
            this.ModuleTree.OptionsBehavior.Editable = false;
            this.ModuleTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ModuleTree.OptionsView.ShowIndicator = false;
            this.ModuleTree.OptionsView.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.None;
            this.ModuleTree.SelectImageList = this.IMG16;
            this.ModuleTree.Size = new System.Drawing.Size(1061, 449);
            this.ModuleTree.TabIndex = 4;
            this.ModuleTree.Tag = "";
            this.ModuleTree.ToolTipController = this.ToolTipController;
            this.ModuleTree.TreeLevelWidth = 12;
            this.ModuleTree.CompareNodeValues += new DevExpress.XtraTreeList.CompareNodeValuesEventHandler(this.ModuleTree_CompareNodeValues);
            this.ModuleTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ModuleTree_MouseUp);
            // 
            // ModuleTreeNameColumn
            // 
            this.ModuleTreeNameColumn.Caption = "Name";
            this.ModuleTreeNameColumn.FieldName = "Name";
            this.ModuleTreeNameColumn.MinWidth = 33;
            this.ModuleTreeNameColumn.Name = "ModuleTreeNameColumn";
            this.ModuleTreeNameColumn.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ModuleTreeNameColumn.Visible = true;
            this.ModuleTreeNameColumn.VisibleIndex = 0;
            this.ModuleTreeNameColumn.Width = 339;
            // 
            // ModuleTreeAddressColumn
            // 
            this.ModuleTreeAddressColumn.Caption = "Address";
            this.ModuleTreeAddressColumn.FieldName = "Address";
            this.ModuleTreeAddressColumn.Name = "ModuleTreeAddressColumn";
            this.ModuleTreeAddressColumn.Visible = true;
            this.ModuleTreeAddressColumn.VisibleIndex = 1;
            this.ModuleTreeAddressColumn.Width = 201;
            // 
            // ModuleTreeSizeColumn
            // 
            this.ModuleTreeSizeColumn.Caption = "Size";
            this.ModuleTreeSizeColumn.FieldName = "Size";
            this.ModuleTreeSizeColumn.Name = "ModuleTreeSizeColumn";
            this.ModuleTreeSizeColumn.Visible = true;
            this.ModuleTreeSizeColumn.VisibleIndex = 2;
            this.ModuleTreeSizeColumn.Width = 257;
            // 
            // ModuleTreeOccupiedMemoryColumn
            // 
            this.ModuleTreeOccupiedMemoryColumn.Caption = "Occupied Memory Region";
            this.ModuleTreeOccupiedMemoryColumn.FieldName = "Occupied Memory Region";
            this.ModuleTreeOccupiedMemoryColumn.Name = "ModuleTreeOccupiedMemoryColumn";
            this.ModuleTreeOccupiedMemoryColumn.Visible = true;
            this.ModuleTreeOccupiedMemoryColumn.VisibleIndex = 3;
            this.ModuleTreeOccupiedMemoryColumn.Width = 262;
            // 
            // BarManager
            // 
            this.BarManager.AllowCustomization = false;
            this.BarManager.AllowQuickCustomization = false;
            this.BarManager.AllowShowToolbarsPopup = false;
            this.BarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.StatusBar});
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.StatusText,
            this.ModuleCopyValueItem,
            this.ModuleDumpItem,
            this.ModuleViewInfoItem,
            this.SkinEdit,
            this.ForceReconnectButton,
            this.AboutItem,
            this.JoinPartyItem,
            this.AcceptDeclineFRItem,
            this.RemoveFriendItem,
            this.MessageFriendItem,
            this.InviteFriendItem,
            this.ShowGamercardItem,
            this.ModuleDumpSubMenu,
            this.ModuleDumpEntireItem,
            this.ModuleDumpSpecificSectionSubMenu,
            this.ViewGamertagItem,
            this.CopyOnlineXUIDItem,
            this.ShowFoFItem,
            this.CurrentTileVisitItem,
            this.ViewAllTitleInfoItem,
            this.TitleUpdateSearchItem});
            this.BarManager.MaxItemId = 25;
            this.BarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.SkinEditRepo});
            this.BarManager.StatusBar = this.StatusBar;
            this.BarManager.UseAltKeyForMenu = false;
            this.BarManager.UseF10KeyForMenu = false;
            // 
            // StatusBar
            // 
            this.StatusBar.BarName = "Status bar";
            this.StatusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.StatusBar.DockCol = 0;
            this.StatusBar.DockRow = 0;
            this.StatusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.StatusBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.StatusText),
            new DevExpress.XtraBars.LinkPersistInfo(this.ForceReconnectButton),
            new DevExpress.XtraBars.LinkPersistInfo(this.SkinEdit, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.AboutItem, true)});
            this.StatusBar.OptionsBar.AllowQuickCustomization = false;
            this.StatusBar.OptionsBar.DisableClose = true;
            this.StatusBar.OptionsBar.DisableCustomization = true;
            this.StatusBar.OptionsBar.DrawDragBorder = false;
            this.StatusBar.OptionsBar.UseWholeRow = true;
            this.StatusBar.Text = "Status bar";
            // 
            // StatusText
            // 
            this.StatusText.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.StatusText.Caption = "Idle";
            this.StatusText.Id = 1;
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(32, 0);
            this.StatusText.Width = 32;
            // 
            // ForceReconnectButton
            // 
            this.ForceReconnectButton.Caption = "Force Reconnect";
            this.ForceReconnectButton.Id = 8;
            this.ForceReconnectButton.Name = "ForceReconnectButton";
            this.ForceReconnectButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ForceReconnectButton_ItemClick);
            // 
            // SkinEdit
            // 
            this.SkinEdit.Edit = this.SkinEditRepo;
            this.SkinEdit.EditValue = "Metropolis";
            this.SkinEdit.EditWidth = 120;
            this.SkinEdit.Id = 6;
            this.SkinEdit.Name = "SkinEdit";
            this.SkinEdit.EditValueChanged += new System.EventHandler(this.SkinEdit_EditValueChanged);
            // 
            // SkinEditRepo
            // 
            this.SkinEditRepo.AutoHeight = false;
            this.SkinEditRepo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SkinEditRepo.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.SkinEditRepo.Items.AddRange(new object[] {
            "DevExpress Style",
            "DevExpress Dark Style",
            "Seven Classic",
            "Office 2010 Black",
            "Office 2010 Blue",
            "Office 2010 Silver",
            "Office 2013",
            "VS2010"});
            this.SkinEditRepo.Name = "SkinEditRepo";
            this.SkinEditRepo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // AboutItem
            // 
            this.AboutItem.Caption = "About";
            this.AboutItem.Id = 9;
            this.AboutItem.Name = "AboutItem";
            this.AboutItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AboutItem_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1067, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 586);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1067, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 586);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1067, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 586);
            // 
            // ModuleCopyValueItem
            // 
            this.ModuleCopyValueItem.Caption = "Copy Value";
            this.ModuleCopyValueItem.Id = 3;
            this.ModuleCopyValueItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ModuleCopyValueItem.ImageOptions.Image")));
            this.ModuleCopyValueItem.Name = "ModuleCopyValueItem";
            this.ModuleCopyValueItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ModuleCopyValueItem_ItemClick);
            // 
            // ModuleDumpItem
            // 
            this.ModuleDumpItem.Caption = "Dump Module";
            this.ModuleDumpItem.Id = 4;
            this.ModuleDumpItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ModuleDumpItem.ImageOptions.Image")));
            this.ModuleDumpItem.Name = "ModuleDumpItem";
            // 
            // ModuleViewInfoItem
            // 
            this.ModuleViewInfoItem.Caption = "View More Information";
            this.ModuleViewInfoItem.Id = 5;
            this.ModuleViewInfoItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ModuleViewInfoItem.ImageOptions.Image")));
            this.ModuleViewInfoItem.Name = "ModuleViewInfoItem";
            this.ModuleViewInfoItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ModuleViewInfoItem_ItemClick);
            // 
            // JoinPartyItem
            // 
            this.JoinPartyItem.Caption = "Join Party";
            this.JoinPartyItem.Id = 10;
            this.JoinPartyItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("JoinPartyItem.ImageOptions.Image")));
            this.JoinPartyItem.Name = "JoinPartyItem";
            this.JoinPartyItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.JoinPartyItem_ItemClick);
            // 
            // AcceptDeclineFRItem
            // 
            this.AcceptDeclineFRItem.Caption = "Accept or Decline";
            this.AcceptDeclineFRItem.Id = 11;
            this.AcceptDeclineFRItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("AcceptDeclineFRItem.ImageOptions.Image")));
            this.AcceptDeclineFRItem.Name = "AcceptDeclineFRItem";
            this.AcceptDeclineFRItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AcceptDeclineFRItem_ItemClick);
            // 
            // RemoveFriendItem
            // 
            this.RemoveFriendItem.Caption = "Remove";
            this.RemoveFriendItem.Id = 12;
            this.RemoveFriendItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("RemoveFriendItem.ImageOptions.Image")));
            this.RemoveFriendItem.Name = "RemoveFriendItem";
            this.RemoveFriendItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.RemoveFriendItem_ItemClick);
            // 
            // MessageFriendItem
            // 
            this.MessageFriendItem.Caption = "Message";
            this.MessageFriendItem.Id = 13;
            this.MessageFriendItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("MessageFriendItem.ImageOptions.Image")));
            this.MessageFriendItem.Name = "MessageFriendItem";
            this.MessageFriendItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.MessageFriendItem_ItemClick);
            // 
            // InviteFriendItem
            // 
            this.InviteFriendItem.Caption = "Invite";
            this.InviteFriendItem.Id = 14;
            this.InviteFriendItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("InviteFriendItem.ImageOptions.Image")));
            this.InviteFriendItem.Name = "InviteFriendItem";
            this.InviteFriendItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.InviteFriendItem_ItemClick);
            // 
            // ShowGamercardItem
            // 
            this.ShowGamercardItem.Caption = "Show Gamercard";
            this.ShowGamercardItem.Id = 15;
            this.ShowGamercardItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ShowGamercardItem.ImageOptions.Image")));
            this.ShowGamercardItem.Name = "ShowGamercardItem";
            this.ShowGamercardItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ShowGamercardItem_ItemClick);
            // 
            // ModuleDumpSubMenu
            // 
            this.ModuleDumpSubMenu.Caption = "Dump";
            this.ModuleDumpSubMenu.Id = 16;
            this.ModuleDumpSubMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ModuleDumpSubMenu.ImageOptions.Image")));
            this.ModuleDumpSubMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ModuleDumpEntireItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ModuleDumpSpecificSectionSubMenu)});
            this.ModuleDumpSubMenu.Name = "ModuleDumpSubMenu";
            // 
            // ModuleDumpEntireItem
            // 
            this.ModuleDumpEntireItem.Caption = "Entire Module";
            this.ModuleDumpEntireItem.Id = 17;
            this.ModuleDumpEntireItem.Name = "ModuleDumpEntireItem";
            this.ModuleDumpEntireItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ModuleDumpEntireItem_ItemClick);
            // 
            // ModuleDumpSpecificSectionSubMenu
            // 
            this.ModuleDumpSpecificSectionSubMenu.Caption = "Specific Section";
            this.ModuleDumpSpecificSectionSubMenu.Id = 18;
            this.ModuleDumpSpecificSectionSubMenu.Name = "ModuleDumpSpecificSectionSubMenu";
            // 
            // ViewGamertagItem
            // 
            this.ViewGamertagItem.Caption = "View Gamertag";
            this.ViewGamertagItem.Id = 19;
            this.ViewGamertagItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ViewGamertagItem.ImageOptions.Image")));
            this.ViewGamertagItem.Name = "ViewGamertagItem";
            this.ViewGamertagItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ViewGamertagItem_ItemClick);
            // 
            // CopyOnlineXUIDItem
            // 
            this.CopyOnlineXUIDItem.Caption = "Copy Online XUID";
            this.CopyOnlineXUIDItem.Id = 20;
            this.CopyOnlineXUIDItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("CopyOnlineXUIDItem.ImageOptions.Image")));
            this.CopyOnlineXUIDItem.Name = "CopyOnlineXUIDItem";
            this.CopyOnlineXUIDItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CopyOnlineXUIDItem_ItemClick);
            // 
            // ShowFoFItem
            // 
            this.ShowFoFItem.Caption = "Show Friends";
            this.ShowFoFItem.Id = 21;
            this.ShowFoFItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ShowFoFItem.ImageOptions.Image")));
            this.ShowFoFItem.Name = "ShowFoFItem";
            this.ShowFoFItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ShowFoFItem_ItemClick);
            // 
            // CurrentTileVisitItem
            // 
            this.CurrentTileVisitItem.Caption = "Visit Xbox.com Page";
            this.CurrentTileVisitItem.Id = 22;
            this.CurrentTileVisitItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("CurrentTileVisitItem.ImageOptions.Image")));
            this.CurrentTileVisitItem.Name = "CurrentTileVisitItem";
            this.CurrentTileVisitItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CurrentTileVisitItem_ItemClick);
            // 
            // ViewAllTitleInfoItem
            // 
            this.ViewAllTitleInfoItem.Caption = "View all Information";
            this.ViewAllTitleInfoItem.Id = 23;
            this.ViewAllTitleInfoItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ViewAllTitleInfoItem.ImageOptions.Image")));
            this.ViewAllTitleInfoItem.Name = "ViewAllTitleInfoItem";
            this.ViewAllTitleInfoItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ViewAllTitleInfoItem_ItemClick);
            // 
            // TitleUpdateSearchItem
            // 
            this.TitleUpdateSearchItem.Caption = "Search for Title Update";
            this.TitleUpdateSearchItem.Id = 24;
            this.TitleUpdateSearchItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("TitleUpdateSearchItem.ImageOptions.Image")));
            this.TitleUpdateSearchItem.Name = "TitleUpdateSearchItem";
            this.TitleUpdateSearchItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.TitleUpdateSearchItem_ItemClick);
            // 
            // IMG16
            // 
            this.IMG16.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("IMG16.ImageStream")));
            this.IMG16.Images.SetKeyName(0, "ModuleEXE");
            this.IMG16.Images.SetKeyName(1, "ModuleDLL");
            this.IMG16.Images.SetKeyName(2, "ModuleUnk");
            // 
            // ToolTipController
            // 
            this.ToolTipController.ToolTipType = DevExpress.Utils.ToolTipType.SuperTip;
            // 
            // CurrentTitleEdit
            // 
            this.CurrentTitleEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.CurrentTitleEdit.Location = new System.Drawing.Point(0, 86);
            this.CurrentTitleEdit.MenuManager = this.BarManager;
            this.CurrentTitleEdit.Name = "CurrentTitleEdit";
            this.CurrentTitleEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right)});
            this.CurrentTitleEdit.Size = new System.Drawing.Size(1061, 20);
            this.CurrentTitleEdit.TabIndex = 3;
            this.CurrentTitleEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.CurrentTitleEdit_ButtonClick);
            this.CurrentTitleEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CurrentTitleEdit_KeyPress);
            // 
            // CurrentTitleLabel
            // 
            this.CurrentTitleLabel.AutoEllipsis = true;
            this.CurrentTitleLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.CurrentTitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CurrentTitleLabel.Location = new System.Drawing.Point(0, 73);
            this.CurrentTitleLabel.Name = "CurrentTitleLabel";
            this.CurrentTitleLabel.Size = new System.Drawing.Size(1061, 13);
            this.CurrentTitleLabel.TabIndex = 0;
            this.CurrentTitleLabel.Text = "Current title info";
            this.CurrentTitleLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CurrentTitleLabel_MouseClick);
            // 
            // MemGoButton
            // 
            this.MemGoButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MemGoButton.Location = new System.Drawing.Point(0, 40);
            this.MemGoButton.Name = "MemGoButton";
            this.MemGoButton.Size = new System.Drawing.Size(1061, 33);
            this.MemGoButton.TabIndex = 2;
            this.MemGoButton.Text = "Dump Memory + Edit";
            this.MemGoButton.Click += new System.EventHandler(this.MemGoButton_Click);
            // 
            // MemLengthText
            // 
            this.MemLengthText.Dock = System.Windows.Forms.DockStyle.Top;
            this.MemLengthText.Location = new System.Drawing.Point(0, 20);
            this.MemLengthText.MenuManager = this.BarManager;
            this.MemLengthText.Name = "MemLengthText";
            this.MemLengthText.Properties.NullValuePrompt = "How many bytes to read (hex)";
            this.MemLengthText.Size = new System.Drawing.Size(1061, 20);
            this.MemLengthText.TabIndex = 1;
            this.MemLengthText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MemText_KeyPress);
            // 
            // MemAddressText
            // 
            this.MemAddressText.Dock = System.Windows.Forms.DockStyle.Top;
            this.MemAddressText.Location = new System.Drawing.Point(0, 0);
            this.MemAddressText.MenuManager = this.BarManager;
            this.MemAddressText.Name = "MemAddressText";
            this.MemAddressText.Properties.NullValuePrompt = "Address (hex)";
            this.MemAddressText.Size = new System.Drawing.Size(1061, 20);
            this.MemAddressText.TabIndex = 0;
            this.MemAddressText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MemText_KeyPress);
            // 
            // PatchingTab
            // 
            this.PatchingTab.Controls.Add(this.PatchText);
            this.PatchingTab.Controls.Add(this.PatchCompileWriteButton);
            this.PatchingTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("PatchingTab.ImageOptions.Image")));
            this.PatchingTab.Name = "PatchingTab";
            this.PatchingTab.Size = new System.Drawing.Size(1061, 555);
            this.PatchingTab.Text = "Patching";
            // 
            // PatchText
            // 
            this.PatchText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PatchText.Location = new System.Drawing.Point(0, 0);
            this.PatchText.MenuManager = this.BarManager;
            this.PatchText.Name = "PatchText";
            this.PatchText.Size = new System.Drawing.Size(1061, 515);
            this.PatchText.TabIndex = 0;
            // 
            // PatchCompileWriteButton
            // 
            this.PatchCompileWriteButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PatchCompileWriteButton.Location = new System.Drawing.Point(0, 515);
            this.PatchCompileWriteButton.Name = "PatchCompileWriteButton";
            this.PatchCompileWriteButton.Size = new System.Drawing.Size(1061, 40);
            this.PatchCompileWriteButton.TabIndex = 1;
            this.PatchCompileWriteButton.Text = "Compile and Write ";
            this.PatchCompileWriteButton.Click += new System.EventHandler(this.PatchCompileWriteButton_Click);
            // 
            // XBLCenterTab
            // 
            this.XBLCenterTab.Controls.Add(this.FriendsTileControl);
            this.XBLCenterTab.Controls.Add(this.XBLCenterFunctionsGroup);
            this.XBLCenterTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("XBLCenterTab.ImageOptions.Image")));
            this.XBLCenterTab.Name = "XBLCenterTab";
            this.XBLCenterTab.Size = new System.Drawing.Size(1061, 555);
            this.XBLCenterTab.Text = "XBL Center";
            // 
            // FriendsTileControl
            // 
            this.FriendsTileControl.AllowDrag = false;
            this.FriendsTileControl.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.FriendsTileControl.AppearanceText.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FriendsTileControl.AppearanceText.Options.UseFont = true;
            this.FriendsTileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FriendsTileControl.Groups.Add(this.FriendsTileGroup);
            this.FriendsTileControl.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.FriendsTileControl.Location = new System.Drawing.Point(0, 0);
            this.FriendsTileControl.MaxId = 14;
            this.FriendsTileControl.Name = "FriendsTileControl";
            this.FriendsTileControl.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.FriendsTileControl.ShowText = true;
            this.FriendsTileControl.Size = new System.Drawing.Size(841, 555);
            this.FriendsTileControl.TabIndex = 0;
            this.FriendsTileControl.Tag = "0";
            this.FriendsTileControl.Text = "Friends";
            this.FriendsTileControl.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            // 
            // FriendsTileGroup
            // 
            this.FriendsTileGroup.Name = "FriendsTileGroup";
            this.FriendsTileGroup.Text = null;
            // 
            // XBLCenterFunctionsGroup
            // 
            this.XBLCenterFunctionsGroup.AppearanceCaption.Options.UseTextOptions = true;
            this.XBLCenterFunctionsGroup.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.XBLCenterFunctionsGroup.Controls.Add(this.FriendFunctionsGroup);
            this.XBLCenterFunctionsGroup.Controls.Add(this.XUIDGTConversionsButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.ShowPlayersUIButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.ShowMessagesUIButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.ShowFriendsUIButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.ShowPartyUIButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.LeavePartyButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.JoinSpecificPartyButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.SendFRButton);
            this.XBLCenterFunctionsGroup.Controls.Add(this.SignOutButton);
            this.XBLCenterFunctionsGroup.Dock = System.Windows.Forms.DockStyle.Right;
            this.XBLCenterFunctionsGroup.Location = new System.Drawing.Point(841, 0);
            this.XBLCenterFunctionsGroup.Name = "XBLCenterFunctionsGroup";
            this.XBLCenterFunctionsGroup.Size = new System.Drawing.Size(220, 555);
            this.XBLCenterFunctionsGroup.TabIndex = 0;
            this.XBLCenterFunctionsGroup.Text = "Functions";
            // 
            // FriendFunctionsGroup
            // 
            this.FriendFunctionsGroup.Controls.Add(this.InviteAllFriendsButton);
            this.FriendFunctionsGroup.Controls.Add(this.InviteSelectedFriendsButton);
            this.FriendFunctionsGroup.Controls.Add(this.MessageAllFriendsButton);
            this.FriendFunctionsGroup.Controls.Add(this.MessageSelectedFriendsButton);
            this.FriendFunctionsGroup.Controls.Add(this.RemoveAllFriendsButton);
            this.FriendFunctionsGroup.Controls.Add(this.RemoveSelectedFriendsButton);
            this.FriendFunctionsGroup.Controls.Add(this.DeclineAllFRsButton);
            this.FriendFunctionsGroup.Controls.Add(this.DeclineSelectedFRsButton);
            this.FriendFunctionsGroup.Controls.Add(this.BlockFriendCheck);
            this.FriendFunctionsGroup.Controls.Add(this.AcceptAllFRsButton);
            this.FriendFunctionsGroup.Controls.Add(this.AcceptSelectedFRsButton);
            this.FriendFunctionsGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FriendFunctionsGroup.Location = new System.Drawing.Point(2, 263);
            this.FriendFunctionsGroup.Name = "FriendFunctionsGroup";
            this.FriendFunctionsGroup.Size = new System.Drawing.Size(216, 290);
            this.FriendFunctionsGroup.TabIndex = 0;
            this.FriendFunctionsGroup.Text = "Friend Functions";
            // 
            // InviteAllFriendsButton
            // 
            this.InviteAllFriendsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InviteAllFriendsButton.Location = new System.Drawing.Point(2, 282);
            this.InviteAllFriendsButton.Name = "InviteAllFriendsButton";
            this.InviteAllFriendsButton.Size = new System.Drawing.Size(212, 27);
            this.InviteAllFriendsButton.TabIndex = 19;
            this.InviteAllFriendsButton.Text = "Invite ALL Friends";
            this.InviteAllFriendsButton.Click += new System.EventHandler(this.InviteAllFriendsButton_Click);
            // 
            // InviteSelectedFriendsButton
            // 
            this.InviteSelectedFriendsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InviteSelectedFriendsButton.Location = new System.Drawing.Point(2, 255);
            this.InviteSelectedFriendsButton.Name = "InviteSelectedFriendsButton";
            this.InviteSelectedFriendsButton.Size = new System.Drawing.Size(212, 27);
            this.InviteSelectedFriendsButton.TabIndex = 18;
            this.InviteSelectedFriendsButton.Text = "Invite Selected Friends";
            this.InviteSelectedFriendsButton.Click += new System.EventHandler(this.InviteSelectedFriendsButton_Click);
            // 
            // MessageAllFriendsButton
            // 
            this.MessageAllFriendsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageAllFriendsButton.Location = new System.Drawing.Point(2, 228);
            this.MessageAllFriendsButton.Name = "MessageAllFriendsButton";
            this.MessageAllFriendsButton.Size = new System.Drawing.Size(212, 27);
            this.MessageAllFriendsButton.TabIndex = 17;
            this.MessageAllFriendsButton.Text = "Message ALL Friends";
            this.MessageAllFriendsButton.Click += new System.EventHandler(this.MessageAllFriendsButton_Click);
            // 
            // MessageSelectedFriendsButton
            // 
            this.MessageSelectedFriendsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageSelectedFriendsButton.Location = new System.Drawing.Point(2, 201);
            this.MessageSelectedFriendsButton.Name = "MessageSelectedFriendsButton";
            this.MessageSelectedFriendsButton.Size = new System.Drawing.Size(212, 27);
            this.MessageSelectedFriendsButton.TabIndex = 16;
            this.MessageSelectedFriendsButton.Text = "Message Selected Friends";
            this.MessageSelectedFriendsButton.Click += new System.EventHandler(this.MessageSelectedFriendsButton_Click);
            // 
            // RemoveAllFriendsButton
            // 
            this.RemoveAllFriendsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveAllFriendsButton.Location = new System.Drawing.Point(2, 174);
            this.RemoveAllFriendsButton.Name = "RemoveAllFriendsButton";
            this.RemoveAllFriendsButton.Size = new System.Drawing.Size(212, 27);
            this.RemoveAllFriendsButton.TabIndex = 15;
            this.RemoveAllFriendsButton.Text = "Remove ALL Friends";
            this.RemoveAllFriendsButton.Click += new System.EventHandler(this.RemoveAllFriendsButton_Click);
            // 
            // RemoveSelectedFriendsButton
            // 
            this.RemoveSelectedFriendsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemoveSelectedFriendsButton.Location = new System.Drawing.Point(2, 147);
            this.RemoveSelectedFriendsButton.Name = "RemoveSelectedFriendsButton";
            this.RemoveSelectedFriendsButton.Size = new System.Drawing.Size(212, 27);
            this.RemoveSelectedFriendsButton.TabIndex = 14;
            this.RemoveSelectedFriendsButton.Text = "Remove Selected Friends";
            this.RemoveSelectedFriendsButton.Click += new System.EventHandler(this.RemoveSelectedFriendsButton_Click);
            // 
            // DeclineAllFRsButton
            // 
            this.DeclineAllFRsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeclineAllFRsButton.Location = new System.Drawing.Point(2, 120);
            this.DeclineAllFRsButton.Name = "DeclineAllFRsButton";
            this.DeclineAllFRsButton.Size = new System.Drawing.Size(212, 27);
            this.DeclineAllFRsButton.TabIndex = 13;
            this.DeclineAllFRsButton.Text = "Decline ALL Friend Requests";
            this.DeclineAllFRsButton.Click += new System.EventHandler(this.DeclineAllFRsButton_Click);
            // 
            // DeclineSelectedFRsButton
            // 
            this.DeclineSelectedFRsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeclineSelectedFRsButton.Location = new System.Drawing.Point(2, 93);
            this.DeclineSelectedFRsButton.Name = "DeclineSelectedFRsButton";
            this.DeclineSelectedFRsButton.Size = new System.Drawing.Size(212, 27);
            this.DeclineSelectedFRsButton.TabIndex = 12;
            this.DeclineSelectedFRsButton.Text = "Decline Selected Friend Requests";
            this.DeclineSelectedFRsButton.Click += new System.EventHandler(this.DeclineSelectedFRsButton_Click);
            // 
            // BlockFriendCheck
            // 
            this.BlockFriendCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.BlockFriendCheck.Location = new System.Drawing.Point(2, 74);
            this.BlockFriendCheck.MenuManager = this.BarManager;
            this.BlockFriendCheck.Name = "BlockFriendCheck";
            this.BlockFriendCheck.Properties.Caption = "Decline AND Block";
            this.BlockFriendCheck.Size = new System.Drawing.Size(212, 19);
            this.BlockFriendCheck.TabIndex = 11;
            // 
            // AcceptAllFRsButton
            // 
            this.AcceptAllFRsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AcceptAllFRsButton.Location = new System.Drawing.Point(2, 47);
            this.AcceptAllFRsButton.Name = "AcceptAllFRsButton";
            this.AcceptAllFRsButton.Size = new System.Drawing.Size(212, 27);
            this.AcceptAllFRsButton.TabIndex = 10;
            this.AcceptAllFRsButton.Text = "Accept ALL Friend Requests";
            this.AcceptAllFRsButton.Click += new System.EventHandler(this.AcceptAllFRsButton_Click);
            // 
            // AcceptSelectedFRsButton
            // 
            this.AcceptSelectedFRsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AcceptSelectedFRsButton.Location = new System.Drawing.Point(2, 20);
            this.AcceptSelectedFRsButton.Name = "AcceptSelectedFRsButton";
            this.AcceptSelectedFRsButton.Size = new System.Drawing.Size(212, 27);
            this.AcceptSelectedFRsButton.TabIndex = 9;
            this.AcceptSelectedFRsButton.Text = "Accept Selected Friend Requests";
            this.AcceptSelectedFRsButton.Click += new System.EventHandler(this.AcceptSelectedFRsButton_Click);
            // 
            // XUIDGTConversionsButton
            // 
            this.XUIDGTConversionsButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.XUIDGTConversionsButton.Location = new System.Drawing.Point(2, 236);
            this.XUIDGTConversionsButton.Name = "XUIDGTConversionsButton";
            this.XUIDGTConversionsButton.Size = new System.Drawing.Size(216, 27);
            this.XUIDGTConversionsButton.TabIndex = 8;
            this.XUIDGTConversionsButton.Text = "XUID/Gamertag Conversions";
            this.XUIDGTConversionsButton.Click += new System.EventHandler(this.XUIDGTConversionsButton_Click);
            // 
            // ShowPlayersUIButton
            // 
            this.ShowPlayersUIButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowPlayersUIButton.Location = new System.Drawing.Point(2, 209);
            this.ShowPlayersUIButton.Name = "ShowPlayersUIButton";
            this.ShowPlayersUIButton.Size = new System.Drawing.Size(216, 27);
            this.ShowPlayersUIButton.TabIndex = 7;
            this.ShowPlayersUIButton.Text = "Show Players UI";
            this.ShowPlayersUIButton.Click += new System.EventHandler(this.ShowPlayersUIButton_Click);
            // 
            // ShowMessagesUIButton
            // 
            this.ShowMessagesUIButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowMessagesUIButton.Location = new System.Drawing.Point(2, 182);
            this.ShowMessagesUIButton.Name = "ShowMessagesUIButton";
            this.ShowMessagesUIButton.Size = new System.Drawing.Size(216, 27);
            this.ShowMessagesUIButton.TabIndex = 6;
            this.ShowMessagesUIButton.Text = "Show Messages UI";
            this.ShowMessagesUIButton.Click += new System.EventHandler(this.ShowMessagesUIButton_Click);
            // 
            // ShowFriendsUIButton
            // 
            this.ShowFriendsUIButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowFriendsUIButton.Location = new System.Drawing.Point(2, 155);
            this.ShowFriendsUIButton.Name = "ShowFriendsUIButton";
            this.ShowFriendsUIButton.Size = new System.Drawing.Size(216, 27);
            this.ShowFriendsUIButton.TabIndex = 5;
            this.ShowFriendsUIButton.Text = "Show Friends UI";
            this.ShowFriendsUIButton.Click += new System.EventHandler(this.ShowFriendsUIButton_Click);
            // 
            // ShowPartyUIButton
            // 
            this.ShowPartyUIButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ShowPartyUIButton.Location = new System.Drawing.Point(2, 128);
            this.ShowPartyUIButton.Name = "ShowPartyUIButton";
            this.ShowPartyUIButton.Size = new System.Drawing.Size(216, 27);
            this.ShowPartyUIButton.TabIndex = 4;
            this.ShowPartyUIButton.Text = "Show Party UI";
            this.ShowPartyUIButton.Click += new System.EventHandler(this.ShowPartyUIButton_Click);
            // 
            // LeavePartyButton
            // 
            this.LeavePartyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.LeavePartyButton.Enabled = false;
            this.LeavePartyButton.Location = new System.Drawing.Point(2, 101);
            this.LeavePartyButton.Name = "LeavePartyButton";
            this.LeavePartyButton.Size = new System.Drawing.Size(216, 27);
            this.LeavePartyButton.TabIndex = 3;
            this.LeavePartyButton.Text = "Leave Current Party";
            this.LeavePartyButton.Click += new System.EventHandler(this.LeavePartyButton_Click);
            // 
            // JoinSpecificPartyButton
            // 
            this.JoinSpecificPartyButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.JoinSpecificPartyButton.Location = new System.Drawing.Point(2, 74);
            this.JoinSpecificPartyButton.Name = "JoinSpecificPartyButton";
            this.JoinSpecificPartyButton.Size = new System.Drawing.Size(216, 27);
            this.JoinSpecificPartyButton.TabIndex = 2;
            this.JoinSpecificPartyButton.Text = "Join Specific Party";
            this.JoinSpecificPartyButton.Click += new System.EventHandler(this.JoinSpecificPartyButton_Click);
            // 
            // SendFRButton
            // 
            this.SendFRButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendFRButton.Location = new System.Drawing.Point(2, 47);
            this.SendFRButton.Name = "SendFRButton";
            this.SendFRButton.Size = new System.Drawing.Size(216, 27);
            this.SendFRButton.TabIndex = 1;
            this.SendFRButton.Text = "Send Friend Request";
            this.SendFRButton.Click += new System.EventHandler(this.SendFRButton_Click);
            // 
            // SignOutButton
            // 
            this.SignOutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SignOutButton.Location = new System.Drawing.Point(2, 20);
            this.SignOutButton.Name = "SignOutButton";
            this.SignOutButton.Size = new System.Drawing.Size(216, 27);
            this.SignOutButton.TabIndex = 8;
            this.SignOutButton.Text = "Sign Out";
            this.SignOutButton.Click += new System.EventHandler(this.SignOutButton_Click);
            // 
            // KeyboardHookingTab
            // 
            this.KeyboardHookingTab.Controls.Add(this.KeyboardHookingScroller);
            this.KeyboardHookingTab.Controls.Add(this.SaveKeyboardHooksButton);
            this.KeyboardHookingTab.Controls.Add(this.AddKeyboardHookButton);
            this.KeyboardHookingTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("KeyboardHookingTab.ImageOptions.Image")));
            this.KeyboardHookingTab.Name = "KeyboardHookingTab";
            this.KeyboardHookingTab.Size = new System.Drawing.Size(1061, 555);
            this.KeyboardHookingTab.Text = "Keyboard Hooking";
            // 
            // KeyboardHookingScroller
            // 
            this.KeyboardHookingScroller.Controls.Add(this.HooksStatusLabel);
            this.KeyboardHookingScroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyboardHookingScroller.FireScrollEventOnMouseWheel = true;
            this.KeyboardHookingScroller.Location = new System.Drawing.Point(0, 27);
            this.KeyboardHookingScroller.Name = "KeyboardHookingScroller";
            this.KeyboardHookingScroller.Size = new System.Drawing.Size(1061, 501);
            this.KeyboardHookingScroller.TabIndex = 1;
            // 
            // HooksStatusLabel
            // 
            this.HooksStatusLabel.AutoEllipsis = true;
            this.HooksStatusLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.HooksStatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HooksStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.HooksStatusLabel.Name = "HooksStatusLabel";
            this.HooksStatusLabel.Size = new System.Drawing.Size(1061, 13);
            this.HooksStatusLabel.TabIndex = 0;
            this.HooksStatusLabel.Text = "No hooks found. Add one using the button above.";
            // 
            // SaveKeyboardHooksButton
            // 
            this.SaveKeyboardHooksButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveKeyboardHooksButton.Location = new System.Drawing.Point(0, 528);
            this.SaveKeyboardHooksButton.Name = "SaveKeyboardHooksButton";
            this.SaveKeyboardHooksButton.Size = new System.Drawing.Size(1061, 27);
            this.SaveKeyboardHooksButton.TabIndex = 2;
            this.SaveKeyboardHooksButton.Text = "Save Keyboard Hook Configuration";
            this.SaveKeyboardHooksButton.Click += new System.EventHandler(this.SaveKeyboardHooksButton_Click);
            // 
            // AddKeyboardHookButton
            // 
            this.AddKeyboardHookButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddKeyboardHookButton.Location = new System.Drawing.Point(0, 0);
            this.AddKeyboardHookButton.Name = "AddKeyboardHookButton";
            this.AddKeyboardHookButton.Size = new System.Drawing.Size(1061, 27);
            this.AddKeyboardHookButton.TabIndex = 0;
            this.AddKeyboardHookButton.Text = "Add Hook";
            this.AddKeyboardHookButton.Click += new System.EventHandler(this.AddKeyboardHookButton_Click);
            // 
            // CommandsTab
            // 
            this.CommandsTab.Controls.Add(this.SendTextCommandButton);
            this.CommandsTab.Controls.Add(this.DashboardButton);
            this.CommandsTab.Controls.Add(this.XDKLauncherButton);
            this.CommandsTab.Controls.Add(this.ScreenShotButton);
            this.CommandsTab.Controls.Add(this.RebootButton);
            this.CommandsTab.Controls.Add(this.UnfreezeButton);
            this.CommandsTab.Controls.Add(this.FreezeButton);
            this.CommandsTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("CommandsTab.ImageOptions.Image")));
            this.CommandsTab.Name = "CommandsTab";
            this.CommandsTab.Size = new System.Drawing.Size(1061, 555);
            this.CommandsTab.Text = "Commands";
            // 
            // SendTextCommandButton
            // 
            this.SendTextCommandButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendTextCommandButton.Location = new System.Drawing.Point(0, 162);
            this.SendTextCommandButton.Name = "SendTextCommandButton";
            this.SendTextCommandButton.Size = new System.Drawing.Size(1061, 27);
            this.SendTextCommandButton.TabIndex = 6;
            this.SendTextCommandButton.Text = "Send Text Command";
            this.SendTextCommandButton.Click += new System.EventHandler(this.SendTextCommandButton_Click);
            // 
            // DashboardButton
            // 
            this.DashboardButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DashboardButton.Location = new System.Drawing.Point(0, 135);
            this.DashboardButton.Name = "DashboardButton";
            this.DashboardButton.Size = new System.Drawing.Size(1061, 27);
            this.DashboardButton.TabIndex = 5;
            this.DashboardButton.Text = "Launch Dashboard";
            this.DashboardButton.Click += new System.EventHandler(this.DashboardButton_Click);
            // 
            // XDKLauncherButton
            // 
            this.XDKLauncherButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.XDKLauncherButton.Location = new System.Drawing.Point(0, 108);
            this.XDKLauncherButton.Name = "XDKLauncherButton";
            this.XDKLauncherButton.Size = new System.Drawing.Size(1061, 27);
            this.XDKLauncherButton.TabIndex = 4;
            this.XDKLauncherButton.Text = "Launch XDK Launcher";
            this.XDKLauncherButton.Click += new System.EventHandler(this.XDKLauncherButton_Click);
            // 
            // ScreenShotButton
            // 
            this.ScreenShotButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScreenShotButton.Location = new System.Drawing.Point(0, 81);
            this.ScreenShotButton.Name = "ScreenShotButton";
            this.ScreenShotButton.Size = new System.Drawing.Size(1061, 27);
            this.ScreenShotButton.TabIndex = 3;
            this.ScreenShotButton.Text = "Take Screenshot";
            this.ScreenShotButton.Click += new System.EventHandler(this.ScreenShotButton_Click);
            // 
            // RebootButton
            // 
            this.RebootButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RebootButton.Location = new System.Drawing.Point(0, 54);
            this.RebootButton.Name = "RebootButton";
            this.RebootButton.Size = new System.Drawing.Size(1061, 27);
            this.RebootButton.TabIndex = 2;
            this.RebootButton.Text = "Reboot";
            this.RebootButton.Click += new System.EventHandler(this.RebootButton_Click);
            // 
            // UnfreezeButton
            // 
            this.UnfreezeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UnfreezeButton.Location = new System.Drawing.Point(0, 27);
            this.UnfreezeButton.Name = "UnfreezeButton";
            this.UnfreezeButton.Size = new System.Drawing.Size(1061, 27);
            this.UnfreezeButton.TabIndex = 1;
            this.UnfreezeButton.Text = "Unfreeze";
            this.UnfreezeButton.Click += new System.EventHandler(this.UnfreezeButton_Click);
            // 
            // FreezeButton
            // 
            this.FreezeButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.FreezeButton.Location = new System.Drawing.Point(0, 0);
            this.FreezeButton.Name = "FreezeButton";
            this.FreezeButton.Size = new System.Drawing.Size(1061, 27);
            this.FreezeButton.TabIndex = 0;
            this.FreezeButton.Text = "Freeze";
            this.FreezeButton.Click += new System.EventHandler(this.FreezeButton_Click);
            // 
            // ModuleLauncherTab
            // 
            this.ModuleLauncherTab.Controls.Add(this.ModuleLauncherScroller);
            this.ModuleLauncherTab.Controls.Add(this.ModuleLauncherStatusLabel);
            this.ModuleLauncherTab.Controls.Add(this.AddModuleShortcutButton);
            this.ModuleLauncherTab.Controls.Add(this.SaveModulesButton);
            this.ModuleLauncherTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ModuleLauncherTab.ImageOptions.Image")));
            this.ModuleLauncherTab.Name = "ModuleLauncherTab";
            this.ModuleLauncherTab.Size = new System.Drawing.Size(1061, 555);
            this.ModuleLauncherTab.Text = "Module Launcher";
            // 
            // ModuleLauncherScroller
            // 
            this.ModuleLauncherScroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleLauncherScroller.FireScrollEventOnMouseWheel = true;
            this.ModuleLauncherScroller.Location = new System.Drawing.Point(0, 40);
            this.ModuleLauncherScroller.Name = "ModuleLauncherScroller";
            this.ModuleLauncherScroller.Size = new System.Drawing.Size(1061, 488);
            this.ModuleLauncherScroller.TabIndex = 1;
            // 
            // ModuleLauncherStatusLabel
            // 
            this.ModuleLauncherStatusLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.ModuleLauncherStatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModuleLauncherStatusLabel.Location = new System.Drawing.Point(0, 27);
            this.ModuleLauncherStatusLabel.Name = "ModuleLauncherStatusLabel";
            this.ModuleLauncherStatusLabel.Size = new System.Drawing.Size(1061, 13);
            this.ModuleLauncherStatusLabel.TabIndex = 0;
            this.ModuleLauncherStatusLabel.Text = "No module shortcuts found. Add one using the button above.";
            // 
            // AddModuleShortcutButton
            // 
            this.AddModuleShortcutButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddModuleShortcutButton.Location = new System.Drawing.Point(0, 0);
            this.AddModuleShortcutButton.Name = "AddModuleShortcutButton";
            this.AddModuleShortcutButton.Size = new System.Drawing.Size(1061, 27);
            this.AddModuleShortcutButton.TabIndex = 0;
            this.AddModuleShortcutButton.Text = "Add Module Shortcut";
            this.AddModuleShortcutButton.Click += new System.EventHandler(this.AddModuleShortcutButton_Click);
            // 
            // SaveModulesButton
            // 
            this.SaveModulesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveModulesButton.Location = new System.Drawing.Point(0, 528);
            this.SaveModulesButton.Name = "SaveModulesButton";
            this.SaveModulesButton.Size = new System.Drawing.Size(1061, 27);
            this.SaveModulesButton.TabIndex = 2;
            this.SaveModulesButton.Text = "Save Module Launcher Configuration";
            this.SaveModulesButton.Click += new System.EventHandler(this.SaveModulesButton_Click);
            // 
            // TempControlTab
            // 
            this.TempControlTab.Controls.Add(this.TemperatureGauges);
            this.TempControlTab.Controls.Add(this.ConsoleTempsWarningLabel);
            this.TempControlTab.Controls.Add(this.ConsoleTempsLabel);
            this.TempControlTab.Controls.Add(this.FanSpeedTrack);
            this.TempControlTab.Controls.Add(this.FanSpeedLabel);
            this.TempControlTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("TempControlTab.ImageOptions.Image")));
            this.TempControlTab.Name = "TempControlTab";
            this.TempControlTab.Size = new System.Drawing.Size(1061, 555);
            this.TempControlTab.Text = "Temperature Control";
            // 
            // TemperatureGauges
            // 
            this.TemperatureGauges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemperatureGauges.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.CPUTempGauge,
            this.GPUTempGauge,
            this.RAMTempGauge,
            this.BoardTempGauge});
            this.TemperatureGauges.Location = new System.Drawing.Point(0, 84);
            this.TemperatureGauges.Name = "TemperatureGauges";
            this.TemperatureGauges.Size = new System.Drawing.Size(1061, 471);
            this.TemperatureGauges.TabIndex = 0;
            this.TemperatureGauges.TabStop = false;
            // 
            // CPUTempGauge
            // 
            this.CPUTempGauge.AutoSize = DevExpress.Utils.DefaultBoolean.True;
            this.CPUTempGauge.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.CPUTempGaugeBackground});
            this.CPUTempGauge.Bounds = new System.Drawing.Rectangle(9, 6, 257, 459);
            this.CPUTempGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.CPUTempGaugeHeaderLabel,
            this.CPUTempGaugeCelsiusLabel,
            this.CPUTempGaugeFahrenheitLabel});
            this.CPUTempGauge.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.CPUTempGaugeActualScale});
            this.CPUTempGauge.Name = "CPUTempGauge";
            this.CPUTempGauge.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.CPUTempGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.CPUTempGaugeCelsiusScale,
            this.CPUTempGaugeFahrenheitScale});
            // 
            // CPUTempGaugeBackground
            // 
            this.CPUTempGaugeBackground.LinearScale = this.CPUTempGaugeCelsiusScale;
            this.CPUTempGaugeBackground.Name = "bg1";
            this.CPUTempGaugeBackground.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.85F);
            this.CPUTempGaugeBackground.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style16;
            this.CPUTempGaugeBackground.ZOrder = 1000;
            // 
            // CPUTempGaugeCelsiusScale
            // 
            this.CPUTempGaugeCelsiusScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.CPUTempGaugeCelsiusScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.CPUTempGaugeCelsiusScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.CPUTempGaugeCelsiusScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.CPUTempGaugeCelsiusScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.CPUTempGaugeCelsiusScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.CPUTempGaugeCelsiusScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.CPUTempGaugeCelsiusScale.MajorTickCount = 6;
            this.CPUTempGaugeCelsiusScale.MajorTickmark.FormatString = "{0:F0}";
            this.CPUTempGaugeCelsiusScale.MajorTickmark.ShapeOffset = -19F;
            this.CPUTempGaugeCelsiusScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.CPUTempGaugeCelsiusScale.MajorTickmark.TextOffset = -34F;
            this.CPUTempGaugeCelsiusScale.MaxValue = 100F;
            this.CPUTempGaugeCelsiusScale.MinorTickCount = 3;
            this.CPUTempGaugeCelsiusScale.MinorTickmark.ShapeOffset = -17F;
            this.CPUTempGaugeCelsiusScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.CPUTempGaugeCelsiusScale.Name = "scale1";
            linearScaleRange33.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange33.EndThickness = 13F;
            linearScaleRange33.EndValue = 50F;
            linearScaleRange33.Name = "Range0";
            linearScaleRange33.ShapeOffset = -23F;
            linearScaleRange33.StartThickness = 13F;
            linearScaleRange33.StartValue = -1F;
            linearScaleRange34.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange34.EndThickness = 13F;
            linearScaleRange34.EndValue = 70F;
            linearScaleRange34.Name = "Range1";
            linearScaleRange34.ShapeOffset = -23F;
            linearScaleRange34.StartThickness = 13F;
            linearScaleRange34.StartValue = 50F;
            linearScaleRange35.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange35.EndThickness = 13F;
            linearScaleRange35.EndValue = 90F;
            linearScaleRange35.Name = "Range2";
            linearScaleRange35.ShapeOffset = -23F;
            linearScaleRange35.StartThickness = 13F;
            linearScaleRange35.StartValue = 70F;
            linearScaleRange36.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange36.EndThickness = 13F;
            linearScaleRange36.EndValue = 101F;
            linearScaleRange36.Name = "Range3";
            linearScaleRange36.ShapeOffset = -23F;
            linearScaleRange36.StartThickness = 13F;
            linearScaleRange36.StartValue = 90F;
            this.CPUTempGaugeCelsiusScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange33,
            linearScaleRange34,
            linearScaleRange35,
            linearScaleRange36});
            this.CPUTempGaugeCelsiusScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            // 
            // CPUTempGaugeHeaderLabel
            // 
            this.CPUTempGaugeHeaderLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.CPUTempGaugeHeaderLabel.Name = "CPUTempGauge_Label1";
            this.CPUTempGaugeHeaderLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(61.9F, 9.5F);
            this.CPUTempGaugeHeaderLabel.Text = "CPU";
            this.CPUTempGaugeHeaderLabel.ZOrder = -1001;
            // 
            // CPUTempGaugeCelsiusLabel
            // 
            this.CPUTempGaugeCelsiusLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.CPUTempGaugeCelsiusLabel.Name = "CPUTempGauge_Label2";
            this.CPUTempGaugeCelsiusLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(31F, 24.4F);
            this.CPUTempGaugeCelsiusLabel.Text = "ct";
            this.CPUTempGaugeCelsiusLabel.ZOrder = -1001;
            // 
            // CPUTempGaugeFahrenheitLabel
            // 
            this.CPUTempGaugeFahrenheitLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.CPUTempGaugeFahrenheitLabel.Name = "CPUTempGauge_Label3";
            this.CPUTempGaugeFahrenheitLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(96.2F, 24.4F);
            this.CPUTempGaugeFahrenheitLabel.Text = "ft";
            this.CPUTempGaugeFahrenheitLabel.ZOrder = -1001;
            // 
            // CPUTempGaugeActualScale
            // 
            this.CPUTempGaugeActualScale.LinearScale = this.CPUTempGaugeCelsiusScale;
            this.CPUTempGaugeActualScale.Name = "level1";
            this.CPUTempGaugeActualScale.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style16;
            this.CPUTempGaugeActualScale.Value = 0F;
            this.CPUTempGaugeActualScale.ZOrder = -50;
            // 
            // CPUTempGaugeFahrenheitScale
            // 
            this.CPUTempGaugeFahrenheitScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.CPUTempGaugeFahrenheitScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.CPUTempGaugeFahrenheitScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.CPUTempGaugeFahrenheitScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.CPUTempGaugeFahrenheitScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.CPUTempGaugeFahrenheitScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.CPUTempGaugeFahrenheitScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 38F);
            this.CPUTempGaugeFahrenheitScale.MajorTickCount = 6;
            this.CPUTempGaugeFahrenheitScale.MajorTickmark.FormatString = "{0:F0}";
            this.CPUTempGaugeFahrenheitScale.MajorTickmark.ShapeOffset = -23F;
            this.CPUTempGaugeFahrenheitScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.CPUTempGaugeFahrenheitScale.MajorTickmark.TextOffset = 1F;
            this.CPUTempGaugeFahrenheitScale.MaxValue = 212F;
            this.CPUTempGaugeFahrenheitScale.MinorTickCount = 3;
            this.CPUTempGaugeFahrenheitScale.MinorTickmark.ShapeOffset = -23F;
            this.CPUTempGaugeFahrenheitScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.CPUTempGaugeFahrenheitScale.Name = "scale1Copy0";
            linearScaleRange37.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange37.EndThickness = 13F;
            linearScaleRange37.EndValue = 106F;
            linearScaleRange37.Name = "Range0";
            linearScaleRange37.ShapeOffset = -23F;
            linearScaleRange37.StartThickness = 13F;
            linearScaleRange37.StartValue = -2F;
            linearScaleRange38.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange38.EndThickness = 13F;
            linearScaleRange38.EndValue = 149F;
            linearScaleRange38.Name = "Range1";
            linearScaleRange38.ShapeOffset = -23F;
            linearScaleRange38.StartThickness = 13F;
            linearScaleRange38.StartValue = 106F;
            linearScaleRange39.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange39.EndThickness = 13F;
            linearScaleRange39.EndValue = 191F;
            linearScaleRange39.Name = "Range2";
            linearScaleRange39.ShapeOffset = -23F;
            linearScaleRange39.StartThickness = 13F;
            linearScaleRange39.StartValue = 149F;
            linearScaleRange40.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange40.EndThickness = 13F;
            linearScaleRange40.EndValue = 214F;
            linearScaleRange40.Name = "Range3";
            linearScaleRange40.ShapeOffset = -23F;
            linearScaleRange40.StartThickness = 13F;
            linearScaleRange40.StartValue = 191F;
            this.CPUTempGaugeFahrenheitScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange37,
            linearScaleRange38,
            linearScaleRange39,
            linearScaleRange40});
            this.CPUTempGaugeFahrenheitScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 212F);
            // 
            // GPUTempGauge
            // 
            this.GPUTempGauge.AutoSize = DevExpress.Utils.DefaultBoolean.True;
            this.GPUTempGauge.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.GPUTempGaugeBackground});
            this.GPUTempGauge.Bounds = new System.Drawing.Rectangle(272, 6, 257, 459);
            this.GPUTempGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.GPUTempGaugeHeaderLabel,
            this.GPUTempGaugeCelsiusLabel,
            this.GPUTempGaugeFahrenheitLabel});
            this.GPUTempGauge.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.GPUTempGaugeActualScale});
            this.GPUTempGauge.Name = "GPUTempGauge";
            this.GPUTempGauge.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.GPUTempGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.GPUTempGaugeCelsiusScale,
            this.GPUTempGaugeFahrenheitScale});
            // 
            // GPUTempGaugeBackground
            // 
            this.GPUTempGaugeBackground.LinearScale = this.GPUTempGaugeCelsiusScale;
            this.GPUTempGaugeBackground.Name = "bg1";
            this.GPUTempGaugeBackground.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.85F);
            this.GPUTempGaugeBackground.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style16;
            this.GPUTempGaugeBackground.ZOrder = 1000;
            // 
            // GPUTempGaugeCelsiusScale
            // 
            this.GPUTempGaugeCelsiusScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.GPUTempGaugeCelsiusScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.GPUTempGaugeCelsiusScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.GPUTempGaugeCelsiusScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.GPUTempGaugeCelsiusScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.GPUTempGaugeCelsiusScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.GPUTempGaugeCelsiusScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.GPUTempGaugeCelsiusScale.MajorTickCount = 6;
            this.GPUTempGaugeCelsiusScale.MajorTickmark.FormatString = "{0:F0}";
            this.GPUTempGaugeCelsiusScale.MajorTickmark.ShapeOffset = -19F;
            this.GPUTempGaugeCelsiusScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.GPUTempGaugeCelsiusScale.MajorTickmark.TextOffset = -34F;
            this.GPUTempGaugeCelsiusScale.MaxValue = 100F;
            this.GPUTempGaugeCelsiusScale.MinorTickCount = 3;
            this.GPUTempGaugeCelsiusScale.MinorTickmark.ShapeOffset = -17F;
            this.GPUTempGaugeCelsiusScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.GPUTempGaugeCelsiusScale.Name = "scale1";
            linearScaleRange41.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange41.EndThickness = 13F;
            linearScaleRange41.EndValue = 50F;
            linearScaleRange41.Name = "Range0";
            linearScaleRange41.ShapeOffset = -23F;
            linearScaleRange41.StartThickness = 13F;
            linearScaleRange41.StartValue = -1F;
            linearScaleRange42.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange42.EndThickness = 13F;
            linearScaleRange42.EndValue = 70F;
            linearScaleRange42.Name = "Range1";
            linearScaleRange42.ShapeOffset = -23F;
            linearScaleRange42.StartThickness = 13F;
            linearScaleRange42.StartValue = 50F;
            linearScaleRange43.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange43.EndThickness = 13F;
            linearScaleRange43.EndValue = 90F;
            linearScaleRange43.Name = "Range2";
            linearScaleRange43.ShapeOffset = -23F;
            linearScaleRange43.StartThickness = 13F;
            linearScaleRange43.StartValue = 70F;
            linearScaleRange44.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange44.EndThickness = 13F;
            linearScaleRange44.EndValue = 101F;
            linearScaleRange44.Name = "Range3";
            linearScaleRange44.ShapeOffset = -23F;
            linearScaleRange44.StartThickness = 13F;
            linearScaleRange44.StartValue = 90F;
            this.GPUTempGaugeCelsiusScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange41,
            linearScaleRange42,
            linearScaleRange43,
            linearScaleRange44});
            this.GPUTempGaugeCelsiusScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            // 
            // GPUTempGaugeHeaderLabel
            // 
            this.GPUTempGaugeHeaderLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.GPUTempGaugeHeaderLabel.Name = "linearGauge1_Label1";
            this.GPUTempGaugeHeaderLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(61.9F, 9.5F);
            this.GPUTempGaugeHeaderLabel.Text = "GPU";
            this.GPUTempGaugeHeaderLabel.ZOrder = -1001;
            // 
            // GPUTempGaugeCelsiusLabel
            // 
            this.GPUTempGaugeCelsiusLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.GPUTempGaugeCelsiusLabel.Name = "linearGauge1_Label2";
            this.GPUTempGaugeCelsiusLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(31F, 24.4F);
            this.GPUTempGaugeCelsiusLabel.Text = "ct";
            this.GPUTempGaugeCelsiusLabel.ZOrder = -1001;
            // 
            // GPUTempGaugeFahrenheitLabel
            // 
            this.GPUTempGaugeFahrenheitLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.GPUTempGaugeFahrenheitLabel.Name = "linearGauge1_Label3";
            this.GPUTempGaugeFahrenheitLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(96.2F, 24.4F);
            this.GPUTempGaugeFahrenheitLabel.Text = "ft";
            this.GPUTempGaugeFahrenheitLabel.ZOrder = -1001;
            // 
            // GPUTempGaugeActualScale
            // 
            this.GPUTempGaugeActualScale.LinearScale = this.GPUTempGaugeCelsiusScale;
            this.GPUTempGaugeActualScale.Name = "level1";
            this.GPUTempGaugeActualScale.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style16;
            this.GPUTempGaugeActualScale.ZOrder = -50;
            // 
            // GPUTempGaugeFahrenheitScale
            // 
            this.GPUTempGaugeFahrenheitScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.GPUTempGaugeFahrenheitScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.GPUTempGaugeFahrenheitScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.GPUTempGaugeFahrenheitScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.GPUTempGaugeFahrenheitScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.GPUTempGaugeFahrenheitScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.GPUTempGaugeFahrenheitScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 38F);
            this.GPUTempGaugeFahrenheitScale.MajorTickCount = 6;
            this.GPUTempGaugeFahrenheitScale.MajorTickmark.FormatString = "{0:F0}";
            this.GPUTempGaugeFahrenheitScale.MajorTickmark.ShapeOffset = -23F;
            this.GPUTempGaugeFahrenheitScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.GPUTempGaugeFahrenheitScale.MajorTickmark.TextOffset = 1F;
            this.GPUTempGaugeFahrenheitScale.MaxValue = 212F;
            this.GPUTempGaugeFahrenheitScale.MinorTickCount = 3;
            this.GPUTempGaugeFahrenheitScale.MinorTickmark.ShapeOffset = -23F;
            this.GPUTempGaugeFahrenheitScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.GPUTempGaugeFahrenheitScale.Name = "scale1Copy0";
            linearScaleRange45.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange45.EndThickness = 13F;
            linearScaleRange45.EndValue = 106F;
            linearScaleRange45.Name = "Range0";
            linearScaleRange45.ShapeOffset = -23F;
            linearScaleRange45.StartThickness = 13F;
            linearScaleRange45.StartValue = -2F;
            linearScaleRange46.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange46.EndThickness = 13F;
            linearScaleRange46.EndValue = 149F;
            linearScaleRange46.Name = "Range1";
            linearScaleRange46.ShapeOffset = -23F;
            linearScaleRange46.StartThickness = 13F;
            linearScaleRange46.StartValue = 106F;
            linearScaleRange47.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange47.EndThickness = 13F;
            linearScaleRange47.EndValue = 191F;
            linearScaleRange47.Name = "Range2";
            linearScaleRange47.ShapeOffset = -23F;
            linearScaleRange47.StartThickness = 13F;
            linearScaleRange47.StartValue = 149F;
            linearScaleRange48.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange48.EndThickness = 13F;
            linearScaleRange48.EndValue = 214F;
            linearScaleRange48.Name = "Range3";
            linearScaleRange48.ShapeOffset = -23F;
            linearScaleRange48.StartThickness = 13F;
            linearScaleRange48.StartValue = 191F;
            this.GPUTempGaugeFahrenheitScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange45,
            linearScaleRange46,
            linearScaleRange47,
            linearScaleRange48});
            this.GPUTempGaugeFahrenheitScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 212F);
            // 
            // RAMTempGauge
            // 
            this.RAMTempGauge.AutoSize = DevExpress.Utils.DefaultBoolean.True;
            this.RAMTempGauge.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.RAMTempGaugeBackground});
            this.RAMTempGauge.Bounds = new System.Drawing.Rectangle(535, 6, 257, 459);
            this.RAMTempGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.RAMTempGaugeHeaderLabel,
            this.RAMTempGaugeCelsiusLabel,
            this.RAMTempGaugeFahrenheitLabel});
            this.RAMTempGauge.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.RAMTempGaugeActualScale});
            this.RAMTempGauge.Name = "RAMTempGauge";
            this.RAMTempGauge.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.RAMTempGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.RAMTempGaugeCelsiusScale,
            this.RAMTempGaugeFahrenheitScale});
            // 
            // RAMTempGaugeBackground
            // 
            this.RAMTempGaugeBackground.LinearScale = this.RAMTempGaugeCelsiusScale;
            this.RAMTempGaugeBackground.Name = "bg1";
            this.RAMTempGaugeBackground.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.85F);
            this.RAMTempGaugeBackground.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style16;
            this.RAMTempGaugeBackground.ZOrder = 1000;
            // 
            // RAMTempGaugeCelsiusScale
            // 
            this.RAMTempGaugeCelsiusScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.RAMTempGaugeCelsiusScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.RAMTempGaugeCelsiusScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.RAMTempGaugeCelsiusScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.RAMTempGaugeCelsiusScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RAMTempGaugeCelsiusScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.RAMTempGaugeCelsiusScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.RAMTempGaugeCelsiusScale.MajorTickCount = 6;
            this.RAMTempGaugeCelsiusScale.MajorTickmark.FormatString = "{0:F0}";
            this.RAMTempGaugeCelsiusScale.MajorTickmark.ShapeOffset = -19F;
            this.RAMTempGaugeCelsiusScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.RAMTempGaugeCelsiusScale.MajorTickmark.TextOffset = -34F;
            this.RAMTempGaugeCelsiusScale.MaxValue = 100F;
            this.RAMTempGaugeCelsiusScale.MinorTickCount = 3;
            this.RAMTempGaugeCelsiusScale.MinorTickmark.ShapeOffset = -17F;
            this.RAMTempGaugeCelsiusScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.RAMTempGaugeCelsiusScale.Name = "scale1";
            linearScaleRange49.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange49.EndThickness = 13F;
            linearScaleRange49.EndValue = 50F;
            linearScaleRange49.Name = "Range0";
            linearScaleRange49.ShapeOffset = -23F;
            linearScaleRange49.StartThickness = 13F;
            linearScaleRange49.StartValue = -1F;
            linearScaleRange50.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange50.EndThickness = 13F;
            linearScaleRange50.EndValue = 70F;
            linearScaleRange50.Name = "Range1";
            linearScaleRange50.ShapeOffset = -23F;
            linearScaleRange50.StartThickness = 13F;
            linearScaleRange50.StartValue = 50F;
            linearScaleRange51.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange51.EndThickness = 13F;
            linearScaleRange51.EndValue = 90F;
            linearScaleRange51.Name = "Range2";
            linearScaleRange51.ShapeOffset = -23F;
            linearScaleRange51.StartThickness = 13F;
            linearScaleRange51.StartValue = 70F;
            linearScaleRange52.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange52.EndThickness = 13F;
            linearScaleRange52.EndValue = 101F;
            linearScaleRange52.Name = "Range3";
            linearScaleRange52.ShapeOffset = -23F;
            linearScaleRange52.StartThickness = 13F;
            linearScaleRange52.StartValue = 90F;
            this.RAMTempGaugeCelsiusScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange49,
            linearScaleRange50,
            linearScaleRange51,
            linearScaleRange52});
            this.RAMTempGaugeCelsiusScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            // 
            // RAMTempGaugeHeaderLabel
            // 
            this.RAMTempGaugeHeaderLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.RAMTempGaugeHeaderLabel.Name = "linearGauge2_Label1";
            this.RAMTempGaugeHeaderLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(61.9F, 9.5F);
            this.RAMTempGaugeHeaderLabel.Text = "RAM";
            this.RAMTempGaugeHeaderLabel.ZOrder = -1001;
            // 
            // RAMTempGaugeCelsiusLabel
            // 
            this.RAMTempGaugeCelsiusLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.RAMTempGaugeCelsiusLabel.Name = "linearGauge2_Label2";
            this.RAMTempGaugeCelsiusLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(31F, 24.4F);
            this.RAMTempGaugeCelsiusLabel.Text = "ct";
            this.RAMTempGaugeCelsiusLabel.ZOrder = -1001;
            // 
            // RAMTempGaugeFahrenheitLabel
            // 
            this.RAMTempGaugeFahrenheitLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.RAMTempGaugeFahrenheitLabel.Name = "linearGauge2_Label3";
            this.RAMTempGaugeFahrenheitLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(96.2F, 24.4F);
            this.RAMTempGaugeFahrenheitLabel.Text = "ft";
            this.RAMTempGaugeFahrenheitLabel.ZOrder = -1001;
            // 
            // RAMTempGaugeActualScale
            // 
            this.RAMTempGaugeActualScale.LinearScale = this.RAMTempGaugeCelsiusScale;
            this.RAMTempGaugeActualScale.Name = "level1";
            this.RAMTempGaugeActualScale.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style16;
            this.RAMTempGaugeActualScale.ZOrder = -50;
            // 
            // RAMTempGaugeFahrenheitScale
            // 
            this.RAMTempGaugeFahrenheitScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.RAMTempGaugeFahrenheitScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.RAMTempGaugeFahrenheitScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.RAMTempGaugeFahrenheitScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.RAMTempGaugeFahrenheitScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.RAMTempGaugeFahrenheitScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.RAMTempGaugeFahrenheitScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 38F);
            this.RAMTempGaugeFahrenheitScale.MajorTickCount = 6;
            this.RAMTempGaugeFahrenheitScale.MajorTickmark.FormatString = "{0:F0}";
            this.RAMTempGaugeFahrenheitScale.MajorTickmark.ShapeOffset = -23F;
            this.RAMTempGaugeFahrenheitScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.RAMTempGaugeFahrenheitScale.MajorTickmark.TextOffset = 1F;
            this.RAMTempGaugeFahrenheitScale.MaxValue = 212F;
            this.RAMTempGaugeFahrenheitScale.MinorTickCount = 3;
            this.RAMTempGaugeFahrenheitScale.MinorTickmark.ShapeOffset = -23F;
            this.RAMTempGaugeFahrenheitScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.RAMTempGaugeFahrenheitScale.Name = "scale1Copy0";
            linearScaleRange53.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange53.EndThickness = 13F;
            linearScaleRange53.EndValue = 106F;
            linearScaleRange53.Name = "Range0";
            linearScaleRange53.ShapeOffset = -23F;
            linearScaleRange53.StartThickness = 13F;
            linearScaleRange53.StartValue = -2F;
            linearScaleRange54.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange54.EndThickness = 13F;
            linearScaleRange54.EndValue = 149F;
            linearScaleRange54.Name = "Range1";
            linearScaleRange54.ShapeOffset = -23F;
            linearScaleRange54.StartThickness = 13F;
            linearScaleRange54.StartValue = 106F;
            linearScaleRange55.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange55.EndThickness = 13F;
            linearScaleRange55.EndValue = 191F;
            linearScaleRange55.Name = "Range2";
            linearScaleRange55.ShapeOffset = -23F;
            linearScaleRange55.StartThickness = 13F;
            linearScaleRange55.StartValue = 149F;
            linearScaleRange56.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange56.EndThickness = 13F;
            linearScaleRange56.EndValue = 214F;
            linearScaleRange56.Name = "Range3";
            linearScaleRange56.ShapeOffset = -23F;
            linearScaleRange56.StartThickness = 13F;
            linearScaleRange56.StartValue = 191F;
            this.RAMTempGaugeFahrenheitScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange53,
            linearScaleRange54,
            linearScaleRange55,
            linearScaleRange56});
            this.RAMTempGaugeFahrenheitScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 212F);
            // 
            // BoardTempGauge
            // 
            this.BoardTempGauge.AutoSize = DevExpress.Utils.DefaultBoolean.True;
            this.BoardTempGauge.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleBackgroundLayerComponent[] {
            this.BoardTempGaugeBackground});
            this.BoardTempGauge.Bounds = new System.Drawing.Rectangle(798, 6, 257, 459);
            this.BoardTempGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.BoardTempGaugeHeaderLabel,
            this.BoardTempGaugeCelsiusLabel,
            this.BoardTempGaugeFahrenheitLabel});
            this.BoardTempGauge.Levels.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleLevelComponent[] {
            this.BoardTempGaugeActualScale});
            this.BoardTempGauge.Name = "BoardTempGauge";
            this.BoardTempGauge.OptionsToolTip.TooltipTitleFormat = "{0}";
            this.BoardTempGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Linear.LinearScaleComponent[] {
            this.BoardTempGaugeCelsiusScale,
            this.BoardTempGaugeFahrenheitScale});
            // 
            // BoardTempGaugeBackground
            // 
            this.BoardTempGaugeBackground.LinearScale = this.BoardTempGaugeCelsiusScale;
            this.BoardTempGaugeBackground.Name = "bg1";
            this.BoardTempGaugeBackground.ScaleStartPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.85F);
            this.BoardTempGaugeBackground.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.Linear_Style16;
            this.BoardTempGaugeBackground.ZOrder = 1000;
            // 
            // BoardTempGaugeCelsiusScale
            // 
            this.BoardTempGaugeCelsiusScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.BoardTempGaugeCelsiusScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.BoardTempGaugeCelsiusScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.BoardTempGaugeCelsiusScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.BoardTempGaugeCelsiusScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.BoardTempGaugeCelsiusScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.BoardTempGaugeCelsiusScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 38F);
            this.BoardTempGaugeCelsiusScale.MajorTickCount = 6;
            this.BoardTempGaugeCelsiusScale.MajorTickmark.FormatString = "{0:F0}";
            this.BoardTempGaugeCelsiusScale.MajorTickmark.ShapeOffset = -19F;
            this.BoardTempGaugeCelsiusScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.BoardTempGaugeCelsiusScale.MajorTickmark.TextOffset = -34F;
            this.BoardTempGaugeCelsiusScale.MaxValue = 100F;
            this.BoardTempGaugeCelsiusScale.MinorTickCount = 3;
            this.BoardTempGaugeCelsiusScale.MinorTickmark.ShapeOffset = -17F;
            this.BoardTempGaugeCelsiusScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.BoardTempGaugeCelsiusScale.Name = "scale1";
            linearScaleRange57.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange57.EndThickness = 13F;
            linearScaleRange57.EndValue = 50F;
            linearScaleRange57.Name = "Range0";
            linearScaleRange57.ShapeOffset = -23F;
            linearScaleRange57.StartThickness = 13F;
            linearScaleRange57.StartValue = -1F;
            linearScaleRange58.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange58.EndThickness = 13F;
            linearScaleRange58.EndValue = 70F;
            linearScaleRange58.Name = "Range1";
            linearScaleRange58.ShapeOffset = -23F;
            linearScaleRange58.StartThickness = 13F;
            linearScaleRange58.StartValue = 50F;
            linearScaleRange59.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange59.EndThickness = 13F;
            linearScaleRange59.EndValue = 90F;
            linearScaleRange59.Name = "Range2";
            linearScaleRange59.ShapeOffset = -23F;
            linearScaleRange59.StartThickness = 13F;
            linearScaleRange59.StartValue = 70F;
            linearScaleRange60.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange60.EndThickness = 13F;
            linearScaleRange60.EndValue = 101F;
            linearScaleRange60.Name = "Range3";
            linearScaleRange60.ShapeOffset = -23F;
            linearScaleRange60.StartThickness = 13F;
            linearScaleRange60.StartValue = 90F;
            this.BoardTempGaugeCelsiusScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange57,
            linearScaleRange58,
            linearScaleRange59,
            linearScaleRange60});
            this.BoardTempGaugeCelsiusScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(62.5F, 212F);
            // 
            // BoardTempGaugeHeaderLabel
            // 
            this.BoardTempGaugeHeaderLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.BoardTempGaugeHeaderLabel.Name = "linearGauge3_Label1";
            this.BoardTempGaugeHeaderLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(61.9F, 9.5F);
            this.BoardTempGaugeHeaderLabel.Text = "Board";
            this.BoardTempGaugeHeaderLabel.ZOrder = -1001;
            // 
            // BoardTempGaugeCelsiusLabel
            // 
            this.BoardTempGaugeCelsiusLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.BoardTempGaugeCelsiusLabel.Name = "linearGauge3_Label2";
            this.BoardTempGaugeCelsiusLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(31F, 24.4F);
            this.BoardTempGaugeCelsiusLabel.Text = "ct";
            this.BoardTempGaugeCelsiusLabel.ZOrder = -1001;
            // 
            // BoardTempGaugeFahrenheitLabel
            // 
            this.BoardTempGaugeFahrenheitLabel.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.BoardTempGaugeFahrenheitLabel.Name = "linearGauge3_Label3";
            this.BoardTempGaugeFahrenheitLabel.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(96.2F, 24.4F);
            this.BoardTempGaugeFahrenheitLabel.Text = "ft";
            this.BoardTempGaugeFahrenheitLabel.ZOrder = -1001;
            // 
            // BoardTempGaugeActualScale
            // 
            this.BoardTempGaugeActualScale.LinearScale = this.BoardTempGaugeCelsiusScale;
            this.BoardTempGaugeActualScale.Name = "level1";
            this.BoardTempGaugeActualScale.ShapeType = DevExpress.XtraGauges.Core.Model.LevelShapeSetType.Style16;
            this.BoardTempGaugeActualScale.ZOrder = -50;
            // 
            // BoardTempGaugeFahrenheitScale
            // 
            this.BoardTempGaugeFahrenheitScale.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.BoardTempGaugeFahrenheitScale.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Black");
            this.BoardTempGaugeFahrenheitScale.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.BoardTempGaugeFahrenheitScale.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.BoardTempGaugeFahrenheitScale.AppearanceTickmarkText.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.BoardTempGaugeFahrenheitScale.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#484E5A");
            this.BoardTempGaugeFahrenheitScale.EndPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 38F);
            this.BoardTempGaugeFahrenheitScale.MajorTickCount = 6;
            this.BoardTempGaugeFahrenheitScale.MajorTickmark.FormatString = "{0:F0}";
            this.BoardTempGaugeFahrenheitScale.MajorTickmark.ShapeOffset = -23F;
            this.BoardTempGaugeFahrenheitScale.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style24_1;
            this.BoardTempGaugeFahrenheitScale.MajorTickmark.TextOffset = 1F;
            this.BoardTempGaugeFahrenheitScale.MaxValue = 212F;
            this.BoardTempGaugeFahrenheitScale.MinorTickCount = 3;
            this.BoardTempGaugeFahrenheitScale.MinorTickmark.ShapeOffset = -23F;
            this.BoardTempGaugeFahrenheitScale.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Linear_Style16_2;
            this.BoardTempGaugeFahrenheitScale.Name = "scale1Copy0";
            linearScaleRange61.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:YellowGreen");
            linearScaleRange61.EndThickness = 13F;
            linearScaleRange61.EndValue = 106F;
            linearScaleRange61.Name = "Range0";
            linearScaleRange61.ShapeOffset = -23F;
            linearScaleRange61.StartThickness = 13F;
            linearScaleRange61.StartValue = -2F;
            linearScaleRange62.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            linearScaleRange62.EndThickness = 13F;
            linearScaleRange62.EndValue = 149F;
            linearScaleRange62.Name = "Range1";
            linearScaleRange62.ShapeOffset = -23F;
            linearScaleRange62.StartThickness = 13F;
            linearScaleRange62.StartValue = 106F;
            linearScaleRange63.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:DarkOrange");
            linearScaleRange63.EndThickness = 13F;
            linearScaleRange63.EndValue = 191F;
            linearScaleRange63.Name = "Range2";
            linearScaleRange63.ShapeOffset = -23F;
            linearScaleRange63.StartThickness = 13F;
            linearScaleRange63.StartValue = 149F;
            linearScaleRange64.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Red");
            linearScaleRange64.EndThickness = 13F;
            linearScaleRange64.EndValue = 214F;
            linearScaleRange64.Name = "Range3";
            linearScaleRange64.ShapeOffset = -23F;
            linearScaleRange64.StartThickness = 13F;
            linearScaleRange64.StartValue = 191F;
            this.BoardTempGaugeFahrenheitScale.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            linearScaleRange61,
            linearScaleRange62,
            linearScaleRange63,
            linearScaleRange64});
            this.BoardTempGaugeFahrenheitScale.StartPoint = new DevExpress.XtraGauges.Core.Base.PointF2D(95.5F, 212F);
            // 
            // ConsoleTempsWarningLabel
            // 
            this.ConsoleTempsWarningLabel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConsoleTempsWarningLabel.Appearance.ForeColor = System.Drawing.Color.Red;
            this.ConsoleTempsWarningLabel.Appearance.Options.UseFont = true;
            this.ConsoleTempsWarningLabel.Appearance.Options.UseForeColor = true;
            this.ConsoleTempsWarningLabel.AutoEllipsis = true;
            this.ConsoleTempsWarningLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.ConsoleTempsWarningLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsoleTempsWarningLabel.Location = new System.Drawing.Point(0, 71);
            this.ConsoleTempsWarningLabel.Name = "ConsoleTempsWarningLabel";
            this.ConsoleTempsWarningLabel.Size = new System.Drawing.Size(1061, 13);
            this.ConsoleTempsWarningLabel.TabIndex = 3;
            this.ConsoleTempsWarningLabel.Text = "WARNING: Temperatures in the orange zone or higher for extended periods of time m" +
    "ay cause damage to your console!";
            // 
            // ConsoleTempsLabel
            // 
            this.ConsoleTempsLabel.AutoEllipsis = true;
            this.ConsoleTempsLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.ConsoleTempsLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsoleTempsLabel.Location = new System.Drawing.Point(0, 58);
            this.ConsoleTempsLabel.Name = "ConsoleTempsLabel";
            this.ConsoleTempsLabel.Size = new System.Drawing.Size(1061, 13);
            this.ConsoleTempsLabel.TabIndex = 0;
            this.ConsoleTempsLabel.Text = "Console component temperatures are updated every 2 seconds. The measurement on th" +
    "e left is celsius and the other is fahrenheit.";
            // 
            // FanSpeedTrack
            // 
            this.FanSpeedTrack.Dock = System.Windows.Forms.DockStyle.Top;
            this.FanSpeedTrack.EditValue = 45;
            this.FanSpeedTrack.Location = new System.Drawing.Point(0, 13);
            this.FanSpeedTrack.MenuManager = this.BarManager;
            this.FanSpeedTrack.Name = "FanSpeedTrack";
            this.FanSpeedTrack.Properties.Maximum = 100;
            this.FanSpeedTrack.Properties.Minimum = 45;
            this.FanSpeedTrack.Properties.ShowValueToolTip = true;
            this.FanSpeedTrack.Properties.SmallChange = 5;
            this.FanSpeedTrack.Properties.TickFrequency = 5;
            this.FanSpeedTrack.Properties.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.FanSpeedTrack.Size = new System.Drawing.Size(1061, 45);
            this.FanSpeedTrack.TabIndex = 0;
            this.FanSpeedTrack.Value = 45;
            this.FanSpeedTrack.EditValueChanged += new System.EventHandler(this.FanSpeedTrack_EditValueChanged);
            // 
            // FanSpeedLabel
            // 
            this.FanSpeedLabel.AutoEllipsis = true;
            this.FanSpeedLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.FanSpeedLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FanSpeedLabel.Location = new System.Drawing.Point(0, 0);
            this.FanSpeedLabel.Name = "FanSpeedLabel";
            this.FanSpeedLabel.Size = new System.Drawing.Size(1061, 13);
            this.FanSpeedLabel.TabIndex = 2;
            this.FanSpeedLabel.Text = "Fan speed:";
            // 
            // NeighborhoodDrivesTab
            // 
            this.NeighborhoodDrivesTab.Controls.Add(this.NeighborhoodDrivesScroller);
            this.NeighborhoodDrivesTab.Controls.Add(this.AddNeighborhoodDriveButton);
            this.NeighborhoodDrivesTab.Controls.Add(this.SaveDrivesButton);
            this.NeighborhoodDrivesTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("NeighborhoodDrivesTab.ImageOptions.Image")));
            this.NeighborhoodDrivesTab.Name = "NeighborhoodDrivesTab";
            this.NeighborhoodDrivesTab.Size = new System.Drawing.Size(1061, 555);
            this.NeighborhoodDrivesTab.Text = "Neighborhood Drives";
            // 
            // NeighborhoodDrivesScroller
            // 
            this.NeighborhoodDrivesScroller.Controls.Add(this.NeighborhoodDrivesStatusLabel);
            this.NeighborhoodDrivesScroller.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NeighborhoodDrivesScroller.FireScrollEventOnMouseWheel = true;
            this.NeighborhoodDrivesScroller.Location = new System.Drawing.Point(0, 27);
            this.NeighborhoodDrivesScroller.Name = "NeighborhoodDrivesScroller";
            this.NeighborhoodDrivesScroller.Size = new System.Drawing.Size(1061, 501);
            this.NeighborhoodDrivesScroller.TabIndex = 4;
            // 
            // NeighborhoodDrivesStatusLabel
            // 
            this.NeighborhoodDrivesStatusLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.NeighborhoodDrivesStatusLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.NeighborhoodDrivesStatusLabel.Location = new System.Drawing.Point(0, 0);
            this.NeighborhoodDrivesStatusLabel.Name = "NeighborhoodDrivesStatusLabel";
            this.NeighborhoodDrivesStatusLabel.Size = new System.Drawing.Size(1061, 13);
            this.NeighborhoodDrivesStatusLabel.TabIndex = 1;
            this.NeighborhoodDrivesStatusLabel.Text = "No custom drives found. Add one using the button above.";
            // 
            // AddNeighborhoodDriveButton
            // 
            this.AddNeighborhoodDriveButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddNeighborhoodDriveButton.Location = new System.Drawing.Point(0, 0);
            this.AddNeighborhoodDriveButton.Name = "AddNeighborhoodDriveButton";
            this.AddNeighborhoodDriveButton.Size = new System.Drawing.Size(1061, 27);
            this.AddNeighborhoodDriveButton.TabIndex = 3;
            this.AddNeighborhoodDriveButton.Text = "Add Drive";
            this.AddNeighborhoodDriveButton.Click += new System.EventHandler(this.AddNeighborhoodDriveButton_Click);
            // 
            // SaveDrivesButton
            // 
            this.SaveDrivesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveDrivesButton.Location = new System.Drawing.Point(0, 528);
            this.SaveDrivesButton.Name = "SaveDrivesButton";
            this.SaveDrivesButton.Size = new System.Drawing.Size(1061, 27);
            this.SaveDrivesButton.TabIndex = 5;
            this.SaveDrivesButton.Text = "Save Drive Configuration";
            this.SaveDrivesButton.Click += new System.EventHandler(this.SaveDrivesButton_Click);
            // 
            // DebugPrintingTab
            // 
            this.DebugPrintingTab.Controls.Add(this.DebugPrintingMemo);
            this.DebugPrintingTab.Controls.Add(this.DebugPrintingClearButton);
            this.DebugPrintingTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DebugPrintingTab.ImageOptions.Image")));
            this.DebugPrintingTab.Name = "DebugPrintingTab";
            this.DebugPrintingTab.Size = new System.Drawing.Size(1061, 555);
            this.DebugPrintingTab.Text = "Debug Printing";
            // 
            // DebugPrintingMemo
            // 
            this.DebugPrintingMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DebugPrintingMemo.Location = new System.Drawing.Point(0, 0);
            this.DebugPrintingMemo.MenuManager = this.BarManager;
            this.DebugPrintingMemo.Name = "DebugPrintingMemo";
            this.DebugPrintingMemo.Properties.ReadOnly = true;
            this.DebugPrintingMemo.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DebugPrintingMemo.Properties.WordWrap = false;
            this.DebugPrintingMemo.Size = new System.Drawing.Size(1061, 528);
            this.DebugPrintingMemo.TabIndex = 0;
            // 
            // DebugPrintingClearButton
            // 
            this.DebugPrintingClearButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DebugPrintingClearButton.Location = new System.Drawing.Point(0, 528);
            this.DebugPrintingClearButton.Name = "DebugPrintingClearButton";
            this.DebugPrintingClearButton.Size = new System.Drawing.Size(1061, 27);
            this.DebugPrintingClearButton.TabIndex = 1;
            this.DebugPrintingClearButton.Text = "Clear";
            this.DebugPrintingClearButton.Click += new System.EventHandler(this.DebugPrintingClearButton_Click);
            // 
            // SettingsTab
            // 
            this.SettingsTab.Controls.Add(this.XamFeaturesGroup);
            this.SettingsTab.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("SettingsTab.ImageOptions.Image")));
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Size = new System.Drawing.Size(1061, 555);
            this.SettingsTab.Text = "Settings";
            // 
            // XamFeaturesGroup
            // 
            this.XamFeaturesGroup.Controls.Add(this.XamFeatureChecks);
            this.XamFeaturesGroup.Controls.Add(this.SaveXamFeaturesButton);
            this.XamFeaturesGroup.Controls.Add(this.XamFeaturesInfoLabel);
            this.XamFeaturesGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.XamFeaturesGroup.Location = new System.Drawing.Point(0, 0);
            this.XamFeaturesGroup.Name = "XamFeaturesGroup";
            this.XamFeaturesGroup.Size = new System.Drawing.Size(1061, 174);
            this.XamFeaturesGroup.TabIndex = 0;
            this.XamFeaturesGroup.Text = "Xam Features";
            // 
            // XamFeatureChecks
            // 
            this.XamFeatureChecks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XamFeatureChecks.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.XamFeatureChecks.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(1, "Preloaded HUD"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(2, "LIVE Messenger"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(3, "XMP"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(4, "Xam Community"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(5, "XIME"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(6, "XStudio"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(7, "Wireless Wave A"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(33, "XDK Heap"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem("34", "PIX Stream"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(35, "ETX Boost"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(36, "XS Logs"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(38, "Test Xex"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(39, "Xam UI Automation")});
            this.XamFeatureChecks.Location = new System.Drawing.Point(2, 33);
            this.XamFeatureChecks.Name = "XamFeatureChecks";
            this.XamFeatureChecks.Size = new System.Drawing.Size(1057, 112);
            this.XamFeatureChecks.TabIndex = 2;
            // 
            // SaveXamFeaturesButton
            // 
            this.SaveXamFeaturesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveXamFeaturesButton.Location = new System.Drawing.Point(2, 145);
            this.SaveXamFeaturesButton.Name = "SaveXamFeaturesButton";
            this.SaveXamFeaturesButton.Size = new System.Drawing.Size(1057, 27);
            this.SaveXamFeaturesButton.TabIndex = 3;
            this.SaveXamFeaturesButton.Text = "Save Changes";
            this.SaveXamFeaturesButton.Click += new System.EventHandler(this.SaveXamFeaturesButton_Click);
            // 
            // XamFeaturesInfoLabel
            // 
            this.XamFeaturesInfoLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.XamFeaturesInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.XamFeaturesInfoLabel.Location = new System.Drawing.Point(2, 20);
            this.XamFeaturesInfoLabel.Name = "XamFeaturesInfoLabel";
            this.XamFeaturesInfoLabel.Size = new System.Drawing.Size(1057, 13);
            this.XamFeaturesInfoLabel.TabIndex = 1;
            this.XamFeaturesInfoLabel.Text = "Disabling unnecessary xam features can free memory, reduce errors, and increase p" +
    "erformance.";
            // 
            // ModuleRightClickPopup
            // 
            this.ModuleRightClickPopup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ModuleCopyValueItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ModuleViewInfoItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ModuleDumpSubMenu)});
            this.ModuleRightClickPopup.Manager = this.BarManager;
            this.ModuleRightClickPopup.Name = "ModuleRightClickPopup";
            this.ModuleRightClickPopup.ShowCaption = true;
            // 
            // FriendRightClickMenu
            // 
            this.FriendRightClickMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.AcceptDeclineFRItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.MessageFriendItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.InviteFriendItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.JoinPartyItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ShowGamercardItem, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ViewGamertagItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ShowFoFItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.CopyOnlineXUIDItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.RemoveFriendItem, true)});
            this.FriendRightClickMenu.Manager = this.BarManager;
            this.FriendRightClickMenu.Name = "FriendRightClickMenu";
            this.FriendRightClickMenu.ShowCaption = true;
            // 
            // CurrentTitleRightClickMenu
            // 
            this.CurrentTitleRightClickMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.CurrentTileVisitItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ViewAllTitleInfoItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.TitleUpdateSearchItem)});
            this.CurrentTitleRightClickMenu.Manager = this.BarManager;
            this.CurrentTitleRightClickMenu.Name = "CurrentTitleRightClickMenu";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 611);
            this.Controls.Add(this.MainTabs);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "DevTool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainTabs)).EndInit();
            this.MainTabs.ResumeLayout(false);
            this.MemoryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModuleTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SkinEditRepo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IMG16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTitleEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemLengthText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemAddressText.Properties)).EndInit();
            this.PatchingTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PatchText.Properties)).EndInit();
            this.XBLCenterTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XBLCenterFunctionsGroup)).EndInit();
            this.XBLCenterFunctionsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FriendFunctionsGroup)).EndInit();
            this.FriendFunctionsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BlockFriendCheck.Properties)).EndInit();
            this.KeyboardHookingTab.ResumeLayout(false);
            this.KeyboardHookingScroller.ResumeLayout(false);
            this.CommandsTab.ResumeLayout(false);
            this.ModuleLauncherTab.ResumeLayout(false);
            this.TempControlTab.ResumeLayout(false);
            this.TempControlTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeCelsiusScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeHeaderLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeCelsiusLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeFahrenheitLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeActualScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CPUTempGaugeFahrenheitScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeCelsiusScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeHeaderLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeCelsiusLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeFahrenheitLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeActualScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GPUTempGaugeFahrenheitScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeCelsiusScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeHeaderLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeCelsiusLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeFahrenheitLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeActualScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMTempGaugeFahrenheitScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeCelsiusScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeHeaderLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeCelsiusLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeFahrenheitLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeActualScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardTempGaugeFahrenheitScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FanSpeedTrack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FanSpeedTrack)).EndInit();
            this.NeighborhoodDrivesTab.ResumeLayout(false);
            this.NeighborhoodDrivesScroller.ResumeLayout(false);
            this.DebugPrintingTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DebugPrintingMemo.Properties)).EndInit();
            this.SettingsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XamFeaturesGroup)).EndInit();
            this.XamFeaturesGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XamFeatureChecks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleRightClickPopup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FriendRightClickMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentTitleRightClickMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private XtraTabControl MainTabs;
        private XtraTabPage MemoryTab;
        private BarManager BarManager;
        private Bar StatusBar;
        private BarStaticItem StatusText;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private XtraTabPage PatchingTab;
        private MemoEdit PatchText;
        private SimpleButton PatchCompileWriteButton;
        private SimpleButton MemGoButton;
        private TextEdit MemLengthText;
        private TextEdit MemAddressText;
        private TreeList ModuleTree;
        private TreeListColumn ModuleTreeNameColumn;
        private TreeListColumn ModuleTreeAddressColumn;
        private TreeListColumn ModuleTreeSizeColumn;
        private TreeListColumn ModuleTreeOccupiedMemoryColumn;
        private ToolTipController ToolTipController;
        private BarButtonItem ModuleCopyValueItem;
        private PopupMenu ModuleRightClickPopup;
        private ImageCollection IMG16;
        private BarButtonItem ModuleDumpItem;
        private BarButtonItem ModuleViewInfoItem;
        private BarEditItem SkinEdit;
        private RepositoryItemComboBox SkinEditRepo;
        private ButtonEdit CurrentTitleEdit;
        private LabelControl CurrentTitleLabel;
        private XtraTabPage KeyboardHookingTab;
        private XtraScrollableControl KeyboardHookingScroller;
        private SimpleButton AddKeyboardHookButton;
        private SimpleButton SaveKeyboardHooksButton;
        private LabelControl HooksStatusLabel;
        private BarButtonItem ForceReconnectButton;
        private XtraTabPage XBLCenterTab;
        private XtraTabPage CommandsTab;
        private SimpleButton XDKLauncherButton;
        private SimpleButton ScreenShotButton;
        private SimpleButton FreezeButton;
        private SimpleButton RebootButton;
        private SimpleButton UnfreezeButton;
        private XtraTabPage ModuleLauncherTab;
        private XtraScrollableControl ModuleLauncherScroller;
        private LabelControl ModuleLauncherStatusLabel;
        private XtraTabPage TempControlTab;
        private TrackBarControl FanSpeedTrack;
        private GaugeControl TemperatureGauges;
        private LinearGauge CPUTempGauge;
        private LinearScaleBackgroundLayerComponent CPUTempGaugeBackground;
        private LinearScaleComponent CPUTempGaugeCelsiusScale;
        private LinearScaleLevelComponent CPUTempGaugeActualScale;
        private LinearScaleComponent CPUTempGaugeFahrenheitScale;
        private LinearGauge GPUTempGauge;
        private LinearScaleBackgroundLayerComponent GPUTempGaugeBackground;
        private LinearScaleComponent GPUTempGaugeCelsiusScale;
        private LinearScaleLevelComponent GPUTempGaugeActualScale;
        private LinearScaleComponent GPUTempGaugeFahrenheitScale;
        private LinearGauge RAMTempGauge;
        private LinearScaleBackgroundLayerComponent RAMTempGaugeBackground;
        private LinearScaleComponent RAMTempGaugeCelsiusScale;
        private LinearScaleLevelComponent RAMTempGaugeActualScale;
        private LinearScaleComponent RAMTempGaugeFahrenheitScale;
        private LinearGauge BoardTempGauge;
        private LinearScaleBackgroundLayerComponent BoardTempGaugeBackground;
        private LinearScaleComponent BoardTempGaugeCelsiusScale;
        private LinearScaleLevelComponent BoardTempGaugeActualScale;
        private LinearScaleComponent BoardTempGaugeFahrenheitScale;
        private LabelControl ConsoleTempsLabel;
        private LabelControl FanSpeedLabel;
        private LabelComponent CPUTempGaugeHeaderLabel;
        private LabelComponent GPUTempGaugeHeaderLabel;
        private LabelComponent RAMTempGaugeHeaderLabel;
        private LabelComponent BoardTempGaugeHeaderLabel;
        private LabelComponent CPUTempGaugeCelsiusLabel;
        private LabelComponent CPUTempGaugeFahrenheitLabel;
        private LabelComponent GPUTempGaugeCelsiusLabel;
        private LabelComponent GPUTempGaugeFahrenheitLabel;
        private LabelComponent RAMTempGaugeCelsiusLabel;
        private LabelComponent RAMTempGaugeFahrenheitLabel;
        private LabelComponent BoardTempGaugeCelsiusLabel;
        private LabelComponent BoardTempGaugeFahrenheitLabel;
        private BarButtonItem AboutItem;
        private SimpleButton AddModuleShortcutButton;
        private SimpleButton SaveModulesButton;
        private TileControl FriendsTileControl;
        private TileGroup FriendsTileGroup;
        private GroupControl XBLCenterFunctionsGroup;
        private GroupControl FriendFunctionsGroup;
        private SimpleButton SendFRButton;
        private SimpleButton MessageAllFriendsButton;
        private SimpleButton MessageSelectedFriendsButton;
        private SimpleButton InviteAllFriendsButton;
        private SimpleButton InviteSelectedFriendsButton;
        private SimpleButton RemoveAllFriendsButton;
        private SimpleButton RemoveSelectedFriendsButton;
        private SimpleButton DeclineAllFRsButton;
        private SimpleButton DeclineSelectedFRsButton;
        private SimpleButton AcceptAllFRsButton;
        private SimpleButton AcceptSelectedFRsButton;
        private CheckEdit BlockFriendCheck;
        private BarButtonItem JoinPartyItem;
        private PopupMenu FriendRightClickMenu;
        private BarButtonItem AcceptDeclineFRItem;
        private BarButtonItem RemoveFriendItem;
        private BarButtonItem MessageFriendItem;
        private BarButtonItem InviteFriendItem;
        private SimpleButton LeavePartyButton;
        private SimpleButton JoinSpecificPartyButton;
        private BarButtonItem ShowGamercardItem;
        private SimpleButton ShowPlayersUIButton;
        private SimpleButton ShowMessagesUIButton;
        private SimpleButton ShowFriendsUIButton;
        private SimpleButton ShowPartyUIButton;
        private LabelControl ConsoleTempsWarningLabel;
        private BarSubItem ModuleDumpSubMenu;
        private BarButtonItem ModuleDumpEntireItem;
        private BarSubItem ModuleDumpSpecificSectionSubMenu;
        private SimpleButton SendTextCommandButton;
        private BarButtonItem ViewGamertagItem;
        private SimpleButton SignOutButton;
        private BarButtonItem CopyOnlineXUIDItem;
        private BarButtonItem ShowFoFItem;
        private PopupMenu CurrentTitleRightClickMenu;
        private BarButtonItem CurrentTileVisitItem;
        private XtraTabPage NeighborhoodDrivesTab;
        private XtraScrollableControl NeighborhoodDrivesScroller;
        private SimpleButton AddNeighborhoodDriveButton;
        private SimpleButton SaveDrivesButton;
        private SimpleButton XUIDGTConversionsButton;
        private SimpleButton DashboardButton;
        private BarButtonItem ViewAllTitleInfoItem;
        private BarButtonItem TitleUpdateSearchItem;
        private LabelControl NeighborhoodDrivesStatusLabel;
        private XtraTabPage DebugPrintingTab;
        private MemoEdit DebugPrintingMemo;
        private SimpleButton DebugPrintingClearButton;
        private XtraTabPage SettingsTab;
        private GroupControl XamFeaturesGroup;
        private LabelControl XamFeaturesInfoLabel;
        private CheckedListBoxControl XamFeatureChecks;
        private SimpleButton SaveXamFeaturesButton;
        private SplashScreenManager SplashScreenManager;
    }
}