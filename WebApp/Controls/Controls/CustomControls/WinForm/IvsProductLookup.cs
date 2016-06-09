using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.BLL.Common;
using Ivs.DTO.Master;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsProductLookup : IvsDataLookUp
    {
        public string ItemGroupCode { get; set; }

        public string ItemType { get; set; }

        public IvsProductLookup()
        {
            this.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
        }

        protected override void FillData()
        {
            //Select item data
            DataTable dtResult = new DataTable();
            CommonBl commonBl = new CommonBl();
            MS_ItemDto itemDto = new MS_ItemDto()
            {
                GroupCode = this.ItemGroupCode,
                ItemType = this.ItemType
            };
            commonBl.SelectProductData(itemDto, out dtResult);

            if (dtResult.Columns.Count > 0)
            {
                if (this.HasNull)
                {
                    DataRow newRow = dtResult.NewRow();
                    newRow[1] = CommonData.StringEmpty;
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
