using System;
using System.Collections.Generic;
using System.Data;
using Ivs.Core.Common;
using Ivs.DAL.Dao;
using Ivs.DAL.EFModels;
using System.Linq;
using Ivs.DTO.Systems;
using Ivs.Core.Interface;

namespace Ivs.BLL.Sys
{
    public class SYS_GroupUserBL : Ivs.Core.Interface.IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        private DataTable dtFunction = null;
        private DataTable dtIs = null;
        //private ishida_payrollEntities DBContext;
        #region IBl Members

        public int SearchData(Ivs.Core.Interface.IDto selectDto, out System.Data.DataTable dtResult)
        {
            //STGroupListDao dao = new STGroupListDao();
            //STGroupListDto dto = (STGroupListDto)selectDto;

            //System.Collections.Hashtable htCondition = new System.Collections.Hashtable();

            //if (!string.IsNullOrEmpty(dto.GroupName))
            //{
            //    htCondition.Add(MSGP00Key.GroupName, dto.GroupName);
            //}

            //return dao.SelectData(htCondition, out dtResult);

            //Create Group datatable
            dtResult = new DataTable();
            dtResult.Columns.Add("ID");
            dtResult.Columns.Add("GroupName");
            dtResult.Columns.Add("Note");

            //Group data - row 1
            DataRow drGroup = dtResult.NewRow();
            drGroup["ID"] = "1";
            drGroup["GroupName"] = "Administrator";
            drGroup["Note"] = "";
            dtResult.Rows.Add(drGroup);

            //Group data - row 2
            drGroup = dtResult.NewRow();
            drGroup["ID"] = "2";
            drGroup["GroupName"] = "Dev Group";
            drGroup["Note"] = "";
            dtResult.Rows.Add(drGroup);

            //Group data - row 3
            drGroup = dtResult.NewRow();
            drGroup["ID"] = "3";
            drGroup["GroupName"] = "Test Group";
            drGroup["Note"] = "";
            dtResult.Rows.Add(drGroup);

            //Group data - row 4
            drGroup = dtResult.NewRow();
            drGroup["ID"] = "4";
            drGroup["GroupName"] = "Manager";
            drGroup["Note"] = "";
            dtResult.Rows.Add(drGroup);

            //Group data - row 5
            drGroup = dtResult.NewRow();
            drGroup["ID"] = "5";
            drGroup["GroupName"] = "Employee";
            drGroup["Note"] = "";
            dtResult.Rows.Add(drGroup);

            //Group data - row 6
            drGroup = dtResult.NewRow();
            drGroup["ID"] = "6";
            drGroup["GroupName"] = "User";
            drGroup["Note"] = "";
            dtResult.Rows.Add(drGroup);

            return 0;
        }

        //public int SearchData(out System.Data.DataTable dtResult)
        //{
        //    //SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    //return dao.SelectData(out dtResult);
        //}
        public int InsertData(Ivs.Core.Interface.IDto insertDto)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(Ivs.Core.Interface.IDto updateDto)
        {
            throw new NotImplementedException();
        }

        //public int DeleteData(List<Ivs.Core.Interface.IDto> listDeleteData)
        //{
        //    SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    int returnCode = Ivs.Iwms.Core.Data.CommonData.DbReturnCode.Succeed;

        //    List<string> listCodeDeleteData = new List<string>();
        //    foreach (STGroupDetailDto dto in listDeleteData)
        //    {
        //        string code = dto.ID.ToString();
        //        listCodeDeleteData.Add(code);
        //    }
        //    returnCode = dao.DeleteData(listCodeDeleteData);

        //    return returnCode;
        //}

        #endregion IBl Members

        #region Search User in Group

        //public int SelectUserInGroup(Ivs.Core.Interface.IDto selectDto, out DataTable dtResult)
        //{
        //    SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    STGroupListDto dto = (STGroupListDto)selectDto;
        //    Hashtable htCondition = new Hashtable();

