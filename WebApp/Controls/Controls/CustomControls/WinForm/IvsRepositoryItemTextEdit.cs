using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsRepositoryItemTextEdit : DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    {
        #region Format RepositoryItemTextEdit

        private string _langID;

        private bool _isPositiveNumber = false;

        public bool IsPositiveNumber
        {
            get
            {
                return _isPositiveNumber;
            }
            set
            {
                _isPositiveNumber = value;
                if (_isPositiveNumber == true)
                {
                    this.Mask.EditMask = "\\d+";
                    this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                }
            }
        }

        private bool _isPositivePercentage = false;

        public bool IsPositivePercentage
        {
            get
            {
                return _isPositivePercentage;
            }
            set
            {
                _isPositivePercentage = value;
                if (_isPositivePercentage == true)
                {
                    this.Mask.EditMask = "(((100)|((100)(\\.00))|\\d{0,2}|\\d{0,2}\\.\\d{0,2})|(0))";
                    this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                }
            }
        }

        private bool _isCurrency = false;

        public bool IsCurrency
        {
            get
            {
                return _isCurrency;
            }
            set
            {
                _isCurrency = value;
                if (_isCurrency == true)
                {
                    this.Mask.EditMask = "###,###,###,###,##0;";
                    this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                }
            }
        }

        private int _numOfDecimalPlaces = 0;

        public int NumOfDecimalPlaces
        {
            get
            {
                return _numOfDecimalPlaces;
            }
            set
            {
                if (value >= 0)
                {
                    _numOfDecimalPlaces = value;
                    if (IsNumberic)
                    {
                        this.Mask.EditMask = string.Concat("n", _numOfDecimalPlaces.ToString());
                        this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.Mask.UseMaskAsDisplayFormat = true;
                    }
                }
            }
        }

        private bool _isNumberic = false;

        public bool IsNumberic
        {
            get
            {
                return _isNumberic;
            }
            set
            {
                _isNumberic = value;
                if (_isNumberic)
                {
                    this.Mask.EditMask = string.Concat("n", NumOfDecimalPlaces.ToString());
                    this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.Mask.UseMaskAsDisplayFormat = true;
                }
            }
        }

        private bool _isPositiveNumberic = false;
        public bool IsPositiveNumberic
        {
            get
            {
                return _isPositiveNumberic;
            }
            set
            {
                _isPositiveNumberic = value;
                if (_isPositiveNumberic == true)
                {
                    this.Mask.EditMask = "###,###,###,###,##0.00;";
                    this.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.Mask.UseMaskAsDisplayFormat = true;
                }
            }
        }

        /// <summary>
        /// Setting Culture for display and store Name
        /// </summary>
        public void Reset()
        {
            _langID = UserSession.LangId;
            CultureInfo cultureInfo = new CultureInfo();
            this.Mask.EditMask = cultureInfo.NameFormatPattern;
        }

        #endregion Format RepositoryItemTextEdit
    }
}