using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ivs.Controls.CustomControls.WinForm;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.Core.Logger;
using DevExpress.Utils;

namespace Ivs.Controls.Forms
{
    public partial class MasterEditForm : IVSForm
    {
        private static readonly Logger log = new Logger();

        #region Private Variables

        /// <summary>
        /// Next position of member in ListDto that need load data to input control
        /// </summary>
        protected int currentPosition = 0;

        private bool isProgrammaticClose = false;

        #endregion Private Variables

        #region Public Variables

        protected SuperToolTip sTooltip = new SuperToolTip();
        protected SuperToolTipSetupArgs args = new SuperToolTipSetupArgs();
        public virtual CommonData.Mode ViewMode { get; set; }

        #endregion Public Variables

        #region Properties

        protected virtual bool IsChanged
        {
            get { return IsFormChanged(); }
        }

        protected virtual IDto Dto
        {
            get;
            set;
        }

        public virtual List<IDto> ListDto
        {
            get;
            set;
        }

        protected virtual IDto CurrentDto
        {
            get
            {
                if (ListDto != null && ListDto.Count > 0)
                {
                    return this.ListDto[currentPosition];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                this.ListDto[currentPosition] = value;
            }
        }

        protected virtual IBl Bl
        {
            get;
            set;
        }

        protected virtual MessageBoxs MessageBox
        {
            get;
            set;
        }

        protected override string FunctionId
        {
            get;
            set;
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = new Dictionary<object, string>();
                lstControls.Add(this.btnSaveAndClose, btnSaveAndClose.Name);
                lstControls.Add(this.btnClose, btnClose.Name);
                lstControls.Add(this.btnPrevious, btnPrevious.Name);
                lstControls.Add(this.btnSaveAndNext, btnSaveAndNext.Name);
                lstControls.Add(this.btnClear, btnClear.Name);
                return lstControls;
            }
        }

        /// <summary>
        /// ReturnCode: catch error system
        /// </summary>
        public virtual int ReturnCode
        {
            get;
            set;
        }

        /// <summary>
        /// MessageTypeResult
        /// None = 0,
        /// OK = 1,
        /// Cancel = 2,
        /// Yes = 3,
        /// No = 4,
        /// </summary>
        public virtual CommonData.MessageTypeResult MsgTypeResult
        {
            get;
            set;
        }

        #endregion Properties

        #region Constructor

        public MasterEditForm()
        {
            InitializeComponent();
        }

        private void MasterEditForm_Activated(object sender, EventArgs e)
        {
            UserSession.FunctionId = FunctionId;
        }

