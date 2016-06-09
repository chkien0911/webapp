namespace Ivs.Controls.CustomControls.WinForm.Inventory
{
    partial class SAForPurchaseOrder01UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAForPurchaseOrder01UC));
            this.ivsLabelControl2 = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtLotNo = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.lblLotNo = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblMandatoryStockPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblMandatoryStockDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.txtDescription = new Ivs.Controls.CustomControls.WinForm.IvsMemoEdit();
            this.lblDesciption = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.cboSupplier = new IvsCompanyLookup();
            this.lblSupplier = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.lblArrivingPerson = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            this.dtpArrivingDate = new Ivs.Controls.CustomControls.WinForm.IvsDateEdit();
            this.lblArrivingDate = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
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
            this.cboArrivingPerson = new IvsEmployeeLookUp();
            this.txtDocumentType = new Ivs.Controls.CustomControls.WinForm.IvsTextEdit();
            this.cboPostedPerson = new Ivs.Controls.CustomControls.WinForm.IvsDataLookUp();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSupplier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpArrivingDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpArrivingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArrivingPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ivsLabelControl2
            // 
            resources.ApplyResources(this.ivsLabelControl2, "ivsLabelControl2");
            this.ivsLabelControl2.Appearance.DisabledImage = ((System.Drawing.Image)(resources.GetObject("ivsLabelControl2.Appearance.DisabledImage")));
            this.ivsLabelControl2.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("ivsLabelControl2.Appearance.ForeColor")));
            this.ivsLabelControl2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("ivsLabelControl2.Appearance.GradientMode")));
            this.ivsLabelControl2.Appearance.HoverImage = ((System.Drawing.Image)(resources.GetObject("ivsLabelControl2.Appearance.HoverImage")));
            this.ivsLabelControl2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("ivsLabelControl2.Appearance.Image")));
            this.ivsLabelControl2.Appearance.PressedImage = ((System.Drawing.Image)(resources.GetObject("ivsLabelControl2.Appearance.PressedImage")));
            this.ivsLabelControl2.Name = "ivsLabelControl2";
            // 
            // txtLotNo
            // 
            resources.ApplyResources(this.txtLotNo, "txtLotNo");
            this.txtLotNo.IsCurrency = false;
            this.txtLotNo.IsNumberic = false;
            this.txtLotNo.IsNumOfDay = false;
            this.txtLotNo.IsPositiveNumber = false;
            this.txtLotNo.IsPositivePercentage = false;
            this.txtLotNo.Name = "txtLotNo";
            this.txtLotNo.NumOfDecimalPlaces = 0;
            this.txtLotNo.Properties.AccessibleDescription = resources.GetString("txtLotNo.Properties.AccessibleDescription");
            this.txtLotNo.Properties.AccessibleName = resources.GetString("txtLotNo.Properties.AccessibleName");
            this.txtLotNo.Properties.AutoHeight = ((bool)(resources.GetObject("txtLotNo.Properties.AutoHeight")));
            this.txtLotNo.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtLotNo.Properties.Mask.AutoComplete")));
            this.txtLotNo.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtLotNo.Properties.Mask.BeepOnError")));
            this.txtLotNo.Properties.Mask.EditMask = resources.GetString("txtLotNo.Properties.Mask.EditMask");
            this.txtLotNo.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtLotNo.Properties.Mask.IgnoreMaskBlank")));
            this.txtLotNo.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtLotNo.Properties.Mask.MaskType")));
            this.txtLotNo.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtLotNo.Properties.Mask.PlaceHolder")));
            this.txtLotNo.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtLotNo.Properties.Mask.SaveLiteral")));
            this.txtLotNo.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtLotNo.Properties.Mask.ShowPlaceHolders")));
            this.txtLotNo.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtLotNo.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtLotNo.Properties.NullValuePrompt = resources.GetString("txtLotNo.Properties.NullValuePrompt");
            this.txtLotNo.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtLotNo.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblLotNo
            // 
            resources.ApplyResources(this.lblLotNo, "lblLotNo");
            this.lblLotNo.Name = "lblLotNo";
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
            // cboSupplier
            // 
            resources.ApplyResources(this.cboSupplier, "cboSupplier");
            this.cboSupplier.Code = "";
            this.cboSupplier.EmpWrkType = "";
            this.cboSupplier.HasNull = false;
            this.cboSupplier.IsActive = false;
            this.cboSupplier.IsFemale = false;
            this.cboSupplier.IsLeavePlanning = false;
            this.cboSupplier.IsLeaveReason = false;
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Properties.AccessibleDescription = resources.GetString("cboSupplier.Properties.AccessibleDescription");
            this.cboSupplier.Properties.AccessibleName = resources.GetString("cboSupplier.Properties.AccessibleName");
            this.cboSupplier.Properties.AutoHeight = ((bool)(resources.GetObject("cboSupplier.Properties.AutoHeight")));
            this.cboSupplier.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboSupplier.Properties.Buttons"))))});
            this.cboSupplier.Properties.NullValuePrompt = resources.GetString("cboSupplier.Properties.NullValuePrompt");
            this.cboSupplier.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboSupplier.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // lblSupplier
            // 
            resources.ApplyResources(this.lblSupplier, "lblSupplier");
            this.lblSupplier.Name = "lblSupplier";
            // 
            // lblArrivingPerson
            // 
            resources.ApplyResources(this.lblArrivingPerson, "lblArrivingPerson");
            this.lblArrivingPerson.Name = "lblArrivingPerson";
            // 
            // dtpArrivingDate
            // 
            resources.ApplyResources(this.dtpArrivingDate, "dtpArrivingDate");
            this.dtpArrivingDate.IsFormatDate = false;
            this.dtpArrivingDate.Name = "dtpArrivingDate";
            this.dtpArrivingDate.Properties.AccessibleDescription = resources.GetString("dtpArrivingDate.Properties.AccessibleDescription");
            this.dtpArrivingDate.Properties.AccessibleName = resources.GetString("dtpArrivingDate.Properties.AccessibleName");
            this.dtpArrivingDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpArrivingDate.Properties.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("dtpArrivingDate.Properties.Appearance.GradientMode")));
            this.dtpArrivingDate.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("dtpArrivingDate.Properties.Appearance.Image")));
            this.dtpArrivingDate.Properties.Appearance.Options.UseTextOptions = true;
            this.dtpArrivingDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dtpArrivingDate.Properties.AutoHeight = ((bool)(resources.GetObject("dtpArrivingDate.Properties.AutoHeight")));
            this.dtpArrivingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("dtpArrivingDate.Properties.Buttons"))))});
            this.dtpArrivingDate.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtpArrivingDate.Properties.Mask.AutoComplete")));
            this.dtpArrivingDate.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("dtpArrivingDate.Properties.Mask.BeepOnError")));
            this.dtpArrivingDate.Properties.Mask.EditMask = resources.GetString("dtpArrivingDate.Properties.Mask.EditMask");
            this.dtpArrivingDate.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtpArrivingDate.Properties.Mask.IgnoreMaskBlank")));
            this.dtpArrivingDate.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtpArrivingDate.Properties.Mask.MaskType")));
            this.dtpArrivingDate.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("dtpArrivingDate.Properties.Mask.PlaceHolder")));
            this.dtpArrivingDate.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtpArrivingDate.Properties.Mask.SaveLiteral")));
            this.dtpArrivingDate.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtpArrivingDate.Properties.Mask.ShowPlaceHolders")));
            this.dtpArrivingDate.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtpArrivingDate.Properties.Mask.UseMaskAsDisplayFormat")));
            this.dtpArrivingDate.Properties.NullDate = new System.DateTime(((long)(0)));
            this.dtpArrivingDate.Properties.NullValuePrompt = resources.GetString("dtpArrivingDate.Properties.NullValuePrompt");
            this.dtpArrivingDate.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtpArrivingDate.Properties.NullValuePromptShowForEmptyValue")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.AccessibleDescription = resources.GetString("dtpArrivingDate.Properties.VistaTimeProperties.AccessibleDescription");
            this.dtpArrivingDate.Properties.VistaTimeProperties.AccessibleName = resources.GetString("dtpArrivingDate.Properties.VistaTimeProperties.AccessibleName");
            this.dtpArrivingDate.Properties.VistaTimeProperties.AutoHeight = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.AutoHeight")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.AutoComplete")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.BeepOnError = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.BeepOnError")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.EditMask = resources.GetString("dtpArrivingDate.Properties.VistaTimeProperties.Mask.EditMask");
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.IgnoreMaskBlank")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.MaskType")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.PlaceHolder = ((char)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.PlaceHolder")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.SaveLiteral = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.SaveLiteral")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.ShowPlaceHolders")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.Mask.UseMaskAsDisplayFormat")));
            this.dtpArrivingDate.Properties.VistaTimeProperties.NullValuePrompt = resources.GetString("dtpArrivingDate.Properties.VistaTimeProperties.NullValuePrompt");
            this.dtpArrivingDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("dtpArrivingDate.Properties.VistaTimeProperties.NullValuePromptShowForEmptyValue")));
            // 
            // lblArrivingDate
            // 
            resources.ApplyResources(this.lblArrivingDate, "lblArrivingDate");
            this.lblArrivingDate.Name = "lblArrivingDate";
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
            // cboArrivingPerson
            // 
            resources.ApplyResources(this.cboArrivingPerson, "cboArrivingPerson");
            this.cboArrivingPerson.Code = "";
            this.cboArrivingPerson.EmpWrkType = "";
            this.cboArrivingPerson.HasNull = false;
            this.cboArrivingPerson.IsActive = false;
            this.cboArrivingPerson.IsFemale = false;
            this.cboArrivingPerson.IsLeavePlanning = false;
            this.cboArrivingPerson.IsLeaveReason = false;
            this.cboArrivingPerson.Name = "cboArrivingPerson";
            this.cboArrivingPerson.Properties.AccessibleDescription = resources.GetString("cboArrivingPerson.Properties.AccessibleDescription");
            this.cboArrivingPerson.Properties.AccessibleName = resources.GetString("cboArrivingPerson.Properties.AccessibleName");
            this.cboArrivingPerson.Properties.AutoHeight = ((bool)(resources.GetObject("cboArrivingPerson.Properties.AutoHeight")));
            this.cboArrivingPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cboArrivingPerson.Properties.Buttons"))))});
            this.cboArrivingPerson.Properties.NullValuePrompt = resources.GetString("cboArrivingPerson.Properties.NullValuePrompt");
            this.cboArrivingPerson.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cboArrivingPerson.Properties.NullValuePromptShowForEmptyValue")));
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
            // SAForPurchaseOrder01UC
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboPostedPerson);
            this.Controls.Add(this.txtDocumentType);
            this.Controls.Add(this.cboArrivingPerson);
            this.Controls.Add(this.ivsLabelControl2);
            this.Controls.Add(this.txtLotNo);
            this.Controls.Add(this.lblLotNo);
            this.Controls.Add(this.lblMandatoryStockPerson);
            this.Controls.Add(this.lblMandatoryStockDate);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDesciption);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.lblArrivingPerson);
            this.Controls.Add(this.dtpArrivingDate);
            this.Controls.Add(this.lblArrivingDate);
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
            this.Name = "SAForPurchaseOrder01UC";
            ((System.ComponentModel.ISupportInitialize)(this.txtLotNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSupplier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpArrivingDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpArrivingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpPostedDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboWarehouse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArrivingPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPostedPerson.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected IvsLabelControl ivsLabelControl2;
        protected IvsTextEdit txtLotNo;
        protected IvsLabelControl lblLotNo;
        protected IvsLabelControl lblMandatoryStockPerson;
        protected IvsLabelControl lblMandatoryStockDate;
        protected IvsMemoEdit txtDescription;
        protected IvsLabelControl lblDesciption;
        protected IvsCompanyLookup cboSupplier;
        protected IvsLabelControl lblSupplier;
        protected IvsLabelControl lblArrivingPerson;
        protected IvsDateEdit dtpArrivingDate;
        protected IvsLabelControl lblArrivingDate;
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
        protected IvsEmployeeLookUp cboArrivingPerson;
        protected IvsTextEdit txtDocumentType;
        protected IvsDataLookUp cboPostedPerson;

    }
}
