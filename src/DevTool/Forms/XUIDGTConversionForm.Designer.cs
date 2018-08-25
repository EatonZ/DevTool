using System.ComponentModel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace DevTool.Forms
{
    partial class XUIDGTConversionForm
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
            this.Panel = new DevExpress.XtraEditors.PanelControl();
            this.GetValuesButton = new DevExpress.XtraEditors.SimpleButton();
            this.XUIDEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.XUIDLabel = new DevExpress.XtraEditors.LabelControl();
            this.GamertagEdit = new DevExpress.XtraEditors.TextEdit();
            this.GamertagLabel = new DevExpress.XtraEditors.LabelControl();
            this.ConversionInfoLabel = new DevExpress.XtraEditors.LabelControl();
            this.ShowGamercardButton = new DevExpress.XtraEditors.SimpleButton();
            this.ViewGamertagButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Panel)).BeginInit();
            this.Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.XUIDEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GamertagEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Controls.Add(this.GetValuesButton);
            this.Panel.Controls.Add(this.XUIDEdit);
            this.Panel.Controls.Add(this.XUIDLabel);
            this.Panel.Controls.Add(this.GamertagEdit);
            this.Panel.Controls.Add(this.GamertagLabel);
            this.Panel.Controls.Add(this.ConversionInfoLabel);
            this.Panel.Controls.Add(this.ShowGamercardButton);
            this.Panel.Controls.Add(this.ViewGamertagButton);
            this.Panel.Location = new System.Drawing.Point(12, 12);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(240, 200);
            this.Panel.TabIndex = 0;
            // 
            // GetValuesButton
            // 
            this.GetValuesButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GetValuesButton.Enabled = false;
            this.GetValuesButton.Location = new System.Drawing.Point(2, 117);
            this.GetValuesButton.Name = "GetValuesButton";
            this.GetValuesButton.Size = new System.Drawing.Size(236, 27);
            this.GetValuesButton.TabIndex = 2;
            this.GetValuesButton.Text = "Get Values";
            this.GetValuesButton.Click += new System.EventHandler(this.GetValuesButton_Click);
            // 
            // XUIDEdit
            // 
            this.XUIDEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.XUIDEdit.EditValue = "";
            this.XUIDEdit.Location = new System.Drawing.Point(2, 87);
            this.XUIDEdit.MenuManager = this.BarManager;
            this.XUIDEdit.Name = "XUIDEdit";
            this.XUIDEdit.Properties.MaxLength = 16;
            this.XUIDEdit.Size = new System.Drawing.Size(236, 20);
            this.XUIDEdit.TabIndex = 1;
            this.XUIDEdit.InvalidValue += new DevExpress.XtraEditors.Controls.InvalidValueExceptionEventHandler(this.XUIDEdit_InvalidValue);
            this.XUIDEdit.TextChanged += new System.EventHandler(this.XUIDEdit_TextChanged);
            this.XUIDEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.XUIDEdit_KeyPress);
            this.XUIDEdit.Validating += new System.ComponentModel.CancelEventHandler(this.XUIDEdit_Validating);
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
            this.barDockControlTop.Size = new System.Drawing.Size(264, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 224);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(264, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 224);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(264, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 224);
            // 
            // XUIDLabel
            // 
            this.XUIDLabel.AutoEllipsis = true;
            this.XUIDLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.XUIDLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.XUIDLabel.Location = new System.Drawing.Point(2, 74);
            this.XUIDLabel.Name = "XUIDLabel";
            this.XUIDLabel.Size = new System.Drawing.Size(236, 13);
            this.XUIDLabel.TabIndex = 4;
            this.XUIDLabel.Text = "XUID (in hex):";
            // 
            // GamertagEdit
            // 
            this.GamertagEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.GamertagEdit.Location = new System.Drawing.Point(2, 54);
            this.GamertagEdit.MenuManager = this.BarManager;
            this.GamertagEdit.Name = "GamertagEdit";
            this.GamertagEdit.Properties.MaxLength = 15;
            this.GamertagEdit.Size = new System.Drawing.Size(236, 20);
            this.GamertagEdit.TabIndex = 0;
            this.GamertagEdit.TextChanged += new System.EventHandler(this.GamertagEdit_TextChanged);
            this.GamertagEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GamertagEdit_KeyPress);
            // 
            // GamertagLabel
            // 
            this.GamertagLabel.AutoEllipsis = true;
            this.GamertagLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.GamertagLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GamertagLabel.Location = new System.Drawing.Point(2, 41);
            this.GamertagLabel.Name = "GamertagLabel";
            this.GamertagLabel.Size = new System.Drawing.Size(236, 13);
            this.GamertagLabel.TabIndex = 2;
            this.GamertagLabel.Text = "Gamertag (case insensitive):";
            // 
            // ConversionInfoLabel
            // 
            this.ConversionInfoLabel.AutoEllipsis = true;
            this.ConversionInfoLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.ConversionInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConversionInfoLabel.Location = new System.Drawing.Point(2, 2);
            this.ConversionInfoLabel.Name = "ConversionInfoLabel";
            this.ConversionInfoLabel.Size = new System.Drawing.Size(236, 39);
            this.ConversionInfoLabel.TabIndex = 1;
            this.ConversionInfoLabel.Text = "Fill in ONE of the boxes below. The missing field will be populated once you pres" +
    "s the button.\r\n\r\n";
            // 
            // ShowGamercardButton
            // 
            this.ShowGamercardButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ShowGamercardButton.Enabled = false;
            this.ShowGamercardButton.Location = new System.Drawing.Point(2, 144);
            this.ShowGamercardButton.Name = "ShowGamercardButton";
            this.ShowGamercardButton.Size = new System.Drawing.Size(236, 27);
            this.ShowGamercardButton.TabIndex = 6;
            this.ShowGamercardButton.Text = "Show Gamercard";
            this.ShowGamercardButton.Click += new System.EventHandler(this.ShowGamercardButton_Click);
            // 
            // ViewGamertagButton
            // 
            this.ViewGamertagButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ViewGamertagButton.Enabled = false;
            this.ViewGamertagButton.Location = new System.Drawing.Point(2, 171);
            this.ViewGamertagButton.Name = "ViewGamertagButton";
            this.ViewGamertagButton.Size = new System.Drawing.Size(236, 27);
            this.ViewGamertagButton.TabIndex = 5;
            this.ViewGamertagButton.Text = "View Gamertag";
            this.ViewGamertagButton.Click += new System.EventHandler(this.ViewGamertagButton_Click);
            // 
            // XUIDGTConversionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 224);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XUIDGTConversionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XUID/Gamertag Conversions";
            this.Shown += new System.EventHandler(this.XUIDGTConversionForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Panel)).EndInit();
            this.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.XUIDEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GamertagEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PanelControl Panel;
        private LabelControl ConversionInfoLabel;
        private SimpleButton GetValuesButton;
        private TextEdit XUIDEdit;
        private LabelControl XUIDLabel;
        private TextEdit GamertagEdit;
        private LabelControl GamertagLabel;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private SimpleButton ShowGamercardButton;
        private SimpleButton ViewGamertagButton;
    }
}