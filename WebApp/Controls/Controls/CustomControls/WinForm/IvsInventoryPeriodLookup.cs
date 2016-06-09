using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.DTO.Stock;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsInventoryPeriodLookup : IvsDataLookUp
    {
        public string ProcessingFlg { get; set; }
        public int NumberOfRow { get; set; }
        public bool OrderByDesc { get; set; }
        public bool LessOrEqualCurrentPeriod { get; set; }

        protected override void FillData()
        {
            DataTable dtResult = new System.Data.DataTable();
            CommonBl commonBl = new CommonBl();
            ST_MontlyProcessDto aa = new ST_MontlyProcessDto()
            {
                ProcessingFlg = this.ProcessingFlg,
                NumberOfRow = this.NumberOfRow,
                OrderByDesc = this.OrderByDesc,
                LessOrEqualCurrentPeriod = this.LessOrEqualCurrentPeriod,
            };
            commonBl.SelectInventoryPeriodDataForControl(aa, out dtResult);

            
            if (this.HasNull && dtResult.Columns.Count > 0)
            {
                DataRow newRow = dtResult.NewRow();
                //newRow[0] = CommonData.StringEmpty;
                dtResult.Rows.InsertAt(newRow, 0);
            }

            this.Properties.DataSource = dtResult;
            this.Properties.NullText = CommonData.StringEmpty;
            //this.EditValue = CommonData.StringEmpty;
            //this.Properties.NullText = CommonData.StringEmpty;
        }
    }
}
