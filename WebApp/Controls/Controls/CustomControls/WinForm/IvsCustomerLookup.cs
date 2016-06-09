using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsCustomerLookup : IvsDataLookUp
    {
        private DataTable dtNewSource = new DataTable();

        public IvsCustomerLookup()
        {
        }

        protected override void FillData()
        {
            //Select customers data
            DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            commonBl.SelectDataForControl(CommonData.FunctionGr.MS_Customers, out dtResult);

            if (dtResult.Columns.Count > 0)
            {
                if (this.HasNull)
                {
                    DataRow newRow = dtResult.NewRow();
                    //newRow[0] = CommonData.StringEmpty;

                    dtResult.Rows.InsertAt(newRow, 0);
                }
            }

            this.Properties.DataSource = dtResult;
            this.Properties.NullText = CommonData.StringEmpty;
            //this.EditValue = CommonData.StringEmpty;
            //this.SetLanguage();
        }
    }
}