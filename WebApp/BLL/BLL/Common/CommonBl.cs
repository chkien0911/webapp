using System;
using System.Collections;
using System.Data;
using Ivs.Core.Common;
using Ivs.Core.Data;
using Ivs.DAL.Dao.Common;
using Ivs.DAL.Dao.Master;
using Ivs.Core.Interface;
using System.Collections.Generic;
using Ivs.DAL.Dao;
using Ivs.DAL.Dao.Systems;
using Ivs.Models.Systems;
using Ivs.Models.Common;

namespace Ivs.BLL.Common
{
    public class CommonBl
    {
        public static string GetDBName()
        {
          return   Ivs.DAL.Data.DbConfig.DbName;
        }
        /// <summary>
        /// Get automatic DocumentNo
        /// </summary>
        /// <param name="documentType"></param>
        /// <param name="documentNo"></param>
        /// <returns></returns>
        public string GetDocumentNo(string documentType)
        {
            return CommonData.StringEmpty;
        }

        /// <summary>
        /// Get System Date
        /// </summary>
        /// <param name="systemDate">DateTime value</param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public static DateTime GetSystemDate()
        {
            CommonDao commonDao = new CommonDao();
            DateTime systemDate = new DateTime();
            commonDao.GetSystemDate(out systemDate);

            return systemDate;
        }

        /// <summary>
        /// Update user's skin
        /// </summary>
        /// <param name="skin"></param>
        /// <returns></returns>
        public int UpdateUserSkin(string skin)
        {
            CommonDao commonDao = new CommonDao();
            return commonDao.UpdateUserSkin(UserSession.UserCode, skin);
        }

        /// <summary>
        /// Select user's skin
        /// </summary>
        /// <param name="skin"></param>
        /// <returns></returns>
        public int SelectUserSkinData(out string skin)
        {
            CommonDao commonDao = new CommonDao();
            return commonDao.SelectUserSkinData(UserSession.UserCode, out skin);
        }

        /// <summary>
        /// Check Operation is existing in Function or not
        /// </summary>
        /// <param name="functionId">
        /// ID of Function
        /// </param>
        /// <param name="operId">
        /// ID of Operation
        /// </param>
        /// <returns>
        /// Ture: is existing
        /// others: not existing
        /// </returns>
        public CommonData.IsAuthority CheckAuthority(string functionId, string operId)
        {
            try
            {
                #region Variables

                //This DataRow using to check the same GroupCode between 2 table
                DataRow[] drResult;
                //This DataTable contain data select from table ms_groupassign
                DataTable dtUserGroupForUser = new DataTable();
                //This DataTable contain data select from table ms_permissionassign
                DataTable dtUserGroupForFunction = new DataTable();
                //This DataTable contain data select from table sy_functionmapping
                DataTable dtFunctionMapping = new DataTable();
                //This Hashtable contain condition to select data from table ms_groupassign
                //Hashtable htGroupAssign = new Hashtable();
                //This Hashtable contain condition to select data from table sy_functionmapping
                //Hashtable htFunctionMapping = new Hashtable();
                //This Hashtable contain condition to select data from table ms_permissionassign
                //Hashtable htPermissionAssign = new Hashtable();
                //Object of GroupAssignDao
                SYS_GroupsAssignDao groupAssignDao = new SYS_GroupsAssignDao();
                //Object of FunctionMappingDao
                SYS_FunctionMappingDao functionMappingDao = new SYS_FunctionMappingDao();
                //Object of PermissionAssignDao
                SYS_PermissionAssignDao permissionAssignDao = new SYS_PermissionAssignDao();

                #endregion Variables

                //htGroupAssign.Add(CommonKey.UserCode, UserSession.UserCode);
                //htFunctionMapping.Add(CommonKey.FunctionId, functionId);
                //htFunctionMapping.Add(CommonKey.OperId, operId);

                //Select data from ms_groupassign
                groupAssignDao.SelectGroupByUserId(UserSession.UserCode, out dtUserGroupForUser);
                //Select data from sy_functionmapping
                functionMappingDao.SelectMappingInfo(functionId, operId, out dtFunctionMapping);
                if (dtFunctionMapping.Rows.Count > 0)
                {
                    //htPermissionAssign.Add(CommonKey.MappingId, dtFunctionMapping.Rows[0][CommonKey.Id].ToString());
                    //Select data from ms_permissionassign
                    permissionAssignDao.SelectGroupByMapping(CommonMethod.ParseInt(dtFunctionMapping.Rows[0][CommonKey.Id].ToString()), out dtUserGroupForFunction);

                    //Check 2 datatable have the same GroupCode or not
                    foreach (DataRow row in dtUserGroupForUser.Rows)
                    {
                        if (dtUserGroupForFunction.Rows.Count != 0)
                        {
                            drResult = dtUserGroupForFunction.Select(CommonKey.GroupCode + " = '" + row[CommonKey.GroupCode].ParseStrQuery() + "'");

                            if (drResult.Length > 0)
                            {
                                return CommonData.IsAuthority.Allow;
                            }
                        }
                    }
                }
                return CommonData.IsAuthority.Deny;
            }
            catch (Exception ex)
            {
                return CommonData.IsAuthority.Deny;
            }
        }

