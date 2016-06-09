using System;
using System.Collections.Generic;
using System.Data;
using Ivs.DAL.Dao.Systems;
using Ivs.DTO.Systems;
using System.Collections;
using Ivs.BLL.Common;
using Ivs.Core.Interface;
using Ivs.Core.Common;
using Ivs.DAL.Dao.Master;
using Ivs.DTO.Master;

namespace Ivs.BLL.Systems
{
    public class SYS_UserGroupsBl : Ivs.Core.Interface.IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        #region IBl Members

        /// <summary>
        /// Search Data in UserGroup table
        /// </summary>
        /// <param name="iDto">
        /// Dto of UserGroup form
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in UserGroup table
        /// </param>
        /// <returns>
        /// 0: Update successful
        /// 1: Access denied, login to database fail(invalid username, invalid password)
        /// 2: Invalid host, cannot find server(host) that set in app config file
        /// 3: Invalid database, cannot find database that set in DbConfig file
        /// 4: Lost connection, cannot connect to database because lost connection
        /// 5: Duplicate key: insert Primary Key or Unique Key that already exist in database
        /// 6: Forgeign key not exist: insert a foreign key that not exist in primary key
        /// 7: Foreign Key Violation: Foreign Key Violation (delete primary key that is foreign key in other table)
        /// 8: Data not found: Delete or Update data that not exist in database
        /// 9: Exception occured: other exception
        /// </returns>
        public int SearchData(IDto searchDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            SYS_UserGroupsDao mSUG00Dao = new SYS_UserGroupsDao();
            SYS_UserGroupsDto dto = (SYS_UserGroupsDto)searchDto;

            //Select group
            returnCode = mSUG00Dao.SelectData(dto, out dtResult);

            //Select user
            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add(CommonKey.UserCode, typeof(string));
            dtDetail.Columns.Add(CommonKey.DisplayName, typeof(string));
            dtDetail.Columns.Add(CommonKey.Status, typeof(string));
            dtDetail.Columns.Add(CommonKey.GroupCode, typeof(string));

            DataTable dtDetailTerm = new DataTable();
            foreach (DataRow row in dtResult.Rows)
            {
                SYS_UserGroupsDto groupDto = new SYS_UserGroupsDto()
                {
                    Code = CommonMethod.ParseString(row[CommonKey.Code]),
                };
                returnCode = this.SelectUsersByGroup(groupDto, out dtDetailTerm);
                if (returnCode != 0)
                {
                    return returnCode;
                }
                foreach (DataRow detailRow in dtDetailTerm.Rows)
                {
                    dtDetail.Rows.Add(detailRow[CommonKey.UserCode]
                                    , detailRow[CommonKey.DisplayName]
                                    , detailRow[CommonKey.Status]
                                    , detailRow[CommonKey.GroupCode]
                                    );
                }
            }

            #region Create relationship

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(dtResult);
            dataSet.Tables.Add(dtDetail);
            dataSet.Relations.Add(" ", dataSet.Tables[0].Columns[CommonKey.Code],
                                       dataSet.Tables[1].Columns[CommonKey.GroupCode]);

            #endregion

            return returnCode;
        }

        /// <summary>
        /// Insert UserGroup data to Database
        /// </summary>
        /// <param name="insertDto">
        /// object that contains data to insert
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertData(IDto insertDto)
        {
            SYS_UserGroupsDao userGroupDao = new SYS_UserGroupsDao();
            SYS_UserGroupsDto dto = (SYS_UserGroupsDto)insertDto;

            return userGroupDao.InsertData(dto);
        }

        /// <summary>
        /// Insert Permission for UserGroup
        /// </summary>
        /// <param name="insertDto">
        /// object that contains data to insert
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertPermisionData(IDto insertDto)
        {
            SYS_UserGroupsDao userGroupDao = new SYS_UserGroupsDao();
            SYS_UserGroupsDto dto = (SYS_UserGroupsDto)insertDto;

            return userGroupDao.InsertPermissionData(dto);
        }

        /// <summary>
        /// Update UserGroup data to Database
        /// </summary>
        /// <param name="updateDto">
        /// object that contains data to update
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int UpdateData(IDto updateDto)
        {
            SYS_UserGroupsDao userGroupDao = new SYS_UserGroupsDao();
            SYS_UserGroupsDto dto = (SYS_UserGroupsDto)updateDto;

            return userGroupDao.UpdateData(dto);
        }

        /// <summary>
        /// Delete ItemGroup data from Database
        /// </summary>
        /// <param name="ListDto">
        /// list object that contains data to delete
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DeleteData(List<IDto> listDto)
        {
            SYS_UserGroupsDao userGroupDao = new SYS_UserGroupsDao();
            List<int> listDeleteData = new List<int>();
            foreach (SYS_UserGroupsDto dto in listDto)
            {
                listDeleteData.Add(dto.Id);
            }
            return userGroupDao.DeleteData(listDeleteData);
        }

