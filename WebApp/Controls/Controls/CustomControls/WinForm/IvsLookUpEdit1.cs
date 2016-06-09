/* =========================================
 * Author:      NNHieu
 * Create Date: 2012/08/28
 * Reviser:     NHKhuong
 * Revise Date: 2012/09/11
 ========================================= */

using DevExpress.XtraEditors.Controls;
using System.ComponentModel;
namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsLookUpEdit1 : DevExpress.XtraEditors.LookUpEdit
    {
        #region Private Variables

        protected IvsErrorProvider _errorProvider = new IvsErrorProvider();

        #endregion Private Variables

        #region Propertis

        //private bool _showReload = false;
        //[DefaultValue(false)]
        //public bool ShowReload 
        //{
        //    get
        //    {
        //        return _showReload;
        //    }
        //    set
        //    {
        //        _showReload = value;
        //        if (_showReload)
        //        {
        //            EditorButton reloadButton = new EditorButton(ButtonPredefines.Redo);
        //            int numOfButton = this.Properties.Buttons.VisibleCount;
        //            this.Properties.Buttons.Insert(numOfButton - 1, reloadButton);

        //            this.ButtonClick += new ButtonPressedEventHandler(IvsLookUpEdit1_ButtonClick);
        //        }
        //    } 
        //}

        #endregion

        #region Events

        //void IvsLookUpEdit1_ButtonClick(object sender, ButtonPressedEventArgs e)
        //{
        //    if (e.Button.Kind == ButtonPredefines.Redo)
        //    {
        //        this.ReloadData();
        //        return;
        //    }
        //    //else
        //    //{
        //    //    if (this.IsPopupOpen)
        //    //    {
        //    //        base.DoClosePopup(DevExpress.XtraEditors.PopupCloseMode.Normal);
        //    //    }
        //    //    else
        //    //    {
        //    //        this.DoShowPopup();
        //    //    }
        //    //}
        //}

        #endregion

        #region public Method

        /// <summary>
        /// Set error content to control
        /// </summary>
        /// <param name="messageText">
        /// Error content
        /// </param>
        public virtual void SetError(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.User1);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set warning content to control
        /// </summary>
        /// <param name="messageText">
        /// Warning content
        /// </param>
        public virtual void SetWarning(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        /// <summary>
        /// Set information content to control
        /// </summary>
        /// <param name="messageText">
        /// Information content
        /// </param>
        public virtual void SetInfo(string messageText)
        {
            _errorProvider.SetError(this, messageText, DevExpress.XtraEditors.DXErrorProvider.ErrorType.Information);
            _errorProvider.SetIconAlignment(this, System.Windows.Forms.ErrorIconAlignment.MiddleRight);
        }

        protected virtual void FillData()
        {

        }

        public virtual void ReloadData()
        {
            this.FillData();
        }

        #endregion public Method
    }
}