using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.DTO.Master;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsEmployeeLookUp : IvsDataLookUp
    {
        public string DepartmentCode { get; set; }

        private DataTable dtNewSource = new DataTable();

        public IvsEmployeeLookUp()
        {
        }

        protected override void FillData()
        {
            //Select employees data
            DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            MS_EmployeeDto empDto = new MS_EmployeeDto()
            {
                DepartmentCode = this.DepartmentCode,
            };
            commonBl.SelectEmployeeData(empDto, out dtResult);

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