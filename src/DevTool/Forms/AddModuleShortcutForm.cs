// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System;

namespace DevTool.Forms
{
    public sealed partial class AddModuleShortcutForm : XtraForm
    {
        #region Properties and Constructors

        public string ModulePath { get; private set; }

        public string DisplayName { get; private set; }

        public AddModuleShortcutForm(List<string> Drives)
        {
            InitializeComponent();
            Drives.ForEach(drive => DriveCombo.Properties.Items.Add(drive + ":\\"));
            DriveCombo.SelectedIndex = 0;
        }

        #endregion

        #region Events

        private void AddModuleShortcutForm_Shown(object sender, EventArgs e) { ActiveControl = null; }

        private void ModulePathEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || string.IsNullOrWhiteSpace(ModulePathEdit.Text) || string.IsNullOrWhiteSpace(DisplayNameEdit.Text)) return;
            ModulePath = DriveCombo.EditValue + ModulePathEdit.Text;
            DisplayName = DisplayNameEdit.Text;
            Close();
        }

        private void DisplayNameEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || string.IsNullOrWhiteSpace(ModulePathEdit.Text) || string.IsNullOrWhiteSpace(DisplayNameEdit.Text)) return;
            ModulePath = DriveCombo.EditValue + ModulePathEdit.Text;
            DisplayName = DisplayNameEdit.Text;
            Close();
        }

        #endregion
    }
}