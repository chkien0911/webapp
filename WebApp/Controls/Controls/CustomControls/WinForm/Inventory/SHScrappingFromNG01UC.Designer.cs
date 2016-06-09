namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    partial class SHScrappingFromNG01UC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHScrappingFromNG01UC));
            this.lblMandatoryStockPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblMandatoryStockDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtDescription = new Ivs.Controls.CustomControls.WinForm.IvsMemoEdit();
            this.lblDesciption = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblShippingPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.dtpShippingDate = new Ivs.Controls.CustomControls.WinForm.IvsDateEdit();
            this.lblShippingDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtDocumentNo = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.lblDocumentNo = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblPostedPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.dtpPostedDate = new Ivs.Controls.CustomControls.WinForm.IvsDateEdit();
            this.lblPostedDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblDocumentType = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.cboWarehouse = new Ivs.Controls.CustomControls.WinForm.IvsDataLookUp();
            this.lblWarehouse = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.cboDepartment = new Ivs.Controls.CustomControls.WinForm.IvsDataLookUp();
            this.lblDepartment = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.cboShippingPerson = new IvsEmployeeLookUp();
            this.txtDocumentType = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.cboPostedPerson = new Ivs.Controls.CustomControls.WinForm.IvsDataLookUp();
            this.txtPrintReason = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.txtPrintCount = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.lblPrinted = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShippingPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintReason.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintCount.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMandatoryStockPerson
            // 
            this.lblMandatoryStockPerson.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMandatoryStockPerson.Appearance.ForeColor")));
            resources.ApplyResources(this.lblMandatoryStockPerson, "lblMandatoryStockPerson");
            this.lblMandatoryStockPerson.Name = "lblMandatoryStockPerson";
            // 
            // lblMandatoryStockDate
            // 
            this.lblMandatoryStockDate.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMandatoryStockDate.Appearance.ForeColor")));
            resources.ApplyResources(this.lblMandatoryStockDate, "lblMandatoryStockDate");
            this.lblMandatoryStockDate.Name = "lblMandatoryStockDate";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            // 
            // lblDesciption
            // 
            resources.ApplyResources(this.lblDesciption, "lblDesciption");
            this.lblDesciption.Name = "lblDesciption";
            // 
            // lblShippingPerson
            // 
            resources.ApplyResources(this.lblShippingPerson, "lblShippingPerson");
            this.lblShippingPerson.Name = "lblShippingPerson";
            // 
            // dtpShippingDate
            // 
            resources.ApplyResources(this.dtpShippingDate, "dtpShippingDate");
            this.dtpShippingDate.IsFormatDate = false;
            this.dtpShippingDate.Name = "dtpShippingDate";
            this.dtpShippingDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpShippingDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpShippingDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpShippingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpShippingDate.Properties.Buttons"))))});
            this.dtpShippingDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpShippingDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblShippingDate
            // 
            resources.ApplyResources(this.lblShippingDate, "lblShippingDate");
            this.lblShippingDate.Name = "lblShippingDate";
            // 
            // txtDocumentNo
            // 
            resources.ApplyResources(this.txtDocumentNo, "txtDocumentNo");
            this.txtDocumentNo.IsCurrency = false;
            this.txtDocumentNo.IsNumberic = false;
            this.txtDocumentNo.IsNumOfDay = false;
            this.txtDocumentNo.IsPositiveNumber = false;
            this.txtDocumentNo.IsPositivePercentage = false;
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.NumOfDecimalPlaces = 0;
            // 
            // lblDocumentNo
            // 
            resources.ApplyResources(this.lblDocumentNo, "lblDocumentNo");
            this.lblDocumentNo.Name = "lblDocumentNo";
            // 
            // lblPostedPerson
            // 
            resources.ApplyResources(this.lblPostedPerson, "lblPostedPerson");
            this.lblPostedPerson.Name = "lblPostedPerson";
            // 
            // dtpPostedDate
            // 
            resources.ApplyResources(this.dtpPostedDate, "dtpPostedDate");
            this.dtpPostedDate.IsFormatDate = false;
            this.dtpPostedDate.Name = "dtpPostedDate";
            this.dtpPostedDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpPostedDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpPostedDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpPostedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpPostedDate.Properties.Buttons"))))});
            this.dtpPostedDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpPostedDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblPostedDate
            // 
            resources.ApplyResources(this.lblPostedDate, "lblPostedDate");
            this.lblPostedDate.Name = "lblPostedDate";
            // 
            // lblDocumentType
            // 
            resources.ApplyResources(this.lblDocumentType, "lblDocumentType");
            this.lblDocumentType.Name = "lblDocumentType";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.Code = "";
            this.cboWarehouse.EmpWrkType = "";
            resources.ApplyResources(this.cboWarehouse, "cboWarehouse");
            this.cboWarehouse.HasNull = false;
            this.cboWarehouse.IsActive = false;
            this.cboWarehouse.IsFemale = false;
            this.cboWarehouse.IsLeavePlanning = false;
            this.cboWarehouse.IsLeaveReason = false;
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboWarehouse.Properties.Buttons"))))});
            // 
            // lblWarehouse
            // 
            resources.ApplyResources(this.lblWarehouse, "lblWarehouse");
            this.lblWarehouse.Name = "lblWarehouse";
            // 
            // cboDepartment
            // 
            this.cboDepartment.Code = "";
            this.cboDepartment.EmpWrkType = "";
            resources.ApplyResources(this.cboDepartment, "cboDepartment");
            this.cboDepartment.HasNull = false;
            this.cboDepartment.IsActive = false;
            this.cboDepartment.IsFemale = false;
            this.cboDepartment.IsLeavePlanning = false;
            this.cboDepartment.IsLeaveReason = false;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboDepartment.Properties.Buttons"))))});
            // 
            // lblDepartment
            // 
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Name = "lblDepartment";
            // 
            // cboShippingPerson
            // 
            this.cboShippingPerson.Code = "";
            this.cboShippingPerson.EmpWrkType = "";
            resources.ApplyResources(this.cboShippingPerson, "cboShippingPerson");
            this.cboShippingPerson.HasNull = false;
            this.cboShippingPerson.IsActive = false;
            this.cboShippingPerson.IsFemale = false;
            this.cboShippingPerson.IsLeavePlanning = false;
            this.cboShippingPerson.IsLeaveReason = false;
            this.cboShippingPerson.Name = "cboShippingPerson";
            this.cboShippingPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboShippingPerson.Properties.Buttons"))))});
            // 
            // txtDocumentType
            // 
            resources.ApplyResources(this.txtDocumentType, "txtDocumentType");
            this.txtDocumentType.IsCurrency = false;
            this.txtDocumentType.IsNumberic = false;
            this.txtDocumentType.IsNumOfDay = false;
            this.txtDocumentType.IsPositiveNumber = false;
            this.txtDocumentType.IsPositivePercentage = false;
            this.txtDocumentType.Name = "txtDocumentType";
            this.txtDocumentType.NumOfDecimalPlaces = 0;
            // 
            // cboPostedPerson
            // 
            this.cboPostedPerson.Code = "";
            this.cboPostedPerson.EmpWrkType = "";
            resources.ApplyResources(this.cboPostedPerson, "cboPostedPerson");
            this.cboPostedPerson.HasNull = false;
            this.cboPostedPerson.IsActive = false;
            this.cboPostedPerson.IsFemale = false;
            this.cboPostedPerson.IsLeavePlanning = false;
            this.cboPostedPerson.IsLeaveReason = false;
            this.cboPostedPerson.Name = "cboPostedPerson";
            this.cboPostedPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboPostedPerson.Properties.Buttons"))))});
            // 
            // txtPrintReason
            // 
            resources.ApplyResources(this.txtPrintReason, "txtPrintReason");
            this.txtPrintReason.IsCurrency = false;
            this.txtPrintReason.IsNumberic = false;
            this.txtPrintReason.IsNumOfDay = false;
            this.txtPrintReason.IsPositiveNumber = false;
            this.txtPrintReason.IsPositivePercentage = false;
            this.txtPrintReason.Name = "txtPrintReason";
            this.txtPrintReason.NumOfDecimalPlaces = 0;
            // 
            // txtPrintCount
            // 
            resources.ApplyResources(this.txtPrintCount, "txtPrintCount");
            this.txtPrintCount.IsCurrency = false;
            this.txtPrintCount.IsNumberic = false;
            this.txtPrintCount.IsNumOfDay = false;
            this.txtPrintCount.IsPositiveNumber = false;
            this.txtPrintCount.IsPositivePercentage = false;
            this.txtPrintCount.Name = "txtPrintCount";
            this.txtPrintCount.NumOfDecimalPlaces = 0;
            // 
            // lblPrinted
            // 
            resources.ApplyResources(this.lblPrinted, "lblPrinted");
            this.lblPrinted.Name = "lblPrinted";
            // 
            // SHScrappingFromNG01UC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtPrintReason);
            this.Controls.Add(this.txtPrintCount);
            this.Controls.Add(this.lblPrinted);
            this.Controls.Add(this.txtDocumentType);
            this.Controls.Add(this.cboPostedPerson);
            this.Controls.Add(this.cboShippingPerson);
            this.Controls.Add(this.lblMandatoryStockPerson);
            this.Controls.Add(this.lblMandatoryStockDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDesciption);
            this.Controls.Add(this.lblShippingPerson);
            this.Controls.Add(this.dtpShippingDate);
            this.Controls.Add(this.lblShippingDate);
            this.Controls.Add(this.txtDocumentNo);
            this.Controls.Add(this.lblDocumentNo);
            this.Controls.Add(this.lblPostedPerson);
            this.Controls.Add(this.dtpPostedDate);
            this.Controls.Add(this.lblPostedDate);
            this.Controls.Add(this.lblDocumentType);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.lblDepartment);
            this.Name = "SHScrappingFromNG01UC";
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpShippingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboShippingPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintReason.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrintCount.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected IvsLabelControl lblMandatoryStockPerson;
        protected IvsLabelControl lblMandatoryStockDate;
        protected IvsMemoEdit txtDescription;
        protected IvsLabelControl lblDesciption;
        protected IvsLabelControl lblShippingPerson;
        protected IvsDateEdit dtpShippingDate;
        protected IvsLabelControl lblShippingDate;
        protected IvsTextEdit txtDocumentNo;
        protected IvsLabelControl lblDocumentNo;
        protected IvsLabelControl lblPostedPerson;
        protected IvsDateEdit dtpPostedDate;
        protected IvsLabelControl lblPostedDate;
        protected IvsLabelControl lblDocumentType;
        protected IvsDataLookUp cboWarehouse;
        protected IvsLabelControl lblWarehouse;
        protected IvsDataLookUp cboDepartment;
        protected IvsLabelControl lblDepartment;
        protected IvsEmployeeLookUp cboShippingPerson;
        protected IvsTextEdit txtDocumentType;
        protected IvsDataLookUp cboPostedPerson;
        private IvsTextEdit txtPrintReason;
        private IvsTextEdit txtPrintCount;
        private IvsLabelControl lblPrinted;

    }
}
