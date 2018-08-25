// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils.Taskbar.Core;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevTool.Classes;
using XDevkit;

namespace DevTool.Forms
{
    public partial class AddNeighborhoodDriveForm : XtraForm
    {
        #region Fields, Properties, and Constructors

        private readonly MainForm mainForm;
        private readonly NeighborhoodDrives drives;
        private readonly XboxManager manager;

        public string DriveName { get; private set; }

        public string DrivePath { get; private set; }

        public AddNeighborhoodDriveForm(MainForm MainForm, NeighborhoodDrives Drives, XboxManager Manager)
        {
            InitializeComponent();
            mainForm = MainForm;
            drives = Drives;
            manager = Manager;
        }

        #endregion

        #region Events

        private void AddNeighborhoodDriveForm_Shown(object sender, EventArgs e) { ActiveControl = null; }

        private void DriveNameEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || !NeighborhoodDrives.IsValidDriveName(DriveNameEdit.Text) || !NeighborhoodDrives.IsValidDriveLocation(DrivePathEdit.Text)) return;
            DriveName = DriveNameEdit.Text;
            DrivePath = DrivePathEdit.Text;
            Close();
        }

        private void DriveNameEdit_Validating(object sender, CancelEventArgs e) { e.Cancel = !NeighborhoodDrives.IsValidDriveName(DriveNameEdit.Text); }

        private void DriveNameEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { e.ErrorText = "Invalid drive name specified. It must be composed of 35 or less valid characters. A-Z, 0-9."; }

        private void DrivePathEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || !NeighborhoodDrives.IsValidDriveName(DriveNameEdit.Text) || !NeighborhoodDrives.IsValidDriveLocation(DrivePathEdit.Text)) return;
            DriveName = DriveNameEdit.Text;
            DrivePath = DrivePathEdit.Text;
            Close();
        }

        private void DrivePathEdit_Validating(object sender, CancelEventArgs e) { e.Cancel = !NeighborhoodDrives.IsValidDriveLocation(DrivePathEdit.Text); }

        private void DrivePathEdit_InvalidValue(object sender, InvalidValueExceptionEventArgs e) { e.ErrorText = "Invalid drive path specified. It is not a proper device path."; }

        private void DrivePathEdit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Indeterminate);
                mainForm.ShowWaitForm("Listing mounted packages...");
                var sb = new StringBuilder();
                sb.AppendLine("These packages are currently mounted and can be accessed. You do not have write access to PIRS/LIVE packages. Console signed volumes will continue to expand until their maximum size (4 GB) is reached.");
                sb.AppendLine();
                foreach (var package in drives.GetMountedPackageDeviceNames())
                {
                    sb.AppendLine(package.Key);
                    sb.AppendLine(package.Value);
                }
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
                mainForm.CloseWaitForm();
                using (var txtdf = new TextDisplayForm("Mounted Packages", sb)) txtdf.ShowDialog();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.Error);
                mainForm.CloseWaitForm();
                XtraMessageBox.Show("Failed to list the mounted package structures." + Environment.NewLine + XDKUtilities.CreateExceptionMessage(ex, manager), "DevTool Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WindowsTaskbarHelper.SetProgressState(TaskbarButtonProgressMode.NoProgress);
        }

        #endregion
    }
}