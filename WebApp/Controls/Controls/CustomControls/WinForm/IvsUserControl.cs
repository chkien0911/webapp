using System.ComponentModel;
using Ivs.Core.Common;
using Ivs.Core.Interface;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsUserControl : System.Windows.Forms.UserControl, Ivs.Core.Interface.IUserControl
    {
        #region Properties

        #region Properties

        private CommonData.Mode _viewMode = CommonData.Mode.New;

        public virtual CommonData.Mode ViewMode
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

        public virtual IDto ControlDto { get; private set; }

        public virtual IDto Dto { get; set; }

        #endregion Properties

        #region Construction

        public IvsUserControl()
        {
            InitializeComponent();
        }

        public IvsUserControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion Construction

        #region Abtract methods

        public virtual void SetLanguage()
        {
        }

        public virtual void Reset()
        {
        }

        public virtual void InitControl()
        {
        }

        public virtual void LoadControlData()
        {
        }


        public virtual void SetControl()
        {
        }

        public virtual void ClearError()
        {
        }

        public virtual void SetError(string errorFieldName, string errorText)
        {
        }

        public virtual void SetError(int errorRowIndex, string errorFieldName, string errorText)
        {
        }

        #endregion Abtract methods
    }
}