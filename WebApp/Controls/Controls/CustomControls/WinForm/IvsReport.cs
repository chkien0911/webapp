using Ivs.Core.Interface;
namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsReport : DevExpress.XtraReports.UI.XtraReport
    {
        //private int AutoNumber { get; set; }
        //protected IvsReportTableCell AutoNumberCell { get; set; }

        //#region Default

        //private void InitializeComponent()
        //{
        //    this.BeforePrint +=new System.Drawing.Printing.PrintEventHandler(IvsReport_BeforePrint);
        //    ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        //}

        //void  IvsReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
        //    this.AutoNumber++;
        //    if (this.AutoNumberCell != null)
        //    {
        //        this.AutoNumberCell.Text = this.AutoNumber.ToString();
        //    }
        //}

        //#endregion

        //public IvsReport()
        //{
        //    this.InitializeComponent();
        //}

        public virtual void BindData()
        {
            return;
        }

        public virtual void BindHeader(IDto dto)
        {
            return;
        }
    }
}