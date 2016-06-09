using System;
using Ivs.Core.Common;
using Ivs.Core.Data;

namespace Ivs.Controls.Forms
{
    public partial class BackupForm : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        #region Private members

        private SYBK01Form backupScheduleForm = null;
        //protected Services.Services service = new Ivs.Core.Services.Services();

        #endregion Private members

        protected virtual bool isBackup
        {
            get
            {
                return true;
            }
        }

        protected override string FunctionId
        {
            get
            {
                return CommonData.FunctionId.SYBK00;
            }
        }

        protected override string FunctionGr
        {
            get
            {
                return CommonData.FunctionGr.Sybk;
            }
        }

        public BackupForm()
        {
            InitializeComponent();
            this.Name = "SYBK00Form";
            this.SetLanguage();
            this.SetAuthorityControlOnlyThis();

            #region Event Handle

            this.btnChoosePath.Click += new System.EventHandler(this.btnChoosePath_Click);
            this.btnAdvance.Click += new System.EventHandler(this.btnAdvance_Click);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnOK.Click += new System.EventHandler(this.BackupOrRestore);
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);

            #endregion Event Handle
        }

        #region Event Handle

        /// <summary>
        /// Processing when click btnChoosePath
        /// </summary>
        protected void btnChoosePath_Click(object sender, EventArgs e)
        {
            this.ChoosePath();
        }

        /// <summary>
        /// Processing when click btnBackup
        /// </summary>
        protected void BackupOrRestore(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateData())
                {
                    this.BackupOrRestore();

                    #region Old version

                    //if (!string.IsNullOrEmpty(result))
                    //{
                    //    message = new IvsMessage("SYBK00_001");
                    //    msg.Add(message);
                    //    msg.Display(CommonData.MessageType.Ok);
                    //}
                    //CommonBl commonBl = new CommonBl();
                    //int iReturnCode = commonBl.Backup(this.txtPath.Text);
                    //switch (iReturnCode)
                    //{
                    //    case CommonData.DbReturnCode.Succeed:
                    //        message = new IvsMessage("SYBK00_001");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);

                    //        break;
                    //    case CommonData.DbReturnCode.AccessDenied:
                    //        message = new IvsMessage("CMN017");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Access Denied");
                    //        break;
                    //    case CommonData.DbReturnCode.InvalidHost:
                    //        message = new IvsMessage("CMN018");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Invalid Host");
                    //        break;
                    //    case CommonData.DbReturnCode.InvalidDatabase:
                    //        message = new IvsMessage("CMN019");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Invalid Database");
                    //        break;
                    //    case CommonData.DbReturnCode.LostConnection:
                    //        message = new IvsMessage("CMN020");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Lost Connection");
                    //        break;
                    //    case CommonData.DbReturnCode.DuplicateKey:
                    //        message = new IvsMessage("CMN014");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Duplicate Key");
                    //        break;
                    //    case CommonData.DbReturnCode.ForgeignKeyNotExist:
                    //        message = new IvsMessage("CMN022");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Forgeign Key Not Exist");
                    //        break;
                    //    case CommonData.DbReturnCode.ForeignKeyViolation:
                    //        message = new IvsMessage("CMN023");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Foreign Key Violation");
                    //        break;
                    //    case CommonData.DbReturnCode.DataNotFound:
                    //        message = new IvsMessage("CMN024");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Data Not Found");
                    //        break;
                    //    case CommonData.DbReturnCode.ExceptionOccured:
                    //        message = new IvsMessage("CMN025");
                    //        msg.Add(message);
                    //        msg.Display(CommonData.MessageType.Ok);
                    //        //MessageBox.Show("Exception Occured");
                    //        break;
                    //}

                    #endregion Old version
                }
            }
            catch
            {
                MessageBoxs msg = new MessageBoxs();
                IvsMessage message = null;
                message = new IvsMessage("SYBK00_006");
                msg.Add(message);
                msg.Display(CommonData.MessageType.Ok);
            }
        }

        protected virtual void BackupOrRestore()
        {
            MessageBoxs msg = new MessageBoxs();
            IvsMessage message = null;
            if (isBackup)
            {
                message = new IvsMessage("SYBK00_008");
            }
            else
            {
                message = new IvsMessage("SYRT00_002");
            }
            msg.Add(message);
            CommonData.MessageTypeResult result = msg.Display(CommonData.MessageType.YesNo);
            if (result == CommonData.MessageTypeResult.Yes)
            {
                //this.service = new Ivs.Core.Services.Services();
                //this.service.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //this.service.BackupOrRestoreCompleted += new Ivs.Core.Services.BackupOrRestoreCompletedEventHandler(service_BackupOrRestoreCompleted);
                //this.service.BackupOrRestoreAsync(this.isBackup, this.txtPath.Text);
                //backupService.BackupOrRestore(this.isBackup, this.txtPath.Text);
                this.btnOK.Enabled = false;
            }
        }

        //protected virtual void service_BackupOrRestoreCompleted(object sender,
        //                                Ivs.Core.Services.BackupOrRestoreCompletedEventArgs e)
        //{
        //    if (this != null && !this.IsDisposed)
        //    {
        //        this.btnOK.Enabled = true;
        //    }
        //    MessageBoxs msg = new MessageBoxs();
        //    IvsMessage message = null;
        //    if (e.Error == null)
        //    {
        //        message = new IvsMessage("SYBK00_001");
        //        msg.Add(message);
        //        msg.Display(CommonData.MessageType.Ok);
        //    }
        //    else
        //    {
        //        message = new IvsMessage("CMN025");
        //        msg.Add(message);
        //        msg.Display(CommonData.MessageType.Ok);
        //    }
        //}

        /// <summary>
        /// Processing when click btnCancel
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Processing when click btnAdvance
        /// </summary>
        private void btnAdvance_Click(object sender, EventArgs e)
        {
            if (backupScheduleForm != null && backupScheduleForm.Disposing)
            {
                backupScheduleForm.Show();
            }
            else
            {
                backupScheduleForm = new SYBK01Form();
                backupScheduleForm.Show();
            }
        }

        /// <summary>
        /// Processing when click btnViewLog
        /// </summary>
        private void btnViewLog_Click(object sender, EventArgs e)
        {
            try
            {
                string[] logContent = null;
                string logFile = CommonData.StringEmpty;
                //this.service = new Ivs.Core.Services.Services();
                //if (DbConfig.UsingProxy.Equals("true"))
                //{
                //    string address = "http://" + DbConfig.ServerName + ":" + DbConfig.WebServicePort;
                //    WebProxy proxyObject = new WebProxy(address, true);
                //    service.Proxy = proxyObject;
                //}
                //service.Credentials = CredentialCache.DefaultCredentials;

                //bool result = this.service.GetLogFile(out logFile, out logContent);
                //if (!result)
                //{
                //    if (Directory.Exists(logFile))
                //    {
                //        MessageBoxs msg = new MessageBoxs();
                //        IvsMessage message = null;
                //        message = new IvsMessage("CMN025");
                //        msg.Add(message);
                //        msg.Display(CommonData.MessageType.Ok);
                //    }
                //    else
                //    {
                //        MessageBoxs msg = new MessageBoxs();
                //        IvsMessage message = null;
                //        message = new IvsMessage("CMN071");
                //        msg.Add(message);
                //        msg.Display(CommonData.MessageType.Ok);
                //    }

                //}
                //else
                //{
                //    File.WriteAllLines(logFile, logContent);
                //    System.Diagnostics.Process.Start(logFile);
                //}
            }
            catch
            {
                MessageBoxs msg = new MessageBoxs();
                IvsMessage message = null;
                message = new IvsMessage("SYBK00_006");
                msg.Add(message);
                msg.Display(CommonData.MessageType.Ok);
            }
        }

        #endregion Event Handle

        #region Methods

        /// <summary>
        /// Check validated path
        /// </summary>
        protected bool IsValidatePath(string pathIn)
        {
            string[] paths = pathIn.TrimEnd().Split('.');

            if (paths.Length > 1 && (paths[1].Equals(CommonData.BackupFormat.MySql) || paths[1].Equals(CommonData.BackupFormat.MSSQL) || paths[1].Equals(CommonData.BackupFormat.Oracle)))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check validated data
        /// </summary>
        protected bool ValidateData()
        {
            MessageBoxs msg = new MessageBoxs();
            IvsMessage message = null;
            this.txtPath.ClearErrors();
            if (!this.IsValidatePath(this.txtPath.Text))
            {
                message = new IvsMessage("SYBK00_004");
                msg.Add(message);
                msg.Display(CommonData.MessageType.Ok);
                this.txtPath.SetError(message.MessageText);
                this.txtPath.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Choose path to backup or restore
        /// </summary>
        protected virtual void ChoosePath()
        {
            System.Windows.Forms.SaveFileDialog file = new System.Windows.Forms.SaveFileDialog();
            file.Filter = this.GetFilterFile();

            file.FileName = "Backup_" + DateTime.Now.ToString(CommonData.DateFormat.YyyyMMddHHmmss);
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtPath.Text = file.FileName;
            }
        }

        protected string GetFilterFile()
        {
            string fileFilter = CommonData.StringEmpty;
            fileFilter = "Backup Files (.sql)|*.sql|All files|*.*";
            //switch (DbConfig.ServerType)
            //{
            //    case DbConfig.DbType.MySql:
            //        fileFilter = "Backup Files (.sql)|*.sql|All files|*.*";
            //        break;
            //    case DbConfig.DbType.Oracle:
            //        fileFilter = "Backup Files (.dmp)|*.dmp|All files|*.*";
            //        break;
            //    case DbConfig.DbType.MSSQL:
            //        fileFilter = "Backup Files (.bak)|*.bak|All files|*.*";
            //        break;
            //    default:
            //        fileFilter = "Backup Files (.sql)|*.sql|All files|*.*";
            //        break;
            //}
            return fileFilter;
        }

        /// <summary>
        /// Set language for form
        /// </summary>
        protected virtual void SetLanguage()
        {
            //create I18n class object
            I18n i18n = new I18n(this.FunctionId);
            this.Text = i18n.GetString(this.Name);
            this.btnChoosePath.Text = i18n.GetString(this.btnChoosePath.Name);
            this.btnCancel.Text = i18n.GetString(this.btnCancel.Name);
            this.btnOK.Text = i18n.GetString(this.btnOK.Name);
            this.btnAdvance.Text = i18n.GetString(this.btnAdvance.Name);
            this.lblPath.Text = i18n.GetString(this.lblPath.Name);
            this.btnViewLog.Text = i18n.GetString(this.btnViewLog.Name);
        }

        private void SetAuthorityControlOnlyThis()
        {
            if (this.IsAuthority(CommonData.OperId.Backup) == CommonData.IsAuthority.Deny)
            {
                btnOK.Enabled = false;
                btnAdvance.Enabled = false;
            }
        }

        #endregion Methods
    }
}