        //public int SelectWarehouseByUser(string userCode, out DataTable dtResult)
        //{
        //    CommonDao commonDao = new CommonDao();
        //    return commonDao.SelectWarehouseByUser(userCode, out dtResult);
        //    //#region Variables
        //    //List<MS_WarehouseDTO> lstWH = new List<MS_WarehouseDTO>();
        //    //dtResult = new DataTable();
        //    ////This DataRow using to check the same GroupCode between 2 table
        //    //DataRow[] drResult = null;
        //    ////This DataTable contain data select from table ms_groupassign
        //    //DataTable dtUserGroupForUser = new DataTable();
        //    ////Object of GroupAssignDao
        //    //SYS_GroupsAssignDao groupAssignDao = new SYS_GroupsAssignDao();
        //    //MS_WarehouseAssignDao whAssignDao = new MS_WarehouseAssignDao();
        //    //DataTable dtUserGroupForWarehouse = new DataTable();

        //    //#endregion Variables

        //    ////Select data from ms_groupassign
        //    //int returnCode = groupAssignDao.SelectGroupByUserId(userCode, out dtUserGroupForUser);
        //    //if (returnCode != 0)
        //    //{
        //    //    return returnCode;
        //    //}

        //    ////Select warehouse assign
        //    //MS_WarehouseAssignDto whAssignDto = new MS_WarehouseAssignDto();
        //    //returnCode = whAssignDao.SelectData(whAssignDto, out dtUserGroupForWarehouse);
        //    //if (returnCode != 0)
        //    //{
        //    //    return returnCode;
        //    //}

        //    //foreach (DataRow row in dtUserGroupForUser.Rows)
        //    //{
        //    //    //Get all warehouse assign to group
        //    //    drResult = dtUserGroupForWarehouse.Select(CommonKey.GroupCode + " = '" + row[CommonKey.GroupCode].ParseStrQuery() + "'");
        //    //    if (drResult.Length > 0)
        //    //    {
        //    //        foreach (DataRow drWHAssign in drResult)
        //    //        {
        //    //            //Create new warehouse
        //    //            MS_WarehouseDTO whDto = new MS_WarehouseDTO()
        //    //            {
        //    //                Code = CommonMethod.ParseString(drWHAssign[CommonKey.WarehouseCode]),
        //    //                Name1 = CommonMethod.ParseString(drWHAssign["WarehouseName1"]),
        //    //                Name2 = CommonMethod.ParseString(drWHAssign["WarehouseName2"]),
        //    //                Name3 = CommonMethod.ParseString(drWHAssign["WarehouseName3"]),
        //    //                DepartmentCode = CommonMethod.ParseString(drWHAssign["DepartmentCode"])
        //    //            };

        //    //            //Add to result list if not exist
        //    //            if (lstWH.Find(wh => wh.Code.Equals(whDto.Code)) == null)
        //    //            {
        //    //                lstWH.Add(whDto);
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //    //dtResult = CommonMethod.ToDataTable(lstWH);

        //    //return returnCode;
        //}

        //public CommonData.IsAuthority CheckAuthority(string functionId, string operId, string warehouseCode)
        //{
        //    try
        //    {
        //        #region Variables

