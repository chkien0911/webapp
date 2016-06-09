using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Ivs.Core.Common;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsUnitLookup : IvsDataLookUp
    {
        private string _displayMemb = CommonKey.Code;
        [DefaultValue(CommonKey.Code)]
        public string DisplayValue
        {
            get
            {
                return _displayMemb;
            }
            set
            {
                _displayMemb = value;
            }
        }

        protected override void SetLanguage()
        {
            this.Properties.Columns.Clear();

            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
            IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
            this.Properties.Columns.Add(columnCode);
            this.Properties.Columns.Add(columnName);
            this.Properties.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
            this.Properties.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
            this.Properties.DisplayMember = this.DisplayValue;
            this.Properties.ValueMember = CommonKey.Code;
        }
    }
}
