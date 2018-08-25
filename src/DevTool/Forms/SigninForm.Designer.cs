using System.ComponentModel;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

namespace DevTool.Forms
{
    partial class SigninForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SigninForm));
            this.SigninInfoLabel = new DevExpress.XtraEditors.LabelControl();
            this.SigninTileControl = new DevExpress.XtraEditors.TileControl();
            this.SigninTileGroup = new DevExpress.XtraEditors.TileGroup();
            this.ProfileRightClickMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.ViewAccountInfoItem = new DevExpress.XtraBars.BarButtonItem();
            this.ViewGamertagItem = new DevExpress.XtraBars.BarButtonItem();
            this.CopyOnlineXUIDItem = new DevExpress.XtraBars.BarButtonItem();
            this.CopyOfflineXUIDItem = new DevExpress.XtraBars.BarButtonItem();
            this.DeleteProfileItem = new DevExpress.XtraBars.BarButtonItem();
            this.BarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.ProfileRightClickMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).BeginInit();
            this.SuspendLayout();
            // 
            // SigninInfoLabel
            // 
            this.SigninInfoLabel.AutoEllipsis = true;
            this.SigninInfoLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.SigninInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SigninInfoLabel.Location = new System.Drawing.Point(0, 0);
            this.SigninInfoLabel.Name = "SigninInfoLabel";
            this.SigninInfoLabel.Size = new System.Drawing.Size(616, 13);
            this.SigninInfoLabel.TabIndex = 0;
            this.SigninInfoLabel.Text = "Before you can use XBL Center, you must sign in to one of your profiles. Only val" +
    "id XBL enabled profiles will be listed.";
            // 
            // SigninTileControl
            // 
            this.SigninTileControl.AllowDrag = false;
            this.SigninTileControl.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.SigninTileControl.AppearanceText.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SigninTileControl.AppearanceText.Options.UseFont = true;
            this.SigninTileControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SigninTileControl.Groups.Add(this.SigninTileGroup);
            this.SigninTileControl.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.SigninTileControl.ItemSize = 127;
            this.SigninTileControl.Location = new System.Drawing.Point(0, 13);
            this.SigninTileControl.MaxId = 6;
            this.SigninTileControl.Name = "SigninTileControl";
            this.SigninTileControl.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollButtons;
            this.SigninTileControl.ShowText = true;
            this.SigninTileControl.Size = new System.Drawing.Size(616, 209);
            this.SigninTileControl.TabIndex = 0;
            this.SigninTileControl.Text = "Profiles";
            this.SigninTileControl.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // SigninTileGroup
            // 
            this.SigninTileGroup.Name = "SigninTileGroup";
            this.SigninTileGroup.Text = null;
            // 
            // ProfileRightClickMenu
            // 
            this.ProfileRightClickMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ViewAccountInfoItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.ViewGamertagItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.CopyOnlineXUIDItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.CopyOfflineXUIDItem),
            new DevExpress.XtraBars.LinkPersistInfo(this.DeleteProfileItem, true)});
            this.ProfileRightClickMenu.Manager = this.BarManager;
            this.ProfileRightClickMenu.Name = "ProfileRightClickMenu";
            this.ProfileRightClickMenu.ShowCaption = true;
            // 
            // ViewAccountInfoItem
            // 
            this.ViewAccountInfoItem.Caption = "View Account Information";
            this.ViewAccountInfoItem.Id = 17;
            this.ViewAccountInfoItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ViewAccountInfoItem.ImageOptions.Image")));
            this.ViewAccountInfoItem.Name = "ViewAccountInfoItem";
            this.ViewAccountInfoItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ViewAccountInfoItem_ItemClick);
            // 
            // ViewGamertagItem
            // 
            this.ViewGamertagItem.Caption = "View Gamertag";
            this.ViewGamertagItem.Id = 18;
            this.ViewGamertagItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ViewGamertagItem.ImageOptions.Image")));
            this.ViewGamertagItem.Name = "ViewGamertagItem";
            this.ViewGamertagItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ViewGamertagItem_ItemClick);
            // 
            // CopyOnlineXUIDItem
            // 
            this.CopyOnlineXUIDItem.Caption = "Copy Online XUID";
            this.CopyOnlineXUIDItem.Id = 19;
            this.CopyOnlineXUIDItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("CopyOnlineXUIDItem.ImageOptions.Image")));
            this.CopyOnlineXUIDItem.Name = "CopyOnlineXUIDItem";
            this.CopyOnlineXUIDItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CopyOnlineXUIDItem_ItemClick);
            // 
            // CopyOfflineXUIDItem
            // 
            this.CopyOfflineXUIDItem.Caption = "Copy Offline XUID";
            this.CopyOfflineXUIDItem.Id = 20;
            this.CopyOfflineXUIDItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("CopyOfflineXUIDItem.ImageOptions.Image")));
            this.CopyOfflineXUIDItem.Name = "CopyOfflineXUIDItem";
            this.CopyOfflineXUIDItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.CopyOfflineXUIDItem_ItemClick);
            // 
            // DeleteProfileItem
            // 
            this.DeleteProfileItem.Caption = "Delete";
            this.DeleteProfileItem.Id = 16;
            this.DeleteProfileItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("DeleteProfileItem.ImageOptions.Image")));
            this.DeleteProfileItem.Name = "DeleteProfileItem";
            this.DeleteProfileItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.DeleteProfileItem_ItemClick);
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
            this.BarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.DeleteProfileItem,
            this.ViewAccountInfoItem,
            this.ViewGamertagItem,
            this.CopyOnlineXUIDItem,
            this.CopyOfflineXUIDItem});
            this.BarManager.MaxItemId = 21;
            this.BarManager.UseAltKeyForMenu = false;
            this.BarManager.UseF10KeyForMenu = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(616, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 222);
            this.barDockControlBottom.Manager = this.BarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(616, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.BarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 222);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(616, 0);
            this.barDockControlRight.Manager = this.BarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 222);
            // 
            // SigninForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 222);
            this.Controls.Add(this.SigninTileControl);
            this.Controls.Add(this.SigninInfoLabel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SigninForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In";
            this.Shown += new System.EventHandler(this.SigninForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ProfileRightClickMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelControl SigninInfoLabel;
        private TileControl SigninTileControl;
        private TileGroup SigninTileGroup;
        private PopupMenu ProfileRightClickMenu;
        private BarManager BarManager;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarButtonItem DeleteProfileItem;
        private BarButtonItem ViewAccountInfoItem;
        private BarButtonItem ViewGamertagItem;
        private BarButtonItem CopyOnlineXUIDItem;
        private BarButtonItem CopyOfflineXUIDItem;
    }
}