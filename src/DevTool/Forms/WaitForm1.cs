// Copyright © Eaton Works 2011-2018. All rights reserved.
// License: https://github.com/EatonZ/DevTool/blob/master/LICENSE

using DevExpress.XtraWaitForm;

namespace DevTool.Forms
{
    public sealed partial class WaitForm1 : WaitForm
    {
        #region Constructors

        public WaitForm1()
        {
            InitializeComponent();
            ProgressPanel.AutoHeight = true;
        }

        #endregion

        #region Overrides

        public override void SetCaption(string Caption)
        {
            base.SetCaption(Caption);
            ProgressPanel.Caption = Caption;
        }
        public override void SetDescription(string Description)
        {
            base.SetDescription(Description);
            ProgressPanel.Description = Description;
        }

        #endregion
    }
}