        //        //This DataRow using to check the same GroupCode between 2 table
        //        DataRow[] drResult;
        //        //This DataTable contain data select from table ms_groupassign
        //        DataTable dtUserGroupForUser = new DataTable();
        //        //This DataTable contain data select from table ms_permissionassign
        //        DataTable dtUserGroupForFunction = new DataTable();
        //        //This DataTable contain data select from table sy_functionmapping
        //        DataTable dtFunctionMapping = new DataTable();
        //        //This Hashtable contain condition to select data from table ms_groupassign
        //        //Hashtable htGroupAssign = new Hashtable();
        //        //This Hashtable contain condition to select data from table sy_functionmapping
        //        //Hashtable htFunctionMapping = new Hashtable();
        //        //This Hashtable contain condition to select data from table ms_permissionassign
        //        //Hashtable htPermissionAssign = new Hashtable();
        //        //Object of GroupAssignDao
        //        SYS_GroupsAssignDao groupAssignDao = new SYS_GroupsAssignDao();
        //        //Object of FunctionMappingDao
        //        SYS_FunctionMappingDao functionMappingDao = new SYS_FunctionMappingDao();
        //        //Object of PermissionAssignDao
        //        SYS_PermissionAssignDao permissionAssignDao = new SYS_PermissionAssignDao();
        //        MS_WarehouseAssignDao whAssignDao = new MS_WarehouseAssignDao();
        //        DataTable dtUserGroupForWarehouse = new DataTable();
        //        #endregion Variables

        //        //htGroupAssign.Add(CommonKey.UserCode, UserSession.UserCode);
        //        //htFunctionMapping.Add(CommonKey.FunctionId, functionId);
        //        //htFunctionMapping.Add(CommonKey.OperId, operId);

        //        //Select data from ms_groupassign
        //        groupAssignDao.SelectGroupByUserId(UserSession.UserCode, out dtUserGroupForUser);
        //        //Select data from sy_functionmapping
        //        functionMappingDao.SelectMappingInfo(functionId, operId, out dtFunctionMapping);
        //        if (dtFunctionMapping.Rows.Count > 0)
        //        {
        //            //htPermissionAssign.Add(CommonKey.MappingId, dtFunctionMapping.Rows[0][CommonKey.Id].ToString());
        //            //Select data from ms_permissionassign
        //            permissionAssignDao.SelectGroupByMapping(CommonMethod.ParseInt(dtFunctionMapping.Rows[0][CommonKey.Id].ToString()), out dtUserGroupForFunction);

        //            //Check 2 datatable have the same GroupCode or not
        //            foreach (DataRow row in dtUserGroupForUser.Rows)
        //            {
        //                if (dtUserGroupForFunction.Rows.Count != 0)
        //                {
        //                    drResult = dtUserGroupForFunction.Select(CommonKey.GroupCode + " = '" + row[CommonKey.GroupCode].ParseStrQuery() + "'");

        //                    if (drResult.Length > 0)
        //                    {
        //                        //Check exist warehouse inside group
        //                        whAssignDao.SelectGroupByMapping(warehouseCode, out dtUserGroupForWarehouse);
        //                        if (dtUserGroupForWarehouse.Rows.Count != 0)
        //                        {
        //                            drResult = dtUserGroupForWarehouse.Select(CommonKey.GroupCode + " = '" + row[CommonKey.GroupCode].ParseStrQuery() + "'");

        //                            if (drResult.Length > 0)
        //                            {
        //                                return CommonData.IsAuthority.Allow;
        //                            }
        //                        }
        //                        //return CommonData.IsAuthority.Deny;
        //                    }
        //                }
        //            }
        //        }
        //        return CommonData.IsAuthority.Deny;
        //    }
        //    catch (Exception ex)
        //    {
        //        return CommonData.IsAuthority.Deny;
        //    }
        //}

        /// <summary>
        /// Check Operation is existing in Function or not for Warehouse
        /// </summary>
        /// <param name="functionId">
        /// ID of Function
        /// </param>
        /// <param name="operId">
        /// ID of Operation
        /// </param>
        /// <param name="warehouseCode">
        /// Warehouse's Code
        /// </param>
        /// <returns>
        /// Ture: is existing
        /// others: not existing
        /// </returns>
        //public CommonData.IsAuthority CheckWarehouseAuthority(string warehouseCode, string operId)
        //{
        //    try
        //    {
        //        #region Variables

