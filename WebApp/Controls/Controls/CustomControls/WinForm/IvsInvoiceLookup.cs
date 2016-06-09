using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ivs.BLL.Business;
using Ivs.DTO.Common;
using Ivs.Core.Common;
using System.Data;
using Ivs.BLL.Common;
using Ivs.DTO.Invoice;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsInvoiceLookup : IvsDataLookUp
    {
        public string CompanyCode { get; set; }
        public string Status { get; set; }

        protected override void FillData()
        {
            DataTable dtResult = new DataTable();
            CommonBl commonBl = new CommonBl();
            INV_InvoiceHeaderDto dto = new INV_InvoiceHeaderDto();
            dto.Status = this.Status;
            dto.CompanyCode = this.CompanyCode;
            commonBl.SelectInvoiceData(dto, out dtResult);

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

            //base.FillData();
        }

    }
}
