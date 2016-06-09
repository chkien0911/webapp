using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ivs.Core.Common;
using System.Data;
using Ivs.BLL.Common;
using Ivs.DTO.Common;
using Ivs.DTO.Stock;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsCountSheetLookup : IvsDataLookUp
    {
        public string PhysicalInventoryStatus { get; set; }
        public string WarehouseCode { get; set; }
        public string Period { get; set; }

        protected override void FillData()
        {
            if (CommonMethod.IsNullOrEmpty(this.Period) && CommonMethod.IsNullOrEmpty(this.WarehouseCode))
            {
                base.FillData();
            }
            else
            {
                DataTable dtResult = new DataTable();
                CommonBl commonBl = new CommonBl();
                ST_CountSheetHeaderDto dto = new ST_CountSheetHeaderDto();
                dto.Period = this.Period;
                dto.WarehouseCode = this.WarehouseCode;
                dto.PhysicalInventoryStatus = this.PhysicalInventoryStatus;
                commonBl.SelectCountSheetData(dto, out dtResult);

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
            }
        }
    }
}
