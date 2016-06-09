using System.Collections.Generic;
using System.Reflection;
using Ivs.BLL.Common;
using Ivs.Controls.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IVSForm : DevExpress.XtraEditors.XtraForm
    {
        public virtual Dictionary<object, string> LstControls { get; set; }

        protected string baseName = "Ivs.Core.Properties.COM_MSG_{0}";

        protected virtual string FunctionId
        {
            get;
            set;
        }

        protected virtual string FunctionGr
        {
            get;
            set;
        }

        protected static ProcessingForm processingForm;

        #region Constructor

        public IVSForm()
        {
            LstControls = new Dictionary<object, string>();
            LanguageUltility.SetMessageLanguage(baseName, Assembly.GetAssembly(typeof(LanguageUltility)), UserSession.LangId ?? CommonData.Language.English);
        }

        #endregion Constructor

        /// <summary>
        /// Set authority for screen
        /// </summary>
        protected virtual CommonData.IsAuthority IsAuthority(string operId)
        {
            CommonData.IsAuthority returnCode = CommonData.IsAuthority.Allow;
            CommonBl commonBl = new CommonBl();
            returnCode = commonBl.CheckAuthority(this.FunctionGr, CommonData.OperId.All);
            if (returnCode == CommonData.IsAuthority.Deny)
            {
                returnCode = commonBl.CheckAuthority(this.FunctionGr, operId);
            }

            return returnCode;
        }

        /// <summary>
        /// Set authority for screen
        /// </summary>
        protected virtual CommonData.IsAuthority IsAuthority(string functionGr, string operId)
        {
            CommonData.IsAuthority returnCode = CommonData.IsAuthority.Allow;
            CommonBl commonBl = new CommonBl();
            returnCode = commonBl.CheckAuthority(functionGr, CommonData.OperId.All);
            if (returnCode == CommonData.IsAuthority.Deny)
            {
                returnCode = commonBl.CheckAuthority(functionGr, operId);
            }

            return returnCode;
        }

        public virtual string ProcessDbExcetion(int returnCode)
        {
            MessageBoxs msg = new MessageBoxs();
            IvsMessage message = null;
            switch (returnCode)
            {
                case CommonData.DbReturnCode.AccessDenied:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.InvalidHost:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_INVALID_HOST);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.InvalidDatabase:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_INVALID_DATABASE);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.LostConnection:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_CONNECTION_LOST);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.DuplicateKey:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_DUPPLICATE_KEY);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.ForgeignKeyNotExist:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FOREIGN_KEY_NOT_EXIST);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.ForeignKeyViolation:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FOREIGN_KEY_VIOLATION);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.DataNotFound:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_DATA_NOT_FOUND);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.DeadlockFound:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_DEADLOCK_FOUND);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.LockWaitTimeoutExceeded:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_LOCK_WAIT_TIMEOUT_EXCEEDED);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.ExceptionOccured:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_GENERAL_EXCEPTION);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;

                case CommonData.DbReturnCode.ConcurrencyViolation:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_CONCURRENCY_VIOLATION);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    break;
            }
            return msg.DisplayMessage;
        }

        public virtual string ProcessCommonExcetion(int returnCode)
        {
            MessageBoxs msg = new MessageBoxs();
            IvsMessage message = null;
            switch (returnCode)
            {
                case CommonData.ImportReturnCode.PathNotExist:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_DATA_OR_FILE_NOT_FOUND);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.ImportReturnCode.FileFormatInvalid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FILE_FORMAT_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.ImportReturnCode.NumRowInvalid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FILE_NUM_OF_ROW_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.ImportReturnCode.NumFieldInvalid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FILE_NUM_OF_COLUMN_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.ImportReturnCode.SystemError:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_GENERAL_EXCEPTION);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.IOReturnCode.PrinterInValid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_PRINTER_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.IOReturnCode.RPCServerUnavailable:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_RPC_SERVER_UNAVAILABLE);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;

                case CommonData.IOReturnCode.AccessDenied:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);
                    break;
                case CommonData.IOReturnCode.CancelExport:
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_EXPORT_NOT_FLOW);
                    message.MessageIcon = CommonData.MessageIcon.Error;
                    msg.Add(message);
                  
                    msg.Display(CommonData.MessageType.Ok);
                    break;
            }
            return msg.DisplayMessage;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // IVSForm
            //
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Name = "IVSForm";
            this.ResumeLayout(false);
        }

        protected virtual void SetAuthorityControl()
        {
        }

        /// <summary>
        /// Validate input control when save data
        /// Child form will override this method
        /// </summary>
        protected virtual CommonData.IsValid ValidateData()
        {
            return CommonData.IsValid.Successful;
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected void ShowProgressBar()
        {
            IvsSplashScreenManager.CloseForm(false);
            IvsSplashScreenManager.ShowForm(this, typeof(ProgressBarForm), true, false, false);
        }

        protected void HideProgressBar()
        {
            IvsSplashScreenManager.CloseForm(false);
        }

        public virtual void InitLanguage(string lang, bool isSetCulture = true)
        {
            //LanguageUltility.ChangeLanguage("Ivs.Core.Properties.COM_MSG_{0}", Assembly.GetAssembly(typeof(LanguageUltility)), this, UserSession.LangId);
            LanguageUltility.ChangeLanguage(baseName, Assembly.GetAssembly(typeof(LanguageUltility)), this, LstControls, lang ?? UserSession.LangId, isSetCulture);
            this.Text = LanguageUltility.GetString(this.Name, "Message");
            //this.Invalidate();
        }
    }
}