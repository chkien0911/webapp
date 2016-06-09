using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.DTO.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_UserGroupsDao : Ivs.DAL.Dao.BaseDao
    {
        /// <summary>
        /// Search Data in ms_UserGroup table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), Type
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_UserGroup table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(SYS_UserGroupsDto selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_usergroups> lstGroup = context.ms_usergroups.AsQueryable();

                    #region Search Condition

                    //Filter by Code
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Code.Contains(selectDto.Code));
                    }

                    //Filter by Name(VN)
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Name1))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Name1.Contains(selectDto.Name1));
                    }

                    //Filter by Name(EN)
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Name2))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Name2.Contains(selectDto.Name2));
                    }

                    //Filter by Name(JP)
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Name3))
                    {
                        lstGroup = lstGroup.Where(ig => ig.Name3.Contains(selectDto.Name3));
                    }

                    #endregion Search Condition

                    #region Search data

                    IEnumerable<SYS_UserGroupsDto> lstResult = lstGroup.Select(ig => new SYS_UserGroupsDto
                    {
                        Id = ig.ID,
                        Code = ig.Code,
                        Name1 = ig.Name1,
                        Name2 = ig.Name2,
                        Name3 = ig.Name3,
                        Description = ig.Description,
                    });

                    dtResult = base.ToDataTable(lstResult);

                    #endregion Search data
                }
                catch (Exception ex)
                {
                    returnCode = this.ProcessDbException(ex);
                }
            }
            return returnCode;
        }

        public IEnumerable<SYS_UserGroupDTO> GetAllUserGroups()
        {
            return new BaseDao().ms_usergroups.Select(c => new SYS_UserGroupDTO
            {
                ID = c.ID,
                Code = c.Code,
                Name1 = c.Name1,
                Name2 = c.Name2,
                Name3 = c.Name3,
                Description = c.Description
            });
        }

        /// <summary>
        /// Insert new UserGroup
        /// </summary>
        /// <param name="insertDto">
        /// Dto that contains all UserGroup data
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertData(SYS_UserGroupsDto insertDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_usergroups userGroup = new ms_usergroups();
                    userGroup.Code = CommonMethod.ParseString(insertDto.Code);
                    userGroup.Name1 = CommonMethod.ParseString(insertDto.Name1);
                    userGroup.Name2 = CommonMethod.ParseString(insertDto.Name2);
                    userGroup.Name3 = CommonMethod.ParseString(insertDto.Name3);
                    userGroup.Description = insertDto.Description;
                    userGroup.SystemData = CommonData.Status.Disable;

                    //Create insert information
                    this.CreateInsertHistory(userGroup, CommonData.FunctionGr.SY_UserGroups);

                    //Add itemGroup
                    context.ms_usergroups.AddObject(userGroup);

                    //Save to database
                    //returnCode = context.Saves();
                    returnCode = context.Saves(CommonData.FunctionGr.SY_UserGroups, CommonData.Action.Insert,
                        new { userGroup.Code, userGroup.Name1, userGroup.Name2, userGroup.Name3, userGroup.Description, userGroup.SystemData },
                        typeof(ms_usergroups).Name);
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Update UserGroup
        /// </summary>
        /// <param name="updateDto">
        /// Dto that contains all UserGroup data
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int UpdateData(SYS_UserGroupsDto updateDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_usergroups userGroup = context.ms_usergroups.FirstOrDefault(ig => ig.ID.Equals(updateDto.Id));
                    if (userGroup != null)
                    {
                        userGroup.Name1 = updateDto.Name1;
                        userGroup.Name2 = updateDto.Name2;
                        userGroup.Name3 = updateDto.Name3;
                        userGroup.Description = updateDto.Description;
                        //userGroup.SystemData = CommonData.Status.Disable;

                        //Create Update information
                        this.CreateUpdateHistory(userGroup, CommonData.FunctionGr.SY_UserGroups);

                        //Save to database
                        //returnCode = context.Saves();
                        returnCode = context.Saves(CommonData.FunctionGr.SY_UserGroups, CommonData.Action.Update, new { userGroup.Code, userGroup.Name1, userGroup.Name2, userGroup.Name3, userGroup.Description }, typeof(ms_usergroups).Name);
                    }
                    else
                    {
                        returnCode = CommonData.DbReturnCode.DataNotFound;
                    }
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Delete UserGroup list
        /// </summary>
        /// <param name="listDeleteData">
        /// List that contains UserGroup id
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DeleteData(List<int> listDeleteData)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                List<object> lstHis = new List<object>();
                using (BaseDao context = new BaseDao())
                {
                    foreach (var id in listDeleteData)
                    {
                        ms_usergroups userGroup = context.ms_usergroups.FirstOrDefault(ig => ig.ID.Equals(id));
                        if (userGroup != null)
                        {
                            //Delete object
                            context.ms_usergroups.DeleteObject(userGroup);
                            lstHis.Add(new { userGroup.Code, userGroup.Name1, userGroup.Name2, userGroup.Name3, userGroup.Description });
                        }
                        else
                        {
                            return CommonData.DbReturnCode.DataNotFound;
                        }
                    }

                    //Save to database
                    //returnCode = context.Saves();
                    returnCode = context.Saves(CommonData.FunctionGr.SY_UserGroups, CommonData.Action.Delete, lstHis, typeof(ms_usergroups).Name);
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int InsertPermissionData(SYS_UserGroupsDto permissionDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            using (BaseDao context = new BaseDao())
            {
                try
                {
                    context.BeginTransaction();

                    ms_usergroups userGroup = context.ms_usergroups.FirstOrDefault(ig => ig.Code.Equals(permissionDto.GroupCode));
                    if (userGroup != null)
                    {
                        #region Assign function

                        #region Remove old permission

                        //Remove function assign
                        IQueryable<ms_permissionsassign> lstFunctionPermission = context.ms_permissionsassign.Where(p => p.GroupCode.Equals(userGroup.Code));
                        foreach (ms_permissionsassign permission in lstFunctionPermission)
                        {
                            //Delete from database
                            context.ms_permissionsassign.DeleteObject(permission);
                        }

                        #endregion Remove old permission

                        #region Insert new permission

                        //insert function assign
                        foreach (SYS_PermissionAssignDto mappingDto in permissionDto.Mappings)
                        {
                            ms_permissionsassign permissionsAssign = new ms_permissionsassign();
                            permissionsAssign.GroupCode = userGroup.Code;
                            permissionsAssign.MappingID = mappingDto.MappingId;
                            permissionsAssign.SystemData = CommonData.Status.Disable;
                            //Create insert infomation
                            this.CreateInsertHistory(permissionsAssign, CommonData.FunctionGr.SY_UserGroups);

                            //Add to database
                            context.ms_permissionsassign.AddObject(permissionsAssign);
                        }

                        #endregion Insert new permission

                        #endregion Assign function

                        #region Assign warehouse

                        #region Remove old warehouse

                        //Remove warehouse assign
                        IQueryable<ms_warehouseassign> lstWHPermission = context.ms_warehouseassign.Where(p => p.GroupCode.Equals(userGroup.Code));
                        foreach (ms_warehouseassign whAssign in lstWHPermission)
                        {
                            //Delete from database
                            context.ms_warehouseassign.DeleteObject(whAssign);
                        }

                        #endregion Remove old warehouse

                        #region Insert new warehouse

                        //insert warehouse assign
                        foreach (MS_WarehouseAssignDto mappingDto in permissionDto.WHMappings)
                        {
                            if (!CommonMethod.IsNullOrEmpty(mappingDto.WarehouseCode))
                            {
                                ms_warehouseassign whAssign = new ms_warehouseassign();
                                whAssign.GroupCode = userGroup.Code;
                                whAssign.WarehouseCode = mappingDto.WarehouseCode;
                                //whAssign.OperID = mappingDto.OperID;
                                //whAssign.SystemData = CommonData.Status.Disable;
                                //Create insert infomation
                                this.CreateInsertHistory(whAssign, CommonData.FunctionGr.SY_UserGroups);

                                //Add to database
                                context.ms_warehouseassign.AddObject(whAssign);
                            }
                        }

                        #endregion Insert new warehouse

                        #endregion Assign warehouse

                        returnCode = context.Saves();
                        if (returnCode == 0)
                        {
                            returnCode = context.Commit();
                        }
                        else
                        {
                            context.Rollback();
                        }
                    }
                    else
                    {
                        context.Rollback();
                        returnCode = CommonData.DbReturnCode.DataNotFound;
                    }
                }
                catch (Exception ex)
                {
                    context.Rollback();
                    returnCode = this.ProcessDbException(ex);
                }
            }

            return returnCode;
        }
    }
}