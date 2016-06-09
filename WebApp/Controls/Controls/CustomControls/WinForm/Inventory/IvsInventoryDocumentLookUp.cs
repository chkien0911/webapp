using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;

using Ivs.BLL.Common;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    public partial class IvsInventoryDocumentLookUp : IvsDataLookUp
    {
        public string Warehouse { get; set; }
        public int TransactionType { get; set; }
        public string TransactionSubCode { get; set; }
        protected override void FillData()
        {
            DataTable dtResult = new DataTable();
            CommonBl commonBl = new CommonBl();
            commonBl.SelectDocumentByWarehouse(out  dtResult, TransactionType, TransactionSubCode, Warehouse);
            if (dtResult.Columns.Count > 0)
            {
                if (this.HasNull)
                    dtResult.Rows.InsertAt(dtResult.NewRow(), 0);
            }

            this.Properties.DataSource = dtResult;
        }

        protected override void SetLanguage()
        {
            this.Properties.Columns.Clear();
            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.DocumentNumber);
            columnCode.Caption = string.Empty;
            this.Properties.Columns.Add(columnCode);
            this.Properties.DisplayMember = CommonKey.DocumentNumber;
            this.Properties.ValueMember = CommonKey.DocumentNumber;
            this.Properties.BestFitWidth = 125;
        }
    }
}
