using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.Core.Validation;

namespace Ivs.Controls.Forms
{
    public partial class MessageBoxs : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        //public event EventHandler Resize
        //Set Base Name
        private string baseName = "Ivs.Core.Properties.COM_MSG_{0}";

        private List<IvsMessage> _list = new List<IvsMessage>();
        private CommonData.MessageType _type;
        private CommonData.MessageTypeResult _typeResult;
        private string _firstMessage = "";

        public string DisplayMessage
        {
            get
            {
                if (_list.Count > 0)
                {
                    foreach (IvsMessage ms in _list)
                    {
                        ms.ChangeLanguage(UserSession.LangId);
                    }
                    _firstMessage = _list[0].MessageText;
                }
                return _firstMessage;
            }
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = new Dictionary<object, string>();
                lstControls.Add(this, this.Name);
                lstControls.Add(this.btnExport, btnExport.Name);
                lstControls.Add(this.btnNo, btnNo.Name);
                lstControls.Add(this.btnOKClose, btnOKClose.Name);
                lstControls.Add(this.btnYes, btnYes.Name);
                lstControls.Add(this.btnCancel, btnCancel.Name);
                lstControls.Add(this.colErrorType, colErrorType.Name);
                lstControls.Add(this.colMessageText, colMessageText.Name);
                lstControls.Add(this.itemLanguage, itemLanguage.Name);
                return lstControls;
            }
        }

        private void Clear()
        {
            _list.Clear();
        }

        private void Export(object sender, EventArgs e)
        {
            this.dgcMain.ExportToXls();
        }

        public void Add(IvsMessage msg)
        {
            _list.Add(msg);
        }

        public void Add(List<ValidationResult> vResuls)
        {
            foreach (ValidationResult vr in vResuls)
            {
                _list.Add(vr.Message);
            }
        }

        private void LoadButton()
        {
            switch (_type)
            {
                case CommonData.MessageType.Ok:
                    this.btnYes.Visible = false;
                    this.btnNo.Visible = false;
                    this.btnExport.Visible = true;
                    this.btnOKClose.Visible = true;
                    this.btnCancel.Visible = false;
                    this.btnExport.Location = new System.Drawing.Point(159, 3);
                    this.btnOKClose.Location = new System.Drawing.Point(269, 3);
                    this.btnOKClose.Select();
                    //this.btnOKClose.Focus();

                    break;

                case CommonData.MessageType.OkCancel:
                    this.btnYes.Visible = false;
                    this.btnNo.Visible = false;
                    this.btnExport.Visible = false;
                    this.btnOKClose.Visible = true;
                    this.btnCancel.Visible = true;
                    this.btnOKClose.Location = new System.Drawing.Point(159, 3);
                    this.btnCancel.Location = new System.Drawing.Point(269, 3);
                    this.btnOKClose.Select();
                    break;

                case CommonData.MessageType.YesNo:
                    this.btnExport.Visible = false;
                    this.btnOKClose.Visible = false;
                    this.btnCancel.Visible = false;
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    this.btnYes.Location = new System.Drawing.Point(159, 3);
                    this.btnNo.Location = new System.Drawing.Point(269, 3);
                    this.btnYes.Select();
                    break;

                case CommonData.MessageType.YesNoCancel:
                    this.btnExport.Visible = false;
                    this.btnOKClose.Visible = false;
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    this.btnCancel.Visible = true;
                    //this.btnExport.Location = new System.Drawing.Point(3, 3);
                    this.btnYes.Location = new System.Drawing.Point(109, 3);
                    this.btnNo.Location = new System.Drawing.Point(219, 3);
                    this.btnCancel.Location = new System.Drawing.Point(329, 3);
                    this.btnYes.Select();
                    break;

                default:
                    break;
            }
        }

        private void MessageBoxForm_Load(object sender, EventArgs e)
        {
            //this.SetLanguage(string.Empty);
            //this.SetLanguage(UserSession.LangId);
            this.LoadButton();
        }

        public CommonData.MessageTypeResult Display()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("MessageText", Type.GetType("System.String"));
            //tb.Columns.Add("ErrorType", Type.GetType("System.Drawing.Image"));

            foreach (IvsMessage ms in _list)
            {
                DataRow dr = tb.NewRow();
                dr["MessageText"] = ms.MessageText;
                tb.Rows.Add(dr);
            }
            //this._firstIvsMessage = _list[0].MessageText;
            dgcMain.DataSource = tb;
            if (!this.Modal)
                this.ShowDialog();

            return _typeResult;
        }

        /// <summary>
        /// Change language message dialog
        /// </summary>
        public void ChangeMessage()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("MessageText", Type.GetType("System.String"));
            foreach (IvsMessage ms in _list)
            {
                DataRow dr = tb.NewRow();
                if (ms.ParameterString == null || ms.ParameterString.Length == 0)
                {
                    string message = LanguageUltility.GetString(ms.MessageId);
                    dr["MessageText"] = message;
                }
                else
                {
                    string message = LanguageUltility.GetString(ms.MessageId);
                    dr["MessageText"] = !string.IsNullOrEmpty(message) ? string.Format(message, ms.ParameterString) : string.Empty;
                }

                tb.Rows.Add(dr);
            }
            dgcMain.DataSource = tb;
        }

        public CommonData.MessageTypeResult Display(CommonData.MessageType type)
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("MessageText", Type.GetType("System.String"));
            //tb.Columns.Add("ErrorType", Type.GetType("System.Drawing.Image"));
            _type = type;

            foreach (IvsMessage ms in _list)
            {
                DataRow dr = tb.NewRow();
                dr["MessageText"] = ms.MessageText;
                tb.Rows.Add(dr);
            }

            //this._firstIvsMessage = _list[0].MessageText;

            dgcMain.DataSource = tb;

            if (!this.Modal)
                this.ShowDialog();

            return _typeResult;
        }

        public void ReDisplay()
        {
            if (dgcMain.DataSource != null)
            {
                //Set Base Name
                string baseName = "Ivs.Core.Properties.COM_MSG_{0}";
                //Set List Control For Main
                ResourceManager resources = new ResourceManager(this.GetType());
                // change main form resources
                this.Text = resources.GetString("$this.Text");
                //Change Language For Main Form
                LanguageUltility.ChangeLanguage(baseName, Assembly.GetAssembly(typeof(LanguageUltility)), this, LstControls, (UserSession.LangId));

                this.ChangeMessage();
                _type = CommonData.MessageType.Ok;
                if (!this.Modal)
                    this.ShowDialog();
            }
        }


        public MessageBoxs()
        {
            InitializeComponent();

            this.Load += new EventHandler(MessageBoxForm_Load);

            this.btnExport.Click += new EventHandler(this.Export);
            this.btnOKClose.Click += new EventHandler(btn_OKClose_Click);
            this.btnYes.Click += new EventHandler(btnYes_Click);
            this.btnNo.Click += new EventHandler(btnNo_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            this.lbl_EN.Click += new EventHandler(lbl_EN_Click);
            this.lbl_JP.Click += new EventHandler(lbl_JP_Click);
            this.lbl_VN.Click += new EventHandler(lbl_VN_Click);
        }

        public MessageBoxs(CommonData.MessageType type)
        {
            this._type = type;
            InitializeComponent();

            this.Load += new EventHandler(MessageBoxForm_Load);
            this.btnExport.Click += new EventHandler(this.Export);
            this.btnOKClose.Click += new EventHandler(btn_OKClose_Click);
            this.btnYes.Click += new EventHandler(btnYes_Click);
            this.btnNo.Click += new EventHandler(btnNo_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);

            this.lbl_EN.Click += new EventHandler(lbl_EN_Click);
            this.lbl_JP.Click += new EventHandler(lbl_JP_Click);
            this.lbl_VN.Click += new EventHandler(lbl_VN_Click);
        }

        private void lbl_VN_Click(object sender, EventArgs e)
        {
            this.InitLanguage(CommonData.Language.VietNamese, false);
            LoadButton();
            this.ChangeMessage();
        }

        private void lbl_JP_Click(object sender, EventArgs e)
        {
            this.InitLanguage(CommonData.Language.Japanese, false);
            LoadButton();
            this.ChangeMessage();
        }

        private void lbl_EN_Click(object sender, EventArgs e)
        {
            this.InitLanguage(CommonData.Language.English, false);
            LoadButton();
            this.ChangeMessage();
        }

        //void changeLanguage(string langid)
        //{
        //    this.SetLanguage(langid);

        //    foreach (IvsMessage ms in _list)
        //    {
        //        ms.ChangeLanguage(langid);
        //    }
        //    this.Display(_type);
        //}


        private void btnNo_Click(object sender, EventArgs e)
        {
            _typeResult = CommonData.MessageTypeResult.No;
            this.Clear();
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _typeResult = CommonData.MessageTypeResult.Yes;
            this.Clear();
            this.Close();
        }

        private void btn_OKClose_Click(object sender, EventArgs e)
        {
            _typeResult = CommonData.MessageTypeResult.OK;
            //this.Clear();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _typeResult = CommonData.MessageTypeResult.Cancel;
            //this.Clear();
            this.Close();
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Escape)
            {
                this.Hide();
                return true;
            }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        private void MessageBoxs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserSession.LangId != null)
            {
                this.InitLanguage(UserSession.LangId);
            }
        }
    }
}