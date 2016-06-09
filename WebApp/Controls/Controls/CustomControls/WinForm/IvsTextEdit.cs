/* =========================================
 * Author: NHKhuong
 * Create Date: 2012/09/20
 ========================================= */

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsTextEdit : DevExpress.XtraEditors.TextEdit
    {
        #region Pirvate Variables

        //An instance of error provider
        private IvsErrorProvider _errorProvider = new IvsErrorProvider();

        #endregion Pirvate Variables

        #region override property

        public override string Text
        {
            get
            {
                return base.Text.Trim();
            }
            set
            {
                base.Text = value;
            }
        }

        #endregion override property

        #region Format TextEdit

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
                    this.Properties.Mask.EditMask = "\\d+";
                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
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
                    this.Properties.Mask.EditMask = "(((100)|((100)(\\.00))|\\d{0,2}|\\d{0,2}\\.\\d{0,2})|(0))";
                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                }
            }
        }

        private bool _isNumOfDay = false;

        public bool IsNumOfDay
        {
            get
            {
                return _isNumOfDay;
            }
            set
            {
                _isNumOfDay = value;
                if (_isNumOfDay == true)
                {
                    this.Properties.Mask.EditMask = "(\\d{1,3}|(\\d{1,3}(\\.5))|(0))";
                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
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
                    this.Properties.Mask.EditMask = "###,###,###,###,##0;";
                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
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
                        this.Properties.Mask.EditMask = string.Concat("n", _numOfDecimalPlaces.ToString());
                        this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                        this.Properties.Mask.UseMaskAsDisplayFormat = true;
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
                if (_isNumberic == true)
                {
                    this.Properties.Mask.EditMask = string.Concat("n", _numOfDecimalPlaces.ToString());
                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
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
                    this.Properties.Mask.EditMask = "###,###,###,###,##0.00;";
                    this.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                    this.Properties.Mask.UseMaskAsDisplayFormat = true;
                }
            }
        }

        #endregion Format TextEdit

        #region Methods About Setting Message

        /// <summary>
        /// Set error IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set warning IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetWarning(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set information IvsMessage and icon for textbox control
        /// </summary>
        /// <param name="messageText">
        /// Content of message
        /// </param>
        public void SetInfo(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        #endregion Methods About Setting Message

        #region Methods About Clearing Message

        /// <summary>
        ///Clear error IvsMessage and icon for textbox control
        /// </summary>
        public void ClearErrors()
        {
            if (_errorProvider.HasErrors)
            {
                _errorProvider.ClearErrors();
            }
        }

        #endregion Methods About Clearing Message
    }
}