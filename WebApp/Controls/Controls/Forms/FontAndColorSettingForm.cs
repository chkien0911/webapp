using System;
using System.Drawing;

namespace Ivs.Controls.Forms
{
    public partial class FontAndColorSettingForm : DevExpress.XtraEditors.XtraForm
    {
        private bool isBold = false;
        private bool isItalic = false;
        private bool isUnderline = false;

        public bool isOk = false;

        public bool IsBold
        {
            get
            {
                return isBold;
            }
            set
            {
                isBold = value;
                if (isBold)
                {
                    isBold = true;
                    btnBold.BackColor = Color.Yellow;
                }
                else
                {
                    isBold = false;
                    btnBold.BackColor = Color.Empty;
                }
                ChangeStyle();
            }
        }

        public bool IsItalic
        {
            get
            {
                return isItalic;
            }
            set
            {
                isItalic = value;
                if (isItalic)
                {
                    isItalic = true;
                    btnItalic.BackColor = Color.Yellow;
                }
                else
                {
                    isItalic = false;
                    btnItalic.BackColor = Color.Empty;
                }
                ChangeStyle();
            }
        }

        public bool IsUnderline
        {
            get
            {
                return isUnderline;
            }
            set
            {
                isUnderline = value;
                if (isUnderline)
                {
                    isUnderline = true;
                    btnUnderline.BackColor = Color.Yellow;
                }
                else
                {
                    isUnderline = false;
                    btnUnderline.BackColor = Color.Empty;
                }
                ChangeStyle();
            }
        }

        public Color TextColor
        {
            set
            {
                colorPickEdit1.Color = value;
            }
            get
            {
                Color value = Color.Empty;

                try
                {
                    value = colorPickEdit1.Color;
                }
                catch
                {
                }

                return value;
            }
        }

        public Color BackgroundColor
        {
            set
            {
                colorPickEdit2.Color = value;
            }
            get
            {
                Color value = Color.Empty;

                try
                {
                    value = colorPickEdit2.Color;
                }
                catch
                {
                }

                return value;
            }
        }

        public FontAndColorSettingForm()
        {
            InitializeComponent();
        }

        public FontAndColorSettingForm(bool bold, bool italic, bool underline,
            int textColorA, int textColorR, int textColorG, int textColorB,
            int backColorA, int backColorR, int backColorG, int backColorB)
        {
            InitializeComponent();
            IsBold = bold;
            IsItalic = italic;
            IsUnderline = underline;
            TextColor = Color.FromArgb(textColorA, textColorR, textColorG, textColorB);
            BackgroundColor = Color.FromArgb(backColorA, backColorR, backColorG, backColorB);
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if (isBold)
            {
                isBold = false;
                btnBold.BackColor = Color.Empty;
            }
            else
            {
                isBold = true;
                btnBold.BackColor = Color.Yellow;
            }
            ChangeStyle();
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (isItalic)
            {
                isItalic = false;
                btnItalic.BackColor = Color.Empty;
            }
            else
            {
                isItalic = true;
                btnItalic.BackColor = Color.Yellow;
            }
            ChangeStyle();
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            if (isUnderline)
            {
                isUnderline = false;
                btnUnderline.BackColor = Color.Empty;
            }
            else
            {
                isUnderline = true;
                btnUnderline.BackColor = Color.Yellow;
            }
            ChangeStyle();
        }

        private void colorPickEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ChangeStyle();
        }

        private void colorPickEdit2_EditValueChanged(object sender, EventArgs e)
        {
            ChangeStyle();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            isOk = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeStyle()
        {
            Font fPreview = new Font(lblPreview.Font, lblPreview.Font.Style);

            if (isBold && isItalic && isUnderline)
            {
                fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))));
            }
            else
            {
                if (isBold && isItalic)
                {
                    fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold)
                            | System.Drawing.FontStyle.Italic))));
                }
                else
                {
                    if (isBold && isUnderline)
                    {
                        fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold)
                            | System.Drawing.FontStyle.Underline))));
                    }
                    else if (isItalic && isUnderline)
                    {
                        fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Italic)
                            | System.Drawing.FontStyle.Underline))));
                    }
                    else if (isBold)
                    {
                        fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold)
                            ))));
                    }
                    else if (isItalic)
                    {
                        fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Italic)
                            ))));
                    }
                    else if (isUnderline)
                    {
                        fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Underline)
                            ))));
                    }
                    else
                    {
                        fPreview = new Font(lblPreview.Font, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Regular)
                            ))));
                    }
                }
            }

            pnlPreview.BackColor = colorPickEdit2.Color;
            lblPreview.ForeColor = colorPickEdit1.Color;
            lblPreview.Font = fPreview;
        }

        // Start add by Nguyen Thai An on 30/7/2013 for DMP project
        public virtual void SetLanguage()
        {
            //create I18n class object
            //I18n i18n = new I18n(CommonData.FunctionId.FACS);

            //Set language for control of MasterEdit form
            //this.lblPreview.Text = i18n.GetString(this.lblPreview.Name);
            //this.lblTextColor.Text = i18n.GetString(this.lblTextColor.Name);
            //this.lblBackgroundColor.Text = i18n.GetString(this.lblBackgroundColor.Name);
            //this.btnOk.Text = i18n.GetString(this.btnOk.Name);
            //this.btnCancel.Text = i18n.GetString(this.btnCancel.Name);
        }

        // End add by Nguyen Thai An on 30/7/2013 for DMP project
    }
}