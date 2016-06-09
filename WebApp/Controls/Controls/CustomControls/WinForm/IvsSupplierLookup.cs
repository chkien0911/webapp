using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsSupplierLookup : IvsDataLookUp
    {
        private DataTable dtNewSource = new DataTable();

        public IvsSupplierLookup()
        {
        }

        protected override void FillData()
        {
            //Select supplier data
            DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            commonBl.SelectDataForControl(CommonData.FunctionGr.MS_Suppliers, out dtResult);

            if (dtResult.Columns.Count > 0)
            {
                if (this.HasNull)
                {
                    DataRow newRow = dtNewSource.NewRow();
                    newRow[0] = CommonData.StringEmpty;

                    dtNewSource.Rows.InsertAt(newRow, 0);
                }
            }

            this.Properties.DataSource = dtNewSource;
            this.EditValue = CommonData.StringEmpty;
            this.SetLanguage();
        }
    }
}