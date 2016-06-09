using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ivs.Controls.Forms;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Microsoft.Office.Interop.Excel;

namespace Ivs.Controls.Forms
{
    public partial class ImportForm : Ivs.Controls.CustomControls.WinForm.IVSForm
    {
        protected object[,] importData = new object[0, 0];

        public bool IsOverwrite { get; set; }

        public bool IsImportErr { get; set; }

        public int NumOfColumn { get; set; }

        public int sheetIndex { get; set; }

        public string sheetName { get; set; }

        public int iStartRow { get; set; }

        public string icolumnFormatDatetime { get; set; }

        public string FileName
        {
            get
            {
                string path = CommonData.StringEmpty;
                string[] paths = Path.GetFileName(txtPath.Text).Split('.');
                if (paths.Length > 1)
                {
                    path = paths[0];
                }
                return path;
            }
        }

        protected override string FunctionId
        {
            get
            {
                return CommonData.FunctionId.ImportForm;
            }
        }

        public override Dictionary<object, string> LstControls
        {
            get
            {
                Dictionary<object, string> lstControls = new Dictionary<object, string>();
                lstControls.Add(this.btnChoosePath, btnChoosePath.Name);
                lstControls.Add(this.btnOK, btnOK.Name);
                lstControls.Add(this.btnCancel, btnCancel.Name);
                return lstControls;
            }
        }

        public override void InitLanguage(string lang, bool isSetCulture = true)
        {
            base.InitLanguage(lang, isSetCulture);
            //SetLanguage();
        }

        public ImportForm()
        {
            InitializeComponent();
            chkOverWire.CheckedChanged += new EventHandler(chkOverWire_CheckedChanged);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnChoosePath.Click += new EventHandler(btnChoosePath_Click);
            btnOK.Click += new EventHandler(btnOK_Click);

            sheetIndex = 1;
            iStartRow = 3;
            icolumnFormatDatetime = string.Empty;
        }

        public ImportForm(bool showOverwrite)
        {
            InitializeComponent();
            chkOverWire.CheckedChanged += new EventHandler(chkOverWire_CheckedChanged);
            btnCancel.Click += new EventHandler(btnCancel_Click);
            btnChoosePath.Click += new EventHandler(btnChoosePath_Click);
            btnOK.Click += new EventHandler(btnOK_Click);
            chkOverWire.Visible = showOverwrite;

            sheetIndex = 1;
            iStartRow = 3;
            icolumnFormatDatetime = string.Empty;
            //SetLanguage();
        }

        public virtual void btnOK_Click(object sender, EventArgs e)
        {
            MessageBoxs msg = new MessageBoxs();
            IvsMessage message = null;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            int returnCode = 0;
            returnCode = this.GetImportData();
            switch (returnCode)
            {
                case CommonData.ImportReturnCode.PathIsEmpty:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_REQUIRED, lblPath_Import.Text);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    this.importData = null;
                    this.IsImportErr = true;
                    break;

                case CommonData.ImportReturnCode.PathNotExist:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_DATA_OR_FILE_NOT_FOUND, txtPath.Text);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    this.importData = null;
                    this.IsImportErr = true;
                    break;

                case CommonData.ImportReturnCode.FileFormatInvalid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FILE_FORMAT_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    this.importData = null;
                    this.IsImportErr = true;
                    break;

                case CommonData.ImportReturnCode.NumRowInvalid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FILE_NUM_OF_ROW_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    this.importData = null;
                    this.IsImportErr = true;
                    break;

                case CommonData.ImportReturnCode.NumFieldInvalid:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_FILE_NUM_OF_COLUMN_INVALID);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    this.importData = null;
                    this.IsImportErr = true;
                    break;

                case CommonData.ImportReturnCode.SystemError:

                    message = new IvsMessage(CommonConstantMessage.COM_MSG_GENERAL_EXCEPTION);
                    msg.Add(message);
                    msg.Display(CommonData.MessageType.Ok);

                    this.importData = null;
                    this.IsImportErr = true;
                    break;

