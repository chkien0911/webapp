using System.Windows.Forms;
using Ivs.Core.Interface;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsReportFilter : UserControl
    {
        public IvsReportFilter()
        {
            InitializeComponent();
        }

        protected virtual IDto Dto
        {
            get;
            set;
        }

        public IDto GetIDto
        {
            get
            {
                return Dto;
            }
        }
    }
}