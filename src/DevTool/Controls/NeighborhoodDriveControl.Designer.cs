using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Controls
{
    partial class NeighborhoodDriveControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DriveGroup = new DevExpress.XtraEditors.GroupControl();
            this.RemoveButton = new DevExpress.XtraEditors.SimpleButton();
            this.EnabledCheck = new DevExpress.XtraEditors.CheckEdit();
            this.DrivePathEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DrivePathLabel = new DevExpress.XtraEditors.LabelControl();
            this.DriveNameEdit = new DevExpress.XtraEditors.TextEdit();
            this.DriveNameLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.DriveGroup)).BeginInit();
            this.DriveGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnabledCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrivePathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveNameEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // DriveGroup
            // 
            this.DriveGroup.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriveGroup.AppearanceCaption.Options.UseFont = true;
            this.DriveGroup.Controls.Add(this.RemoveButton);
            this.DriveGroup.Controls.Add(this.EnabledCheck);
            this.DriveGroup.Controls.Add(this.DrivePathEdit);
            this.DriveGroup.Controls.Add(this.DrivePathLabel);
            this.DriveGroup.Controls.Add(this.DriveNameEdit);
            this.DriveGroup.Controls.Add(this.DriveNameLabel);
            this.DriveGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DriveGroup.Location = new System.Drawing.Point(0, 0);
            this.DriveGroup.Name = "DriveGroup";
            this.DriveGroup.Size = new System.Drawing.Size(482, 142);
            this.DriveGroup.TabIndex = 0;
            this.DriveGroup.Text = "Custom Drive ";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Location = new System.Drawing.Point(3, 112);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // EnabledCheck
            // 
            this.EnabledCheck.Dock = System.Windows.Forms.DockStyle.Top;
            this.EnabledCheck.EditValue = true;
            this.EnabledCheck.Location = new System.Drawing.Point(2, 87);
            this.EnabledCheck.Name = "EnabledCheck";
            this.EnabledCheck.Properties.Caption = "Enabled";
            this.EnabledCheck.Size = new System.Drawing.Size(478, 19);
            this.EnabledCheck.TabIndex = 2;
            // 
            // DrivePathEdit
            // 
            this.DrivePathEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.DrivePathEdit.Location = new System.Drawing.Point(2, 67);
            this.DrivePathEdit.MenuManager = this.BarManager;
            this.DrivePathEdit.Name = "DrivePathEdit";
            this.DrivePathEdit.Size = new System.Drawing.Size(478, 20);
            this.DrivePathEdit.TabIndex = 1;
            this.DrivePathEdit.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.DrivePathEdit_InvalidValue);
            this.DrivePathEdit.Validating += new System.ComponentModel.CancelEventHandler(this.DrivePathEdit_Validating);
            // 
            // BarManager
            // 
            this.BarManager.AllowCustomization = false;
            this.BarManager.AllowQuickCustomization = false;
            this.BarManager.AllowShowToolbarsPopup = false;
            this.BarManager.DockControls.Add(this.barDockControlTop);
            this.BarManager.DockControls.Add(this.barDockControlBottom);
            this.BarManager.DockControls.Add(this.barDockControlLeft);
            this.BarManager.DockControls.Add(this.barDockControlRight);
            this.BarManager.Form = this;
            this.BarManager.MaxItemId = 8;
            this.BarManager.UseAltKeyForMenu = false;
            this.BarManager.UseF10KeyForMenu = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(482, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 142);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(482, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 142);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(482, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 142);
            // 
            // DrivePathLabel
            // 
            this.DrivePathLabel.AutoEllipsis = true;
            this.DrivePathLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.DrivePathLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DrivePathLabel.Location = new System.Drawing.Point(2, 54);
            this.DrivePathLabel.Name = "DrivePathLabel";
            this.DrivePathLabel.Size = new System.Drawing.Size(478, 13);
            this.DrivePathLabel.TabIndex = 18;
            this.DrivePathLabel.Text = "Mounted path:";
            // 
            // DriveNameEdit
            // 
            this.DriveNameEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.DriveNameEdit.Location = new System.Drawing.Point(2, 34);
            this.DriveNameEdit.MenuManager = this.BarManager;
            this.DriveNameEdit.Name = "DriveNameEdit";
            this.DriveNameEdit.Properties.MaxLength = 35;
            this.DriveNameEdit.Size = new System.Drawing.Size(478, 20);
            this.DriveNameEdit.TabIndex = 0;
            this.DriveNameEdit.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.DriveNameEdit_InvalidValue);
            this.DriveNameEdit.Validating += new System.ComponentModel.CancelEventHandler(this.DriveNameEdit_Validating);
            // 
            // DriveNameLabel
            // 
            this.DriveNameLabel.AutoEllipsis = true;
            this.DriveNameLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.DriveNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DriveNameLabel.Location = new System.Drawing.Point(2, 21);
            this.DriveNameLabel.Name = "DriveNameLabel";
            this.DriveNameLabel.Size = new System.Drawing.Size(478, 13);
            this.DriveNameLabel.TabIndex = 17;
            this.DriveNameLabel.Text = "Drive name:";
            // 
            // NeighborhoodDriveControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DriveGroup);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "NeighborhoodDriveControl";
            this.Size = new System.Drawing.Size(482, 142);
            ((System.ComponentModel.ISupportInitialize)(this.DriveGroup)).EndInit();
            this.DriveGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnabledCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrivePathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveNameEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupControl DriveGroup;
        private SimpleButton RemoveButton;
        private CheckEdit EnabledCheck;
        private TextEdit DrivePathEdit;
        private LabelControl DrivePathLabel;
        private TextEdit DriveNameEdit;
        private LabelControl DriveNameLabel;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
    }
}