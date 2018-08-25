// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevTool.Classes;
using XDevkit;

namespace DevTool.Controls
{
    public sealed partial class ModuleLauncherControl : XtraUserControl
    {
        #region Properties and Constructors

        public XboxConsole Console { get; set; }

        public uint Connection { get; set; }

        public string DisplayName
        {
            get { return ModuleControlGroup.Text; }
            set { ModuleControlGroup.Text = value; }
        }

        public string ModulePath
        {
            get { return ModulePathEdit.Text; }
            set { ModulePathEdit.Text = value; }
        }

        public string JoinedLine { get { return string.Format("{0},{1}", DisplayName, ModulePath); } }

        public ModuleLauncherControl(XboxConsole Console, uint Connection, string JoinedLine)
        {
            InitializeComponent();
            this.Console = Console;
            this.Connection = Connection;
            var np = JoinedLine.Split(',');
            ModuleControlGroup.Text = np[0];
            ModulePathEdit.Text = np[1];
        }

        #endregion

        #region Events

        private void ModuleLaunchButton_Click(object sender, EventArgs e)
        {
            try { XDKUtilities.LaunchModule(Console, Connection, ModulePathEdit.Text); }
            catch (Exception ex) { XtraMessageBox.Show(string.Format("Failed to launch {0}.{1}{2}", ModuleControlGroup.Text, Environment.NewLine, XDKUtilities.CreateExceptionMessage(ex, Console.XboxManager)), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void RemoveButton_Click(object sender, EventArgs e) { Dispose(); }

        #endregion
    }
}