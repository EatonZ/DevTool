// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevTool.Classes;

namespace DevTool.Controls
{
    public sealed partial class NeighborhoodDriveControl : XtraUserControl
    {
        #region Properties and Constructors

        public string DriveName
        {
            get { return DriveNameEdit.Text; }
            set { DriveNameEdit.Text = value; }
        }

        public string DrivePath
        {
            get { return DrivePathEdit.Text; }
            set { DrivePathEdit.Text = value; }
        }

        public bool Enabled
        {
            get { return EnabledCheck.Checked; }
            set { EnabledCheck.Checked = value; }
        }

        public NeighborhoodDriveControl(string JoinedLine)
        {
            InitializeComponent();
            var np = JoinedLine.Split(',');
            DriveNameEdit.Text = np[0];
            DriveGroup.Text = np[0];
            DrivePathEdit.Text = np[1];
        }

        #endregion

        #region Events

        private void DriveNameEdit_Validating(object sender, CancelEventArgs e) { e.Cancel = !NeighborhoodDrives.IsValidDriveName(DriveNameEdit.Text); }

        private void DriveNameEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { e.ErrorText = "Invalid drive name specified. It must be composed of 35 or less valid characters. A-Z, 0-9."; }

        private void DrivePathEdit_Validating(object sender, CancelEventArgs e) { e.Cancel = !NeighborhoodDrives.IsValidDriveLocation(DrivePathEdit.Text); }

        private void DrivePathEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { e.ErrorText = "Invalid drive path specified. It is not a proper device path."; }

        private void RemoveButton_Click(object sender, EventArgs e) { Dispose(); }

        #endregion
    }
}