        //        //This DataRow using to check the same GroupCode between 2 table
        //        DataRow[] drResult;
        //        //This DataTable contain data select from table ms_groupassign
        //        DataTable dtUserGroupForUser = new DataTable();
        //        //This DataTable contain data select from table ms_warehouseassign
        //        DataTable dtUserGroupForWarehouse = new DataTable();
        //        //This DataTable contain data select from table sy_warehousemapping
        //        //DataTable dtWarehouseMapping = new DataTable();
        //        //Object of GroupAssignDao
        //        SYS_GroupsAssignDao groupAssignDao = new SYS_GroupsAssignDao();
        //        //Object of FunctionMappingDao
        //        MS_WarehouseMappingDao whMappingDao = new MS_WarehouseMappingDao();
        //        //Object of PermissionAssignDao
        //        MS_WarehouseAssignDao whAssignDao = new MS_WarehouseAssignDao();

        //        #endregion Variables

        //        //Select data from ms_groupassign
        //        groupAssignDao.SelectGroupByUserId(UserSession.UserCode, out dtUserGroupForUser);
        //        //Select data from ms_warehouseasign
        //        whAssignDao.SelectGroupByMapping(warehouseCode, out dtUserGroupForWarehouse);
        //        //Check 2 datatable have the same GroupCode or not
        //        foreach (DataRow row in dtUserGroupForUser.Rows)
        //        {
        //            if (dtUserGroupForWarehouse.Rows.Count != 0)
        //            {
        //                drResult = dtUserGroupForWarehouse.Select(CommonKey.GroupCode + " = '" + row[CommonKey.GroupCode].ParseStrQuery() + "'");

        //                if (drResult.Length > 0)
        //                {
        //                    return CommonData.IsAuthority.Allow;
        //                }
        //            }
        //        }
        //        //}
        //        return CommonData.IsAuthority.Deny;
        //    }
        //    catch (Exception ex)
        //    {
        //        return CommonData.IsAuthority.Deny;
        //    }
        //}


        /// <summary>
        /// get All Functions of System
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_usergroups table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Error
        /// </returns>
        //public int SelectFunctions(out DataTable dtResult)
        //{
        //    SYS_FunctionDao functionsDao = new SYS_FunctionDao();
        //    return functionsDao.SelectData(new Ivs.DTO.Systems.SYS_FunctionsDto(), out dtResult);
        //}

        /// <summary>
        /// Get Company Infomation
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_companyinfo table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Error
        /// </returns>
        //public int SelectCommonData(Hashtable htCondition, out DataTable dtResult)
        //{
        //    SYS_CommonDao commonDao = new SYS_CommonDao();
        //    SYS_CommonDto commonDto = new SYS_CommonDto();
        //    commonDto.Code = CommonMethod.ParseString(htCondition[CommonKey.Code]);
        //    commonDto.LangId = UserSession.LangId == null ? CommonData.Language.English.ConvertCultureLanguageToDB() : UserSession.LangId.ConvertCultureLanguageToDB();
        //    //commonDto.LangId = UserSession.LangId == null ? CommonData.Language.English : UserSession.LangId;
        //    return commonDao.SelectCommonData(commonDto, out dtResult);
        //}

        /// <summary>
        /// Get Company Infomation
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_companyinfo table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Error
        /// </returns>
        //public int SelectCommonData(SYS_CommonDto commonDto, out DataTable dtResult)
        //{
        //    SYS_CommonDao commonDao = new SYS_CommonDao();
        //    commonDto.LangId = UserSession.LangId == null ? CommonData.Language.English.ConvertCultureLanguageToDB() : UserSession.LangId.ConvertCultureLanguageToDB();
        //    //commonDto.LangId = UserSession.LangId == null ? CommonData.Language.English : UserSession.LangId;
        //    return commonDao.SelectCommonData(commonDto, out dtResult);
        //}