                case CommonData.ImportReturnCode.Succeed:
                    this.IsImportErr = false;
                    this.Hide();
                    break;
            }
        }

        public virtual int GetImportData()
        {
            ApplicationClass xlsApp = new ApplicationClass();
            Workbook xlsWorkbook;
            Worksheet xlsWorksheet;
            Range xlsRange = null;

            try
            {
                string filePath = CommonData.StringEmpty;
                string[] fileNameChosen;

                //check path empty
                if (txtPath.Text.Equals(CommonData.StringEmpty))
                {
                    return CommonData.ImportReturnCode.PathIsEmpty;
                }

                else
                {
                    filePath = Path.GetFullPath(txtPath.Text);
                    fileNameChosen = Path.GetFileName(txtPath.Text).Split('.');

                    //Check the existing of file
                    if (!File.Exists(filePath))
                    {
                        return CommonData.ImportReturnCode.PathNotExist;
                    }

                    xlsWorkbook = (Workbook)(xlsApp.Workbooks.Open(filePath,
                                                           Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                           Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                           Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                           Missing.Value, Missing.Value));
                    //Check File format
                    if (!fileNameChosen[1].Equals(CommonData.FileType.Xls) && !fileNameChosen[1].Equals(CommonData.FileType.Xlsx))
                    {
                        xlsApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        return CommonData.ImportReturnCode.FileFormatInvalid;
                    }
                    //Start 20130724 by NPQuoc set sheetindex
                    if (!CommonMethod.IsNullOrEmpty(sheetName))
                    {
                        int iSheetIndex = 1;
                        foreach (Microsoft.Office.Interop.Excel.Worksheet displayWorksheet in xlsWorkbook.Worksheets)
                        {
                            if (displayWorksheet.Name.Trim() == sheetName)
                            {
                                sheetIndex = iSheetIndex;
                                break;
                            }
                            iSheetIndex++;
                        }
                    }
                    //End 20130724 by NPQuoc set sheetindex

                    xlsWorksheet = (Worksheet)xlsWorkbook.ActiveSheet;
                    xlsWorksheet = (Worksheet)xlsWorkbook.Worksheets[sheetIndex];

                    xlsRange = xlsWorksheet.UsedRange;

                    //int iRowCount = xlsWorksheet.UsedRange.Rows.Count;
                    //xlsRange = xlsWorksheet.get_Range("A8","G17");

                    //Check number field is valid

                    this.importData = new object[xlsRange.Rows.Count, xlsRange.Columns.Count];
                    this.importData = (object[,])xlsRange.Value2;

                    if (this.importData == null || this.importData.GetLength(0) < 3)
                    {
                        xlsApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        return CommonData.ImportReturnCode.NumRowInvalid;
                    }

                    if (this.importData.GetLength(1) != this.NumOfColumn)
                    {
                        xlsApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);
                        return CommonData.ImportReturnCode.NumFieldInvalid;
                    }

                    //check successful
                    xlsApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);

                    return CommonData.ImportReturnCode.Succeed;
                }
            }
            catch
            {
                return CommonData.IOReturnCode.SystemError;
            }
        }

        public virtual List<T> GetData<T>()
        {
            #region DNP code

            //List<T> lstDto = new List<T>();
            //Type type = typeof(T);
            //PropertyInfo[] properties = type.GetProperties();

            //int numOfRow = importData.GetLength(0);
            //int numOfColumn = importData.GetLength(1);
            //#region iStartRow = iStartRow + obj null
            //Boolean iForParent = true;
            //int iObjNull = 0;
            //for (int i = 1; i <= numOfRow; i++)
            //{
            //    for (int j = 0; j < numOfColumn; j++)
            //    {
            //        if (importData.GetLength(1) == numOfColumn)
            //        {
            //            object value = importData[i, j + 1];
            //            if (!CommonMethod.IsNullOrEmpty(value))
            //            {
            //                iObjNull = i - 1;
            //                iForParent = false;
            //                break;
            //            }
            //        }
            //    }
            //    if (!iForParent)
            //    {
            //        break;
            //    }
            //}
            //#endregion

            //iStartRow = iStartRow + iObjNull;
            //for (int i = iStartRow; i <= numOfRow; i++)
            //{
            //    int countNull = 0;
            //    bool flagCheckNull = false;
            //    T dto = (T)Activator.CreateInstance(type);

            //    for (int j = 0; j < numOfColumn; j++)
            //    {
            //        if (importData.GetLength(1) == numOfColumn)
            //        {
            //            PropertyInfo pi = properties[j];
            //            object value = importData[i, j + 1];
            //            //Start 20130725 by NPQuoc Check FormatDatetime from decimal convert to datetime
            //            if (!CommonMethod.IsNullOrEmpty(icolumnFormatDatetime))
            //            {
            //                foreach (string iColumn in icolumnFormatDatetime.Split(','))
            //                {
            //                    int iColumnCurrent = j + 1;
            //                    if (iColumnCurrent == CommonMethod.ParseInt(iColumn))
            //                    {
            //                        DateTime dateResult = new DateTime();
            //                        CultureInfo culture = CultureInfo.CreateSpecificCulture(CommonData.Environment.Vietnamese);
            //                        DateTimeStyles styles = DateTimeStyles.None;
            //                        if (DateTime.TryParse(CommonMethod.ParseString(value), culture, styles, out dateResult))
            //                        {
            //                            //value = CommonMethod.ParseDateTime(dateResult, CommonData.DateFormat.DdMMyyyyHHmmss);
            //                            value = String.Format("{0:" + CommonData.DateFormat.DdMMyyyyHHmmss + "}", dateResult);
            //                            break;
            //                        }
            //                        else
            //                        {
            //                            if (DateTime.TryParse(CommonData.ConvertDoubleToDate(value).ToString(CommonData.DateFormat.DdMMyyyyHHmmss), culture, styles, out dateResult))
            //                            {
            //                                //value = CommonMethod.ParseDateTime(CommonData.ConvertDoubleToDate(value), CommonData.DateFormat.DdMMyyyyHHmmss);
            //                                //value = dateResult.ToString(CommonData.DateFormat.DdMMyyyyHHmmss);
            //                                value = dateResult.Date.ToShortDateString() + " " +  dateResult.TimeOfDay.ToString();
            //                                break;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            //End 20130725 by NPQuoc Check FormatDatetime from decimal convert to datetime
            //            if (value == null)
            //            {
            //                countNull++;
            //            }
            //            pi.SetValue(dto, Convert.ChangeType(CommonMethod.ParseString(value).Trim(), pi.PropertyType), null);
            //        }
            //        if (countNull == properties.GetLength(0))
            //        {
            //            flagCheckNull = true;
            //        }
            //    }

            //    this.IsImportErr = false;
            //    if (!flagCheckNull)
            //    {
            //        lstDto.Add(dto);
            //    }
            //}
            //return lstDto;

            #endregion DNP code

            List<T> lstDto = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            int numOfRow = importData.GetLength(0);

            int numOfColumn = importData.GetLength(1);

            for (int i = 3; i <= numOfRow; i++)
            {
                int countNull = 0;
                bool flagCheckNull = false;
                T dto = (T)Activator.CreateInstance(type);

                for (int j = 0; j < numOfColumn; j++)
                {
                    if (importData.GetLength(1) == numOfColumn)
                    {
                        PropertyInfo pi = properties[j];
                        object value = importData[i, j + 1];
                        if (value == null)
                        {
                            countNull++;
                        }
                        pi.SetValue(dto, Convert.ChangeType(CommonMethod.ParseString(value).Trim(), pi.PropertyType), null);
                    }
                    if (countNull == properties.GetLength(0))
                    {
                        flagCheckNull = true;
                    }
                }

                this.IsImportErr = false;
                if (!flagCheckNull)
                {
                    lstDto.Add(dto);
                }
            }

            return lstDto;
        }

        protected void btnChoosePath_Click(object sender, EventArgs e)
        {
            this.ChoosePath();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Hide();
        }

        private void chkOverWire_CheckedChanged(object sender, EventArgs e)
        {
            IsOverwrite = chkOverWire.Checked;
        }

        //protected virtual void SetLanguage()
        //{
        //    //create I18n class object
        //    I18n i18n = new I18n(this.FunctionId);

        //    this.Text = i18n.GetString(lblPath_Import.Name);
        //    this.btnCancel.Text = i18n.GetString(this.btnCancel.Name);
        //    this.btnOK.Text = i18n.GetString(this.btnOK.Name);
        //    this.chkOverWire.Text = i18n.GetString(this.chkOverWire.Name);
        //    this.lblName.Text = i18n.GetString(lblName.Name);
        //}

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
            if (keyData == System.Windows.Forms.Keys.Escape)
            {
                this.Hide();
                return true;
            }
            else return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Choose path from file
        /// </summary>
        protected virtual void ChoosePath()
        {
            System.Windows.Forms.OpenFileDialog file = new System.Windows.Forms.OpenFileDialog();
            file.Filter = "Excel files (*.xls)|*.xls|(*.xlsx)|*.xlsx|All files (*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.txtPath.Text = file.FileName;
            }
        }
    }
}