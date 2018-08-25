// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System;
using System.Text;
using DevExpress.XtraEditors;

namespace DevTool.Forms
{
    public sealed partial class TextDisplayForm : XtraForm
    {
        #region Constructors

        public TextDisplayForm(string FormTitle, StringBuilder DisplayContents)
        {
            InitializeComponent();
            Text = FormTitle;
            TextDisplayMemo.Text = DisplayContents.ToString();
        }

        #endregion

        #region Events

        private void TextDisplayForm_Shown(object sender, EventArgs e) { ActiveControl = null; }

        #endregion
    }
}