        /// <summary>
        /// Get data for combobox
        /// </summary>
        /// <param name="functionGroup">Function group code</param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns)
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Error
        /// </returns>
        public int SelectDataForControl<T>(string functionGroup, out List<T> lstResult, bool isActive = false)
        {
            int returnCode = 0;
            lstResult = new List<T>();
            switch (functionGroup)
            {
                #region Master

                //case CommonData.FunctionGr.MS_Customers:
                //    MS_CustomerLookupDao custDao = new MS_CustomerLookupDao();
                //    returnCode = custDao.SelectData(out dtResult);
                //    break;

                //case CommonData.FunctionGr.MS_Departments:
                //    MS_DepartmentLookupDao deptDao = new MS_DepartmentLookupDao();
                //    returnCode = deptDao.SelectData(out dtResult);
                //    break;

                //case CommonData.FunctionGr.MS_Employees:
                //    MS_EmployeeLookupDao empDao = new MS_EmployeeLookupDao();
                //    returnCode = empDao.SelectData(out dtResult);
                //    break;

                //case CommonData.FunctionGr.MS_ErrorReasons:
                //    MS_ErrorReasonLookupDao errorReasonDao = new MS_ErrorReasonLookupDao();
                //    returnCode = errorReasonDao.SelectData(out dtResult);
                //    break;

                //case CommonData.FunctionGr.MS_Factories:
                //    MS_FactoryLookupDao factoryDao = new MS_FactoryLookupDao();
                //    returnCode = factoryDao.SelectData(out dtResult);
                //    break;

                //case CommonData.FunctionGr.MS_InventoryPeriods:
                //case CommonData.FunctionGr.ST_MonthlyProcess:
                //    ST_MonthlyProcessLookupDao monthlyProcessDao = new ST_MonthlyProcessLookupDao();
                //    returnCode = monthlyProcessDao.SelectData(out dtResult);
                //    break;
                //case CommonData.FunctionGr.ST_MonthlyProcess_PeriodClose:
                //    ST_MonthlyProcessLookupDao monthlyProcessDao_PeriodClose = new ST_MonthlyProcessLookupDao();
                //    returnCode = monthlyProcessDao_PeriodClose.SelectData_PeriodClose(out dtResult);
                //    break;

                case CommonData.FunctionGr.MS_ItemGroups:
                    MS_ItemGroupLookupDao itemGroupDao = new MS_ItemGroupLookupDao();
                    returnCode = itemGroupDao.SelectData(out lstResult);
                    break;

                //case CommonData.FunctionGr.MS_Items:
                //    MS_ItemLookupDao itemDao = new MS_ItemLookupDao();
                //    if (!isActive)
                //        returnCode = itemDao.SelectData(out dtResult);
                //    else
                //        returnCode = itemDao.SelectData(out dtResult, "", "");
                //    break;

                case CommonData.FunctionGr.MS_Units:
                    MS_UnitLookupDao unitDao = new MS_UnitLookupDao();
                    returnCode = unitDao.SelectData(out lstResult);
                    break;
                #endregion Master


                default:
                    break;
            }

            return returnCode;
        }

        public int SelectCommonData(string code, out List<IModel> lstResult)
        {
            CommonDao commonDao = new CommonDao();
            SYS_CommonModel commonDto = new SYS_CommonModel();
            commonDto.Code = CommonMethod.ParseString(code);
            commonDto.LangId = UserSession.LangId == null ? CommonData.Language.English.ConvertCultureLanguageToDB() : UserSession.LangId.ConvertCultureLanguageToDB();
            //commonDto.LangId = UserSession.LangId == null ? CommonData.Language.English : UserSession.LangId;
            return commonDao.SelectCommonData(commonDto, out lstResult);
        }

        /// <summary>
        /// Set authority for screen
        /// </summary>
        public CommonData.IsAuthority IsAuthority(string functionGr, string operId)
        {
            CommonData.IsAuthority returnCode = CommonData.IsAuthority.Allow;
            CommonBl commonBl = new CommonBl();
            returnCode = commonBl.CheckAuthority(functionGr, CommonData.OperId.All);
            if (returnCode == CommonData.IsAuthority.Deny)
            {
                returnCode = commonBl.CheckAuthority(functionGr, operId);
            }

            return returnCode;
        }

