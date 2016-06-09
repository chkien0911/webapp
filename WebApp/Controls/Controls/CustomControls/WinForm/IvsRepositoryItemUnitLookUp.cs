using System.Data;
using Ivs.BLL.Common;
using Ivs.Core.Common;
using Ivs.DTO.Common;
using Ivs.DTO.Master;
using System.ComponentModel;

namespace Ivs.Controls.CustomControls.WinForm
{
    public partial class IvsRepositoryItemUnitLookUp : IvsRepositoryItemDataLookUp
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
            this.Columns.Clear();

            IvsLookUpColumnInfo columnCode = new IvsLookUpColumnInfo(CommonKey.Code);
            IvsLookUpColumnInfo columnName = new IvsLookUpColumnInfo(CommonKey.Name);
            this.Columns.Add(columnCode);
            this.Columns.Add(columnName);
            this.Columns[CommonKey.Code].Caption = CommonData.StringEmpty;
            this.Columns[CommonKey.Name].Caption = CommonData.StringEmpty;
            this.DisplayMember = this.DisplayValue;
            this.ValueMember = CommonKey.Code;
        }
    }
}