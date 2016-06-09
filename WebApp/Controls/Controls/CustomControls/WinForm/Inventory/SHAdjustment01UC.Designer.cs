namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    partial class SHAdjustment01UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHAdjustment01UC));
            this.btnAddItem = new Ivs.Controls.CustomControls.WinForm.IvsSimpleButton();
            this.cboPIC = new Ivs.Controls.CustomControls.WinForm.IvsEmployeeLookUp();
            this.cboPostedPerson = new Ivs.Controls.CustomControls.WinForm.IvsDataLookUp();
            this.pnlType = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.rdoPlus = new System.Windows.Forms.RadioButton();
            this.rdoMinus = new System.Windows.Forms.RadioButton();
            this.lblMandatoryPIC = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblMandatoryDocumentDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtRemark = new Ivs.Controls.CustomControls.WinForm.IvsMemoEdit();
            this.lblRemark = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblPIC = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.dtpDocumentDate = new Ivs.Controls.CustomControls.WinForm.IvsDateEdit();
            this.lblDocumentDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtDocumentType = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
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
            this.txtDocumentType2 = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPIC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).BeginInit();
            this.pnlType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDocumentDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDocumentDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            resources.ApplyResources(this.btnAddItem, "btnAddItem");
            this.btnAddItem.Name = "btnAddItem";
            // 
            // cboPIC
            // 
            this.cboPIC.Code = "";
            this.cboPIC.DepartmentCode = null;
            this.cboPIC.EmpWrkType = "";
            this.cboPIC.HasNull = false;
            this.cboPIC.IsActive = false;
            this.cboPIC.IsFemale = false;
            this.cboPIC.IsLeavePlanning = false;
            this.cboPIC.IsLeaveReason = false;
            resources.ApplyResources(this.cboPIC, "cboPIC");
            this.cboPIC.Name = "cboPIC";
            this.cboPIC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboPIC.Properties.Buttons"))))});
            this.cboPIC.Properties.NullText = resources.GetString("cboPIC.Properties.NullText");
            // 
            // cboPostedPerson
            // 
            this.cboPostedPerson.Code = "";
            this.cboPostedPerson.EmpWrkType = "";
            this.cboPostedPerson.HasNull = false;
            this.cboPostedPerson.IsActive = false;
            this.cboPostedPerson.IsFemale = false;
            this.cboPostedPerson.IsLeavePlanning = false;
            this.cboPostedPerson.IsLeaveReason = false;
            resources.ApplyResources(this.cboPostedPerson, "cboPostedPerson");
            this.cboPostedPerson.Name = "cboPostedPerson";
            this.cboPostedPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboPostedPerson.Properties.Buttons"))))});
            this.cboPostedPerson.Properties.NullText = resources.GetString("cboPostedPerson.Properties.NullText");
            // 
            // pnlType
            // 
            this.pnlType.Controls.Add(this.rdoPlus);
            this.pnlType.Controls.Add(this.rdoMinus);
            resources.ApplyResources(this.pnlType, "pnlType");
            this.pnlType.Name = "pnlType";
            // 
            // rdoPlus
            // 
            resources.ApplyResources(this.rdoPlus, "rdoPlus");
            this.rdoPlus.Name = "rdoPlus";
            this.rdoPlus.UseVisualStyleBackColor = true;
            // 
            // rdoMinus
            // 
            resources.ApplyResources(this.rdoMinus, "rdoMinus");
            this.rdoMinus.Checked = true;
            this.rdoMinus.Name = "rdoMinus";
            this.rdoMinus.TabStop = true;
            this.rdoMinus.UseVisualStyleBackColor = true;
            // 
            // lblMandatoryPIC
            // 
            this.lblMandatoryPIC.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMandatoryPIC.Appearance.ForeColor")));
            resources.ApplyResources(this.lblMandatoryPIC, "lblMandatoryPIC");
            this.lblMandatoryPIC.Name = "lblMandatoryPIC";
            // 
            // lblMandatoryDocumentDate
            // 
            this.lblMandatoryDocumentDate.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMandatoryDocumentDate.Appearance.ForeColor")));
            resources.ApplyResources(this.lblMandatoryDocumentDate, "lblMandatoryDocumentDate");
            this.lblMandatoryDocumentDate.Name = "lblMandatoryDocumentDate";
            // 
            // txtRemark
            // 
            resources.ApplyResources(this.txtRemark, "txtRemark");
            this.txtRemark.Name = "txtRemark";
            // 
            // lblRemark
            // 
            resources.ApplyResources(this.lblRemark, "lblRemark");
            this.lblRemark.Name = "lblRemark";
            // 
            // lblPIC
            // 
            resources.ApplyResources(this.lblPIC, "lblPIC");
            this.lblPIC.Name = "lblPIC";
            // 
            // dtpDocumentDate
            // 
            resources.ApplyResources(this.dtpDocumentDate, "dtpDocumentDate");
            this.dtpDocumentDate.IsFormatDate = false;
            this.dtpDocumentDate.Name = "dtpDocumentDate";
            this.dtpDocumentDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpDocumentDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpDocumentDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpDocumentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpDocumentDate.Properties.Buttons"))))});
            this.dtpDocumentDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpDocumentDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // lblDocumentDate
            // 
            resources.ApplyResources(this.lblDocumentDate, "lblDocumentDate");
            this.lblDocumentDate.Name = "lblDocumentDate";
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
            // txtDocumentNo
            // 
            this.txtDocumentNo.IsCurrency = false;
            this.txtDocumentNo.IsNumberic = false;
            this.txtDocumentNo.IsNumOfDay = false;
            this.txtDocumentNo.IsPositiveNumber = false;
            this.txtDocumentNo.IsPositivePercentage = false;
            resources.ApplyResources(this.txtDocumentNo, "txtDocumentNo");
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
            this.cboWarehouse.HasNull = false;
            this.cboWarehouse.IsActive = false;
            this.cboWarehouse.IsFemale = false;
            this.cboWarehouse.IsLeavePlanning = false;
            this.cboWarehouse.IsLeaveReason = false;
            resources.ApplyResources(this.cboWarehouse, "cboWarehouse");
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboWarehouse.Properties.Buttons"))))});
            this.cboWarehouse.Properties.NullText = resources.GetString("cboWarehouse.Properties.NullText");
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
            this.cboDepartment.HasNull = false;
            this.cboDepartment.IsActive = false;
            this.cboDepartment.IsFemale = false;
            this.cboDepartment.IsLeavePlanning = false;
            this.cboDepartment.IsLeaveReason = false;
            resources.ApplyResources(this.cboDepartment, "cboDepartment");
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboDepartment.Properties.Buttons"))))});
            this.cboDepartment.Properties.NullText = resources.GetString("cboDepartment.Properties.NullText");
            // 
            // lblDepartment
            // 
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Name = "lblDepartment";
            // 
            // txtDocumentType2
            // 
            resources.ApplyResources(this.txtDocumentType2, "txtDocumentType2");
            this.txtDocumentType2.IsCurrency = false;
            this.txtDocumentType2.IsNumberic = false;
            this.txtDocumentType2.IsNumOfDay = false;
            this.txtDocumentType2.IsPositiveNumber = false;
            this.txtDocumentType2.IsPositivePercentage = false;
            this.txtDocumentType2.Name = "txtDocumentType2";
            this.txtDocumentType2.NumOfDecimalPlaces = 0;
            // 
            // SHAdjustment01UC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.cboPIC);
            this.Controls.Add(this.cboPostedPerson);
            this.Controls.Add(this.pnlType);
            this.Controls.Add(this.lblMandatoryPIC);
            this.Controls.Add(this.lblMandatoryDocumentDate);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblRemark);
            this.Controls.Add(this.lblPIC);
            this.Controls.Add(this.dtpDocumentDate);
            this.Controls.Add(this.lblDocumentDate);
            this.Controls.Add(this.txtDocumentType2);
            this.Controls.Add(this.txtDocumentType);
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
            this.Name = "SHAdjustment01UC";
            ((System.ComponentModel.ISupportInitialize)(this.cboPIC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).EndInit();
            this.pnlType.ResumeLayout(false);
            this.pnlType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDocumentDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDocumentDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected IvsEmployeeLookUp cboPIC;
        protected IvsDataLookUp cboPostedPerson;
        private IvsPanel pnlType;
        private System.Windows.Forms.RadioButton rdoPlus;
        private System.Windows.Forms.RadioButton rdoMinus;
        protected IvsLabelControl lblMandatoryPIC;
        protected IvsLabelControl lblMandatoryDocumentDate;
        protected IvsMemoEdit txtRemark;
        protected IvsLabelControl lblRemark;
        protected IvsLabelControl lblPIC;
        protected IvsDateEdit dtpDocumentDate;
        protected IvsLabelControl lblDocumentDate;
        protected IvsTextEdit txtDocumentType;
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
        private IvsSimpleButton btnAddItem;
        protected IvsTextEdit txtDocumentType2;
    }
}
