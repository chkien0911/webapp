using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.DTO.Master;
using System.ComponentModel;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsCompanyLookup : IvsDataLookUp
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

        public string IsCustomer { get; set; }
        public string IsSupplier { get; set; }
        public string IsVendor { get; set; }

        public IvsCompanyLookup()
        {
            this.Properties.PopupWidth = 400;
        }

        protected override void FillData()
        {
            DataTable dtResult = new DataTable();
            CommonBl commonBl = new CommonBl();
            MS_CompanyDto dto = new MS_CompanyDto()
            {
                IsCustomer = this.IsCustomer,
                IsSupplier = this.IsSupplier,
                IsVendor = this.IsVendor,
                Status = this.Status,
            };
            commonBl.SelectCompanyData(dto, out dtResult);

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
        }

        protected override void SetLanguage()
        {
            this.Properties.Columns.Clear();

            if (UserSession.LangId == null)
            {
                IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                columnCode.Width = 100;
                IvsLookUpColumnInfo columnName2 = new IvsLookUpColumnInfo(CommonKey.Name2);
                columnName2.Width = 300;
                this.Properties.Columns.Add(columnCode);
                this.Properties.Columns.Add(columnName2);
                this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                this.Properties.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                this.Properties.DisplayMember = CommonKey.Name2;
                this.Properties.ValueMember = CommonData.CommonCode;
            }
            else
            {
                if (UserSession.LangId.Equals((CommonData.Language.VietNamese)))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                    columnCode.Width = 100;
                    IvsLookUpColumnInfo columnName1 = new IvsLookUpColumnInfo(CommonKey.Name1);
                    columnName1.Width = 300;
                    this.Properties.Columns.Add(columnCode);
                    this.Properties.Columns.Add(columnName1);
                    this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                    this.Properties.Columns[CommonKey.Name1].Caption = CommonData.StringEmpty;
                    this.Properties.DisplayMember = CommonKey.Name1;
                    this.Properties.ValueMember = CommonData.CommonCode;
                }
                else if (UserSession.LangId.Equals((CommonData.Language.English)))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                    columnCode.Width = 100;
                    IvsLookUpColumnInfo columnName2 = new IvsLookUpColumnInfo(CommonKey.Name2);
                    columnName2.Width = 300;
                    this.Properties.Columns.Add(columnCode);
                    this.Properties.Columns.Add(columnName2);
                    this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                    this.Properties.Columns[CommonKey.Name2].Caption = CommonData.StringEmpty;
                    this.Properties.DisplayMember = CommonKey.Name2;
                    this.Properties.ValueMember = CommonData.CommonCode;
                }
                else if (UserSession.LangId.Equals((CommonData.Language.Japanese)))
                {
                    IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonData.CommonCode);
                    columnCode.Width = 100;
                    IvsLookUpColumnInfo columnName3 = new IvsLookUpColumnInfo(CommonKey.Name3);
                    columnName3.Width = 300;
                    this.Properties.Columns.Add(columnCode);
                    this.Properties.Columns.Add(columnName3);
                    this.Properties.Columns[CommonData.CommonCode].Caption = CommonData.StringEmpty;
                    this.Properties.Columns[CommonKey.Name3].Caption = CommonData.StringEmpty;
                    this.Properties.DisplayMember = CommonKey.Name3;
                    this.Properties.ValueMember = CommonData.CommonCode;
                }
            }
        }
    }
}
