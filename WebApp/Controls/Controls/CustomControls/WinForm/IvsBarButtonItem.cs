using System.IO;

/* =========================================
 * Author: NNHieu
 * Create Date: 2012/08/23
 * Adviser: NHKhuong
 * Advise Date: 2012/10/11
 ========================================= */

using System.Reflection;
using System.Windows.Forms;
using Ivs.Core.Common;
using Microsoft.Office.Interop.Excel;

namespace Ivs.Controls.CustomControls.WinForm
{
    public class IvsBarButtonItem : DevExpress.XtraBars.BarButtonItem
    {
        public int ImportData(string fileName, string sheetName, out object[,] objData)
        {
            objData = new object[0, 0];
            int returnCode = 0;
            try
            {
                string filePath = CommonData.StringEmpty;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();
                ApplicationClass xlsApp = new ApplicationClass();
                Workbook xlsWorkbook;
                Worksheet xlsWorksheet;
                Range xlsRange = null;
                openFileDialog.Filter = "Excel files (*.xls)|*.xls|(*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;

                if (result == DialogResult.OK)
                {
                    string[] fileNameChosen = Path.GetFileName(openFileDialog.FileName).Split('.');
                    filePath = Path.GetFullPath(openFileDialog.FileName);

                    //Check the existing of file
                    if (!File.Exists(filePath))
                    {
                        return CommonData.IOReturnCode.FileNotFound;
                    }

                    //Check FileName
                    if (!fileNameChosen[0].Equals(fileName))
                    {
                        return CommonData.IOReturnCode.FileNameInValid;
                    }

                    //Check FileType
                    if (!fileNameChosen[1].Equals(CommonData.FileType.Xls) && !fileNameChosen[1].Equals(CommonData.FileType.Xlsx))
                    {
                        return CommonData.IOReturnCode.FileTypeInValid;
                    }

                    xlsWorkbook = (Workbook)(xlsApp.Workbooks.Open(filePath,
                                                                   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                                   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                                   Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                                   Missing.Value, Missing.Value));
                    xlsWorksheet = (Worksheet)xlsWorkbook.ActiveSheet;
                    xlsWorksheet = (Worksheet)xlsWorkbook.Worksheets[1];

                    //Check SheetName
                    if (!xlsWorksheet.Name.Equals(sheetName))
                    {
                        return CommonData.IOReturnCode.FileFormatInValid;
                    }

                    xlsRange = xlsWorksheet.UsedRange;
                    objData = new object[xlsRange.Rows.Count, xlsRange.Columns.Count];
                    objData = (object[,])xlsRange.Value2;

                    xlsApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsWorkbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp);

                    returnCode = CommonData.IOReturnCode.Succeed;
                }
                else
                {
                    returnCode = CommonData.IOReturnCode.CancelImport;
                }
                return returnCode;
            }
            catch
            {
                return CommonData.IOReturnCode.SystemError;
            }
        }
    }
}