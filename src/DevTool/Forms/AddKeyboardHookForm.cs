// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevTool.Forms
{
    public sealed partial class AddKeyboardHookForm : XtraForm
    {
        #region Properties and Constructors

        public string DisplayName { get; private set; }

        public string TitleOrDescription { get; private set; }

        public string InsertText { get; private set; }

        public AddKeyboardHookForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        private void AddKeyboardHookForm_Shown(object sender, EventArgs e) { ActiveControl = DisplayNameEdit; }

        private void DisplayNameEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || string.IsNullOrWhiteSpace(DisplayNameEdit.Text) || string.IsNullOrWhiteSpace(TitleDescriptionEdit.Text) || string.IsNullOrWhiteSpace(InsertEdit.Text)) return;
            DisplayName = DisplayNameEdit.Text;
            TitleOrDescription = TitleDescriptionEdit.Text;
            InsertText = InsertEdit.Text;
            Close();
        }

        private void TitleDescriptionEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || string.IsNullOrWhiteSpace(DisplayNameEdit.Text) || string.IsNullOrWhiteSpace(TitleDescriptionEdit.Text) || string.IsNullOrWhiteSpace(InsertEdit.Text)) return;
            DisplayName = DisplayNameEdit.Text;
            TitleOrDescription = TitleDescriptionEdit.Text;
            InsertText = InsertEdit.Text;
            Close();
        }

        private void InsertEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || string.IsNullOrWhiteSpace(DisplayNameEdit.Text) || string.IsNullOrWhiteSpace(TitleDescriptionEdit.Text) || string.IsNullOrWhiteSpace(InsertEdit.Text)) return;
            DisplayName = DisplayNameEdit.Text;
            TitleOrDescription = TitleDescriptionEdit.Text;
            InsertText = InsertEdit.Text;
            Close();
        }

        #endregion
    }
}