        public List<SYS_FunctionModel> GetGroupMenu()
        {
            //DataTable dtGroupMenu = new DataTable();
            //dtGroupMenu.Columns.Add(new DataColumn("ModuleCode"));
            //dtGroupMenu.Columns.Add(new DataColumn("ModuleName"));
            //dtGroupMenu.Columns.Add(new DataColumn("Controller"));
            //dtGroupMenu.Columns.Add(new DataColumn("Action"));
            //dtGroupMenu.Columns.Add(new DataColumn("DisplayName"));
            List<SYS_FunctionModel> lstResult = new List<SYS_FunctionModel>();
            if (this.IsAuthority(CommonData.FunctionGr.SY_Users, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "System", "System", "User Management", "User", "Index", "Users");
            }
            if (this.IsAuthority(CommonData.FunctionGr.SY_UserGroups, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "System", "System", "User Management", "UserGroup", "Index", "User Groups");
            }
            if (this.IsAuthority(CommonData.FunctionGr.MS_ItemGroups, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "Master", "Master", "Item Management", "ItemGroup", "Index", "Item Groups");
            }
            if (this.IsAuthority(CommonData.FunctionGr.MS_Items, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "Master", "Master", "Item Management", "Item", "Index", "Items");
            }
            if (this.IsAuthority(CommonData.FunctionGr.MS_Departments, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "Master", "Master", "Structure Management", "Department", "Index", "Departments");
            }
            if (this.IsAuthority(CommonData.FunctionGr.MS_ProductionLines, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "Master", "Master", "Structure Management", "ProductionLine", "Index", "Production Lines");
            }
            if (this.IsAuthority(CommonData.FunctionGr.MS_Warehouses, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
            {
                this.AddFunctionRow(ref lstResult, "Master", "Master", "Warehouse Management", "Warehouse", "Index", "Warehouses");
            }
            

            return lstResult;
        }

        //public DataTable GetGroupMenu()
        //{
        //    DataTable dtGroupMenu = new DataTable();
        //    dtGroupMenu.Columns.Add(new DataColumn("ModuleCode"));
        //    dtGroupMenu.Columns.Add(new DataColumn("ModuleName"));
        //    dtGroupMenu.Columns.Add(new DataColumn("Controller"));
        //    dtGroupMenu.Columns.Add(new DataColumn("Action"));
        //    dtGroupMenu.Columns.Add(new DataColumn("DisplayName"));
        //    if (this.IsAuthority(CommonData.FunctionGr.MS_Items, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
        //    {
        //        this.AddFunctionRow(ref dtGroupMenu, "Master", "Master", "Item", "Index", "Item Management");
        //    }
        //    if (this.IsAuthority(CommonData.FunctionGr.MS_Departments, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
        //    {
        //        this.AddFunctionRow(ref dtGroupMenu, "Master", "Master", "Department", "Index", "Department Management");
        //    }
        //    if (this.IsAuthority(CommonData.FunctionGr.MS_Warehouses, CommonData.OperId.View) == CommonData.IsAuthority.Allow)
        //    {
        //        this.AddFunctionRow(ref dtGroupMenu, "Warehouses", "Warehouses", "Warehouse", "Index", "Warehouse Management");
        //    }
        //    return dtGroupMenu;
        //}

        private void AddFunctionRow(ref List<SYS_FunctionModel> lstGroupMenu, string moduleCode, string moduleName, string groupName, string controller, string action, string displayName)
        {
            SYS_FunctionModel function = new SYS_FunctionModel
            {
                Action = action,
                Controller = controller,
                DisplayName = displayName,
                ModuleCode = moduleCode,
                ModuleName = moduleName,
                GroupName = groupName,
            };

            lstGroupMenu.Add(function);
        }

        //private void AddFunctionRow(ref DataTable dtGroupMenu, string moduleCode, string moduleName, string controller, string action, string displayName)
        //{
        //    DataRow row = dtGroupMenu.NewRow();
        //    row["ModuleCode"] = moduleCode;
        //    row["ModuleName"] = moduleName;
        //    row["Controller"] = controller;
        //    row["Action"] = action;
        //    row["DisplayName"] = displayName;
        //    dtGroupMenu.Rows.Add(row);
        //}

        
    }
}