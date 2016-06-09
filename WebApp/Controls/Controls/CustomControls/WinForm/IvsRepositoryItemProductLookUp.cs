using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.DTO.Common;
using Ivs.DTO.Master;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsRepositoryItemProductLookUp : IvsRepositoryItemDataLookUp
    {
        private DataTable dtNewSource = new DataTable();

        public string ItemType { get; set; }

        public string DocumentNo { get; set; }

        protected override void FillData()
        {
            if (CommonMethod.IsNullOrEmpty(this.ItemType) && CommonMethod.IsNullOrEmpty(this.DocumentNo))
            {
                base.FillData();
            }
            else
            {
                CommonBl commonBl = new CommonBl();
                if (!CommonMethod.IsNullOrEmpty(this.ItemType))
                {
                    MS_ItemDto itemDto = new MS_ItemDto()
                    {
                        ItemType = this.ItemType,
                    };

                    commonBl.SelectItemData(itemDto, out dtNewSource);
                }
                if (!CommonMethod.IsNullOrEmpty(this.DocumentNo))
                {
                    ST_StockTransactionDetailDto stockDetailDto = new ST_StockTransactionDetailDto()
                    {
                        DocumentNumber = this.DocumentNo,
                    };

                    commonBl.SelectItemDataByDocument(stockDetailDto, out dtNewSource);
                }

                if (dtNewSource.Columns.Count > 0)
                {
                    if (this.HasNull)
                    {
                        dtNewSource.Rows.InsertAt(dtNewSource.NewRow(), 0);
                    }
                }

                this.DataSource = dtNewSource;
                // this.EditValue = CommonData.StringEmpty;
                this.NullText = CommonData.StringEmpty;
            }
        }
    }
}