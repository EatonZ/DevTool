// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevTool.Classes;
using XDevkit;

namespace DevTool.Forms
{
    public sealed partial class XUIDGTConversionForm : XtraForm
    {
        #region Fields and Constructors

        private readonly XboxConsole console;
        private readonly ulong p1XUID;
        private readonly uint address;
        private bool converting;
        private XDKUtilities.FIND_USER_REPLY_MSG resUser;

        public XUIDGTConversionForm(XboxConsole Console, ulong P1XUID, uint XUserFindUserAddress)
        {
            InitializeComponent();
            console = Console;
            p1XUID = P1XUID;
            address = XUserFindUserAddress;
        }

        #endregion

        #region Events

        private void XUIDGTConversionForm_Shown(object sender, EventArgs e) { ActiveControl = GamertagEdit; }

        private void GamertagEdit_TextChanged(object sender, EventArgs e)
        {
            if (converting) return;
            GetValuesButton.Enabled = !string.IsNullOrWhiteSpace(GamertagEdit.Text) || !string.IsNullOrWhiteSpace(XUIDEdit.Text);
            if (GamertagEdit.Text.Length > 0)
            {
                XUIDEdit.Properties.ReadOnly = true;
                XUIDEdit.Text = string.Empty;
            }
            else XUIDEdit.Properties.ReadOnly = false;
        }

        private void XUIDEdit_TextChanged(object sender, EventArgs e)
        {
            if (converting) return;
            GetValuesButton.Enabled = !string.IsNullOrWhiteSpace(GamertagEdit.Text) || !string.IsNullOrWhiteSpace(XUIDEdit.Text);
            if (XUIDEdit.Text.Length > 0)
            {
                GamertagEdit.Properties.ReadOnly = true;
                GamertagEdit.Text = string.Empty;
            }
            else GamertagEdit.Properties.ReadOnly = false;
        }

        private void GamertagEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(GamertagEdit.Text)) return;
            GetValuesButton_Click(null, null);
        }

        private void XUIDEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            if (string.IsNullOrWhiteSpace(XUIDEdit.Text)) return;
            GetValuesButton_Click(null, null);
        }

        private void XUIDEdit_Validating(object sender, CancelEventArgs e)
        {
            if (XUIDEdit.Text.Length <= 0) return;
            if (!XtraFunctions.IsValidBase16String(XUIDEdit.Text)) e.Cancel = true;
            else e.Cancel = !XUID.IsOnlineXUID(XtraFunctions.ValueFromHex(XUIDEdit.Text.Insert(0, "0x"))) && !XUID.IsTeamXUID(XtraFunctions.ValueFromHex(XUIDEdit.Text.Insert(0, "0x")));
        }

        private void XUIDEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { e.ErrorText = "Invalid online/team XUID specified."; }

        private void GetValuesButton_Click(object sender, EventArgs e)
        {
            try
            {
                converting = true;
                if (string.IsNullOrWhiteSpace(GamertagEdit.Text))
                {
                    resUser = XDKUtilities.XUserFindUser(console, address, p1XUID, XtraFunctions.ValueFromHex(XUIDEdit.Text.Insert(0, "0x")));
                    GamertagEdit.Text = string.IsNullOrWhiteSpace(resUser.Gamertag) ? "(XUID does not exist on the service)" : resUser.Gamertag;
                    ShowGamercardButton.Enabled = resUser.OnlineXUID != 0;
                    ViewGamertagButton.Enabled = resUser.OnlineXUID != 0;
                }
                else
                {
                    resUser = XDKUtilities.XUserFindUser(console, address, p1XUID, GamertagEdit.Text);
                    if (resUser.OnlineXUID == 0) XUIDEdit.Text = "(Gamertag does not exist on the service)";
                    else
                    {
                        XUIDEdit.Text = XtraFunctions.ValueToHex(resUser.OnlineXUID).Remove(0, 2).PadLeft(16, '0');
                        GamertagEdit.Text = resUser.Gamertag; //To correct case.
                    }
                    ShowGamercardButton.Enabled = resUser.OnlineXUID != 0;
                    ViewGamertagButton.Enabled = resUser.OnlineXUID != 0;
                }
            }
            catch (Exception ex) { XtraMessageBox.Show("Failed to carry out the conversion." + Environment.NewLine + XDKUtilities.CreateExceptionMessage(ex, console.XboxManager), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            converting = false;
        }

        private void ShowGamercardButton_Click(object sender, EventArgs e)
        {
            retry:
            try { XDKUtilities.XamShowGamerCardUIForXUID(console, 0, resUser.OnlineXUID); }
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
                XtraMessageBox.Show(string.Format("Failed to show {0}'s Gamercard UI.{1}{2}", resUser.Gamertag, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, console.XboxManager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewGamertagButton_Click(object sender, EventArgs e)
        {
            try { Process.Start("https://live.xbox.com/en-US/Profile?gamertag=" + resUser.Gamertag); }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to open the link.{0}{1}", Environment.NewLine, ex.Message), "FATXplorer Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #endregion
    }
}