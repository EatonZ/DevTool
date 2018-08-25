using DevExpress.XtraEditors;
using System.ComponentModel;
using DevExpress.XtraBars;

namespace DevTool.Controls
{
    partial class ModuleLauncherControl
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
            this.ModuleLaunchButton = new DevExpress.XtraEditors.SimpleButton();
            this.ModuleControlGroup = new DevExpress.XtraEditors.GroupControl();
            this.ModulePathEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.RemoveButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.ModuleControlGroup)).BeginInit();
            this.ModuleControlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ModulePathEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ModuleLaunchButton
            // 
            this.ModuleLaunchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleLaunchButton.Location = new System.Drawing.Point(2, 41);
            this.ModuleLaunchButton.Name = "ModuleLaunchButton";
            this.ModuleLaunchButton.Size = new System.Drawing.Size(626, 27);
            this.ModuleLaunchButton.TabIndex = 1;
            this.ModuleLaunchButton.Text = "Launch";
            this.ModuleLaunchButton.Click += new System.EventHandler(this.ModuleLaunchButton_Click);
            // 
            // ModuleControlGroup
            // 
            this.ModuleControlGroup.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ModuleControlGroup.AppearanceCaption.Options.UseFont = true;
            this.ModuleControlGroup.Controls.Add(this.ModuleLaunchButton);
            this.ModuleControlGroup.Controls.Add(this.ModulePathEdit);
            this.ModuleControlGroup.Controls.Add(this.RemoveButton);
            this.ModuleControlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModuleControlGroup.Location = new System.Drawing.Point(0, 0);
            this.ModuleControlGroup.Name = "ModuleControlGroup";
            this.ModuleControlGroup.Size = new System.Drawing.Size(705, 70);
            this.ModuleControlGroup.TabIndex = 2;
            this.ModuleControlGroup.Text = "ModuleName";
            // 
            // ModulePathEdit
            // 
            this.ModulePathEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.ModulePathEdit.Location = new System.Drawing.Point(2, 21);
            this.ModulePathEdit.MenuManager = this.BarManager;
            this.ModulePathEdit.Name = "ModulePathEdit";
            this.ModulePathEdit.Size = new System.Drawing.Size(626, 20);
            this.ModulePathEdit.TabIndex = 0;
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
            this.barDockControlTop.Size = new System.Drawing.Size(705, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 70);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(705, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 70);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(705, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 70);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.RemoveButton.Location = new System.Drawing.Point(628, 21);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(75, 47);
            this.RemoveButton.TabIndex = 2;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // ModuleLauncherControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ModuleControlGroup);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "ModuleLauncherControl";
            this.Size = new System.Drawing.Size(705, 70);
            ((System.ComponentModel.ISupportInitialize)(this.ModuleControlGroup)).EndInit();
            this.ModuleControlGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ModulePathEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SimpleButton ModuleLaunchButton;
        private GroupControl ModuleControlGroup;
        private SimpleButton RemoveButton;
        private TextEdit ModulePathEdit;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
    }
}