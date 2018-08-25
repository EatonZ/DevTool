// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevTool.Classes;
using DevTool.Properties;
using Microsoft.Test.Xbox.Profiles;
using DevExpress.XtraBars;
using XDevkit;
using DevExpress.Utils.Taskbar.Core;

namespace DevTool.Forms
{
    public sealed partial class SigninForm : XtraForm
    {
        #region Fields, Properties, and Constructors

        private readonly MainForm mainForm;
        private readonly ConsoleProfilesManager profileManager;

        public ConsoleProfile SignedInProfile { get; private set; }

        public SigninForm(MainForm MainForm, IEnumerable<ConsoleProfile> LocalProfiles, ConsoleProfilesManager Manager)
        {
            InitializeComponent();
            mainForm = MainForm;
            profileManager = Manager;
            SigninTileControl.Text = "Profiles on " + profileManager.Console.Name;
            SigninTileControl.BeginUpdate();
            foreach (var profile in LocalProfiles)
            {
                var xai = XDKUtilities.XamProfileFindAccount((XboxConsole)profile.Console, profile.OfflineXuid.value);
                if (!profile.IsLiveProfile) continue;
                var ti = new TileItem { Tag = new TileTag { Profile = profile, AccountInfo = xai }, Name = profile.Gamertag + "Tile", BackgroundImage = profile.Tier == SubscriptionTier.Silver ? Resources.Signin_Slot_Silver : Resources.Signin_Slot_Gold, BackgroundImageScaleMode = TileItemImageScaleMode.Stretch, Text = string.Format("<Color=\"black\"><b>{0}</b></Color>", profile.Gamertag) };
                ti.RightItemClick += ProfileTile_RightItemClick;
                ti.ItemClick += ProfileTile_ItemClick;
                ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 15), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"gray\"><b>{0}</b></Color>", profile.Tier) });
                ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 30), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"gray\"><b>{0}</b></Color>", XtraFunctions.ValueToHex(profile.OfflineXuid.value).Remove(0, 2).PadLeft(16, '0')) });
                ti.Elements.Add(new TileItemElement { TextLocation = new Point(0, 45), TextAlignment = TileItemContentAlignment.Manual, Text = string.Format("<Color=\"gray\"><b>{0}</b></Color>", XtraFunctions.ValueToHex(profile.OnlineXuid.value).Remove(0, 2).PadLeft(16, '0')) });
                SigninTileGroup.Items.Add(ti);
            }
            SigninTileControl.EndUpdate();
        }

        #endregion

        #region Structures

        private struct TileTag
        {
            public ConsoleProfile Profile { get; set; }

            public XDKUtilities.XAMACCOUNTINFO AccountInfo { get; set; }
        }

        #endregion

        #region Events

        private void SigninForm_Shown(object sender, EventArgs e) { ActiveControl = null; }

        private void ProfileTile_RightItemClick(object sender, TileItemEventArgs e)
        {
            var tag = (TileTag)e.Item.Tag;
            ProfileRightClickMenu.MenuCaption = tag.Profile.Gamertag + " Options";
            SigninTileGroup.Tag = e.Item;
            ProfileRightClickMenu.ShowPopup(MousePosition);
        }

        private void ProfileTile_ItemClick(object sender, TileItemEventArgs e)
        {
            var tag = (TileTag)e.Item.Tag;
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                mainForm.ShowWaitForm("Signing in...");
                tag.Profile.SignIn(0);
                SignedInProfile = tag.Profile;
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                mainForm.CloseWaitForm();
                Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                mainForm.CloseWaitForm();
                XtraMessageBox.Show(string.Format("{0} failed to sign in.{1}{2}", tag.Profile.Gamertag, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        private void DeleteProfileItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tile = (TileItem)SigninTileGroup.Tag;
            var tag = (TileTag)tile.Tag;
            try
            {
                if (XtraMessageBox.Show(string.Format("Are you sure you want to delete {0} AND all associated content?", tag.Profile.Gamertag), string.Format("Delete {0}?", tag.Profile.Gamertag), MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
                profileManager.DeleteConsoleProfile(tag.Profile);
                SigninTileGroup.Items.Remove(tile);
            }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to delete {0}.{1}{2}", tag.Profile.Gamertag, Environment.NewLine, ex.Message), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void ViewAccountInfoItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TileTag)((TileItem)SigninTileGroup.Tag).Tag;
            XtraMessageBox.Show(string.Format("Gamertag: {0}{1}Subscription: {2}{1}Offline XUID: {3}{1}Online XUID: {4}{1}Has Passcode: {5}{1}Passcode: {6}, {7}, {8}, {9}{1}Requires Management: {10}{1}Service: {11}{1}Language: {12}{1}Country: {13}{1}Online Domain: {14}{1}Online Key: {15}{1}Kerberos Realm: {16}{1}User Passport Member Name: {17}{1}User Passport Password: {18}{1}Owner Passport Member Name: {19}", tag.Profile.Gamertag, Environment.NewLine, tag.Profile.Tier, XtraFunctions.ValueToHex(tag.Profile.OfflineXuid.value).Remove(0, 2).PadLeft(16, '0'), XtraFunctions.ValueToHex(tag.Profile.OnlineXuid.value).Remove(0, 2).PadLeft(16, '0'), tag.AccountInfo.HasPasscode, tag.AccountInfo.Passcode[0], tag.AccountInfo.Passcode[1], tag.AccountInfo.Passcode[2], tag.AccountInfo.Passcode[3], tag.AccountInfo.RequiresManagement, tag.AccountInfo.Service, tag.AccountInfo.Language, tag.AccountInfo.Country, tag.AccountInfo.Domain, XtraFunctions.ByteArrayToString(tag.AccountInfo.OnlineKey), tag.AccountInfo.KerberosRealm, tag.AccountInfo.UserPassportMembername, tag.AccountInfo.UserPassportPassword, tag.AccountInfo.OwnerPassportMembername), "Account Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ViewGamertagItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TileTag)((TileItem)SigninTileGroup.Tag).Tag;
            Process.Start("https://live.xbox.com/en-US/Profile?gamertag=" + tag.Profile.Gamertag);
        }

        private void CopyOnlineXUIDItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TileTag)((TileItem)SigninTileGroup.Tag).Tag;
            Clipboard.SetText(XtraFunctions.ValueToHex(tag.Profile.OnlineXuid.value).Remove(0, 2).PadLeft(16, '0'));
        }

        private void CopyOfflineXUIDItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            var tag = (TileTag)((TileItem)SigninTileGroup.Tag).Tag;
            Clipboard.SetText(XtraFunctions.ValueToHex(tag.Profile.OfflineXuid.value).Remove(0, 2).PadLeft(16, '0'));
        }

        #endregion
    }
}