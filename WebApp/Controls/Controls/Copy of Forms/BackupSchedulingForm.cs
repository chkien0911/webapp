using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Logger;
using Ivs.Core.Validation;

namespace Ivs.Controls.Forms
{
    public partial class SYBK01Form : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        private static readonly Logger log = new Logger();

        #region Private members

        private I18n i18n = null;
        //Services.Services service = null;

        #endregion Private members

        public SYBK01Form()
        {
            InitializeComponent();

            #region Add day of month

            for (int i = 1; i <= 31; i++)
            {
                DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem();
                item.CheckState = CheckState.Unchecked;
                item.Description = i.ToString();
                item.Value = i;
                chkListMonth.Items.Add(item);
            }

            #endregion Add day of month

            #region Add event handle

            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            this.rdoDaily.SelectedIndexChanged += new System.EventHandler(this.rdoDaily_SelectedIndexChanged);
            this.chkListMonth.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkListMonth_ItemCheck);
            this.chkListDaily.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.chkListDaily_ItemCheck);
            this.tedTime.EditValueChanged += new System.EventHandler(this.tedTime_EditValueChanged);
            this.btnFolderPath.Click += new System.EventHandler(this.btnFolderPath_Click);
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            #endregion Add event handle

            #region Set format default

            tedTime.Properties.Mask.EditMask = CommonData.TimeFormat.HHmmss;
            tedTime.Properties.Mask.UseMaskAsDisplayFormat = true;

            #endregion Set format default

            this.SetLanguage();
            this.LoadBackupService();
        }

        /// <summary>
        /// override FunctionId in IvsForm
        /// </summary>
        protected override string FunctionId
        {
            get
            {
                return CommonData.FunctionId.SYBK01;
            }
        }

        #region Methods

        /// <summary>
        /// Set language for form
        /// </summary>
        protected virtual void SetLanguage()
        {
            //create I18n class object
            i18n = new I18n(this.FunctionId);
            this.Text = i18n.GetString(this.Name);

            this.grcTimeFrequency.Text = i18n.GetString(grcTimeFrequency.Name);
            this.grcFrequency.Text = i18n.GetString(grcFrequency.Name);
            this.btnCancel.Text = i18n.GetString(this.btnCancel.Name);
            this.btnStop.Text = i18n.GetString(this.btnStop.Name);
            this.btnOk.Text = i18n.GetString(this.btnOk.Name);
            this.rdoDaily.Properties.Items[0].Description = i18n.GetString(rdoDaily.Name + CommonKey.Daily);
            this.rdoDaily.Properties.Items[1].Description = i18n.GetString(rdoDaily.Name + CommonKey.Month);
            this.lblDescription.Text = i18n.GetString(this.lblDescription.Name);
            this.lblTime.Text = i18n.GetString(this.lblTime.Name);
            this.lblFolder.Text = i18n.GetString(this.lblFolder.Name);
            switch (this.rdoDaily.SelectedIndex)
            {
                case 0:
                    this.txtDescription.Text = i18n.GetString(this.txtDescription.Name + "Daily");
                    break;

                case 1:
                    this.txtDescription.Text = i18n.GetString(this.txtDescription.Name + "Month");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Get checked date on CheckedList
        /// </summary>
        private string GetCheckedString(Ivs.Controls.CustomControls.WinForm.IvsCheckedListBoxControl checkList)
        {
            StringBuilder result = new StringBuilder();
            bool flag = true;
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].CheckState == CheckState.Checked)
                {
                    if (flag)
                    {
                        //Add the last checked string
                        result.Append(checkList.Items[i].Description);
                        flag = false;
                    }
                    else
                    {
                        //Add the other checked string
                        result.Append(",").Append(checkList.Items[i].Description);
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Get checked date on CheckedListDaily or CheckedListMonth
        /// </summary>
        private string GetCheckedString()
        {
            if (this.rdoDaily.SelectedIndex == 0)
            {
                return this.GetCheckedString(chkListDaily);
            }
            return this.GetCheckedString(chkListMonth);
        }

        /// <summary>
        /// Get checked valued on CheckedList
        /// </summary>
        private string GetCheckedValue(Ivs.Controls.CustomControls.WinForm.IvsCheckedListBoxControl checkList)
        {
            StringBuilder result = new StringBuilder();
            bool flag = true;
            for (int i = 0; i < checkList.Items.Count; i++)
            {
                if (checkList.Items[i].CheckState == CheckState.Checked)
                {
                    if (flag)
                    {
                        //Add the last checked string
                        result.Append(checkList.Items[i].Value.ToString());
                        flag = false;
                    }
                    else
                    {
                        //Add the other checked string
                        result.Append(",").Append(checkList.Items[i].Value.ToString());
                    }
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// Get full folder path to save backup file
        /// </summary>
        private string GetFullPath(string folderPath)
        {
            if (folderPath.Length > 0)
            {
                if (!folderPath[folderPath.Length - 1].Equals('\\'))
                {
                    folderPath += "\\";
                }
            }
            return folderPath;
        }

        /// <summary>
        /// Get error data
        /// </summary>
        public List<ValidationResult> GetValidateError()
        {
            List<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationResult result = null;

            /// <summary>
            /// CheckedDate must be select
            ///</summary>
            switch (this.rdoDaily.SelectedIndex)
            {
                case 0:
                    if (this.chkListDaily.CheckedItems.Count <= 0)
                    {
                        result = new ValidationResult("ListDate",
                                                               CommonData.IsValid.Failed,
                                                               new IvsMessage("SYBK00_002"));
                        validationResults.Add(result);
                    }
                    break;

                case 1:
                    if (this.chkListMonth.CheckedItems.Count <= 0)
                    {
                        result = new ValidationResult("ListDate",
                                                               CommonData.IsValid.Failed,
                                                               new IvsMessage("SYBK00_002"));
                        validationResults.Add(result);
                    }
                    break;

                default:
                    break;
            }

            /// <summary>
            /// Time must be select
            ///</summary>
            if (string.IsNullOrEmpty(this.tedTime.Text))
            {
                result = new ValidationResult("Time",
                                                    CommonData.IsValid.Failed,
                                                    new IvsMessage("SYBK00_003"));
                validationResults.Add(result);
            }

            /// <summary>
            /// FolderPath must be fill in
            ///</summary>
            if (string.IsNullOrEmpty(this.txtFolderPath.Text))
            {
                result = new ValidationResult("FolderPath",
                                                          CommonData.IsValid.Failed,
                                                          new IvsMessage("SYBK00_004"));
                validationResults.Add(result);
            }

            return validationResults;
        }

        /// <summary>
        /// Validate data
        /// </summary>
        private CommonData.IsValid ValidateData()
        {
            List<ValidationResult> validationResults = this.GetValidateError();
            bool isFocused = true;

            #region Get IvsMessage error

            if (validationResults.Count > 0)
            {
                Ivs.Controls.Forms.MessageBoxs msg = new Ivs.Controls.Forms.MessageBoxs();
                //IvsMessage IvsMessage = null;
                msg.Add(validationResults);
                msg.Display(CommonData.MessageType.Ok);
            }

            #endregion Get IvsMessage error

            #region Clear error

            this.tedTime.ClearErrors();
            this.txtFolderPath.ClearErrors();

            #endregion Clear error

            #region Set Error IvsMessage And Set Focus

            foreach (ValidationResult validationResult in validationResults)
            {
                switch (validationResult.FieldName)
                {
                    case "Time":
                        this.tedTime.SetError(validationResult.Message.MessageText);
                        if (isFocused == false)
                        {
                            this.tedTime.Focus();
                            isFocused = true;
                        }
                        break;

                    case "FolderPath":
                        this.txtFolderPath.SetError(validationResult.Message.MessageText);
                        if (isFocused == false)
                        {
                            this.txtFolderPath.Focus();
                            isFocused = true;
                        }
                        break;

                    case "ListDate":
                        if (isFocused == false)
                        {
                            if (rdoDaily.SelectedIndex == 0)
                            {
                                this.chkListDaily.Focus();
                            }
                            else
                            {
                                this.chkListMonth.Focus();
                            }
                            isFocused = true;
                        }
                        break;
                }
            }

            #endregion Set Error IvsMessage And Set Focus

            return validationResults.Count > 0 ? CommonData.IsValid.Failed : CommonData.IsValid.Successful;
        }

        /// <summary>
        /// Get and Show infomation of service
        /// </summary>
        private void LoadBackupService()
        {
            try
            {
                //#region Init members

                //string folderPath  = string.Empty;
                //bool isDate = true;
                //string listDates = string.Empty;
                //string time  = string.Empty;
                //bool isRunning = true;

                //#endregion
                //this.service = new Ivs.Core.Services.Services();
                //this.service.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //bool result = this.service.GetAppConfig(out folderPath, out isDate, out listDates, out time, out isRunning);
                //if (result)
                //{
                //    #region Show infomation

                //    this.txtFolderPath.Text = folderPath;
                //    this.tedTime.EditValue = time;
                //    if (isDate)
                //    {
                //        this.rdoDaily.SelectedIndex = 0;
                //    }
                //    else
                //    {
                //        this.rdoDaily.SelectedIndex = 1;
                //    }
                //    string[] listDate = listDates.Split(',');
                //    switch (this.rdoDaily.SelectedIndex)
                //    {
                //        case 0:
                //            foreach (string date in listDate)
                //            {
                //                for (int i = 0; i < this.chkListDaily.Items.Count; i++)
                //                {
                //                    if (this.chkListDaily.Items[i].Description.Equals(date))
                //                    {
                //                        this.chkListDaily.Items[i].CheckState = CheckState.Checked;
                //                        break;
                //                    }
                //                }
                //            }
                //            break;
                //        case 1:
                //            foreach (string date in listDate)
                //            {
                //                for (int i = 0; i < this.chkListMonth.Items.Count; i++)
                //                {
                //                    if (this.chkListMonth.Items[i].Description.Equals(date))
                //                    {
                //                        this.chkListMonth.Items[i].CheckState = CheckState.Checked;
                //                        break;
                //                    }
                //                }
                //            }
                //            break;
                //        default:
                //            break;
                //    }

                //    if (isRunning)
                //    {
                //        this.btnOk.Enabled = false;
                //        this.btnStop.Enabled = true;
                //    }
                //    else
                //    {
                //        this.btnOk.Enabled = true;
                //        this.btnStop.Enabled = false;
                //    }

                //    #endregion
                //}
                //else
                //{
                //    Ivs.Core.Data.MessageBoxs msg = new Ivs.Core.Data.MessageBoxs();
                //    IvsMessage IvsMessage = null;
                //    IvsMessage = new IvsMessage("CMN025");
                //    msg.Add(Ivs.Core.Data.Message);
                //    msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
                //}

                //#region Old version
                ////ServiceController serviceController = null;
                ////if (this.IsExistService(serviceName, out serviceController))
                ////{
                ////    #region Show infomation of service
                ////    string path = this.GetServicePath(serviceController);
                ////    if (string.IsNullOrEmpty(path))
                ////    {
                ////        return;
                ////    }

                ////    XmlDocument xmlDoc = new XmlDocument();

                ////    xmlDoc.Load(path + CommonData.ServicesBatch.BackupScheduling + @".exe.config");//AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

                ////    foreach (XmlElement element in xmlDoc.DocumentElement)
                ////    {
                ////        if (element.Name.Equals("appSettings"))
                ////        {
                ////            foreach (XmlNode node in element.ChildNodes)
                ////            {
                ////                if (node.Attributes[0].Value.Equals("IsDate"))
                ////                {
                ////                    if (node.Attributes[1].Value.Equals("true", StringComparison.OrdinalIgnoreCase))
                ////                    {
                ////                        this.rdoDaily.SelectedIndex = 0;
                ////                    }
                ////                    else
                ////                    {
                ////                        this.rdoDaily.SelectedIndex = 1;
                ////                    }
                ////                }
                ////                if (node.Attributes[0].Value.Equals("Time"))
                ////                {
                ////                    this.tedTime.EditValue = string.IsNullOrEmpty(node.Attributes[1].Value) ? "00:00:00" : node.Attributes[1].Value;
                ////                }
                ////                if (node.Attributes[0].Value.Equals("FolderPath"))
                ////                {
                ////                    this.txtFolderPath.Text = node.Attributes[1].Value;
                ////                }
                ////                if (node.Attributes[0].Value.Equals("ListDate"))
                ////                {
                ////                    string[] listDate = node.Attributes[1].Value.Split(',');
                ////                    switch (this.rdoDaily.SelectedIndex)
                ////                    {
                ////                        case 0:
                ////                            foreach (string date in listDate)
                ////                            {
                ////                                for (int i = 0; i < this.chkListDaily.Items.Count; i++)
                ////                                {
                ////                                    if (this.chkListDaily.Items[i].Description.Equals(date))
                ////                                    {
                ////                                        this.chkListDaily.Items[i].CheckState = CheckState.Checked;
                ////                                        break;
                ////                                    }
                ////                                }
                ////                            }
                ////                            break;
                ////                        case 1:
                ////                            foreach (string date in listDate)
                ////                            {
                ////                                for (int i = 0; i < this.chkListMonth.Items.Count; i++)
                ////                                {
                ////                                    if (this.chkListMonth.Items[i].Description.Equals(date))
                ////                                    {
                ////                                        this.chkListMonth.Items[i].CheckState = CheckState.Checked;
                ////                                        break;
                ////                                    }
                ////                                }
                ////                            }
                ////                            break;
                ////                        default:
                ////                            break;
                ////                    }
                ////                }
                ////            }
                ////        }
                ////    }

                ////    #endregion

                ////    #region Show button status

                ////    this.SetButtonStatus(serviceController);

                ////    #endregion
                ////}
                ////else
                ////{
                ////    this.btnOk.Enabled = false;
                ////    this.btnStop.Enabled = false;
                ////}
                //#endregion
            }
            catch { }
        }

        #endregion Methods

        #region Event Handle

        /// <summary>
        /// Processing when click button FolderPath
        /// </summary>
        private void btnFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txtFolderPath.Text = this.GetFullPath(fbd.SelectedPath);
            }
        }

        /// <summary>
        /// Processing when click button OK (Start service)
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            #region Logger start

            log.GetLogger(UserSession.FunctionId);
            log.Write(Logger.Level.Info, "btnOk_Click Start");

            #endregion Logger start

            MessageBoxs msg = new MessageBoxs();
            IvsMessage IvsMessage = null;
            try
            {
                string folderPath = this.txtFolderPath.Text;
                bool isDate = this.rdoDaily.SelectedIndex == 0 ? true : false;
                string listDate = this.GetCheckedString();
                string time = this.tedTime.Text;
                //Ivs.Core.Services.Services service = new Ivs.Core.Services.Services();
                //service.Credentials = System.Net.CredentialCache.DefaultCredentials;
                ////backupService.StartCompleted += new Ivs.Core.WebServices.StartCompletedEventHandler(backupService_StartCompleted);
                //bool result = service.StartBackupScheduling(folderPath, isDate, listDate, time);
                //if (result)
                //{
                //    this.btnOk.Enabled = false;
                //    this.btnStop.Enabled = true;
                //}
                //else
                //{
                //    this.btnOk.Enabled = true;
                //    this.btnStop.Enabled = false;
                //    IvsMessage = new IvsMessage("CMN025");
                //    msg.Add(Ivs.Core.Data.Message);
                //    msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
                //}
            }
            catch (Exception ex)
            {
                #region Logger

                log.Write(Logger.Level.Info, ex.ToString());

                #endregion Logger
            }

            #region logger end

            log.Write(Logger.Level.Info, "btnOk_Click End");

            #endregion logger end

            #region Old version

            //Ivs.Core.Data.MessageBoxs msg = new Ivs.Core.Data.MessageBoxs();
            //IvsMessage IvsMessage = null;
            //try
            //{
            //    if (this.ValidateData() == CommonData.IsValid.Successful)
            //    {
            //        ServiceController serviceController = null;
            //        if (this.IsExistService(CommonData.ServicesBatch.BackupScheduling, out serviceController))
            //        {
            //            #region Get path of service

            //            string path = this.GetServicePath(serviceController);
            //            if (string.IsNullOrEmpty(path))
            //            {
            //                IvsMessage = new IvsMessage("SYBK00_006");
            //                msg.Add(Ivs.Core.Data.Message);
            //                msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //                return;
            //            }

            //            #endregion

            //            #region Stop service and update service config

            //            if (serviceController.Status != ServiceControllerStatus.Stopped)
            //            {
            //                serviceController.Stop();
            //                serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            //            }

            //            XmlDocument xmlDoc = new XmlDocument();

            //            xmlDoc.Load(path + CommonData.ServicesBatch.BackupScheduling + @".exe.config");//AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            //            foreach (XmlElement element in xmlDoc.DocumentElement)
            //            {
            //                if (element.Name.Equals("appSettings"))
            //                {
            //                    foreach (XmlNode node in element.ChildNodes)
            //                    {
            //                        if (node.Attributes[0].Value.Equals("LogPath"))
            //                        {
            //                            node.Attributes[1].Value = "C:\\BackupSchedulingLog.txt";
            //                        }
            //                        if (node.Attributes[0].Value.Equals("IsDate"))
            //                        {
            //                            node.Attributes[1].Value = (this.rdoDaily.SelectedIndex == 0) ? "true" : "false";
            //                        }
            //                        if (node.Attributes[0].Value.Equals("Time"))
            //                        {
            //                            node.Attributes[1].Value = this.tedTime.Text;
            //                        }
            //                        if (node.Attributes[0].Value.Equals("ListDate"))
            //                        {
            //                            node.Attributes[1].Value = this.GetCheckedString();
            //                        }
            //                        if (node.Attributes[0].Value.Equals("FolderPath"))
            //                        {
            //                            node.Attributes[1].Value = this.txtFolderPath.Text;
            //                        }
            //                    }
            //                }
            //            }

            //            xmlDoc.Save(path + CommonData.ServicesBatch.BackupScheduling + ".exe.config");

            //            System.Configuration.ConfigurationManager.RefreshSection("appSettings");

            //            #endregion

            //            //Start service
            //            if (serviceController.Status == ServiceControllerStatus.Stopped)
            //            {
            //                serviceController.Start();
            //                serviceController.WaitForStatus(ServiceControllerStatus.Running);
            //                this.SetButtonStatus(serviceController);
            //            }

            //            IvsMessage = new IvsMessage("SYBK00_005");
            //            msg.Add(Ivs.Core.Data.Message);
            //            msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //        }
            //        else
            //        {
            //            IvsMessage = new IvsMessage("SYBK00_006");
            //            msg.Add(Ivs.Core.Data.Message);
            //            msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //            return;
            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    IvsMessage = new IvsMessage("CMN025");
            //    msg.Add(Ivs.Core.Data.Message);
            //    msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //}

            #endregion Old version
        }

        //private void backupService_StartCompleted(object sender, Ivs.Core.WebServices.StartCompletedEventArgs e)
        //{
        //    this.Cursor = Cursors.Default;
        //    Ivs.Core.Data.MessageBoxs msg = new Ivs.Core.Data.MessageBoxs();
        //    IvsMessage IvsMessage = null;
        //    if (e.Error == null)
        //    {
        //        this.btnOk.Enabled = false;
        //        this.btnStop.Enabled = true;
        //    }
        //    else
        //    {
        //        this.btnOk.Enabled = true;
        //        this.btnStop.Enabled = true;
        //        IvsMessage = new IvsMessage("CMN025");
        //        msg.Add(Ivs.Core.Data.Message);
        //        msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
        //    }
        //}

        /// <summary>
        /// Processing when click button Stop (Stop service)
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            #region Logger start

            log.GetLogger(UserSession.FunctionId);
            log.Write(Logger.Level.Info, "btnStop_Click Start");

            #endregion Logger start

            MessageBoxs msg = new MessageBoxs();
            IvsMessage IvsMessage = null;
            try
            {
                //Ivs.Core.Services.Services backupService = new Ivs.Core.Services.Services();
                //backupService.Credentials = System.Net.CredentialCache.DefaultCredentials;
                ////backupService.StopCompleted += new Ivs.Core.WebServices.StopCompletedEventHandler(backupService_StopCompleted);
                //bool result = backupService.StopBackupScheduling();
                //if (result)
                //{
                //    this.btnOk.Enabled = true;
                //    this.btnStop.Enabled = false;
                //}
                //else
                //{
                //    this.btnOk.Enabled = false;
                //    this.btnStop.Enabled = true;
                //    IvsMessage = new IvsMessage("CMN025");
                //    msg.Add(Ivs.Core.Data.Message);
                //    msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
                //}
            }
            catch (Exception ex)
            {
                #region Logger

                log.Write(Logger.Level.Info, ex.ToString());

                #endregion Logger
            }

            #region logger end

            log.Write(Logger.Level.Info, "btnStop_Click End");

            #endregion logger end

            #region Old version

            //Ivs.Core.Data.MessageBoxs msg = new Ivs.Core.Data.MessageBoxs();
            //IvsMessage IvsMessage = null;
            //try
            //{
            //    ServiceController serviceController = null;
            //    if (this.IsExistService(CommonData.ServicesBatch.BackupScheduling, out serviceController))
            //    {
            //        //Stop service
            //        if (serviceController.Status != ServiceControllerStatus.Stopped)
            //        {
            //            serviceController.Stop();
            //            serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            //            this.SetButtonStatus(serviceController);

            //            IvsMessage = new IvsMessage("SYBK00_007");
            //            msg.Add(Ivs.Core.Data.Message);
            //            msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //        }
            //    }
            //    else
            //    {
            //        IvsMessage = new IvsMessage("SYBK00_006");
            //        msg.Add(Ivs.Core.Data.Message);
            //        msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    IvsMessage = new IvsMessage("CMN025");
            //    msg.Add(Ivs.Core.Data.Message);
            //    msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
            //}

            #endregion Old version
        }

        //private void backupService_StopCompleted(object sender, Ivs.Core.WebServices.StopCompletedEventArgs e)
        //{
        //    this.Cursor = Cursors.Default;
        //    Ivs.Core.Data.MessageBoxs msg = new Ivs.Core.Data.MessageBoxs();
        //    IvsMessage IvsMessage = null;
        //    if (e.Error == null)
        //    {
        //        this.btnOk.Enabled = true;
        //        this.btnStop.Enabled = false;
        //    }
        //    else
        //    {
        //        this.btnOk.Enabled = true;
        //        this.btnStop.Enabled = true;
        //        IvsMessage = new IvsMessage("CMN025");
        //        msg.Add(Ivs.Core.Data.Message);
        //        msg.Display(CommonData.Ivs.Core.Data.MessageType.Ok);
        //    }
        //}

        /// <summary>
        /// Processing when click button Cancel
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Processing when radioDaily changed
        /// </summary>
        private void rdoDaily_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.rdoDaily.SelectedIndex)
            {
                case 0:
                    this.chkListMonth.UnCheckAll();
                    this.chkListMonth.Enabled = false;
                    this.chkListDaily.Enabled = true;
                    break;

                case 1:
                    this.chkListDaily.UnCheckAll();
                    this.chkListDaily.Enabled = false;
                    this.chkListMonth.Enabled = true;
                    break;

                default:
                    break;
            }
        }

        #region Show description

        private void chkListDaily_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            string lstCheckedString = this.GetCheckedString(this.chkListDaily);
            this.txtDescription.Text = i18n.GetString(this.txtDescription.Name + "Daily") + lstCheckedString + " " + this.tedTime.Text + ".";
        }

        private void chkListMonth_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            string lstCheckedString = this.GetCheckedString(this.chkListMonth);
            this.txtDescription.Text = i18n.GetString(this.txtDescription.Name + "Month") + lstCheckedString + " " + this.tedTime.Text + ".";
        }

        private void tedTime_EditValueChanged(object sender, EventArgs e)
        {
            switch (this.rdoDaily.SelectedIndex)
            {
                case 0:
                    string lstCheckedString = this.GetCheckedString(this.chkListDaily);
                    this.txtDescription.Text = i18n.GetString(this.txtDescription.Name + "Daily") + lstCheckedString + " " + this.tedTime.Text + ".";
                    break;

                case 1:
                    lstCheckedString = this.GetCheckedString(this.chkListMonth);
                    this.txtDescription.Text = i18n.GetString(this.txtDescription.Name + "Month") + lstCheckedString + " " + this.tedTime.Text + ".";
                    break;

                default:
                    break;
            }
        }

        #endregion Show description

        #endregion Event Handle
    }
}