        //    DataTable dtUser = new DataTable();
        //    dtUser.Columns.Add("ID");
        //    dtUser.Columns.Add("UserName");
        //    dtUser.Columns.Add("FullName");
        //    dtUser.Columns.Add("Status");
        //    dtUser.Columns.Add("GroupName");

        //    //Row 1
        //    DataRow drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "1";
        //    drUsers["UserName"] = "admin";
        //    drUsers["FullName"] = "Lê Thanh Tùng";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Administrator";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 2
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "2";
        //    drUsers["UserName"] = "dungdn";
        //    drUsers["FullName"] = "Dương Ngọc Dũng";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Dev Group";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 3
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "3";
        //    drUsers["UserName"] = "namdh";
        //    drUsers["FullName"] = "Dương Hoàng Nam";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Test Group";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 4
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "4";
        //    drUsers["UserName"] = "tungdt";
        //    drUsers["FullName"] = "Đặng Trường Tùng";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Manager";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 5
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "5";
        //    drUsers["UserName"] = "tuannv";
        //    drUsers["FullName"] = "Nguyễn Văn Tuấn";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Employee";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 6
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "5";
        //    drUsers["UserName"] = "huanlm";
        //    drUsers["FullName"] = "Lê Minh Huấn";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Employee";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 7
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "2";
        //    drUsers["UserName"] = "tanhn";
        //    drUsers["FullName"] = "Hoàng Nhật Tân";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Dev Group";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 8
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "3";
        //    drUsers["UserName"] = "dangnv";
        //    drUsers["FullName"] = "Nguyễn Văn Đăng";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Test Group";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 9
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "4";
        //    drUsers["UserName"] = "duongnt";
        //    drUsers["FullName"] = "Nguyễn Trung Dương";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "Manager";
        //    dtUser.Rows.Add(drUsers);

        //    //Row 10
        //    drUsers = dtUser.NewRow();
        //    drUsers["ID"] = "6";
        //    drUsers["UserName"] = "thaott";
        //    drUsers["FullName"] = "Trần Thu Thảo";
        //    drUsers["Status"] = "Active";
        //    drUsers["GroupName"] = "User";
        //    dtUser.Rows.Add(drUsers);

        //    dtResult = new DataTable();
        //    dtResult.Columns.Add("UserName");
        //    dtResult.Columns.Add("FullName");
        //    dtResult.Columns.Add("Status");

        //    DataRow drResult = null;
        //    string ID = dto.ID.ToString();
        //    for (int i = 0; i < dtUser.Rows.Count; i++)
        //    {
        //        if (dtUser.Rows[i]["ID"].ToString().Equals(ID))
        //        {
        //            drResult = dtResult.NewRow();
        //            drResult["UserName"] = dtUser.Rows[i]["UserName"].ToString();
        //            drResult["FullName"] = dtUser.Rows[i]["FullName"].ToString();
        //            drResult["Status"] = dtUser.Rows[i]["Status"].ToString();
        //            dtResult.Rows.Add(drResult);
        //        }
        //    }
        //    return 0;

        //    //htCondition.Add(MSGP00Key.ID, dto.ID);
        //    //return dao.SelectUserInGroup(htCondition, out dtResult);
        //}

        #endregion Search User in Group

        #region Search Function List belong User Group

        //public int SelectFunctionInGroup(Ivs.Core.Interface.IDto selectDto, out DataTable dtResult)
        //{
        //    SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    STGroupListDto dto = (STGroupListDto)selectDto;
        //    Hashtable htCondition = new Hashtable();
        //    htCondition.Add(MSGP00Key.ID, dto.ID);
        //    //return dao.SelectFunctionInGroup(htCondition, out dtResult);
        //    //Fill Data
        //    FillData();
        //    //Create data for Administrator Group
        //    dtResult = new DataTable();
        //    DataRow dr = null;
        //    for (int i = 0; i < 19; i++)
        //    {
        //        dr = dtIs.NewRow();
        //        dr["IsFull"] = true;
        //        dr["IsRead"] = true;
        //        dr["IsAdd"] = true;
        //        dr["IsUpdate"] = true;
        //        dr["IsDelete"] = true;
        //        dr["IsPrint"] = true;
        //        dr["IsExport"] = true;
        //        dr["IsImport"] = true;
        //        dtIs.Rows.Add(dr);
        //    }

