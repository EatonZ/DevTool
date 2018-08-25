// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using DevExpress.XtraEditors;
using System;

namespace DevTool.Controls
{
    public sealed partial class KeyboardHookControl : XtraUserControl
    {
        #region Properties and Constructors

        public string DisplayName
        {
            get { return KeyboardHookControlGroup.Text; }
            set { KeyboardHookControlGroup.Text = value; }
        }

        public string TitleOrDescription
        {
            get { return TitleDescriptionEdit.Text; }
            set { TitleDescriptionEdit.Text = value; }
        }

        public string InsertText
        {
            get { return InsertEdit.Text; }
            set { InsertEdit.Text = value; }
        }

        public bool Enabled
        {
            get { return EnabledCheck.Checked; }
            set { EnabledCheck.Checked = value; }
        }

        public KeyboardHookControl(string DisplayName, string TitleOrDescription, string InsertText)
        {
            InitializeComponent();
            KeyboardHookControlGroup.Text = DisplayName;
            TitleDescriptionEdit.Text = TitleOrDescription;
            InsertEdit.Text = InsertText;
        }

        #endregion

        #region Events

        private void RemoveButton_Click(object sender, EventArgs e) { Dispose(); }

        #endregion
    }
}