using Ivs.Controls.CustomControls.WinForm;
namespace Ivs.Controls.Forms
{
    partial class TransEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransEditForm));
            this.barManager1 = new Ivs.Controls.CustomControls.WinForm.IvsBarManager(this.components);
            this.bar2 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.lblPath = new Ivs.Controls.CustomControls.WinForm.IvsBarStaticItem();
            this.bar3 = new Ivs.Controls.CustomControls.WinForm.IvsBar();
            this.btnSaveAndClose = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnPrevious = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnSaveAndNext = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnClear = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.btnClose = new Ivs.Controls.CustomControls.WinForm.IvsBarButtonItem();
            this.barDockControlTop = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlBottom = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlLeft = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.barDockControlRight = new Ivs.Controls.CustomControls.WinForm.IvsBarDockControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new Ivs.Controls.CustomControls.WinForm.IvsPanel();
            this.lblErrorMessage = new Ivs.Controls.CustomControls.WinForm.IvsLabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.lblPath,
            this.btnSaveAndClose,
            this.btnClear,
            this.btnClose,
            this.btnSaveAndNext,
            this.btnPrevious});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblPath)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // lblPath
            // 
            this.lblPath.Caption = "Danh mục > Danh mục cơ cấu tổ chức  > Chi tiết văn phòng";
            this.lblPath.Id = 1;
            this.lblPath.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.ItemAppearance.Normal.Options.UseFont = true;
            this.lblPath.Name = "lblPath";
            this.lblPath.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSaveAndClose),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrevious, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSaveAndNext, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClear),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClose)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Caption = "Lưu và đóng";
            this.btnSaveAndClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Glyph")));
            this.btnSaveAndClose.Id = 2;
            this.btnSaveAndClose.ImageIndex = 0;
            this.btnSaveAndClose.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnSaveAndClose.ItemAppearance.Normal.Options.UseFont = true;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Caption = "Quay lại";
            this.btnPrevious.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Glyph")));
            this.btnPrevious.Id = 7;
            this.btnPrevious.Name = "btnPrevious";
            // 
            // btnSaveAndNext
            // 
            this.btnSaveAndNext.Caption = "Lưu và tiếp theo";
            this.btnSaveAndNext.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaveAndNext.Glyph")));
            this.btnSaveAndNext.Id = 5;
            this.btnSaveAndNext.Name = "btnSaveAndNext";
            // 
            // btnClear
            // 
            this.btnClear.Caption = "Xóa trắng";
            this.btnClear.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClear.Glyph")));
            this.btnClear.Id = 3;
            this.btnClear.ImageIndex = 0;
            this.btnClear.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClear.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClear.Name = "btnClear";
            this.btnClear.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Đóng";
            this.btnClose.Glyph = ((System.Drawing.Image)(resources.GetObject("btnClose.Glyph")));
            this.btnClose.Id = 4;
            this.btnClose.ImageIndex = 0;
            this.btnClose.ItemAppearance.Normal.Font = new System.Drawing.Font("Arial", 9F);
            this.btnClose.ItemAppearance.Normal.Options.UseFont = true;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(835, 22);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 282);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(835, 35);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 260);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(835, 22);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 260);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblErrorMessage, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 22);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(835, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(4, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 225);
            this.panel2.TabIndex = 7;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorMessage.Location = new System.Drawing.Point(4, 4);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(827, 20);
            this.lblErrorMessage.TabIndex = 6;
            this.lblErrorMessage.Text = "Error";
            // 
            // TransEditForm
            // 
            this.Appearance.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 317);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected IvsBarStaticItem lblPath;
        protected IvsBar bar3;
        protected IvsBarButtonItem btnSaveAndClose;
        protected IvsBarButtonItem btnClear;
        protected IvsBarButtonItem btnClose;
        protected IvsBarDockControl barDockControlTop;
        protected IvsBarDockControl barDockControlBottom;
        protected IvsBarDockControl barDockControlLeft;
        protected IvsBarDockControl barDockControlRight;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected IvsLabelControl lblErrorMessage;
        protected IvsPanel panel2;
        protected IvsBarButtonItem btnSaveAndNext;
        protected IvsBarManager barManager1;
        protected IvsBar bar2;
        protected IvsBarButtonItem btnPrevious;
    }
}