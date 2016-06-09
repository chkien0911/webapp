using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Interface;
using Ivs.Core.Logger;

namespace Ivs.Controls.Forms
{
    public partial class TransEditForm : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        private static readonly Logger log = new Logger();

        #region Private Variables

        //Next position of member in ListDto that need load data to input control
        protected int currentPosition = 0;

        protected bool isProgrammaticClose = false;

        #endregion Private Variables

        #region Public Variables

        //Current mode of form
        public virtual CommonData.Mode ViewMode { get; set; }

        #endregion Public Variables

        #region Properties

        protected virtual bool IsChanged
        {
            get
            {
                return IsFormChanged();
            }
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
                if (ListDto != null)
                {
                    return this.ListDto[currentPosition];
                }
                else
                {
                    return null;
                }
            }
        }

        protected virtual Ivs.Core.Interface.IBl Bl
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

        #endregion Properties

        public TransEditForm()
        {
            InitializeComponent();

            #region Add Event For Control

            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveAndClose);
            this.btnSaveAndNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.SaveAndNext);
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Previous);
            this.btnClear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ClearOrReset);
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Close);
            this.Load += new System.EventHandler(this.TransEditForm_Load);
            this.lblErrorMessage.Click += new EventHandler(lblErrorMessage_Click);
            this.FormClosing += new FormClosingEventHandler(TransEditForm_FormClosing);
            this.Activated += new EventHandler(TransEditForm_Activated);
            //this.SetLanguage();
            //this.LoadData();
            //this.SetControl();

            #endregion Add Event For Control

            SetAuthorityControl();
        }

        private void TransEditForm_Activated(object sender, EventArgs e)
        {
            UserSession.FunctionId = FunctionId;
        }

        private void TransEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

        #region Form Load Event

        protected void TransEditForm_Load(object sender, EventArgs e)
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "TransEditForm_Load Start");

            #endregion Logger Start

            this.SetLanguage();
            this.LoadData();
            this.SetControl();

            #region Logger End

            log.Write(Logger.Level.Debug, "TransEditForm_Load End");

            #endregion Logger End
        }

        #endregion Form Load Event

        #region Protected Method

        /// <summary>
        /// Set language for button control
        /// </summary>
        public virtual void SetLanguage()
        {
            //create I18n class object
            I18n i18n = new I18n(CommonData.FunctionId.MasterEdit);

            //Set language for control of MasterEdit form
            this.btnSaveAndClose.Caption = i18n.GetString(this.btnSaveAndClose.Name);
            this.btnClose.Caption = i18n.GetString(this.btnClose.Name);
            this.btnPrevious.Caption = i18n.GetString(this.btnPrevious.Name);
            this.lblErrorMessage.Text = i18n.GetString(this.lblErrorMessage.Name);
            switch (this.ViewMode)
            {
                case CommonData.Mode.View:
                    {
                        this.btnSaveAndNext.Caption = i18n.GetString(CommonData.ButtonCaption.Next);
                        this.btnClear.Caption = i18n.GetString(CommonData.ButtonCaption.Edit);
                    }
                    break;

                case CommonData.Mode.Edit:
                    {
                        this.btnSaveAndNext.Caption = i18n.GetString(CommonData.ButtonCaption.SaveAndNext);
                        this.btnClear.Caption = i18n.GetString(CommonData.ButtonCaption.Reset);
                    }
                    break;

                case CommonData.Mode.New:
                    {
                        btnSaveAndNext.Caption = i18n.GetString(CommonData.ButtonCaption.SaveAndNext);
                        btnClear.Caption = i18n.GetString(CommonData.ButtonCaption.Clear);
                    }
                    break;
            }
        }

        /// <summary>
        /// Set status display of control follow to viewMode
        /// Child form will override this method
        /// </summary>
        protected virtual void SetControl()
        {
            lblErrorMessage.Visible = true;
            lblErrorMessage.Text = CommonData.StringEmpty;
            btnClose.Enabled = true;

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
            this.Previous();
        }

        /// <summary>
        /// This method is called when click Close button
        /// </summary>
        protected virtual void Close(object sender, EventArgs e)
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

        /// <summary>
        /// Load data for input control follow to viewMode
        /// </summary>
        protected virtual void LoadData()
        {
            try
            {
                this.Dto = null;
                if (this.ListDto != null)
                {
                    switch (this.ViewMode)
                    {
                        case CommonData.Mode.View:
                            {
                                object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                                CommonMethod.Clone(this.CurrentDto, out dto);
                                this.Dto = (IDto)dto;
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
            catch (Exception ex)
            {
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
                iReturnCode = Bl.UpdateData(this.Dto);
                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    object dto = Activator.CreateInstance(this.CurrentDto.GetType());
                    CommonMethod.Clone(this.Dto, out dto);
                    this.ListDto[currentPosition] = (IDto)dto;
                    message = new IvsMessage("CMN004");
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
                else
                {
                    ProcessDbExcetion(iReturnCode);
                }
            }
            ////This is case ViewMode is New, system will insert data to databas
            else if (this.ViewMode == CommonData.Mode.New)
            {
                iReturnCode = Bl.InsertData(this.Dto);
                if (iReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    message = new IvsMessage("CMN003");
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
                else
                {
                    ProcessDbExcetion(iReturnCode);
                }
            }
            return iReturnCode;
        }

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
            if ((keyData == Keys.F4 && this.ViewMode == CommonData.Mode.View)
                || (keyData == Keys.F5 && this.ViewMode != CommonData.Mode.View)
                || (keyData == Keys.F6 && this.ViewMode == CommonData.Mode.Edit))
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
            if (this.btnClear.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnClear.Enabled == false)
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
                        this.SetLanguage();
                    }
                    break;
            }
            this.SetControl();

            #region Logger

            log.Write(Logger.Level.Info, "End");

            #endregion Logger
        }

        /// <summary>
        /// This method is called when click SaveAndNext button
        /// </summary>
        protected void SaveAndNext()
        {
            #region Logger Start

            log.GetLogger(this.Name.ToString());
            log.Write(Logger.Level.Debug, "SaveAndNext Start");

            #endregion Logger Start

            if (btnSaveAndNext.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnSaveAndNext.Enabled == false)
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
                            message = new IvsMessage("CMN021");
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
                            message = new IvsMessage("CMN021");
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
                            message = new IvsMessage("CMN021");
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
                            message = new IvsMessage("CMN021");
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

        #endregion Private Method

        protected virtual bool IsFormChanged()
        {
            if (this.ListDto != null)
            {
                IDto oldDto = this.CurrentDto;
                IDto newDto = this.Dto;
                Type dtoType = oldDto.GetType();
                System.Reflection.PropertyInfo[] properties = dtoType.GetProperties();
                foreach (System.Reflection.PropertyInfo property in properties)
                {
                    object oldVar = dtoType.GetProperty(property.Name).GetValue(oldDto, null);
                    object newVar = dtoType.GetProperty(property.Name).GetValue(newDto, null);

                    if (oldVar == null && newVar == null)
                    {
                        continue;
                    }
                    if (oldVar != null && newVar == null)
                    {
                        return true;
                    }
                    if (oldVar == null && newVar != null)
                    {
                        return true;
                    }
                    if (!oldVar.Equals(newVar))
                    {
                        return true;
                    }
                }
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
                message = new IvsMessage("CMN010");
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
                if (result == CommonData.MessageTypeResult.No)
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
    }
}