        //    dtResult = dtIs.Copy();
        //    int count = 0;
        //    for (int i = 0; i < dtFunction.Columns.Count; i++)
        //    {
        //        if (!dtIs.Columns.Contains(dtFunction.Columns[i].ColumnName))
        //        {
        //            dtResult.Columns.Add(dtFunction.Columns[i].ColumnName, dtFunction.Columns[i].DataType);
        //            count++;
        //        }
        //    }
        //    for (int i = 0; i < 19; i++)
        //    {
        //        dtResult.Rows[i]["ID"] = dtFunction.Rows[i]["ID"];
        //        dtResult.Rows[i]["FunctionName"] = dtFunction.Rows[i]["FunctionName"];
        //    }

        //    //Create data for Dev Group
        //    if (dto.ID == 2)
        //    {
        //        //set false
        //        int[] colArr = new int[] { 2, 3, 4, 5, 7 };
        //        int[] rowArr = new int[] { 2, 3, 5, 8, 12 };

        //        for (int i = 0; i < 19; i++)
        //        {
        //            if (i == 1 || i == 3 || i == 5 || i == 8)
        //            {
        //                foreach (int j in colArr)
        //                {
        //                    dtResult.Rows[i][j] = false;
        //                }
        //            }
        //        }

        //    }

        //    //Create data for Test Group
        //    if (dto.ID == 3)
        //    {
        //        //set false
        //        int[] colArr = new int[] { 2, 4, 3, 5, 7 };
        //        int[] rowArr = new int[] { 3, 5, 8, 9, 13 };

        //        for (int i = 0; i < 19; i++)
        //        {
        //            if (i == 1 || i == 3 || i == 5 || i == 8)
        //            {
        //                foreach (int j in colArr)
        //                {
        //                    dtResult.Rows[i][j] = false;
        //                }
        //            }
        //        }

        //    }

        //    //Create data for Manager Group
        //    if (dto.ID == 4)
        //    {
        //        //set false
        //        int[] colArr = new int[] { 2, 3, 5, 7 };
        //        int[] rowArr = new int[] { 2, 3, 6, 9, 11, 15 };

        //        for (int i = 0; i < 19; i++)
        //        {
        //            if (i == 1 || i == 3 || i == 5 || i == 8)
        //            {
        //                foreach (int j in colArr)
        //                {
        //                    dtResult.Rows[i][j] = false;
        //                }
        //            }
        //        }

        //    }

        //    //Create data for User Group
        //    if (dto.ID == 5)
        //    {
        //        //set false
        //        int[] colArr = new int[] { 2, 3, 5, 6, 7 };
        //        int[] rowArr = new int[] { 2, 3, 6, 9, 12 };

        //        for (int i = 0; i < 19; i++)
        //        {
        //            if (i == 1 || i == 3 || i == 5 || i == 8)
        //            {
        //                foreach (int j in colArr)
        //                {
        //                    dtResult.Rows[i][j] = false;
        //                }
        //            }
        //        }

        //    }

        //    //Create data for Employee Group
        //    if (dto.ID == 6)
        //    {
        //        //set false
        //        int[] colArr = new int[] { 3, 5, 4, 6, 7 };
        //        int[] rowArr = new int[] { 2, 3, 6, 9, 12 };

        //        for (int i = 0; i < 19; i++)
        //        {
        //            if (i == 1 || i == 3 || i == 5 || i == 8)
        //            {
        //                foreach (int j in colArr)
        //                {
        //                    dtResult.Rows[i][j] = false;
        //                }
        //            }
        //        }

        //    }
        //    return 0;
        //}

        #endregion Search Function List belong User Group

        #region///Do du lieu vao Datatable

