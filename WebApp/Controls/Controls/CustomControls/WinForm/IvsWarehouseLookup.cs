using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.DTO.Master;
using Ivs.BLL.Systems;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsWarehouseLookup : IvsDataLookUp
    {
        private string _status = CommonData.Status.Enable;
        [DefaultValue(CommonData.Status.Enable)]
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public bool CheckAuthorization { get; set; }

        protected override void FillData()
        {
            if (this.CheckAuthorization)
            {
                DataTable dtResult = new System.Data.DataTable();
                CommonBl commonBl = new CommonBl();
                commonBl.SelectWarehouseByUser(UserSession.UserCode, out dtResult);

                if (dtResult.Columns.Count > 0)
                {
                    if (this.HasNull)
                    {
                        DataRow newRow = dtResult.NewRow();
                        //newRow[CommonKey.Code] = CommonData.StringEmpty;
                        //newRow[CommonKey.Name1] = "Tất cả";
                        //newRow[CommonKey.Name2] = "All";
                        //newRow[CommonKey.Name3] = "All";
                        //newRow[CommonKey.Name] = UserSession.LangId.Equals(CommonData.Language.English)
                        //            ? "All"
                        //            : UserSession.LangId.Equals(CommonData.Language.VietNamese)
                        //                ? "Tất cả"
                        //                : "All";

                        dtResult.Rows.InsertAt(newRow, 0);
                    }
                }

                this.Properties.DataSource = dtResult;
                this.Properties.NullText = CommonData.StringEmpty;
            }
            else
            {
                DataTable dtResult = new DataTable();
                CommonBl commonBl = new CommonBl();
                MS_WarehouseDTO dto = new MS_WarehouseDTO()
                {
                    Status = this.Status,
                };
                commonBl.SelectWarehouseData(dto, out dtResult);

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
                //base.FillData();
            }
        }
    }
}
