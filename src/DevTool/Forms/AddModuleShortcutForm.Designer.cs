using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Forms
{
    partial class AddModuleShortcutForm
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
            this.ModulePathLabel = new DevExpress.XtraEditors.LabelControl();
            this.DriveCombo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ModulePathEdit = new DevExpress.XtraEditors.TextEdit();
            this.DisplayNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.DisplayNameEdit = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.DriveCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModulePathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ModulePathLabel
            // 
            this.ModulePathLabel.AutoEllipsis = true;
            this.ModulePathLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.ModulePathLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModulePathLabel.Location = new System.Drawing.Point(0, 0);
            this.ModulePathLabel.Name = "ModulePathLabel";
            this.ModulePathLabel.Size = new System.Drawing.Size(342, 13);
            this.ModulePathLabel.TabIndex = 0;
            this.ModulePathLabel.Text = "Enter the path to the module.";
            // 
            // DriveCombo
            // 
            this.DriveCombo.Location = new System.Drawing.Point(0, 19);
            this.DriveCombo.MenuManager = this.BarManager;
            this.DriveCombo.Name = "DriveCombo";
            this.DriveCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DriveCombo.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Skinned;
            this.DriveCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.DriveCombo.Size = new System.Drawing.Size(88, 20);
            this.DriveCombo.TabIndex = 0;
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
            this.barDockControlTop.Size = new System.Drawing.Size(342, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 78);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(342, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 78);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(342, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 78);
            // 
            // ModulePathEdit
            // 
            this.ModulePathEdit.Location = new System.Drawing.Point(94, 19);
            this.ModulePathEdit.MenuManager = this.BarManager;
            this.ModulePathEdit.Name = "ModulePathEdit";
            this.ModulePathEdit.Size = new System.Drawing.Size(248, 20);
            this.ModulePathEdit.TabIndex = 1;
            this.ModulePathEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ModulePathEdit_KeyPress);
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoEllipsis = true;
            this.DisplayNameLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.DisplayNameLabel.Location = new System.Drawing.Point(0, 45);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(247, 13);
            this.DisplayNameLabel.TabIndex = 0;
            this.DisplayNameLabel.Text = "Enter the name of the module for display purposes.";
            // 
            // DisplayNameEdit
            // 
            this.DisplayNameEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DisplayNameEdit.Location = new System.Drawing.Point(0, 58);
            this.DisplayNameEdit.MenuManager = this.BarManager;
            this.DisplayNameEdit.Name = "DisplayNameEdit";
            this.DisplayNameEdit.Size = new System.Drawing.Size(342, 20);
            this.DisplayNameEdit.TabIndex = 2;
            this.DisplayNameEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisplayNameEdit_KeyPress);
            // 
            // AddModuleShortcutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 78);
            this.Controls.Add(this.DisplayNameEdit);
            this.Controls.Add(this.DisplayNameLabel);
            this.Controls.Add(this.ModulePathEdit);
            this.Controls.Add(this.DriveCombo);
            this.Controls.Add(this.ModulePathLabel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddModuleShortcutForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Module Shortcut";
            this.Shown += new System.EventHandler(this.AddModuleShortcutForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DriveCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModulePathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelControl ModulePathLabel;
        private ComboBoxEdit DriveCombo;
        private TextEdit ModulePathEdit;
        private LabelControl DisplayNameLabel;
        private TextEdit DisplayNameEdit;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
    }
}