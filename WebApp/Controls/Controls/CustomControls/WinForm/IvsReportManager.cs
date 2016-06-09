using System.Windows.Forms;
using DevExpress.XtraPrinting;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsReportManager : UserControl
    {
        public IvsReportManager()
        {
            InitializeComponent();
        }

        private IvsReport _report;
        public IvsReport Report
        {
            get { return _report; }
            set
            {
                if (_report != value)
                {
                    if (_report != null)
                        _report.Dispose();
                    _report = value;
                    if (_report == null)
                        return;
                    Invalidate();
                    Update();

                    this.ivsPrintCtrl.PrintingSystem = _report.PrintingSystem;
                    _report.PrintingSystem.SetCommandVisibility(PrintingSystemCommand.ClosePreview, DevExpress.XtraPrinting.CommandVisibility.None);
                    //_report.CreateDocument(true);
                }
            }
        }
        public void ShowReport()
        {
            if (this.Report != null)
            {
                Report.CreateDocument(true);
            }
        }

        // Start add by Nguyen Thai An on 30/7/2013 for DMP project
        public void ReCreate()
        {
            if (Report != null)
            {
                Report = new IvsReport();
            }
        }
        // End add by Nguyen Thai An on 30/7/2013 for DMP project
    }
}