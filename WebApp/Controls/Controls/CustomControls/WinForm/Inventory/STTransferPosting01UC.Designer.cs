namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    partial class STTransferPosting01UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(STTransferPosting01UC));
            this.lblMandatoryStockPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblMandatoryStockDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtDescription = new Ivs.Controls.CustomControls.WinForm.IvsMemoEdit();
            this.lblDesciption = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblTransferPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.dtpTransferDate = new Ivs.Controls.CustomControls.WinForm.IvsDateEdit();
            this.lblTransferDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
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
            this.cboTransferPerson = new IvsEmployeeLookUp();
            this.txtDocumentType = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.cboPostedPerson = new Ivs.Controls.CustomControls.WinForm.IvsDataLookUp();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTransferDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTransferDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMandatoryStockPerson
            // 
            resources.ApplyResources(this.lblMandatoryStockPerson, "lblMandatoryStockPerson");
            this.lblMandatoryStockPerson.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockPerson.Appearance.DisabledImage")));
            this.lblMandatoryStockPerson.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMandatoryStockPerson.Appearance.ForeColor")));
            this.lblMandatoryStockPerson.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblMandatoryStockPerson.Appearance.GradientMode")));
            this.lblMandatoryStockPerson.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockPerson.Appearance.HoverImage")));
            this.lblMandatoryStockPerson.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockPerson.Appearance.Image")));
            this.lblMandatoryStockPerson.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockPerson.Appearance.PressedImage")));
            this.lblMandatoryStockPerson.Name = "lblMandatoryStockPerson";
            // 
            // lblMandatoryStockDate
            // 
            resources.ApplyResources(this.lblMandatoryStockDate, "lblMandatoryStockDate");
            this.lblMandatoryStockDate.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockDate.Appearance.DisabledImage")));
            this.lblMandatoryStockDate.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblMandatoryStockDate.Appearance.ForeColor")));
            this.lblMandatoryStockDate.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblMandatoryStockDate.Appearance.GradientMode")));
            this.lblMandatoryStockDate.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockDate.Appearance.HoverImage")));
            this.lblMandatoryStockDate.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockDate.Appearance.Image")));
            this.lblMandatoryStockDate.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("lblMandatoryStockDate.Appearance.PressedImage")));
            this.lblMandatoryStockDate.Name = "lblMandatoryStockDate";
            // 
            // txtDescription
            // 
            resources.ApplyResources(this.txtDescription, "txtDescription");
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.AccessibleDescription = resources.GetString("txtDescription.Properties.AccessibleDescription");
            this.txtDescription.Properties.AccessibleName = resources.GetString("txtDescription.Properties.AccessibleName");
            this.txtDescription.Properties.NullValuePrompt = resources.GetString("txtDescription.Properties.NullValuePrompt");
            this.txtDescription.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDescription.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblDesciption
            // 
            resources.ApplyResources(this.lblDesciption, "lblDesciption");
            this.lblDesciption.Name = "lblDesciption";
            // 
            // lblTransferPerson
            // 
            resources.ApplyResources(this.lblTransferPerson, "lblTransferPerson");
            this.lblTransferPerson.Name = "lblTransferPerson";
            // 
            // dtpTransferDate
            // 
            resources.ApplyResources(this.dtpTransferDate, "dtpTransferDate");
            this.dtpTransferDate.IsFormatDate = false;
            this.dtpTransferDate.Name = "dtpTransferDate";
            this.dtpTransferDate.Properties.AccessibleDescription = resources.GetString("dtpTransferDate.Properties.AccessibleDescription");
            this.dtpTransferDate.Properties.AccessibleName = resources.GetString("dtpTransferDate.Properties.AccessibleName");
            this.dtpTransferDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpTransferDate.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtpTransferDate.Properties.Appearance.GradientMode")));
            this.dtpTransferDate.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("dtpTransferDate.Properties.Appearance.Image")));
            this.dtpTransferDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpTransferDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpTransferDate.Properties.AutoHeight = ((bool)(resources.GetObject("dtpTransferDate.Properties.AutoHeight")));
            this.dtpTransferDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpTransferDate.Properties.Buttons"))))});
            this.dtpTransferDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtpTransferDate.Properties.Mask.AutoComplete")));
            this.dtpTransferDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtpTransferDate.Properties.Mask.BeepOnError")));
            this.dtpTransferDate.Properties.Mask.EditMask = resources.GetString("dtpTransferDate.Properties.Mask.EditMask");
            this.dtpTransferDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtpTransferDate.Properties.Mask.IgnoreMaskBlank")));
            this.dtpTransferDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtpTransferDate.Properties.Mask.MaskType")));
            this.dtpTransferDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtpTransferDate.Properties.Mask.PlaceHolder")));
            this.dtpTransferDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtpTransferDate.Properties.Mask.SaveLiteral")));
            this.dtpTransferDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtpTransferDate.Properties.Mask.ShowPlaceHolders")));
            this.dtpTransferDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtpTransferDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtpTransferDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpTransferDate.Properties.NullValuePrompt = resources.GetString("dtpTransferDate.Properties.NullValuePrompt");
            this.dtpTransferDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtpTransferDate.Properties.NullValuePromptShowForEmptyValue")));
            this.dtpTransferDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtpTransferDate.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtpTransferDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtpTransferDate.Properties.VistaTimeProperties.AccessibleName");
            this.dtpTransferDate.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.AutoHeight")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtpTransferDate.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtpTransferDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtpTransferDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtpTransferDate.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtpTransferDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtpTransferDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            // 
            // lblTransferDate
            // 
            resources.ApplyResources(this.lblTransferDate, "lblTransferDate");
            this.lblTransferDate.Name = "lblTransferDate";
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
            this.txtDocumentNo.Properties.AccessibleDescription = resources.GetString("txtDocumentNo.Properties.AccessibleDescription");
            this.txtDocumentNo.Properties.AccessibleName = resources.GetString("txtDocumentNo.Properties.AccessibleName");
            this.txtDocumentNo.Properties.AutoHeight = ((bool)(resources.GetObject("txtDocumentNo.Properties.AutoHeight")));
            this.txtDocumentNo.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtDocumentNo.Properties.Mask.AutoComplete")));
            this.txtDocumentNo.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtDocumentNo.Properties.Mask.BeepOnError")));
            this.txtDocumentNo.Properties.Mask.EditMask = resources.GetString("txtDocumentNo.Properties.Mask.EditMask");
            this.txtDocumentNo.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtDocumentNo.Properties.Mask.IgnoreMaskBlank")));
            this.txtDocumentNo.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtDocumentNo.Properties.Mask.MaskType")));
            this.txtDocumentNo.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtDocumentNo.Properties.Mask.PlaceHolder")));
            this.txtDocumentNo.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtDocumentNo.Properties.Mask.SaveLiteral")));
            this.txtDocumentNo.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtDocumentNo.Properties.Mask.ShowPlaceHolders")));
            this.txtDocumentNo.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtDocumentNo.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtDocumentNo.Properties.NullValuePrompt = resources.GetString("txtDocumentNo.Properties.NullValuePrompt");
            this.txtDocumentNo.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDocumentNo.Properties.NullValuePromptShowForEmptyValue")));
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
            this.dtpPostedDate.Properties.AccessibleDescription = resources.GetString("dtpPostedDate.Properties.AccessibleDescription");
            this.dtpPostedDate.Properties.AccessibleName = resources.GetString("dtpPostedDate.Properties.AccessibleName");
            this.dtpPostedDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpPostedDate.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtpPostedDate.Properties.Appearance.GradientMode")));
            this.dtpPostedDate.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("dtpPostedDate.Properties.Appearance.Image")));
            this.dtpPostedDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpPostedDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpPostedDate.Properties.AutoHeight = ((bool)(resources.GetObject("dtpPostedDate.Properties.AutoHeight")));
            this.dtpPostedDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpPostedDate.Properties.Buttons"))))});
            this.dtpPostedDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtpPostedDate.Properties.Mask.AutoComplete")));
            this.dtpPostedDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtpPostedDate.Properties.Mask.BeepOnError")));
            this.dtpPostedDate.Properties.Mask.EditMask = resources.GetString("dtpPostedDate.Properties.Mask.EditMask");
            this.dtpPostedDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtpPostedDate.Properties.Mask.IgnoreMaskBlank")));
            this.dtpPostedDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtpPostedDate.Properties.Mask.MaskType")));
            this.dtpPostedDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtpPostedDate.Properties.Mask.PlaceHolder")));
            this.dtpPostedDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtpPostedDate.Properties.Mask.SaveLiteral")));
            this.dtpPostedDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtpPostedDate.Properties.Mask.ShowPlaceHolders")));
            this.dtpPostedDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtpPostedDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtpPostedDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpPostedDate.Properties.NullValuePrompt = resources.GetString("dtpPostedDate.Properties.NullValuePrompt");
            this.dtpPostedDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtpPostedDate.Properties.NullValuePromptShowForEmptyValue")));
            this.dtpPostedDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtpPostedDate.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtpPostedDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtpPostedDate.Properties.VistaTimeProperties.AccessibleName");
            this.dtpPostedDate.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.AutoHeight")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtpPostedDate.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtpPostedDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtpPostedDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtpPostedDate.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtpPostedDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtpPostedDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
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
            resources.ApplyResources(this.cboWarehouse, "cboWarehouse");
            this.cboWarehouse.Code = "";
            this.cboWarehouse.EmpWrkType = "";
            this.cboWarehouse.HasNull = false;
            this.cboWarehouse.IsActive = false;
            this.cboWarehouse.IsFemale = false;
            this.cboWarehouse.IsLeavePlanning = false;
            this.cboWarehouse.IsLeaveReason = false;
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Properties.AccessibleDescription = resources.GetString("cboWarehouse.Properties.AccessibleDescription");
            this.cboWarehouse.Properties.AccessibleName = resources.GetString("cboWarehouse.Properties.AccessibleName");
            this.cboWarehouse.Properties.AutoHeight = ((bool)(resources.GetObject("cboWarehouse.Properties.AutoHeight")));
            this.cboWarehouse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboWarehouse.Properties.Buttons"))))});
            this.cboWarehouse.Properties.NullValuePrompt = resources.GetString("cboWarehouse.Properties.NullValuePrompt");
            this.cboWarehouse.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboWarehouse.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblWarehouse
            // 
            resources.ApplyResources(this.lblWarehouse, "lblWarehouse");
            this.lblWarehouse.Name = "lblWarehouse";
            // 
            // cboDepartment
            // 
            resources.ApplyResources(this.cboDepartment, "cboDepartment");
            this.cboDepartment.Code = "";
            this.cboDepartment.EmpWrkType = "";
            this.cboDepartment.HasNull = false;
            this.cboDepartment.IsActive = false;
            this.cboDepartment.IsFemale = false;
            this.cboDepartment.IsLeavePlanning = false;
            this.cboDepartment.IsLeaveReason = false;
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.AccessibleDescription = resources.GetString("cboDepartment.Properties.AccessibleDescription");
            this.cboDepartment.Properties.AccessibleName = resources.GetString("cboDepartment.Properties.AccessibleName");
            this.cboDepartment.Properties.AutoHeight = ((bool)(resources.GetObject("cboDepartment.Properties.AutoHeight")));
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboDepartment.Properties.Buttons"))))});
            this.cboDepartment.Properties.NullValuePrompt = resources.GetString("cboDepartment.Properties.NullValuePrompt");
            this.cboDepartment.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboDepartment.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblDepartment
            // 
            resources.ApplyResources(this.lblDepartment, "lblDepartment");
            this.lblDepartment.Name = "lblDepartment";
            // 
            // cboTransferPerson
            // 
            resources.ApplyResources(this.cboTransferPerson, "cboTransferPerson");
            this.cboTransferPerson.Code = "";
            this.cboTransferPerson.EmpWrkType = "";
            this.cboTransferPerson.HasNull = false;
            this.cboTransferPerson.IsActive = false;
            this.cboTransferPerson.IsFemale = false;
            this.cboTransferPerson.IsLeavePlanning = false;
            this.cboTransferPerson.IsLeaveReason = false;
            this.cboTransferPerson.Name = "cboTransferPerson";
            this.cboTransferPerson.Properties.AccessibleDescription = resources.GetString("cboTransferPerson.Properties.AccessibleDescription");
            this.cboTransferPerson.Properties.AccessibleName = resources.GetString("cboTransferPerson.Properties.AccessibleName");
            this.cboTransferPerson.Properties.AutoHeight = ((bool)(resources.GetObject("cboTransferPerson.Properties.AutoHeight")));
            this.cboTransferPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboTransferPerson.Properties.Buttons"))))});
            this.cboTransferPerson.Properties.NullValuePrompt = resources.GetString("cboTransferPerson.Properties.NullValuePrompt");
            this.cboTransferPerson.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboTransferPerson.Properties.NullValuePromptShowForEmptyValue")));
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
            this.txtDocumentType.Properties.AccessibleDescription = resources.GetString("txtDocumentType.Properties.AccessibleDescription");
            this.txtDocumentType.Properties.AccessibleName = resources.GetString("txtDocumentType.Properties.AccessibleName");
            this.txtDocumentType.Properties.AutoHeight = ((bool)(resources.GetObject("txtDocumentType.Properties.AutoHeight")));
            this.txtDocumentType.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtDocumentType.Properties.Mask.AutoComplete")));
            this.txtDocumentType.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtDocumentType.Properties.Mask.BeepOnError")));
            this.txtDocumentType.Properties.Mask.EditMask = resources.GetString("txtDocumentType.Properties.Mask.EditMask");
            this.txtDocumentType.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtDocumentType.Properties.Mask.IgnoreMaskBlank")));
            this.txtDocumentType.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtDocumentType.Properties.Mask.MaskType")));
            this.txtDocumentType.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtDocumentType.Properties.Mask.PlaceHolder")));
            this.txtDocumentType.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtDocumentType.Properties.Mask.SaveLiteral")));
            this.txtDocumentType.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtDocumentType.Properties.Mask.ShowPlaceHolders")));
            this.txtDocumentType.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtDocumentType.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtDocumentType.Properties.NullValuePrompt = resources.GetString("txtDocumentType.Properties.NullValuePrompt");
            this.txtDocumentType.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtDocumentType.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // cboPostedPerson
            // 
            resources.ApplyResources(this.cboPostedPerson, "cboPostedPerson");
            this.cboPostedPerson.Code = "";
            this.cboPostedPerson.EmpWrkType = "";
            this.cboPostedPerson.HasNull = false;
            this.cboPostedPerson.IsActive = false;
            this.cboPostedPerson.IsFemale = false;
            this.cboPostedPerson.IsLeavePlanning = false;
            this.cboPostedPerson.IsLeaveReason = false;
            this.cboPostedPerson.Name = "cboPostedPerson";
            this.cboPostedPerson.Properties.AccessibleDescription = resources.GetString("cboPostedPerson.Properties.AccessibleDescription");
            this.cboPostedPerson.Properties.AccessibleName = resources.GetString("cboPostedPerson.Properties.AccessibleName");
            this.cboPostedPerson.Properties.AutoHeight = ((bool)(resources.GetObject("cboPostedPerson.Properties.AutoHeight")));
            this.cboPostedPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboPostedPerson.Properties.Buttons"))))});
            this.cboPostedPerson.Properties.NullValuePrompt = resources.GetString("cboPostedPerson.Properties.NullValuePrompt");
            this.cboPostedPerson.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboPostedPerson.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // STTransferPosting01UC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDocumentType);
            this.Controls.Add(this.cboPostedPerson);
            this.Controls.Add(this.cboTransferPerson);
            this.Controls.Add(this.lblMandatoryStockPerson);
            this.Controls.Add(this.lblMandatoryStockDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDesciption);
            this.Controls.Add(this.lblTransferPerson);
            this.Controls.Add(this.dtpTransferDate);
            this.Controls.Add(this.lblTransferDate);
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
            this.Name = "STTransferPosting01UC";
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTransferDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpTransferDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTransferPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected IvsLabelControl lblMandatoryStockPerson;
        protected IvsLabelControl lblMandatoryStockDate;
        protected IvsMemoEdit txtDescription;
        protected IvsLabelControl lblDesciption;
        protected IvsLabelControl lblTransferPerson;
        protected IvsDateEdit dtpTransferDate;
        protected IvsLabelControl lblTransferDate;
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
        protected IvsEmployeeLookUp cboTransferPerson;
        protected IvsTextEdit txtDocumentType;
        protected IvsDataLookUp cboPostedPerson;

    }
}
