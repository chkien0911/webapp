using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ivs.DTO.Common;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.BLL.Common;
using Ivs.Controls.CustomControls.WinForm.Inventory;
using Ivs.Core.Interface;
using Ivs.BLL.Business;
using DevExpress.Utils;
using Ivs.Controls.CustomControls.WinForm;
using Ivs.DTO.Report;
using Ivs.DTO.Systems;
using Ivs.DTO.Stock;
using DevExpress.XtraBars;

namespace Ivs.Controls.Forms.Inventory
{
    public partial class InventoryEditForm : MasterEditForm
    {
        public bool SafetyStockFlag { get; set; }
        protected StockUserControl ctrlHeader = null;
        protected IvsInventoryGridControl ctrlDetail = null;
        protected IvsInventoryGridControl ctrlDetail1 = null;
        protected ST_StockTransactionMasterDto stockMasterDto;
        protected IvsUserControl transactionMasterControl;
        protected int printedCount = 0;

        #region Inventory Properties

        public string DocumentNumber { get; set; }

        protected virtual IDto MasterDto
        {
            get;
            set;
        }

        #endregion

        private bool _includeDetail = true;
        [DefaultValue(true)]
        protected bool IncludeDetail
        {
            get
            {
                return _includeDetail;
            }
            set
            {
                _includeDetail = value;
            }
        }

        #region Report properties
        protected virtual IvsReport ReportForm
        {
            get;
            set;
        }

        protected virtual MasterEditForm ReasonPrintForm
        {
            get;
            set;
        }

        #endregion

        protected virtual IStockBl Bl
        {
            get;
            set;
        }

        public InventoryEditForm()
        {
            this.ShowProgressBar();

            InitializeComponent();

            this.HideProgressBar();
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = base.LstControls;
                lstControls.Add(this.btnCancel, this.btnCancel.Name);
                lstControls.Add(this.btnInventory, this.btnInventory.Name);
                lstControls.Add(this.btnPrintSheet, this.btnPrintSheet.Name);
                lstControls.Add(this.btnExport, this.btnExport.Name);
                return lstControls;
            }
        }

        /// <summary>
        /// Override Open method to turn on Show mode (not ShowDialog mode)
        /// </summary>
        //public override void Open()
        //{
        //    this.Show();
        //}