        public void FillData()
        {
            dtFunction = new DataTable();
            dtFunction.Columns.Add("ID");
            dtFunction.Columns.Add("FunctionName");

            DataRow drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MDDepartmentDetail";
            drFunction["FunctionName"] = "Create/Modify Department";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MDDepartmentList";
            drFunction["FunctionName"] = "List Of Department";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MDOutcomeMasterDetail";
            drFunction["FunctionName"] = "Create/Modify Outcome Master";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MDOutcomeMasterList";
            drFunction["FunctionName"] = "List Of Outcome Master";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MDStaffDetail";
            drFunction["FunctionName"] = "Create/Modify Staff";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MDStaffList";
            drFunction["FunctionName"] = "List Of Staff";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSASH0";
            drFunction["FunctionName"] = "System History";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSGP00";
            drFunction["FunctionName"] = "List Of Users Group";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSGP01";
            drFunction["FunctionName"] = "Create/Modify Users Group";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSPR00";
            drFunction["FunctionName"] = "List Of Parameters";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSPR01";
            drFunction["FunctionName"] = "Create/Modify Paramters";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSPW00";
            drFunction["FunctionName"] = "Change Password";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSUS00";
            drFunction["FunctionName"] = "List Of Users";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "MSUS01";
            drFunction["FunctionName"] = "Create/Modify Users";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "PRCalculator";
            drFunction["FunctionName"] = "List Of Calculator";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "PRCalculatorDetail";
            drFunction["FunctionName"] = "Excute Calculator";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "PRImportProduct";
            drFunction["FunctionName"] = "List Of Importing Product";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "PRImportProductDetaill";
            drFunction["FunctionName"] = "Modify Importing History";
            dtFunction.Rows.Add(drFunction);

            drFunction = dtFunction.NewRow();
            drFunction["ID"] = "PRImportProductHistory";
            drFunction["FunctionName"] = "Importing History";
            dtFunction.Rows.Add(drFunction);

            dtIs = new DataTable();
            dtIs.Columns.Add("IsFull", typeof(bool));
            dtIs.Columns.Add("IsRead", typeof(bool));
            dtIs.Columns.Add("IsAdd", typeof(bool));
            dtIs.Columns.Add("IsUpdate", typeof(bool));
            dtIs.Columns.Add("IsDelete", typeof(bool));
            dtIs.Columns.Add("IsPrint", typeof(bool));
            dtIs.Columns.Add("IsExport", typeof(bool));
            dtIs.Columns.Add("IsImport", typeof(bool));
        }

        #endregion

        #region  Search Function InGroup belond UserName
        //public int SelectFunction(out DataTable dtResult)
        //{
        //    SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    return dao.SelectFunction(out dtResult);
        //}
        #endregion

        #region  UpdateRole
        //public int UpdateRole(Ivs.Core.Interface.IDto updateDto)
        //{
        //    SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    return dao.UpdateRole(updateDto);
        //}
        #endregion

        #region LookupEdit UserGroup
        //public void SetLookupEdit(Ivs.Controls.CustomControls.WinForm.IvsLookUpEdit ctrl, string DisplayMember, string ValueMember)
        //{
        //    SYS_GroupUserDAO dao = new SYS_GroupUserDAO();
        //    DataTable dt = new DataTable();
        //    dao.SelectData(out dt);
        //    CFunction.BindLookupEdit(ctrl, dt, DisplayMember, ValueMember);
        //}
        #endregion

        #region Delete

        public int DeleteData(List<string> listDeleteData)
        {
            int returnCode = 0;
            long id;
            List<object> listMsArea = new List<object>();
            //using (DBContext = new ishida_payrollEntities())
            //{
            //    try
            //    {
            //        foreach (string deleteData in listDeleteData)
            //        {
            //            id = long.Parse(deleteData);
            //            sys_groups dto = DBContext.sys_groups.First(g => g.ID == id);
            //            DBContext.DeleteObject(dto);
            //            DBContext.SaveChanges();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        returnCode = this.ProcessDbException(ex);
            //    }
            //}
            return returnCode;
        }

        #endregion

        public int DeleteData(List<Ivs.Core.Interface.IDto> listDto)
        {
            return 0;
        }
    }
}