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

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsDocumentNumberLookup : IvsDataLookUp
    {
        public bool CheckAuthorization { get; set; }
        public string SampleShippingFlg { get; set; }
        public string WarehouseCode { get; set; }
        public string CompanyCode { get; set; }
        public bool IsCompleted { get; set; }
        public string Period { get; set; }
        public string DocumentType { get; set; }
        public string TransactionSubCode { get; set; }

        private bool _orderByDesc = true;
        [DefaultValue(true)]
        public bool OrderByDesc 
        {
            get
            {
                return _orderByDesc;
            }
            set
            {
                _orderByDesc = value;
            }
        }

        protected override void FillData()
        {
            DataTable dtResult = new DataTable();
            CommonBl commonBl = new CommonBl();
            ST_StockTransactionMasterDto dto = new ST_StockTransactionMasterDto();
            dto.PeriodCdn = this.Period;
            dto.WarehouseCnd = this.WarehouseCode;
            dto.DocumentTypeCdn = this.DocumentType;
            dto.SampleShippingFlg = this.SampleShippingFlg;
            dto.TransactionSubCodeCnd = this.TransactionSubCode;
            dto.CompanyCodeCnd = this.CompanyCode;
            dto.IsCustomerCnd = this.IsCompleted;
            dto.OrderByDesc = this.OrderByDesc;

            commonBl.SelectDocumentData(dto, this.CheckAuthorization, out dtResult);

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
