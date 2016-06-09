using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class StockUserControl : IvsUserControl
    {
        #region Properties

        public bool IsFocusControl { get; set; }

        private CommonData.Mode _viewMode = CommonData.Mode.New;

        public CommonData.Mode ViewMode
        {
            get
            {
                return _viewMode;
            }
            set
            {
                _viewMode = value;
            }
        }

        #endregion Properties

        public StockUserControl()
        {
            InitializeComponent();

            this.AutoScroll = true;
        }
    }
}