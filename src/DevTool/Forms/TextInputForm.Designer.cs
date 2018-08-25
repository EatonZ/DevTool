using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Forms
{
    sealed partial class TextInputForm
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
            this.TextInfoLabel = new DevExpress.XtraEditors.LabelControl();
            this.TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.TextLengthWarningLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // TextInfoLabel
            // 
            this.TextInfoLabel.AutoEllipsis = true;
            this.TextInfoLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.TextInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.TextInfoLabel.Name = "TextInfoLabel";
            this.TextInfoLabel.Size = new System.Drawing.Size(292, 13);
            this.TextInfoLabel.TabIndex = 0;
            this.TextInfoLabel.Text = "labelControl1";
            // 
            // TextEdit
            // 
            this.TextEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextEdit.Location = new System.Drawing.Point(0, 38);
            this.TextEdit.MenuManager = this.BarManager;
            this.TextEdit.Name = "TextEdit";
            this.TextEdit.Size = new System.Drawing.Size(292, 20);
            this.TextEdit.TabIndex = 0;
            this.TextEdit.TextChanged += new System.EventHandler(this.TextEdit_TextChanged);
            this.TextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextEdit_KeyPress);
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
            this.barDockControlTop.Size = new System.Drawing.Size(292, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 58);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(292, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 58);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(292, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 58);
            // 
            // TextLengthWarningLabel
            // 
            this.TextLengthWarningLabel.AutoEllipsis = true;
            this.TextLengthWarningLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.TextLengthWarningLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TextLengthWarningLabel.Location = new System.Drawing.Point(0, 13);
            this.TextLengthWarningLabel.Name = "TextLengthWarningLabel";
            this.TextLengthWarningLabel.Size = new System.Drawing.Size(292, 13);
            this.TextLengthWarningLabel.TabIndex = 5;
            this.TextLengthWarningLabel.Tag = "0";
            this.TextLengthWarningLabel.Text = "labelControl1";
            this.TextLengthWarningLabel.Visible = false;
            // 
            // TextInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 58);
            this.Controls.Add(this.TextLengthWarningLabel);
            this.Controls.Add(this.TextEdit);
            this.Controls.Add(this.TextInfoLabel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextInputForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextInputForm";
            this.Shown += new System.EventHandler(this.TextInputForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelControl TextInfoLabel;
        private TextEdit TextEdit;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private LabelControl TextLengthWarningLabel;
    }
}