// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using System.Windows.Forms;
using DevExpress.XtraEditors;
using System;

namespace DevTool.Forms
{
    public sealed partial class TextInputForm : XtraForm
    {
        #region Properties and Contrusctors

        public string Input { get; private set; }

        public TextInputForm(string TitleAndLabel, int Limit = 0, string Text = "")
        {
            InitializeComponent();
            if (Limit < 0) Limit = 0;
            if (Limit > 0 && Text.Length > Limit) throw new Exception("TextInputForm: Invalid parameters.");
            this.Text = TitleAndLabel;
            TextInfoLabel.Text = TitleAndLabel + ".";
            TextEdit.Properties.MaxLength = Limit;
            TextEdit.Text = Text;
            TextLengthWarningLabel.Visible = Limit > 0;
        }

        #endregion

        #region Events

        private void TextInputForm_Shown(object sender, EventArgs e) { ActiveControl = TextEdit; }

        private void TextEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter || string.IsNullOrWhiteSpace(TextEdit.Text)) return;
            Input = TextEdit.Text;
            Close();
        }

        private void TextEdit_TextChanged(object sender, EventArgs e)
        {
            if (TextEdit.Properties.MaxLength <= 0) return;
            TextLengthWarningLabel.Text = Convert.ToInt32(TextEdit.Properties.MaxLength - TextEdit.Text.Length) + " characters remaining.";
        }

        #endregion
    }
}