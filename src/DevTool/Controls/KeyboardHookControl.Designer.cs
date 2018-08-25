using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Controls
{
    partial class KeyboardHookControl
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
            this.KeyboardHookControlGroup = new DevExpress.XtraEditors.GroupControl();
            this.RemoveButton = new DevExpress.XtraEditors.SimpleButton();
            this.EnabledCheck = new DevExpress.XtraEditors.CheckEdit();
            this.InsertEdit = new DevExpress.XtraEditors.TextEdit();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.InsertLabel = new DevExpress.XtraEditors.LabelControl();
            this.TitleDescriptionEdit = new DevExpress.XtraEditors.TextEdit();
            this.TitleDescriptionLabel = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardHookControlGroup)).BeginInit();
            this.KeyboardHookControlGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EnabledCheck.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsertEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDescriptionEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // KeyboardHookControlGroup
            // 
            this.KeyboardHookControlGroup.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyboardHookControlGroup.AppearanceCaption.Options.UseFont = true;
            this.KeyboardHookControlGroup.Controls.Add(this.RemoveButton);
            this.KeyboardHookControlGroup.Controls.Add(this.EnabledCheck);
            this.KeyboardHookControlGroup.Controls.Add(this.InsertEdit);
            this.KeyboardHookControlGroup.Controls.Add(this.InsertLabel);
            this.KeyboardHookControlGroup.Controls.Add(this.TitleDescriptionEdit);
            this.KeyboardHookControlGroup.Controls.Add(this.TitleDescriptionLabel);
            this.KeyboardHookControlGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KeyboardHookControlGroup.Location = new System.Drawing.Point(0, 0);
            this.KeyboardHookControlGroup.Name = "KeyboardHookControlGroup";
            this.KeyboardHookControlGroup.Size = new System.Drawing.Size(482, 142);
            this.KeyboardHookControlGroup.TabIndex = 0;
            this.KeyboardHookControlGroup.Text = "Hook";
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
            // InsertEdit
            // 
            this.InsertEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsertEdit.Location = new System.Drawing.Point(2, 67);
            this.InsertEdit.MenuManager = this.BarManager;
            this.InsertEdit.Name = "InsertEdit";
            this.InsertEdit.Size = new System.Drawing.Size(478, 20);
            this.InsertEdit.TabIndex = 1;
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
            // InsertLabel
            // 
            this.InsertLabel.AutoEllipsis = true;
            this.InsertLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.InsertLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsertLabel.Location = new System.Drawing.Point(2, 54);
            this.InsertLabel.Name = "InsertLabel";
            this.InsertLabel.Size = new System.Drawing.Size(478, 13);
            this.InsertLabel.TabIndex = 12;
            this.InsertLabel.Text = "Insert this text:";
            // 
            // TitleDescriptionEdit
            // 
            this.TitleDescriptionEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleDescriptionEdit.Location = new System.Drawing.Point(2, 34);
            this.TitleDescriptionEdit.MenuManager = this.BarManager;
            this.TitleDescriptionEdit.Name = "TitleDescriptionEdit";
            this.TitleDescriptionEdit.Size = new System.Drawing.Size(478, 20);
            this.TitleDescriptionEdit.TabIndex = 0;
            // 
            // TitleDescriptionLabel
            // 
            this.TitleDescriptionLabel.AutoEllipsis = true;
            this.TitleDescriptionLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.TitleDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleDescriptionLabel.Location = new System.Drawing.Point(2, 21);
            this.TitleDescriptionLabel.Name = "TitleDescriptionLabel";
            this.TitleDescriptionLabel.Size = new System.Drawing.Size(478, 13);
            this.TitleDescriptionLabel.TabIndex = 10;
            this.TitleDescriptionLabel.Text = "If the title OR description of the message box is:";
            // 
            // KeyboardHookControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.KeyboardHookControlGroup);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Name = "KeyboardHookControl";
            this.Size = new System.Drawing.Size(482, 142);
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardHookControlGroup)).EndInit();
            this.KeyboardHookControlGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EnabledCheck.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InsertEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TitleDescriptionEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupControl KeyboardHookControlGroup;
        private CheckEdit EnabledCheck;
        private TextEdit InsertEdit;
        private LabelControl InsertLabel;
        private TextEdit TitleDescriptionEdit;
        private LabelControl TitleDescriptionLabel;
        private SimpleButton RemoveButton;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
    }
}