        #endregion IBl Members

        #region GetAllUserGroups

        public IEnumerable<SYS_UserGroupDTO> GetAllUserGroups()
        {
            return new SYS_UserGroupsDao().GetAllUserGroups();
        }

        #endregion GetAllUserGroups

        public int SelectUsersByGroup(IDto selectDto, out DataTable dtUsers)
        {
            SYS_GroupsAssignDao groupAssignDao = new SYS_GroupsAssignDao();
            SYS_UserGroupsDto userGroupsDto = (SYS_UserGroupsDto)selectDto;
            return groupAssignDao.SelectDataByGroup(userGroupsDto, out dtUsers);
        }

        public object SelectFunctionsByGroup(IDto selectDto)
        {
            #region Format outputed Datatable
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("FunctionID");
            dtResult.Columns.Add("FunctionName");

            dtResult.Columns.Add("AllMapping", typeof(string));
            dtResult.Columns.Add("AllID", typeof(string));
            dtResult.Columns.Add("AllName", typeof(string));
            dtResult.Columns.Add("All", typeof(bool));

            dtResult.Columns.Add("ViewMapping", typeof(string));
            dtResult.Columns.Add("ViewID", typeof(string));
            dtResult.Columns.Add("ViewName", typeof(string));
            dtResult.Columns.Add("View", typeof(bool));

            dtResult.Columns.Add("AddMapping", typeof(string));
            dtResult.Columns.Add("AddID", typeof(string));
            dtResult.Columns.Add("AddName", typeof(string));
            dtResult.Columns.Add("Add", typeof(bool));

            dtResult.Columns.Add("EditMapping", typeof(string));
            dtResult.Columns.Add("EditID", typeof(string));
            dtResult.Columns.Add("EditName", typeof(string));
            dtResult.Columns.Add("Edit", typeof(bool));

            dtResult.Columns.Add("DeleteMapping", typeof(string));
            dtResult.Columns.Add("DeleteID", typeof(string));
            dtResult.Columns.Add("DeleteName", typeof(string));
            dtResult.Columns.Add("Delete", typeof(bool));

            dtResult.Columns.Add("PrintMapping", typeof(string));
            dtResult.Columns.Add("PrintID", typeof(string));
            dtResult.Columns.Add("PrintName", typeof(string));
            dtResult.Columns.Add("Print", typeof(bool));

            dtResult.Columns.Add("ImportMapping", typeof(string));
            dtResult.Columns.Add("ImportID", typeof(string));
            dtResult.Columns.Add("ImportName", typeof(string));
            dtResult.Columns.Add("Import", typeof(bool));

            dtResult.Columns.Add("ExportMapping", typeof(string));
            dtResult.Columns.Add("ExportID", typeof(string));
            dtResult.Columns.Add("ExportName", typeof(string));
            dtResult.Columns.Add("Export", typeof(bool));

            dtResult.Columns.Add("Other", typeof(bool));
            dtResult.Columns.Add("OtherData", typeof(DataTable));

            #endregion

            //Get all data from sy_function table (FunctionID, FunctionName)
            DataTable dtFunctions = new DataTable();
            CommonBl commonBl = new CommonBl();
            commonBl.SelectFunctions(out dtFunctions);

            //GetHashCode data from ms_permissionsAssign table (GroupCode, MappingID)
            //whewe MSUG00UserGroupsDto.Code(selected GroupCode) = ms_permissionsAssign.GroupCode
            
            //Select permission assign data
            DataTable dtPermissionsAssign = new DataTable();
            SYS_PermissionAssignDao permissionsAssignDao = new SYS_PermissionAssignDao();
            SYS_UserGroupsDto dto = (SYS_UserGroupsDto)selectDto;
            permissionsAssignDao.SelectDataByGroupCode(dto.Code, out dtPermissionsAssign);

            //Select function mapping data
            DataTable dtFunctionsMapping = new DataTable();
            SYS_FunctionMappingDao functionMappingDao = new SYS_FunctionMappingDao();
            functionMappingDao.SelectMappingInfo(CommonData.StringEmpty, CommonData.StringEmpty, out dtFunctionsMapping);