        /// <summary>
        /// Initalize controls
        /// </summary>
        protected override void InitControl()
        {
            base.InitControl();
            #region Set Tooltips
            //Set tool tips 
            this.SupperTip();
            #endregion
            //Add new buttons
            base.bar3.LinksPersistInfo.Clear();
            base.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPrintSheet),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnInventory),
            new DevExpress.XtraBars.LinkPersistInfo(base.btnSaveAndClose),
            new DevExpress.XtraBars.LinkPersistInfo(base.btnSaveAndNext),
            new DevExpress.XtraBars.LinkPersistInfo(base.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExport),
            new DevExpress.XtraBars.LinkPersistInfo(base.btnClose)});

            //Add event
            this.btnInventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnInventory_ItemClick);
            this.btnPrintSheet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnPrintSheet_ItemClick);
            this.btnCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnCancel_ItemClick);
            this.btnExport.ItemClick += new ItemClickEventHandler(btnExport_ItemClick);
            this.btnExportXls.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnExportXls_ItemClick);
            this.btnExportXlsx.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(btnExportXlsx_ItemClick);

            ctrlHeader.InitControl();
            //ctrlHeader.Reset();
            if (ctrlDetail != null)
            {
                ctrlDetail.GridNumber = 1;
                ctrlDetail.SetLanguage();
                if (this.CurrentDto != null)
                {
                    ctrlDetail.InitControl(((ST_StockTransactionMasterDto)this.CurrentDto).WarehouseCode);
                }
            }
            if (ctrlDetail1 != null)
            {
                ctrlDetail1.GridNumber = 2;
                ctrlDetail1.SetLanguage();
                if (this.CurrentDto != null)
                {
                    ctrlDetail1.InitControl(((ST_StockTransactionMasterDto)this.CurrentDto).WarehouseCode);
                }
            }
            this.ReasonPrintForm = new MasterEditForm();
            ReasonPrintForm.FormClosed += new FormClosedEventHandler(ReasonPrintForm_FormClosed);
        }

        protected override void LoadControlData()
        {
            base.LoadControlData();

            ctrlHeader.LoadControlData();

            if (ctrlDetail != null)
            {
                ctrlDetail.LoadControlData();
            }
            if (ctrlDetail1 != null)
            {
                ctrlDetail1.LoadControlData();
            }
        }

        void btnInventory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.btnInventory.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnInventory.Enabled == false)
            {
                return;
            }

            this.ViewInventory();
        }

        /// <summary>
        /// Override ProcessCmdKey method (HotKey processing)
        /// </summary>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            //Hot Key for Inventory button
            if (keyData == (Keys.Control | Keys.F))
            {
                this.btnInventory.PerformClick();
                return true;
            }
            //Hot Key for PrintSheet button
            if (keyData == (Keys.F10))
            {
                this.btnPrintSheet.PerformClick();
                return true;
            }
            //Hot Key for Cancel button
            if (keyData == (Keys.F7))
            {
                this.btnCancel.PerformClick();
                return true;
            }
            if (keyData == (Keys.F9))
            {
                this.btnExport.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


        #region Events

        /// <summary>
        /// Cancel document event
        /// </summary>
        protected void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Cancel();
        }

        /// <summary>
        /// Print delivery sheet event
        /// </summary>
        protected virtual void btnPrintSheet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        protected void btnExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Export();
        }

        protected void btnExportXlsx_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ExportToXlsx();
        }

        protected void btnExportXls_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ExportToXls();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Cancel document
        /// </summary>
        protected virtual void Cancel()
        {
            if (btnCancel.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || btnCancel.Enabled == false)
            {
                return;
            }

            this.MessageBox = new MessageBoxs();
            IvsMessage message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_CANCEL);
            this.MessageBox.Add(message);
            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
            if (result == CommonData.MessageTypeResult.Yes)
            {
                //Input cancel reason
                ReasonForm reasonForm = new ReasonForm();
                reasonForm.ShowDialog();
                if (reasonForm.MsgTypeResult == CommonData.MessageTypeResult.OK)
                {
                    ST_StockTransactionMasterDto cancelDto = ((ST_StockTransactionMasterDto)this.Dto);
                    cancelDto.CancelReason = reasonForm.Reason;

                    this.MessageBox = new MessageBoxs();
                    StockTransactionBl stockTransactionBl = new StockTransactionBl();
                    StockResult stockResult = stockTransactionBl.Cancel(cancelDto);
                    if (stockResult.ReturnCode == CommonData.StockReturnCode.Succeed)
                    {
                        message = new IvsMessage(CommonConstantMessage.COM_MSG_CANCEL_SUCCESSFULLY);
                        this.MessageBox.Add(message);
                        this.MessageBox.Display(CommonData.MessageType.Ok);

                        this.CloseForm();
                    }
                    else
                    {
                        lblErrorMessage.Text = ProcessStockException(stockResult);
                    }
                }
            }
        }

        /// <summary>
        /// Confirm want to clear all data
        /// </summary>
        protected override void ClearOrReset()
        {
            if (this.IsFormChanged())
            {
                this.MessageBox = new MessageBoxs();
                IvsMessage message = new IvsMessage(CommonConstantMessage.COM_MSG_CONFIRM_CLEAR);
                this.MessageBox.Add(message);
                CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
                if (result == CommonData.MessageTypeResult.No)
                    return;
            }
            base.ClearOrReset();
        }

        /// <summary>
        /// Print delivery sheet
        /// </summary>
        protected virtual void PrintSheet(IvsUserControl masterControl)
        {
            if (this.btnPrintSheet.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnPrintSheet.Enabled == false)
            {
                return;
            }

            StockTransactionBl stocktransactionBl = new StockTransactionBl();
            stockMasterDto = (ST_StockTransactionMasterDto)this.Dto;
            transactionMasterControl = masterControl;
            DataTable stockMasterDt = new DataTable();
            int rows = 0;
            int returnCode = stocktransactionBl.SearchMaster(stockMasterDto, out stockMasterDt, out rows);
            if (!CommonMethod.IsNullOrEmpty(stockMasterDt))
            {
                printedCount = CommonMethod.ParseInt32(stockMasterDt.Rows[0][CommonKey.DeliverySheetPrintCount]);
                stockMasterDto.DeliverySheetPrintCount = printedCount;
                if (printedCount == 0)
                {
                    printedCount = printedCount + 1;
                    this.ShowReport(printedCount);
                    this.UpdateStockTransactionMasterForCountingPrint(printedCount, string.Empty);
                    var collection = masterControl.Controls.Find("txtPrintCount", true);
                    if (collection.Length > 0)
                    {
                        Ivs.Controls.CustomControls.WinForm.IvsTextEdit chk = (Ivs.Controls.CustomControls.WinForm.IvsTextEdit)collection[0];
                        chk.Text = printedCount.ToString();
                    }
                }
                else
                {
                    if (printedCount <= CommonData.PrintSheetDelivery.DeliverySheet)
                    {
                        ReasonPrintForm.ShowDialog();
                    }
                    else
                    {
                        //Display message can not print more than four times.
                        this.MessageBox = new MessageBoxs();
                        IvsMessage message = null;
                        message = new IvsMessage(CommonConstantMessage.COM_MSG_CAN_NOT_PRINT, "4");
                        this.MessageBox.Add(message);
                        this.MessageBox.Display(CommonData.MessageType.Ok);
                    }
                }
            }
        }

        /// <summary>
        /// Show report 
        /// </summary>
        protected void ShowReport(int countedPrint)
        {
            StockTransactionBl stocktransactionBl = new StockTransactionBl();
            List<DeliverySheetDTO> lstResult = new List<DeliverySheetDTO>();
            //stockMasterDto = (ST_StockTransactionMasterDto)this.Dto;
            DeliverySheetHeaderDTO deliverySheetHeaderDto = new DeliverySheetHeaderDTO();
            stockMasterDto.DeliverySheetPrintCount = countedPrint;
            stocktransactionBl.SearchDataForReport(stockMasterDto, out lstResult, out deliverySheetHeaderDto);

            //this.ReportForm = new IvsReport();
            this.ReportForm.CreateDocument(true);
            this.ReportForm.BindHeader(deliverySheetHeaderDto);
            this.ReportForm.DataSource = lstResult;
            this.ReportForm.BindData();
            //this.ReportForm.ShowPreview();
        }

        private void UpdateStockTransactionMasterForCountingPrint(int printCounted, string reason)
        {
            ST_StockTransactionMasterDto stockTransactionDto = this.ctrlHeader.Dto as ST_StockTransactionMasterDto;
            stockTransactionDto.DeliverySheetPrintCount = printCounted;
            stockTransactionDto.DeliverySheetRePrintReason = reason;
            new StockTransactionBl().UpdatePrint(stockTransactionDto);
        }

        private void ReasonPrintForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MasterEditForm form = sender as MasterEditForm;
            string printSheetReason = CommonData.StringEmpty;
            if (form.ListDto != null && form.ListDto.Count > 0)
            {
                foreach (SH_DeliveryPrintConfirmDto dto in form.ListDto)
                {
                    printSheetReason = CommonMethod.ParseString(dto.Reason);
                }
            }

            if (form.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                printedCount = printedCount + 1;
                this.UpdateStockTransactionMasterForCountingPrint(printedCount, printSheetReason);
                this.ShowReport(printedCount);

                ////Set Printed check box is checked
                var collection = transactionMasterControl.Controls.Find("txtPrintCount", true);
                if (collection.Length > 0)
                {
                    Ivs.Controls.CustomControls.WinForm.IvsTextEdit chk = (Ivs.Controls.CustomControls.WinForm.IvsTextEdit)collection[0];
                    chk.Text = CommonMethod.ParseString(printedCount);
                    stockMasterDto.DeliverySheetPrintCount = printedCount;
                }

                var collection2 = transactionMasterControl.Controls.Find("txtPrintReason", true);
                if (collection2.Length > 0)
                {
                    //ST_StockTransactionMasterDto stockTransactionMaster = new ST_StockTransactionMastersBL().GetOneStockTransactionMaster((this.ctrlHeader.Dto as ST_StockTransactionMasterDto).DocumentNumber);
                    Ivs.Controls.CustomControls.WinForm.IvsTextEdit txtPrintReason = (Ivs.Controls.CustomControls.WinForm.IvsTextEdit)collection2[0];
                    txtPrintReason.Visible = true;
                    txtPrintReason.Text = printSheetReason;
                }
            }
        }

        private void DeliverySheetReportAfterPrint(object sender, EventArgs e)
        {
            //ST_StockTransactionMasterDto stockTransactionMaster = new ST_StockTransactionMastersBL().GetOneStockTransactionMaster((this.ctrlHeader.Dto as ST_StockTransactionMasterDto).DocumentNumber);
            //if (stockTransactionMaster != null)
            //{
            //    this.UpdateStockTransactionMasterForCountingPrint(Convert.ToInt32(stockTransactionMaster.DeliverySheetPrintFlg) + 1, this.printDeliverySheetMessageFormConfirm.Reason);
            //}
        }

        /// <summary>
        /// View Inventory
        /// </summary>
        protected virtual void ViewInventory()
        {

        }

        protected virtual void Export()
        {
            if (this.btnExport.Visibility == DevExpress.XtraBars.BarItemVisibility.Never || this.btnExport.Enabled == false)
            {
                return;
            }
            PopupMenu menu = new PopupMenu();
            // Bind the menu to a bar manager.
            menu.Manager = barManager1;
            // Add two items that belong to the bar manager.
            menu.ItemLinks.Add(btnExportXls);
            menu.ItemLinks.Add(btnExportXlsx);
            this.btnExport.DropDownControl = menu;
            int index = bar3.ItemLinks.Count - 2 < 0 ? 0 : bar3.ItemLinks.Count - 2;
            System.Drawing.Rectangle rec = bar3.ItemLinks[index].ScreenBounds;
            menu.ShowPopup(new System.Drawing.Point(rec.X, rec.Y));
        }

        /// <summary>
        /// Processing when click btnExportXls
        /// </summary>
        protected virtual void ExportToXls()
        {
            if (this.ctrlDetail != null)
            {
                if (this.ctrlDetail.dgcInventory.ExportToXls() == CommonData.IOReturnCode.AccessDenied)
                {
                    IvsMessage message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                    return;
                }
            }

            if (this.ctrlDetail1 != null)
            {
                if (this.ctrlDetail1.dgcInventory.ExportToXls() == CommonData.IOReturnCode.AccessDenied)
                {
                    IvsMessage message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                    return;
                }
            }
        }

        /// <summary>
        /// Processing when click btnExportXlsx
        /// </summary>
        protected virtual void ExportToXlsx()
        {
            if (this.ctrlDetail != null)
            {
                if (this.ctrlDetail.dgcInventory.ExportToXlsx() == CommonData.IOReturnCode.AccessDenied)
                {
                    IvsMessage message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                    return;
                }
            }

            if (this.ctrlDetail1 != null)
            {
                if (this.ctrlDetail1.dgcInventory.ExportToXlsx() == CommonData.IOReturnCode.AccessDenied)
                {
                    IvsMessage message = new IvsMessage(CommonConstantMessage.COM_MSG_ACCESS_DENIED);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                    return;
                }
            }
        }

        #endregion

        #region Override methods

        /// <summary>
        /// Insert or update data to database
        /// </summary>
        protected override int SaveData()
        {
            this.ShowProgressBar();

            this.MessageBox = new MessageBoxs();
            IvsMessage message = null;
            StockResult stockResult = new StockResult();
            ST_StockTransactionMasterDto stockMaster = (ST_StockTransactionMasterDto)this.Dto;
            stockMaster.SafetyStockFlag = this.SafetyStockFlag;

            //This is case ViewMode is Edit, system will update data to database
            if (this.ViewMode == CommonData.Mode.Edit)
            {
                ///UAT : Nếu ngày xuất và ngày nhận ko cùng 1 ngày => khi nhận sẽ có thông báo warning lên cho user biết > 
                ///nếu user nhấn yes trên warning cho nhận nếu nhấn no trên warning ko cho nhận.
                if (FunctionGr == CommonData.FunctionGr.ST_ST_StockTransferArrivingInStorage)
                {
                    if (Dto != null)
                    {
                        ST_StockTransactionMasterDto dtoMaster = (ST_StockTransactionMasterDto)Dto;

                        if (dtoMaster.ShippingDate != dtoMaster.ArrivingDate)
                        {
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_NOT_MATCH_WARNING, dtoMaster.ArrivingDateCtrl, dtoMaster.ShippingDateCtrl);
                            this.MessageBox.Add(message);
                            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (result != CommonData.MessageTypeResult.Yes)
                                return CommonData.DbReturnCode.DataNotFound;
                        }
                    }

                }

                stockResult = Bl.UpdateTransactionData(stockMaster);
                if (stockResult.ReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    message = new IvsMessage(CommonConstantMessage.COM_MSG_UPDATE_SUCCESSFULLY);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
                else
                {
                    this.ProcessStockException(stockResult);
                }
            }
            //This is case ViewMode is New, system will insert data to databas
            else if (this.ViewMode == CommonData.Mode.New)
            {
                stockResult = Bl.InsertTransactionData(stockMaster);
                if (stockResult.ReturnCode == CommonData.DbReturnCode.Succeed)
                {
                    this.DocumentNumber = stockResult.DocumentNumber;

                    //stockMaster.DocumentNumber = stockResult.DocumentNumber;
                    //this.Dto = stockMaster;
                    //stockMaster.DocumentNumber = stockResult.DocumentNumber;
                    //this.ctrlHeader.Dto = stockMaster;

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_INSERT_SUCCESSFULLY);
                    this.MessageBox.Add(message);
                    this.MessageBox.Display(CommonData.MessageType.Ok);
                }
                else
                {
                    if (this.SafetyStockFlag == false)
                    {
                        //Check warning safety dangerous
                        //count number of safety dangerous
                        int numOfSafetyDangerous = stockResult.ErrorList.Count(lt => lt.ReturnCode.Equals(CommonData.StockReturnCode.StockSafetyDangerous));
                        //check if total error is number of safety dangerous
                        if (numOfSafetyDangerous > 0 && (numOfSafetyDangerous == stockResult.ErrorList.Count))
                        {
                            //Show warning
                            //message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_SAFETY_DANGEROUS);
                            for (int i = 0; i < stockResult.ErrorList.Count; i++)
                            {
                                switch (stockResult.ErrorList[i].ReturnCode)
                                {
                                    case CommonData.StockReturnCode.StockSafetyDangerous:
                                        message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_SAFETY_DANGEROUS, stockResult.ErrorList[i].Line);
                                        this.MessageBox.Add(message);
                                        break;
                                    default:
                                        break;
                                }
                            }
                            //this.MessageBox.Add(message);
                            CommonData.MessageTypeResult result = this.MessageBox.Display(CommonData.MessageType.YesNo);
                            if (result == CommonData.MessageTypeResult.Yes)
                            {
                                //Update SafetyFlag to not warning again.
                                this.SafetyStockFlag = true;

                                //Save again
                                stockResult.ReturnCode = this.SaveData();
                            }
                        }
                        else
                        {
                            this.ProcessStockException(stockResult);
                        }
                    }
                    else
                    {
                        this.ProcessStockException(stockResult);
                    }
                }
            }

            this.HideProgressBar();

            return stockResult.ReturnCode;
        }


        /// <summary>
        /// Override LoadData method
        /// </summary>
        protected override void LoadData()
        {
            //this.ShowProgressBar();

            //Authorization
            //SetAuthorityControlOnlyThis();

            //ReInit
            if (ctrlDetail != null)
            {
                ctrlDetail.InitControl(((ST_StockTransactionMasterDto)this.CurrentDto).WarehouseCode);

                ctrlDetail.dgvInventory.OptionsView.ShowAutoFilterRow = ViewMode == CommonData.Mode.View;
                ctrlDetail.dgvInventory.OptionsCustomization.AllowSort = ViewMode == CommonData.Mode.View;
            }
            if (ctrlDetail1 != null)
            {
                ctrlDetail1.InitControl(((ST_StockTransactionMasterDto)this.CurrentDto).WarehouseCode);

                ctrlDetail1.dgvInventory.OptionsView.ShowAutoFilterRow = ViewMode == CommonData.Mode.View;
                ctrlDetail1.dgvInventory.OptionsCustomization.AllowSort = ViewMode == CommonData.Mode.View;
            }

            base.LoadData();
            this.SetLanguage();

            //this.HideProgressBar();
        }


        /// <summary>
        /// Override IsFormChanged method
        /// </summary>
        protected override bool IsFormChanged()
        {

            if (this.ListDto != null && this.ViewMode != CommonData.Mode.View)
            {
                ST_StockTransactionMasterDto oldDto = (ST_StockTransactionMasterDto)this.CurrentDto;
                ST_StockTransactionMasterDto newDto = (ST_StockTransactionMasterDto)this.Dto;

                if (oldDto.DepartmentCode != newDto.DepartmentCode)
                {
                    return true;
                }

                if (oldDto.WarehouseCode != newDto.WarehouseCode)
                {
                    return true;
                }

                if (oldDto.TransactionSupCode != newDto.TransactionSupCode)
                {
                    return true;
                }

                if (CommonMethod.ParseDate(oldDto.ShippingDate) != CommonMethod.ParseDate(newDto.ShippingDate))
                {
                    return true;
                }

                if (CommonMethod.ParseDate(oldDto.ArrivingDate) != CommonMethod.ParseDate(newDto.ArrivingDate))
                {
                    return true;
                }

                if (oldDto.PersonInChange != newDto.PersonInChange)
                {
                    return true;
                }

                if (oldDto.PostedPerson != newDto.PostedPerson)
                {
                    return true;
                }

                if (CommonMethod.ParseString(oldDto.PersonInChange2) != CommonMethod.ParseString(newDto.PersonInChange2))
                {
                    return true;
                }

                if (CommonMethod.ParseDate(oldDto.PostedDate) != CommonMethod.ParseDate(newDto.PostedDate))
                {
                    return true;
                }

                //if (oldDto.CustomerCode != newDto.CustomerCode)
                //{
                //    return true;
                //}


                //if (oldDto.SupplierCode != newDto.SupplierCode)
                //{
                //    return true;
                //}


                if (oldDto.CompanyCode != newDto.CompanyCode)
                {
                    return true;
                }

                if (CommonMethod.ParseString(oldDto.Description) != CommonMethod.ParseString(newDto.Description))
                {
                    return true;
                }

                if (newDto.CheckDetails.Count > 0)
                {
                    return true;
                }

                if (newDto.CheckDetails1.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Override process error
        /// </summary>
        public virtual string ProcessStockException(StockResult stockResult)
        {
            string messageText = CommonData.StringEmpty;
            if (stockResult.ErrorList.Count == 0)
            {
                messageText = base.ProcessDbExcetion(stockResult.ReturnCode);
                if (CommonMethod.IsNullOrEmpty(messageText))
                {
                    this.MessageBox = new MessageBoxs();
                    IvsMessage message = null;
                    switch (stockResult.ReturnCode)
                    {
                        case CommonData.StockReturnCode.StockArrivingDateNoNull:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_ARRIVING_DATE_NO_NULL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockCancelFail:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_CANCEL_FAIL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockCancelSuccess:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_CANCEL_SUCCESSFULLY);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockCustomerNoNull:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_CUSTOMER_NO_NULL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockDocumnetNoNull:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_DOCUMENT_NO_NULL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockPeriodClose:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_PERIOD_CLOSE);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockPeriodLock:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_PERIOD_LOCK);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockPeriodNotExist:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_PERIOD_NOT_EXIST);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockShippingDateNoNull:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_SHIPPING_DATE_NO_NULL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockSupplierNoNull:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_SUPPLIER_NO_NULL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockWareHouse2NoNull:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_WAREHOUSE2_NO_NULL);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.StockWareHouse2NotExist:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_WAREHOUSE2_NOT_EXIST);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        case CommonData.StockReturnCode.DocumentCanceled:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_DOCUMENT_CANCELED);
                            this.MessageBox.Add(message);
                            this.MessageBox.Display(CommonData.MessageType.Ok);
                            break;
                        default:
                            break;
                    }

                    messageText = this.MessageBox.DisplayMessage;
                }
            }
            else
            {
                this.MessageBox = new MessageBoxs();
                IvsMessage message = null;
                for (int i = 0; i < stockResult.ErrorList.Count; i++)
                {
                    switch (stockResult.ErrorList[i].ReturnCode)
                    {
                        case CommonData.StockReturnCode.StockMinusNg:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_MINUS_NG, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockMinusOk:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_MINUS_OK, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockOutEnough:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_OUT_ENOUGH, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockOutLack:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_OUT_LACK, stockResult.ErrorList[i].Line, stockResult.ErrorList[i].Period);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockSafetyDangerous:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_SAFETY_DANGEROUS, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockProductionLineNotExist:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_PRODUCTION_LINE_NOT_EXIST, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockQualityStatusNotExist:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_QUALITY_STATUS_NOT_EXIST, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockStockTypeNotValid:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_STOCK_TYPE_NOT_VALID, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.RelatedDocumentDateNotValid:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_RELATED_DOCUMENT_DATE_NOT_VALID, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.RelatedDocumentQtyNotValid:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_GRID_STOCK_RELATED_DOCUMENT_QTY_NOT_VALID, stockResult.ErrorList[i].Line);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockCancelFail:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_CANCEL_FAIL);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockCancelRelatedFail:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_CANCEL_RELATED_FAIL);
                            this.MessageBox.Add(message);
                            break;
                        case CommonData.StockReturnCode.StockCancelExistInvoice:
                            message = new IvsMessage(CommonConstantMessage.COM_MSG_STOCK_CANCEL_EXIST_INVOICE);
                            this.MessageBox.Add(message);
                            break;
                        default:
                            break;
                    }
                }
                //Show messsabox error
                this.MessageBox.Display(CommonData.MessageType.Ok);

                messageText = this.MessageBox.DisplayMessage;

            }

            return messageText;
        }

        /// <summary>
        /// Set status of control in form follow to viewMode
        /// </summary>
        protected override void SetControl()
        {
            base.SetControl();

            ctrlHeader.ViewMode = this.ViewMode;
            ctrlHeader.SetControl();
            if (ctrlDetail != null)
            {
                ctrlDetail.ViewMode = this.ViewMode;
                ctrlDetail.SetControl();
            }
            if (ctrlDetail1 != null)
            {
                ctrlDetail1.ViewMode = this.ViewMode;
                ctrlDetail1.SetControl();
            }

            if (this.ViewMode == CommonData.Mode.View)
            {
                base.btnSaveAndNext.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                base.btnClear.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                base.btnClear.Enabled = false;
                this.btnPrintSheet.Enabled = true;
                this.btnExport.Enabled = true;

                if (((ST_StockTransactionMasterDto)this.CurrentDto).CancelFlg == CommonData.CancelFlag.Cancel)
                {
                    this.btnCancel.Enabled = false;
                    this.btnPrintSheet.Enabled = false;
                }
                else
                {
                    this.btnCancel.Enabled = true;
                    this.btnPrintSheet.Enabled = true;
                }
            }
            else
            {
                base.btnClear.Enabled = true;
                this.btnCancel.Enabled = false;
                this.btnPrintSheet.Enabled = false;
                this.btnExport.Enabled = true;
            }
        }

        protected override void SetAuthorityControl()
        {
            //Not apply for Edit
            //Set authorization for Print
            ST_StockTransactionMasterDto currentDto = (ST_StockTransactionMasterDto)this.CurrentDto;
            if (currentDto != null)
            {
                //Set authorization for Print
                if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.InventoryInquiry) == CommonData.IsAuthority.Deny)
                {
                    this.btnInventory.Enabled = false;
                }
                //Set authorization for Print
                if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.Print) == CommonData.IsAuthority.Deny)
                {
                    this.btnPrintSheet.Enabled = false;
                }
                //Set authorization for Cancel
                if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.Cancel) == CommonData.IsAuthority.Deny)
                {
                    this.btnCancel.Enabled = false;
                }
                //Set authorization for Export
                if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.Export) == CommonData.IsAuthority.Deny)
                {
                    this.btnExport.Enabled = false;
                }

                //Set authorization for View PO && SO Price
                if ((currentDto.TransactionSubCode == CommonData.TransactionSubCode.SA_StockArrivingForPurchaseOrder
                    && this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.ViewPOPrice) == CommonData.IsAuthority.Deny)
                    ||
                    (currentDto.TransactionSubCode == CommonData.TransactionSubCode.SH_StockShippingForDelivery
                    && this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.ViewSOPrice) == CommonData.IsAuthority.Deny))
                {
                    if (ctrlDetail != null)
                    {
                        this.ctrlDetail.ShowUnitPrice = false;
                        this.ctrlDetail.ShowAmount = false;

                        this.ctrlDetail.ShowGridColumn();
                    }

                    if (ctrlDetail1 != null)
                    {
                        this.ctrlDetail1.ShowUnitPrice = false;
                        this.ctrlDetail1.ShowAmount = false;

                        this.ctrlDetail1.ShowGridColumn();
                    }
                }
            }
        }

        /// <summary>
        /// Override setlanguge method
        /// </summary>
        public override void SetLanguage()
        {
            base.SetLanguage();

            string fuctionGrp = this.FunctionGr;
            this.lblPath.Caption = string.Format(LanguageUltility.GetString(string.Format("{0}_{1}_Path", fuctionGrp, this.ViewMode.ToString()), "Danh mục > Danh mục cơ cấu tổ chức  > Văn phòng")
                                                , ((ST_StockTransactionMasterDto)this.CurrentDto).WarehouseName);
            this.Text = string.Format(LanguageUltility.GetString(string.Format("{0}_{1}_Form", fuctionGrp, this.ViewMode.ToString()), "Master Edit Form")
                                    , ((ST_StockTransactionMasterDto)this.CurrentDto).WarehouseName);

        }

        /// <summary>
        /// Check authorization for warehouse
        /// </summary>
        protected CommonData.IsAuthority IsWarehouseAuthority(string warehouseCode, string operId)
        {
            CommonData.IsAuthority returnCode;
            CommonBl commonBl = new CommonBl();
            returnCode = commonBl.CheckAuthority(CommonData.FunctionGr.ST_StockOverview, CommonData.OperId.All, warehouseCode);
            if (returnCode == CommonData.IsAuthority.Deny)
            {
                returnCode = commonBl.CheckAuthority(CommonData.FunctionGr.ST_StockOverview, operId, warehouseCode);
            }
            return returnCode;
        }


        /// <summary>
        /// Authorization for form
        /// </summary>
        //protected virtual void SetAuthorityControlOnlyThis()
        //{
        //    //Set authorization for Print
        //    ST_StockTransactionMasterDto currentDto = (ST_StockTransactionMasterDto)this.CurrentDto;
        //    if (currentDto != null)
        //    {
        //        //Set authorization for Print
        //        if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.Print) == CommonData.IsAuthority.Deny)
        //        {
        //            this.btnPrintSheet.Enabled = false;
        //        }
        //        //Set authorization for Cancel
        //        if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.Cancel) == CommonData.IsAuthority.Deny)
        //        {
        //            this.btnCancel.Enabled = false;
        //        }

        //        //Set authorization for ViewPrice
        //        if (this.IsWarehouseAuthority(currentDto.WarehouseCode, CommonData.OperId.ViewPrice) == CommonData.IsAuthority.Deny)
        //        {
        //            this.ctrlDetail.ShowUnitPrice = false;
        //            this.ctrlDetail.ShowAmount = false;

        //            this.ctrlDetail1.ShowUnitPrice = false;
        //            this.ctrlDetail1.ShowAmount = false;
        //        }
        //    }
        //}



        #endregion

        /// <summary>
        /// Set tool tip for button
        /// </summary>
        private void SupperTip()
        {
            SuperToolTip sTooltip;
            SuperToolTipSetupArgs args;

            //Set Supper Tip PrintDeliverySheet Button
            sTooltip = new SuperToolTip();
            args = new SuperToolTipSetupArgs();
            args.Title.Text = "F10";
            sTooltip.Setup(args);
            btnPrintSheet.SuperTip = sTooltip;

            //Set Supper Tip Inventory Button
            sTooltip = new SuperToolTip();
            args = new SuperToolTipSetupArgs();
            args.Title.Text = "Ctr + F";
            sTooltip.Setup(args);
            btnInventory.SuperTip = sTooltip;

            //Set Supper Tip Cancel Button
            sTooltip = new SuperToolTip();
            args = new SuperToolTipSetupArgs();
            args.Title.Text = "F7";
            sTooltip.Setup(args);
            btnCancel.SuperTip = sTooltip;
        }
    }
}