        private void MasterEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isProgrammaticClose)
            {
                e.Cancel = !this.Exit();
            }
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblErrorMessage.Text))
            {
                if (this.MessageBox != null)
                {
                    this.MessageBox.ReDisplay();
                }
            }
        }

        #endregion Constructor

        #region Form Load Event

        protected void MasterEditForm_Load(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "MasterEditForm_Load Start");

            #endregion Logger Start

            this.SetControl();
            this.LoadData();
            this.SetAuthorityControl();

            #region Logger End

            log.Write(Logger.Level.Debug, "MasterEditForm_Load End");

            #endregion Logger End
        }

        #endregion Form Load Event

        #region Protected Method

        /// <summary>
        /// Initalize controls for Edit form
        /// </summary>
        protected virtual void InitControl()
        {
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.HideBarsWhenMerging = false;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblPath,
            this.btnSaveAndClose,
            this.btnClear,
            this.btnClose});

            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = CommonData.StringEmpty;

            #region Add Event For Control

            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveAndClose);
            this.btnSaveAndNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveAndNext);
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Previous);
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ClearOrReset);
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Close);
            this.Load += new System.EventHandler(this.MasterEditForm_Load);
            this.lblErrorMessage.Click += new EventHandler(lblErrorMessage_Click);
            this.FormClosing += new FormClosingEventHandler(MasterEditForm_FormClosing);
            this.Activated += new EventHandler(MasterEditForm_Activated);

            #endregion Add Event For Control      
            #region Set Tooltips
            //Set tool tips 
            this.SupperTip();
            #endregion
        }

        public override void InitLanguage(string lang, bool isSetCulture = true)
        {
            base.InitLanguage(lang, isSetCulture);
            SetLanguage();
        }

        /// <summary>
        /// Change language for gridview
        /// </summary>
        /// <param name="grid"></param>
        protected virtual void ChangeLanguageForGrid(IvsGridControl grid)
        {
            if (grid != null)
            {
                grid.EmbeddedNavigator.TextStringFormat = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_GRID_RECORD_OF_TOTAL, "Mẫu tin {0} của {1}");
                if (grid.MainView != null)
                    ((IvsGridView)grid.MainView).GroupPanelText = LanguageUltility.GetString(CommonConstantMessage.COM_MSG_HEADERGRID_DRAG, "Kéo một tiêu đề cột lên đây để nhóm cột đó");
            }
        }

        /// <summary>
        /// Set language for Title, Path, Grid
        /// </summary>
        public virtual void SetLanguage()
        {
            this.btnSaveAndNext.Caption = LanguageUltility.GetString(this.ViewMode == CommonData.Mode.View ? CommonData.ButtonCaption.Next : CommonData.ButtonCaption.SaveAndNext);
            this.btnClear.Caption = LanguageUltility.GetString(this.ViewMode == CommonData.Mode.View ? CommonData.ButtonCaption.Edit : (this.ViewMode == CommonData.Mode.Edit ? CommonData.ButtonCaption.Reset : CommonData.ButtonCaption.Clear));
            //set language for Path
            /*
                SYS_User_Edit_New_Path
                {0}_{1}_Path
                {0} = SYS_User_Edit = this.FunctionGr
                {1} = New = this.ViewMode.ToString()
             * */
            this.lblPath.Caption = LanguageUltility.GetString(string.Format("{0}_{1}_Path", this.FunctionGr, this.ViewMode.ToString()), "Danh mục > Danh mục cơ cấu tổ chức  > Văn phòng");
            //set language for Title
            /*
                SYS_User_Edit_Edit_Form
                {0}_{1}_Path
                {0} = SYS_User_Edit = this.FunctionGr
                {1} = New = this.ViewMode.ToString()
             * */
            this.Text = LanguageUltility.GetString(string.Format("{0}_{1}_Form", this.FunctionGr, this.ViewMode.ToString()), "Master Edit Form");

            if (this.MessageBox != null)
                this.lblErrorMessage.Text = this.MessageBox.DisplayMessage;
        }

        /// <summary>
        /// Set status display of control follow to viewMode
        /// Child form will override this method
        /// </summary>
        protected virtual void SetControl()
        {
            SetLanguage();

            btnClose.Enabled = true;
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = CommonData.StringEmpty;
            //set status display of control for ViewMode is View
            switch (this.ViewMode)
            {
                case CommonData.Mode.View:
                    {
                        btnSaveAndClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        if (this.ListDto != null)
                        {
                            if (currentPosition == (this.ListDto.Count - 1))
                            {
                                btnSaveAndNext.Enabled = false;
                            }
                            else
                            {
                                btnSaveAndNext.Enabled = true;
                            }

                            if (currentPosition == 0)
                            {
                                btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                btnPrevious.Enabled = false;
                            }
                            else
                            {
                                btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                                btnPrevious.Enabled = true;
                            }
                        }
                        else
                        {
                            btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                    }
                    break;

                case CommonData.Mode.Edit:
                    {
                        btnSaveAndClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        if (this.ListDto != null)
                        {
                            if (currentPosition == (this.ListDto.Count - 1))
                            {
                                btnSaveAndNext.Enabled = false;
                            }
                            else
                            {
                                btnSaveAndNext.Enabled = true;
                            }
                        }
                        else
                        {
                            btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                        }
                    }
                    break;

                case CommonData.Mode.New:
                    {
                        btnSaveAndClose.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        btnSaveAndNext.Enabled = true;
                        btnPrevious.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    }
                    break;
            }

            #region Set Tooltips
            //Set tool tips 
            this.SupperTip();
            #endregion
        }

        /// <summary>
        /// This method is called when click ClearOrReset button
        /// </summary>
        protected virtual void ClearOrReset(object sender, EventArgs e)
        {
            this.ClearOrReset();
        }

        /// <summary>
        /// This method is called when click SaveAndNext button
        /// </summary>
        protected virtual void SaveAndNext(object sender, EventArgs e)
        {
            this.SaveAndNext();
        }

        /// <summary>
        /// This method is called when click SaveAndClose button
        /// ViewMode is Edit: update data and close form
        /// ViewMode is New: insert data and close form
        /// </summary>
        protected virtual void SaveAndClose(object sender, EventArgs e)
        {
            this.SaveAndClose();
        }

        /// <summary>
        /// This method is called when click SaveAndNext button
        /// </summary>
        protected void Previous(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "Previous Start");

            #endregion Logger Start

            this.LoadPreviousData();
            this.SetControl();

            #region Logger End

            log.Write(Logger.Level.Debug, "Previous End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click Close button
        /// </summary>
        protected void Close(object sender, EventArgs e)
        {
            this.Exit();
        }

        /// <summary>
        /// Validate input control when save data
        /// Child form will override this method
        /// </summary>
        protected virtual CommonData.IsValid ValidateData()
        {
            return CommonData.IsValid.Successful;
        }

        #endregion Protected Method

        #region Public Method

        public virtual void Open()
        {
            this.ShowDialog();
        }

        #endregion Public Method

        #region Private Method

        protected virtual void SettingIfSysData(IDto dto)
        {
            if ((dto.GetType().GetProperty("SystemData")) != null)
            {
                string systemDataValue = CommonMethod.ParseString(dto.GetType().GetProperty("SystemData").GetValue(dto, null));
                if (this.IsAuthority(CommonData.OperId.Edit) == CommonData.IsAuthority.Allow)
                {
                    btnClear.Enabled = systemDataValue.Equals(CommonData.SystemData.Yes) ? false : true;
                }
            }
        }

        /// <summary>
        /// Load data for input control follow to viewMode
        /// </summary>
        protected virtual void LoadData()
        {
            if (DesignMode)
                return;

            this.Dto = null;
            if (this.ListDto != null && this.ListDto.Count > 0)
            {
                switch (this.ViewMode)
                {
                    case CommonData.Mode.View:
                        {
                            object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                            CommonMethod.Clone(this.CurrentDto, out dto);
                            this.Dto = (IDto)dto;
                            SettingIfSysData(this.CurrentDto);
                        }
                        break;

                    case CommonData.Mode.Edit:
                        {
                            object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                            CommonMethod.Clone(this.CurrentDto, out dto);
                            this.Dto = (IDto)dto;
                        }
                        break;

                    case CommonData.Mode.New:
                        {
                            if (ListDto != null && ListDto.Count > 0)
                            {
                                object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                                CommonMethod.Clone(this.ListDto[0], out dto);
                                this.Dto = (IDto)dto;
                                //Copy Dto --> ListDto[0] after delete key property value
                                object dto1 = Activator.CreateInstance(this.CurrentDto.GetType());
                                CommonMethod.Clone(this.Dto, out dto1);
                                this.ListDto[0] = (IDto)dto1;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
            else
            {
                ListDto = new List<IDto>();
                object dto = Activator.CreateInstance(this.Dto.GetType());
                CommonMethod.Clone(this.Dto, out dto);
                ListDto.Add((IDto)dto);
            }
        }

        /// <summary>
        /// Load data of next member in ListDto for input control
        /// </summary>
        protected virtual void LoadNextData()
        {
            //This is case ViewMode is View or Edit
            if (this.ViewMode == CommonData.Mode.View || this.ViewMode == CommonData.Mode.Edit)
            {
                if (currentPosition < ListDto.Count - 1)
                {
                    currentPosition++;
                    object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                    CommonMethod.Clone(this.CurrentDto, out dto);
                    this.Dto = (IDto)dto;
                    SettingIfSysData(this.CurrentDto);
                }
            }
            //This is case ViewMode is New
            else
            {
                this.Dto = null;
                ListDto = new List<IDto>();
                object dto = Activator.CreateInstance(this.Dto.GetType());
                CommonMethod.Clone(this.Dto, out dto);
                ListDto.Add((IDto)dto);
            }
        }

        /// <summary>
        /// Load data of previous member in ListDto for input control
        /// </summary>
        protected virtual void LoadPreviousData()
        {
            if (ListDto != null && currentPosition > 0)
            {
                currentPosition--;
                object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                CommonMethod.Clone(this.CurrentDto, out dto);
                this.Dto = (IDto)dto;
                SettingIfSysData(this.CurrentDto);
            }
        }

        /// <summary>
        /// Insert or update data to database
        /// </summary>
        protected virtual int SaveData()
        {
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            int iReturnCode = -1;
            //This is case ViewMode is Edit, system will update data to database
            if (this.ViewMode == CommonData.Mode.Edit)
            {
                ReturnCode = iReturnCode = Bl.UpdateData(this.Dto);
                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                    CommonMethod.Clone(this.Dto, out dto);
                    this.ListDto[currentPosition] = (IDto)dto;
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_UPDATE_SUCCESSFULLY);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
                else
                {
                    this.ProcessDbExcetion(iReturnCode);
                }
            }
            //This is case ViewMode is New, system will insert data to databas
            else if (this.ViewMode == CommonData.Mode.New)
            {
                ReturnCode = iReturnCode = Bl.InsertData(this.Dto);
                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_INSERT_SUCCESSFULLY);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
                else
                {
                    this.ProcessDbExcetion(iReturnCode);
                }
            }
            return iReturnCode;
        }

        #endregion Private Method

        /// <summary>
        /// Override ProcessCmdKey method (HotKey processing)
        /// </summary>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.F11 && this.ViewMode != CommonData.Mode.View)
            {
                this.btnSaveAndClose.PerformClick();
                return true;
            }
            if (keyData == Keys.Left && this.ViewMode == CommonData.Mode.View)
            {
                this.btnPrevious.PerformClick();
                return true;
            }
            if ((keyData == Keys.Right && this.ViewMode == CommonData.Mode.View) || (keyData == Keys.F12 && this.ViewMode == CommonData.Mode.New))
            {
                this.btnSaveAndNext.PerformClick();
                return true;
            }
            if (keyData == Keys.F12 && this.ViewMode == CommonData.Mode.Edit)
            {
                this.btnSaveAndNext.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                Exit();
                return true;
            }
            if ((keyData == Keys.F4 && this.ViewMode == CommonData.Mode.View) || (keyData == Keys.F5 && this.ViewMode != CommonData.Mode.View))
            {
                this.btnClear.PerformClick();
                return true;
            }

            //=====Update 17/05/2013(Kien)=====
            if (keyData == (Keys.Shift | Keys.Tab))
            {
                barManager1.Bars[1].ItemLinks[0].Focus();
                return true;
            }
            //=====EndUpdate===================

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// This method is called when click ClearOrReset button
        /// </summary>
        protected virtual void ClearOrReset()
        {            
            if (this.btnClear.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnClear.Enabled == false)
            {
                return;
            }
            switch (this.ViewMode)
            {
                case CommonData.Mode.Edit:
                    {
                        #region Logger Start

                        log.GetLogger(this.Name.ToString() + " " + "ResetData");
                        log.Write(Logger.Level.Info, "Start");

                        #endregion Logger Start

                        object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                        CommonMethod.Clone(this.CurrentDto, out dto);
                        this.Dto = (IDto)dto;
                    }
                    break;

                case CommonData.Mode.New:
                    {
                        #region Logger Start

                        log.GetLogger(this.Name.ToString() + " " + "ClearData");
                        log.Write(Logger.Level.Info, "Start");

                        #endregion Logger Start

                        this.Dto = null;
                    }
                    break;

                case CommonData.Mode.View:
                    {
                        #region Logger Start

                        log.GetLogger(this.Name.ToString() + " " + "ChangeMode");
                        log.Write(Logger.Level.Info, "Start");

                        #endregion Logger Start

                        this.ViewMode = CommonData.Mode.Edit;
                    }
                    break;
            }
            this.SetControl();

            #region Logger End

            log.Write(Logger.Level.Info, "End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click SaveAndNext button
        /// </summary>
        protected virtual void SaveAndNext()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "SaveAndNext Start");

            #endregion Logger Start

            int iReturnCode = CommonData.DbReturnCode.Succeed;
            if (btnSaveAndNext.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnSaveAndNext.Enabled == false)
            {
                return;
            }
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            switch (this.ViewMode)
            {
                case CommonData.Mode.Edit:
                    {
                        if (this.ValidateData() == CommonData.IsValid.Successful)
                        {
                            this.lblErrorMessage.Text = CommonData.StringEmpty;
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_SAVE);
                            this.MessageBox.Add(message);
                            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (result == CommonData.MessageTypeResult.Yes)
                            {
                                iReturnCode = this.SaveData();
                                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                                {
                                    this.LoadNextData();
                                }
                                this.SetControl();
                            }
                        }
                    }
                    break;

                case CommonData.Mode.New:
                    {
                        if (this.ValidateData() == CommonData.IsValid.Successful)
                        {
                            this.lblErrorMessage.Text = CommonData.StringEmpty;
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_SAVE);
                            this.MessageBox.Add(message);
                            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);

                            if (result == CommonData.MessageTypeResult.Yes)
                            {
                                iReturnCode = this.SaveData();
                                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                                {
                                    this.LoadNextData();
                                }
                                this.SetControl();
                            }
                        }
                    }
                    break;

                case CommonData.Mode.View:
                    {
                        this.LoadNextData();
                        this.SetControl();
                    }
                    break;
            }

            #region Logger End

            log.Write(Logger.Level.Debug, "SaveAndNext End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click SaveAndClose button
        /// ViewMode is Edit: update data and close form
        /// ViewMode is New: insert data and close form
        /// </summary>
        protected virtual void SaveAndClose()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "SaveAndClose Start");

            #endregion Logger Start

            if (btnSaveAndClose.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnSaveAndClose.Enabled == false)
            {
                return;
            }
            int iReturnCode = CommonData.DbReturnCode.Succeed;
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            switch (this.ViewMode)
            {
                case CommonData.Mode.Edit:
                    {
                        if (this.ValidateData() == CommonData.IsValid.Successful)
                        {
                            this.lblErrorMessage.Text = CommonData.StringEmpty;
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_SAVE);
                            this.MessageBox.Add(message);
                            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (result == CommonData.MessageTypeResult.Yes)
                            {
                                iReturnCode = this.SaveData();
                                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                                {
                                    this.CloseForm();
                                }
                            }
                        }
                    }
                    break;

                case CommonData.Mode.New:
                    {
                        if (this.ValidateData() == CommonData.IsValid.Successful)
                        {
                            this.lblErrorMessage.Text = CommonData.StringEmpty;
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_SAVE);
                            this.MessageBox.Add(message);
                            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (result == CommonData.MessageTypeResult.Yes)
                            {
                                iReturnCode = this.SaveData();
                                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                                {
                                    this.CloseForm();
                                }
                                this.SetControl();
                            }
                        }
                    }
                    break;

                case CommonData.Mode.View:
                    {
                        this.CloseForm();
                    }
                    break;
            }

            #region Logger End

            log.Write(Logger.Level.Debug, "SaveAndClose End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click SaveAndClose button
        /// ViewMode is Edit: update data and not close form
        /// ViewMode is New: insert data and not close form
        /// </summary>
        protected virtual void SaveAndNotClose()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "SaveAndClose Start");

            #endregion Logger Start

            if (btnSaveAndClose.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnSaveAndClose.Enabled == false)
            {
                return;
            }
            int iReturnCode = CommonData.DbReturnCode.Succeed;
            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            switch (this.ViewMode)
            {
                case CommonData.Mode.Edit:
                    {
                        if (this.ValidateData() == CommonData.IsValid.Successful)
                        {
                            this.lblErrorMessage.Text = CommonData.StringEmpty;
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_SAVE);
                            this.MessageBox.Add(message);
                            MsgTypeResult = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (MsgTypeResult == CommonData.MessageTypeResult.Yes)
                            {
                                iReturnCode = this.SaveData();
                                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                                {
                                    //do nothing
                                    //this.CloseForm();
                                }
                            }
                        }
                    }
                    break;

                case CommonData.Mode.New:
                    {
                        if (this.ValidateData() == CommonData.IsValid.Successful)
                        {
                            this.lblErrorMessage.Text = CommonData.StringEmpty;
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_SAVE);
                            this.MessageBox.Add(message);
                            MsgTypeResult = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (MsgTypeResult == CommonData.MessageTypeResult.Yes)
                            {
                                iReturnCode = this.SaveData();
                                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                                {
                                    //do nothing
                                    //this.CloseForm();
                                }
                                this.SetControl();
                            }
                        }
                    }
                    break;

                case CommonData.Mode.View:
                    {
                        this.CloseForm();
                    }
                    break;
            }

            #region Logger End

            log.Write(Logger.Level.Debug, "SaveAndClose End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click SaveAndNext button
        /// </summary>
        protected void Previous()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "Previous Start");

            #endregion Logger Start

            if (btnPrevious.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnPrevious.Enabled == false)
            {
                return;
            }
            this.LoadPreviousData();
            this.SetControl();

            #region Logger End

            log.Write(Logger.Level.Debug, "Previous End");

            #endregion Logger End
        }

        /// <summary>
        /// This method is called when click Close button
        /// </summary>
        protected void CloseForm()
        {
            isProgrammaticClose = true;
            this.Close();
        }

        protected override void SetAuthorityControl()
        {
            if (this.IsAuthority(CommonData.OperId.Edit) == CommonData.IsAuthority.Deny)
            {
                btnClear.Enabled = false;
            }
        }

        protected virtual bool IsFormChanged()
        {
            if (this.ListDto != null)
            {
                IDto oldDto = this.CurrentDto;
                IDto newDto = this.Dto;
                Type dtoType = oldDto.GetType();
                System.Reflection.PropertyInfo[] properties = dtoType.GetProperties();

                // Start Update by Trong on 20130801 for DNP project
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    object oldVar = dtoType.GetProperty(property.Name).GetValue(oldDto, null);
                    object newVar = dtoType.GetProperty(property.Name).GetValue(newDto, null);

                    if (CommonMethod.IsNullOrEmpty(oldVar) && CommonMethod.IsNullOrEmpty(newVar))
                    {
                        continue;
                    }
                    if (!CommonMethod.IsNullOrEmpty(oldVar) && CommonMethod.IsNullOrEmpty(newVar))
                    {
                        return true;
                    }
                    if (CommonMethod.IsNullOrEmpty(oldVar) && !CommonMethod.IsNullOrEmpty(newVar))
                    {
                        return true;
                    }
                    if (!CommonMethod.IsNullOrEmpty(oldVar) && !oldVar.Equals(newVar))
                    {
                        return true;
                    }
                }
                // End Update by Trong on 20130801 for DNP project
            }

            return false;
        }

        protected virtual bool Exit()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "Exit Start");

            #endregion Logger Start

            bool isExit = false;
            if (IsChanged)
            {
                this.MessageBox = new MessageBoxs();
                IvsMessage message = null;
                message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_EXIT);
                this.MessageBox.Add(message);
                CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNoCancel);
                if (result == CommonData.MessageTypeResult.Yes)
                {
                    if (this.ValidateData() == CommonData.IsValid.Successful)
                    {
                        this.SaveData();
                        this.CloseForm();
                        isExit = true;
                    }
                }
                else if (result == CommonData.MessageTypeResult.No)
                {
                    this.CloseForm();
                    isExit = true;
                }
            }
            else
            {
                this.CloseForm();
                isExit = true;
            }

            return isExit;
            #region Logger End

            log.Write(Logger.Level.Debug, "Exit End");

            #endregion Logger End
        }

        /// <summary>
        /// Set tool tip for button
        /// </summary>
        protected virtual void SupperTip()
        {
            //Set Supper Tip Clear Button
            if (ViewMode == CommonData.Mode.View)
            {
                args.Title.Text = "F4";
            }
            else
            {
                args.Title.Text = "F5";
            }
            sTooltip.Setup(args);
            btnClear.SuperTip = sTooltip;

            //Set Supper Tip SaveAndNext Button
            sTooltip = new SuperToolTip();
            args = new SuperToolTipSetupArgs();
            if (ViewMode == CommonData.Mode.View)
            {
                args.Title.Text = "→";
            }
            else
            {
                args.Title.Text = "F12";
            }
            sTooltip.Setup(args);
            btnSaveAndNext.SuperTip = sTooltip; 
        }
    }
}