            foreach (DataRow FunctionRow in dtFunctions.Rows)
            {
                DataTable otherData = new DataTable();
                otherData.Columns.Add("FunctionID");
                otherData.Columns.Add("MappingID");
                otherData.Columns.Add("OperID");
                otherData.Columns.Add("OperName");
                otherData.Columns.Add("IsPermission", typeof(bool));

                DataRow dr = dtResult.NewRow();
                dr["FunctionID"] = FunctionRow["FunctionID"];
                dr["FunctionName"] = FunctionRow["Name"];

                dr["All"] = false;
                dr["View"] = false;
                dr["Add"] = false;
                dr["Edit"] = false;
                dr["Delete"] = false;
                dr["Print"] = false;
                dr["Import"] = false;
                dr["Export"] = false;
                dr["Other"] = false;


                DataRow[] FunctionsMappingRows = dtFunctionsMapping.Select("FunctionID =" + "'" + FunctionRow["FunctionID"].ParseStrQuery() + "'");
                bool checkOtherColumn = false;
                foreach (DataRow FunctionsMappingRow in FunctionsMappingRows)
                {
                    switch (FunctionsMappingRow["OperCode"].ToString())
                    {
                        case CommonData.OperId.View:
                            dr["View"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["ViewMapping"] = FunctionsMappingRow["ID"];
                            dr["ViewID"] = FunctionsMappingRow["OperCode"];
                            dr["ViewName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.Add:
                            dr["Add"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["AddMapping"] = FunctionsMappingRow["ID"];
                            dr["AddID"] = FunctionsMappingRow["OperCode"];
                            dr["AddName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.Edit:
                            dr["Edit"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["EditMapping"] = FunctionsMappingRow["ID"];
                            dr["EditID"] = FunctionsMappingRow["OperCode"];
                            dr["EditName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.Delete:
                            dr["Delete"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["DeleteMapping"] = FunctionsMappingRow["ID"];
                            dr["DeleteID"] = FunctionsMappingRow["OperCode"];
                            dr["DeleteName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.Import:
                            dr["Import"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["ImportMapping"] = FunctionsMappingRow["ID"];
                            dr["ImportID"] = FunctionsMappingRow["OperCode"];
                            dr["ImportName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.Export:
                            dr["Export"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["ExportMapping"] = FunctionsMappingRow["ID"];
                            dr["ExportID"] = FunctionsMappingRow["OperCode"];
                            dr["ExportName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.Print:
                            dr["Print"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["PrintMapping"] = FunctionsMappingRow["ID"];
                            dr["PrintID"] = FunctionsMappingRow["OperCode"];
                            dr["PrintName"] = FunctionsMappingRow["OperName"];
                            break;

                        case CommonData.OperId.All:
                            dr["All"] = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            dr["AllMapping"] = FunctionsMappingRow["ID"];
                            dr["AllID"] = FunctionsMappingRow["OperCode"];
                            dr["AllName"] = FunctionsMappingRow["OperName"];
                            break;

                        default:
                            DataRow othRow = otherData.NewRow();
                            othRow["FunctionID"] = FunctionsMappingRow["FunctionId"];
                            othRow["MappingID"] = FunctionsMappingRow["ID"];
                            othRow["OperID"] = FunctionsMappingRow["OperCode"];
                            othRow["OperName"] = FunctionsMappingRow["OperName"];
                            bool OthPermission = false;
                            OthPermission = IsPermission(FunctionRow["FunctionID"].ToString(), FunctionsMappingRow["OperCode"].ToString(), dtPermissionsAssign);
                            othRow["IsPermission"] = OthPermission;
                            if (OthPermission == true)
                            {
                                checkOtherColumn = true;
                            }
                            otherData.Rows.Add(othRow);
                            break;
                    }
                }
                dr["OtherData"] = otherData;
                dr["Other"] = checkOtherColumn;
                dtResult.Rows.Add(dr);
            }
            return dtResult;
        }

        public object SelectWarehousesByGroup(IDto selectDto)
        {
            #region Format outputed Datatable
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Code");
            dtResult.Columns.Add("Name");
            dtResult.Columns.Add("All", typeof(bool));

            #endregion

            //Get all data from sy_function table (FunctionID, FunctionName)
            DataTable dtWHs = new DataTable();
            CommonBl commonBl = new CommonBl();
            int returnCode = commonBl.SelectWarehouses(out dtWHs);

            //Select warehouse assign data
            DataTable dtWHsAssign = new DataTable();
            MS_WarehouseAssignDao warehouseAssignDao = new MS_WarehouseAssignDao();
            SYS_UserGroupsDto dto = (SYS_UserGroupsDto)selectDto;
            warehouseAssignDao.SelectDataByGroupCode(dto.Code, out dtWHsAssign);

            ////Select function mapping data
            //DataTable dtWHsMapping = new DataTable();
            //MS_WarehouseMappingDao whMappingDao = new MS_WarehouseMappingDao();
            //whMappingDao.SelectMappingInfo(CommonData.StringEmpty, CommonData.StringEmpty, out dtWHsMapping);

            ////Select permission assign data
            //DataTable dtPermissionsAssign = new DataTable();
            //SYS_PermissionAssignDao permissionsAssignDao = new SYS_PermissionAssignDao();
            //SYS_UserGroupsDto dto = (SYS_UserGroupsDto)selectDto;
            //permissionsAssignDao.SelectDataByGroupCode(dto.Code, out dtPermissionsAssign);

            //Select function mapping data
            //DataTable dtFunctionsMapping = new DataTable();
            //SYS_FunctionMappingDao functionMappingDao = new SYS_FunctionMappingDao();
            //functionMappingDao.SelectMappingInfo(CommonData.StringEmpty, CommonData.StringEmpty, out dtFunctionsMapping);

            foreach (DataRow whRow in dtWHs.Rows)
            {
                DataRow dr = dtResult.NewRow();
                dr["Code"] = whRow["Code"];
                dr["Name"] = whRow["Name"];
                dr["All"] = false;

                //Check assign warehouse on group
                DataRow[] whAssignRows = dtWHsAssign.Select("WarehouseCode = '" + whRow["Code"].ParseStrQuery() + "'");
                if (whAssignRows.Length > 0)
                {
                    dr["All"] = true;
                }

                dtResult.Rows.Add(dr);
            }
            return dtResult;
        }
        #region Warehouse old

        //public object SelectWarehousesByGroup(IDto selectDto)
        //{
        //    #region Format outputed Datatable
        //    DataTable dtResult = new DataTable();
        //    dtResult.Columns.Add("Code");
        //    dtResult.Columns.Add("Name");

        //    dtResult.Columns.Add("AllMapping", typeof(string));
        //    dtResult.Columns.Add("AllID", typeof(string));
        //    dtResult.Columns.Add("AllName", typeof(string));
        //    dtResult.Columns.Add("All", typeof(bool));

        //    //dtResult.Columns.Add("StockOverviewMapping", typeof(string));
        //    //dtResult.Columns.Add("StockOverviewID", typeof(string));
        //    //dtResult.Columns.Add("StockOverviewName", typeof(string));
        //    //dtResult.Columns.Add("StockOverview", typeof(bool));

        //    //dtResult.Columns.Add("StockShippingMapping", typeof(string));
        //    //dtResult.Columns.Add("StockShippingID", typeof(string));
        //    //dtResult.Columns.Add("StockShippingName", typeof(string));
        //    //dtResult.Columns.Add("StockShipping", typeof(bool));

        //    //dtResult.Columns.Add("StockArrivingMapping", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingID", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingName", typeof(string));
        //    //dtResult.Columns.Add("StockArriving", typeof(bool));

        //    //dtResult.Columns.Add("StockTransferMapping", typeof(string));
        //    //dtResult.Columns.Add("StockTransferID", typeof(string));
        //    //dtResult.Columns.Add("StockTransferName", typeof(string));
        //    //dtResult.Columns.Add("StockTransfer", typeof(bool));

        //    //dtResult.Columns.Add("StockShippingForDeliveryMapping", typeof(string));
        //    //dtResult.Columns.Add("StockShippingForDeliveryID", typeof(string));
        //    //dtResult.Columns.Add("StockShippingForDeliveryName", typeof(string));
        //    //dtResult.Columns.Add("StockShippingForDelivery", typeof(bool));

        //    //dtResult.Columns.Add("ReturnDeliveryToSupplierMapping", typeof(string));
        //    //dtResult.Columns.Add("ReturnDeliveryToSupplierID", typeof(string));
        //    //dtResult.Columns.Add("ReturnDeliveryToSupplierName", typeof(string));
        //    //dtResult.Columns.Add("ReturnDeliveryToSupplier", typeof(bool));

        //    //dtResult.Columns.Add("ScrappingFromNGMapping", typeof(string));
        //    //dtResult.Columns.Add("ScrappingFromNGID", typeof(string));
        //    //dtResult.Columns.Add("ScrappingFromNGName", typeof(string));
        //    //dtResult.Columns.Add("ScrappingFromNG", typeof(bool));

        //    //dtResult.Columns.Add("StockShippingAdjustmentMapping", typeof(string));
        //    //dtResult.Columns.Add("StockShippingAdjustmentID", typeof(string));
        //    //dtResult.Columns.Add("StockShippingAdjustmentName", typeof(string));
        //    //dtResult.Columns.Add("StockShippingAdjustment", typeof(bool));

        //    //dtResult.Columns.Add("StockArrivingForPurchaseOrderMapping", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingForPurchaseOrderID", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingForPurchaseOrderName", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingForPurchaseOrder", typeof(bool));

        //    //dtResult.Columns.Add("ReturnFromCustomerShippingMapping", typeof(string));
        //    //dtResult.Columns.Add("ReturnFromCustomerShippingID", typeof(string));
        //    //dtResult.Columns.Add("ReturnFromCustomerShippingName", typeof(string));
        //    //dtResult.Columns.Add("ReturnFromCustomerShipping", typeof(bool));

        //    //dtResult.Columns.Add("StockArrivingAdjustmentMapping", typeof(bool));
        //    //dtResult.Columns.Add("StockArrivingAdjustmentID", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingAdjustmentName", typeof(string));
        //    //dtResult.Columns.Add("StockArrivingAdjustment", typeof(bool));

        //    //dtResult.Columns.Add("ShippingFromStorageMapping", typeof(bool));
        //    //dtResult.Columns.Add("ShippingFromStorageID", typeof(string));
        //    //dtResult.Columns.Add("ShippingFromStorageName", typeof(string));
        //    //dtResult.Columns.Add("ShippingFromStorage", typeof(bool));

        //    //dtResult.Columns.Add("ArrivingInStorageMapping", typeof(bool));
        //    //dtResult.Columns.Add("ArrivingInStorageID", typeof(string));
        //    //dtResult.Columns.Add("ArrivingInStorageName", typeof(string));
        //    //dtResult.Columns.Add("ArrivingInStorage", typeof(bool));

        //    //dtResult.Columns.Add("NGRecycledMaterialsMapping", typeof(bool));
        //    //dtResult.Columns.Add("NGRecycledMaterialsID", typeof(string));
        //    //dtResult.Columns.Add("NGRecycledMaterialsName", typeof(string));
        //    //dtResult.Columns.Add("NGRecycledMaterials", typeof(bool));

        //    //dtResult.Columns.Add("TransferForProductionLineMapping", typeof(bool));
        //    //dtResult.Columns.Add("TransferForProductionLineID", typeof(string));
        //    //dtResult.Columns.Add("TransferForProductionLineName", typeof(string));
        //    //dtResult.Columns.Add("TransferForProductionLine", typeof(bool));

        //    //dtResult.Columns.Add("TransferPostingMapping", typeof(bool));
        //    //dtResult.Columns.Add("TransferPostingID", typeof(string));
        //    //dtResult.Columns.Add("TransferPostingName", typeof(string));
        //    //dtResult.Columns.Add("TransferPosting", typeof(bool));

        //    //dtResult.Columns.Add("InventoryInquiryMapping", typeof(bool));
        //    //dtResult.Columns.Add("InventoryInquiryID", typeof(string));
        //    //dtResult.Columns.Add("InventoryInquiryName", typeof(string));
        //    //dtResult.Columns.Add("InventoryInquiry", typeof(bool));

        //    //dtResult.Columns.Add("StockModifyMapping", typeof(bool));
        //    //dtResult.Columns.Add("StockModifyID", typeof(string));
        //    //dtResult.Columns.Add("StockModifyName", typeof(string));
        //    //dtResult.Columns.Add("StockModify", typeof(bool));

        //    //dtResult.Columns.Add("CountingAllStockMapping", typeof(bool));
        //    //dtResult.Columns.Add("CountingAllStockID", typeof(string));
        //    //dtResult.Columns.Add("CountingAllStockName", typeof(string));
        //    //dtResult.Columns.Add("CountingAllStock", typeof(bool));

        //    //dtResult.Columns.Add("ViewPriceMapping", typeof(bool));
        //    //dtResult.Columns.Add("ViewPriceID", typeof(string));
        //    //dtResult.Columns.Add("ViewPriceName", typeof(string));
        //    //dtResult.Columns.Add("ViewPrice", typeof(bool));

        //    //dtResult.Columns.Add("InputPriceMapping", typeof(bool));
        //    //dtResult.Columns.Add("InputPriceID", typeof(string));
        //    //dtResult.Columns.Add("InputPriceName", typeof(string));
        //    //dtResult.Columns.Add("InputPrice", typeof(bool));

        //    //dtResult.Columns.Add("ImportMapping", typeof(bool));
        //    //dtResult.Columns.Add("ImportID", typeof(string));
        //    //dtResult.Columns.Add("ImportName", typeof(string));
        //    //dtResult.Columns.Add("Import", typeof(bool));

        //    //dtResult.Columns.Add("ExportMapping", typeof(bool));
        //    //dtResult.Columns.Add("ExportID", typeof(string));
        //    //dtResult.Columns.Add("ExportName", typeof(string));
        //    //dtResult.Columns.Add("Export", typeof(bool));

        //    //dtResult.Columns.Add("PrintMapping", typeof(bool));
        //    //dtResult.Columns.Add("PrintID", typeof(string));
        //    //dtResult.Columns.Add("PrintName", typeof(string));
        //    //dtResult.Columns.Add("Print", typeof(bool));

        //    //dtResult.Columns.Add("CancelMapping", typeof(bool));
        //    //dtResult.Columns.Add("CancelID", typeof(string));
        //    //dtResult.Columns.Add("CancelName", typeof(string));
        //    //dtResult.Columns.Add("Cancel", typeof(bool));

        //    //dtResult.Columns.Add("CloseMapping", typeof(bool));
        //    //dtResult.Columns.Add("CloseID", typeof(string));
        //    //dtResult.Columns.Add("CloseName", typeof(string));
        //    //dtResult.Columns.Add("Close", typeof(bool));

        //    //dtResult.Columns.Add("OpenMapping", typeof(bool));
        //    //dtResult.Columns.Add("OpenID", typeof(string));
        //    //dtResult.Columns.Add("OpenName", typeof(string));
        //    //dtResult.Columns.Add("Open", typeof(bool));

        //    //dtResult.Columns.Add("OpenCloseMapping", typeof(bool));
        //    //dtResult.Columns.Add("OpenCloseID", typeof(string));
        //    //dtResult.Columns.Add("OpenCloseName", typeof(string));
        //    //dtResult.Columns.Add("OpenClose", typeof(bool));

        //    #endregion

        //    //Get all data from sy_function table (FunctionID, FunctionName)
        //    DataTable dtWHs = new DataTable();
        //    CommonBl commonBl = new CommonBl();
        //    int returnCode = commonBl.SelectWarehouses(out dtWHs);
        //    if (returnCode != 0)
        //    {
        //        return returnCode;
        //    }

        //    //Select warehouse assign data
        //    DataTable dtWHsAssign = new DataTable();
        //    MS_WarehouseAssignDao warehouseAssignDao = new MS_WarehouseAssignDao();
        //    SYS_UserGroupsDto dto = (SYS_UserGroupsDto)selectDto;
        //    warehouseAssignDao.SelectDataByGroupCode(dto.Code, out dtWHsAssign);

        //    ////Select function mapping data
        //    //DataTable dtWHsMapping = new DataTable();
        //    //MS_WarehouseMappingDao whMappingDao = new MS_WarehouseMappingDao();
        //    //whMappingDao.SelectMappingInfo(CommonData.StringEmpty, CommonData.StringEmpty, out dtWHsMapping);

        //    foreach (DataRow whRow in dtWHs.Rows)
        //    {
        //        DataRow dr = dtResult.NewRow();
        //        dr["Code"] = whRow["Code"];
        //        dr["Name"] = whRow["Name"];
        //        dr["All"] = false;
        //        //dr["All"] = false;
        //        //dr["StockOverview"] = false;
        //        //dr["StockShipping"] = false;
        //        //dr["StockArriving"] = false;
        //        //dr["StockTransfer"] = false;
        //        //dr["StockShippingForDelivery"] = false;
        //        //dr["ReturnDeliveryToSupplier"] = false;
        //        //dr["ScrappingFromNG"] = false;
        //        //dr["StockShippingAdjustment"] = false;
        //        //dr["StockArrivingForPurchaseOrder"] = false;
        //        //dr["ReturnFromCustomerShipping"] = false;
        //        //dr["StockArrivingAdjustment"] = false;
        //        //dr["ShippingFromStorage"] = false;
        //        //dr["ArrivingInStorage"] = false;
        //        //dr["TransferForProductionLine"] = false;
        //        //dr["NGRecycledMaterials"] = false;
        //        //dr["TransferPosting"] = false;
        //        //dr["InventoryInquiry"] = false;
        //        //dr["StockModify"] = false;
        //        //dr["CountingAllStock"] = false;
        //        //dr["ViewPrice"] = false;
        //        //dr["InputPrice"] = false;
        //        //dr["Import"] = false;
        //        //dr["Export"] = false;
        //        //dr["Print"] = false;
        //        //dr["Open"] = false;
        //        //dr["Close"] = false;
        //        //dr["OpenClose"] = false;
        //        //dr["Cancel"] = false;

        //        DataRow[] whAssignRows = dtWHsAssign.Select("WarehouseCode =" + "'" + whRow["Code"].ParseStrQuery() + "'");
        //        foreach (DataRow whAssignRow in whAssignRows)
        //        {
        //            switch (whAssignRow["OperId"].ToString())
        //            {
        //                case CommonData.OperId.StockOverview:
        //                    dr["StockOverview"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["StockOverviewMapping"] = whAssignRow["Id"];
        //                    dr["StockOverviewID"] = whAssignRow["OperId"];
        //                    dr["StockOverviewName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.StockShippingForDelivery:
        //                    dr["StockShippingForDelivery"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["StockShippingForDeliveryMapping"] = whAssignRow["Id"];
        //                    dr["StockShippingForDeliveryID"] = whAssignRow["OperId"];
        //                    dr["StockShippingForDeliveryName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.ReturnDeliveryToSupplier:
        //                    dr["ReturnDeliveryToSupplier"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ReturnDeliveryToSupplierMapping"] = whAssignRow["Id"];
        //                    dr["ReturnDeliveryToSupplierID"] = whAssignRow["OperId"];
        //                    dr["ReturnDeliveryToSupplierName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.ScrappingFromNG:
        //                    dr["ScrappingFromNG"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ScrappingFromNGMapping"] = whAssignRow["Id"];
        //                    dr["ScrappingFromNGID"] = whAssignRow["OperId"];
        //                    dr["ScrappingFromNGName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.StockShippingAdjustment:
        //                    dr["StockShippingAdjustment"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["StockShippingAdjustmentMapping"] = whAssignRow["Id"];
        //                    dr["StockShippingAdjustmentID"] = whAssignRow["OperId"];
        //                    dr["StockShippingAdjustmentName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.StockArrivingForPurchaseOrder:
        //                    dr["StockArrivingForPurchaseOrder"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["StockArrivingForPurchaseOrderMapping"] = whAssignRow["Id"];
        //                    dr["StockArrivingForPurchaseOrderID"] = whAssignRow["OperId"];
        //                    dr["StockArrivingForPurchaseOrderName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.ReturnFromCustomerShipping:
        //                    dr["ReturnFromCustomerShipping"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ReturnFromCustomerShippingMapping"] = whAssignRow["Id"];
        //                    dr["ReturnFromCustomerShippingID"] = whAssignRow["OperId"];
        //                    dr["ReturnFromCustomerShippingName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.StockArrivingAdjustment:
        //                    dr["StockArrivingAdjustment"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["StockArrivingAdjustmentMapping"] = whAssignRow["Id"];
        //                    dr["StockArrivingAdjustmentID"] = whAssignRow["OperId"];
        //                    dr["StockArrivingAdjustmentName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.ShippingFromStorage:
        //                    dr["ShippingFromStorage"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ShippingFromStorageMapping"] = whAssignRow["Id"];
        //                    dr["ShippingFromStorageID"] = whAssignRow["OperId"];
        //                    dr["ShippingFromStorageName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.ArrivingInStorage:
        //                    dr["ArrivingInStorage"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ArrivingInStorageMapping"] = whAssignRow["Id"];
        //                    dr["ArrivingInStorageID"] = whAssignRow["OperId"];
        //                    dr["ArrivingInStorageName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.NGRecycledMaterials:
        //                    dr["NGRecycledMaterials"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["NGRecycledMaterialsMapping"] = whAssignRow["Id"];
        //                    dr["NGRecycledMaterialsID"] = whAssignRow["OperId"];
        //                    dr["NGRecycledMaterialsName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.TransferForProductionLine:
        //                    dr["TransferForProductionLine"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["TransferForProductionLineMapping"] = whAssignRow["Id"];
        //                    dr["TransferForProductionLineID"] = whAssignRow["OperId"];
        //                    dr["TransferForProductionLineName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.TransferPosting:
        //                    dr["TransferPosting"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["TransferPostingMapping"] = whAssignRow["Id"];
        //                    dr["TransferPostingID"] = whAssignRow["OperId"];
        //                    dr["TransferPostingName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.InventoryInquiry:
        //                    dr["InventoryInquiry"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["InventoryInquiryMapping"] = whAssignRow["Id"];
        //                    dr["InventoryInquiryID"] = whAssignRow["OperId"];
        //                    dr["InventoryInquiryName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.StockModify:
        //                    dr["StockModify"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["StockModifyMapping"] = whAssignRow["Id"];
        //                    dr["StockModifyID"] = whAssignRow["OperId"];
        //                    dr["StockModifyName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.CountingAllStock:
        //                    dr["CountingAllStock"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["CountingAllStockMapping"] = whAssignRow["Id"];
        //                    dr["CountingAllStockID"] = whAssignRow["OperId"];
        //                    dr["CountingAllStockName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.ViewPrice:
        //                    dr["ViewPrice"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ViewPriceMapping"] = whAssignRow["Id"];
        //                    dr["ViewPriceID"] = whAssignRow["OperId"];
        //                    dr["ViewPriceName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.InputPrice:
        //                    dr["InputPrice"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["InputPriceMapping"] = whAssignRow["Id"];
        //                    dr["InputPriceID"] = whAssignRow["OperId"];
        //                    dr["InputPriceName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.Import:
        //                    dr["Import"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ImportMapping"] = whAssignRow["Id"];
        //                    dr["ImportID"] = whAssignRow["OperId"];
        //                    dr["ImportName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.Export:
        //                    dr["Export"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["ExportMapping"] = whAssignRow["Id"];
        //                    dr["ExportID"] = whAssignRow["OperId"];
        //                    dr["ExportName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.Print:
        //                    dr["Print"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["PrintMapping"] = whAssignRow["Id"];
        //                    dr["PrintID"] = whAssignRow["OperId"];
        //                    dr["PrintName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.Cancel:
        //                    dr["Cancel"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["CancelMapping"] = whAssignRow["Id"];
        //                    dr["CancelID"] = whAssignRow["OperId"];
        //                    dr["CancelName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.Open:
        //                    dr["Open"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["OpenMapping"] = whAssignRow["Id"];
        //                    dr["OpenID"] = whAssignRow["OperId"];
        //                    dr["OpenName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.Close:
        //                    dr["Close"] = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["CloseMapping"] = whAssignRow["Id"];
        //                    dr["CloseID"] = whAssignRow["OperId"];
        //                    dr["CloseName"] = whAssignRow["OperName"];
        //                    break;

        //                case CommonData.OperId.All:
        //                    bool checkAll = this.IsWarehousePermission(whAssignRow["WarehouseCode"].ToString(), whAssignRow["OperId"].ToString(), dtWHsAssign);
        //                    dr["All"] = checkAll;
        //                    if (checkAll)
        //                    {
        //                        dr["StockOverview"] = true;
        //                        dr["StockShipping"] = true;
        //                        dr["StockArriving"] = true;
        //                        dr["StockTransfer"] = true;
        //                        dr["StockShippingForDelivery"] = true;
        //                        dr["ReturnDeliveryToSupplier"] = true;
        //                        dr["ScrappingFromNG"] = true;
        //                        dr["StockShippingAdjustment"] = true;
        //                        dr["StockArrivingForPurchaseOrder"] = true;
        //                        dr["ReturnFromCustomerShipping"] = true;
        //                        dr["StockArrivingAdjustment"] = true;
        //                        dr["ShippingFromStorage"] = true;
        //                        dr["ArrivingInStorage"] = true;
        //                        dr["NGRecycledMaterials"] = true;
        //                        dr["TransferForProductionLine"] = true;
        //                        dr["TransferPosting"] = true;
        //                        dr["InventoryInquiry"] = true;
        //                        dr["StockModify"] = true;
        //                        dr["CountingAllStock"] = true;
        //                        dr["ViewPrice"] = true;
        //                        dr["InputPrice"] = true;
        //                        dr["Import"] = true;
        //                        dr["Export"] = true;
        //                        dr["Print"] = true;
        //                        dr["Cancel"] = true;
        //                        dr["Open"] = true;
        //                        dr["Close"] = true;
        //                    }
        //                    dr["AllMapping"] = whAssignRow["Id"];
        //                    dr["AllID"] = whAssignRow["OperId"];
        //                    dr["AllName"] = whAssignRow["OperName"];
        //                    break;

        //                default:
                            
        //                    break;
        //            }


        //            //if ((bool)dr["StockShippingForDelivery"]
        //            //    && (bool)dr["ReturnDeliveryToSupplier"]
        //            //    && (bool)dr["ScrappingFromNG"]
        //            //    && (bool)dr["StockShippingAdjustment"]
        //            //    )
        //            //{
        //            //    dr["StockShipping"] = true;
        //            //}

        //            //if ((bool)dr["StockArrivingForPurchaseOrder"]
        //            //    && (bool)dr["ReturnFromCustomerShipping"]
        //            //    && (bool)dr["StockArrivingAdjustment"]
        //            //    )
        //            //{
        //            //    dr["StockArriving"] = true;
        //            //}

        //            //if ((bool)dr["ShippingFromStorage"]
        //            //    && (bool)dr["ArrivingInStorage"]
        //            //    && (bool)dr["NGRecycledMaterials"]
        //            //    && (bool)dr["TransferForProductionLine"]
        //            //    && (bool)dr["TransferPosting"]
        //            //    )
        //            //{
        //            //    dr["StockTransfer"] = true;
        //            //}

        //            //if ((bool)dr["Open"]
        //            //    || (bool)dr["Close"]
        //            //    )
        //            //{
        //            //    dr["OpenClose"] = true;
        //            //}
        //        }
        //        dtResult.Rows.Add(dr);
        //    }
        //    return dtResult;
        //}

        #endregion

        private bool IsPermission(string functionID, string operID, DataTable permission)
        {
            bool returnCode = false;
            DataRow[] dr1 = permission.Select("FunctionID = " + "'" + functionID.ParseStrQuery() + "' AND OperID = " + "'" + operID.ParseStrQuery() + "'");
            if (dr1.Length == 0)
            {
                DataRow[] dr2 = permission.Select("FunctionID = " + "'" + functionID.ParseStrQuery() + "' AND OperID = " + "'" + CommonData.OperId.All.ParseStrQuery() + "'");
                if (dr2.Length > 0)
                { returnCode = true; }
            }
            else { returnCode = true; }

            return returnCode;
        }

        private bool IsWarehousePermission(string warehouseCode, string operID, DataTable permission)
        {
            bool returnCode = false;
            DataRow[] dr1 = permission.Select("WarehouseCode = " + "'" + warehouseCode.ParseStrQuery() + "' AND OperID = " + "'" + operID.ParseStrQuery() + "'");
            if (dr1.Length == 0)
            {
                DataRow[] dr2 = permission.Select("WarehouseCode = " + "'" + warehouseCode.ParseStrQuery() + "' AND OperID = " + "'" + CommonData.OperId.All.ParseStrQuery() + "'");
                if (dr2.Length > 0)
                { returnCode = true; }
            }
            else { returnCode = true; }

            return returnCode;
        }
    }
}