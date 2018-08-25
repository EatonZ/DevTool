using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Forms
{
    partial class AddNeighborhoodDriveForm
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DrivePathLabel = new DevExpress.XtraEditors.LabelControl();
            this.DriveNameEdit = new DevExpress.XtraEditors.TextEdit();
            this.DriveNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.DrivePathEdit = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrivePathEdit.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.barDockControlTop.Size = new System.Drawing.Size(300, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 66);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(300, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 66);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(300, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 66);
            // 
            // DrivePathLabel
            // 
            this.DrivePathLabel.AutoEllipsis = true;
            this.DrivePathLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.DrivePathLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DrivePathLabel.Location = new System.Drawing.Point(0, 33);
            this.DrivePathLabel.Name = "DrivePathLabel";
            this.DrivePathLabel.Size = new System.Drawing.Size(300, 13);
            this.DrivePathLabel.TabIndex = 11;
            this.DrivePathLabel.Text = "Enter the mounted path.";
            // 
            // DriveNameEdit
            // 
            this.DriveNameEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.DriveNameEdit.Location = new System.Drawing.Point(0, 13);
            this.DriveNameEdit.MenuManager = this.BarManager;
            this.DriveNameEdit.Name = "DriveNameEdit";
            this.DriveNameEdit.Properties.MaxLength = 35;
            this.DriveNameEdit.Size = new System.Drawing.Size(300, 20);
            this.DriveNameEdit.TabIndex = 0;
            this.DriveNameEdit.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.DriveNameEdit_InvalidValue);
            this.DriveNameEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DriveNameEdit_KeyPress);
            this.DriveNameEdit.Validating += new System.ComponentModel.CancelEventHandler(this.DriveNameEdit_Validating);
            // 
            // DriveNameLabel
            // 
            this.DriveNameLabel.AutoEllipsis = true;
            this.DriveNameLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.DriveNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DriveNameLabel.Location = new System.Drawing.Point(0, 0);
            this.DriveNameLabel.Name = "DriveNameLabel";
            this.DriveNameLabel.Size = new System.Drawing.Size(300, 13);
            this.DriveNameLabel.TabIndex = 9;
            this.DriveNameLabel.Text = "Enter the name of the drive.";
            // 
            // DrivePathEdit
            // 
            this.DrivePathEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DrivePathEdit.Location = new System.Drawing.Point(0, 46);
            this.DrivePathEdit.MenuManager = this.BarManager;
            this.DrivePathEdit.Name = "DrivePathEdit";
            this.DrivePathEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "View Packages", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.DrivePathEdit.Size = new System.Drawing.Size(300, 20);
            this.DrivePathEdit.TabIndex = 16;
            this.DrivePathEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.DrivePathEdit_ButtonClick);
            this.DrivePathEdit.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.DrivePathEdit_InvalidValue);
            this.DrivePathEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DrivePathEdit_KeyPress);
            this.DrivePathEdit.Validating += new System.ComponentModel.CancelEventHandler(this.DrivePathEdit_Validating);
            // 
            // AddNeighborhoodDriveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 66);
            this.Controls.Add(this.DrivePathEdit);
            this.Controls.Add(this.DrivePathLabel);
            this.Controls.Add(this.DriveNameEdit);
            this.Controls.Add(this.DriveNameLabel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNeighborhoodDriveForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Neighborhood Drive";
            this.Shown += new System.EventHandler(this.AddNeighborhoodDriveForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DrivePathEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelControl DrivePathLabel;
        private TextEdit DriveNameEdit;
        private LabelControl DriveNameLabel;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private ButtonEdit DrivePathEdit;
    }
}