using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Forms
{
    partial class AddKeyboardHookForm
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
            this.DisplayNameEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.DisplayNameLabel = new DevExpress.XtraEditors.LabelControl();
            this.TitleDescriptionEdit = new DevExpress.XtraEditors.TextEdit();
            this.TitleDescriptionLabel = new DevExpress.XtraEditors.LabelControl();
            this.InsertEdit = new DevExpress.XtraEditors.TextEdit();
            this.InsertLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDescriptionEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsertEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // DisplayNameEdit
            // 
            this.DisplayNameEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.DisplayNameEdit.Location = new System.Drawing.Point(0, 13);
            this.DisplayNameEdit.MenuManager = this.BarManager;
            this.DisplayNameEdit.Name = "DisplayNameEdit";
            this.DisplayNameEdit.Size = new System.Drawing.Size(300, 20);
            this.DisplayNameEdit.TabIndex = 0;
            this.DisplayNameEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DisplayNameEdit_KeyPress);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 99);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(300, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 99);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(300, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 99);
            // 
            // DisplayNameLabel
            // 
            this.DisplayNameLabel.AutoEllipsis = true;
            this.DisplayNameLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.DisplayNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DisplayNameLabel.Location = new System.Drawing.Point(0, 0);
            this.DisplayNameLabel.Name = "DisplayNameLabel";
            this.DisplayNameLabel.Size = new System.Drawing.Size(300, 13);
            this.DisplayNameLabel.TabIndex = 3;
            this.DisplayNameLabel.Text = "Enter the name of the hook for display purposes.";
            // 
            // TitleDescriptionEdit
            // 
            this.TitleDescriptionEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleDescriptionEdit.Location = new System.Drawing.Point(0, 46);
            this.TitleDescriptionEdit.MenuManager = this.BarManager;
            this.TitleDescriptionEdit.Name = "TitleDescriptionEdit";
            this.TitleDescriptionEdit.Size = new System.Drawing.Size(300, 20);
            this.TitleDescriptionEdit.TabIndex = 1;
            this.TitleDescriptionEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TitleDescriptionEdit_KeyPress);
            // 
            // TitleDescriptionLabel
            // 
            this.TitleDescriptionLabel.AutoEllipsis = true;
            this.TitleDescriptionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.TitleDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleDescriptionLabel.Location = new System.Drawing.Point(0, 33);
            this.TitleDescriptionLabel.Name = "TitleDescriptionLabel";
            this.TitleDescriptionLabel.Size = new System.Drawing.Size(300, 13);
            this.TitleDescriptionLabel.TabIndex = 5;
            this.TitleDescriptionLabel.Text = "Enter the message box title or description.";
            // 
            // InsertEdit
            // 
            this.InsertEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InsertEdit.Location = new System.Drawing.Point(0, 79);
            this.InsertEdit.MenuManager = this.BarManager;
            this.InsertEdit.Name = "InsertEdit";
            this.InsertEdit.Size = new System.Drawing.Size(300, 20);
            this.InsertEdit.TabIndex = 2;
            this.InsertEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InsertEdit_KeyPress);
            // 
            // InsertLabel
            // 
            this.InsertLabel.AutoEllipsis = true;
            this.InsertLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.InsertLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsertLabel.Location = new System.Drawing.Point(0, 66);
            this.InsertLabel.Name = "InsertLabel";
            this.InsertLabel.Size = new System.Drawing.Size(300, 13);
            this.InsertLabel.TabIndex = 7;
            this.InsertLabel.Text = "Enter the text to insert.";
            // 
            // AddKeyboardHookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 99);
            this.Controls.Add(this.InsertEdit);
            this.Controls.Add(this.InsertLabel);
            this.Controls.Add(this.TitleDescriptionEdit);
            this.Controls.Add(this.TitleDescriptionLabel);
            this.Controls.Add(this.DisplayNameEdit);
            this.Controls.Add(this.DisplayNameLabel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddKeyboardHookForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Keyboard Hook";
            this.Shown += new System.EventHandler(this.AddKeyboardHookForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DisplayNameEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDescriptionEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsertEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextEdit DisplayNameEdit;
        private LabelControl DisplayNameLabel;
        private TextEdit TitleDescriptionEdit;
        private LabelControl TitleDescriptionLabel;
        private TextEdit InsertEdit;
        private LabelControl InsertLabel;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
    }
}