using System;
using System.Collections.Generic;
using System.Linq;
using Ivs.DAL.EFModels;
using Ivs.DTO.Systems;
using Ivs.Core.Common;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_FunctionPermissionsDao : BaseDao
    {
        #region Function Permission methods

        public IEnumerable<SYS_FunctionPermissionsDto> GetFunctionPermissionsByGroupCode(string groupCode)
        {
            List<SYS_FunctionPermissionsDto> listOfFunctionPermissions = new List<SYS_FunctionPermissionsDto>();
            List<sy_operas> listOfRight = this.GetListOfRights();

            //1. Get all functions for group
            using (BaseDao context = new BaseDao())
            {
                IQueryable<sy_functions> functions = context.sy_functions.AsQueryable();
                foreach (sy_functions item in functions)
                {
                    SYS_FunctionPermissionsDto newFunction = new SYS_FunctionPermissionsDto()
                    {
                        FunctionPermissionID = Guid.NewGuid(),
                        GroupCode = groupCode,
                        FunctionID = item.ID,
                        FunctionCode = item.FunctionID,
                        FunctionNameVN = item.Name1,
                        FunctionNameEL = item.Name2,
                        FunctionNameJP = item.Name3,
                    };
                    listOfFunctionPermissions.Add(newFunction);
                }
            }
            //--------------------------------------------------------------------------------
            //2. Assign Function's permission
            IQueryable<ms_permissionsassign> listofFunctionAssign = this.GetExsitingFunctionPermission(groupCode);
            foreach (ms_permissionsassign ms_permissionsassign in listofFunctionAssign)
            {
                sy_functionmapping sy_functionmapping = this.GetFunctionMapping(ms_permissionsassign.MappingID);
                if (sy_functionmapping != null)
                {
                    SYS_FunctionPermissionsDto sys_FunctionPermission = listOfFunctionPermissions.Where(c => c.FunctionCode == sy_functionmapping.FunctionID).FirstOrDefault();
                    if (sys_FunctionPermission != null)
                    {
                        sys_FunctionPermission.MappingID = ms_permissionsassign.MappingID;
                        sy_operas operate = listOfRight.Where(c => c.OperID == sy_functionmapping.OperID).FirstOrDefault();
                        if (operate != null)
                        {
                            sys_FunctionPermission.Add = (operate.Name2 == "Add");
                            sys_FunctionPermission.All = (operate.Name2 == "All");
                            sys_FunctionPermission.Close = (operate.Name2 == "Close");
                            sys_FunctionPermission.Delete = (operate.Name2 == "Delete");
                            sys_FunctionPermission.Edit = (operate.Name2 == "Edit");
                            sys_FunctionPermission.Export = (operate.Name2 == "Export");
                            sys_FunctionPermission.Import = (operate.Name2 == "Import");
                            sys_FunctionPermission.Lock = (operate.Name2 == "Lock");
                            sys_FunctionPermission.Open = (operate.Name2 == "Open");
                            sys_FunctionPermission.Print = (operate.Name2 == "Print");
                            sys_FunctionPermission.View = (operate.Name2 == "View");
                        }
                    }
                }
            }

            return listOfFunctionPermissions;
        }

        public void UpdateFunctionPermissions(SYS_FunctionPermissionsDto functionPermissionDto)
        {
            // 1 Insert/Delete ms_permissionassign
            bool isRight = false;
            int mappID;
            List<sy_operas> listOfRight = this.GetListOfRights();
            sy_operas rightChange = listOfRight.Where(c => c.Name2 == functionPermissionDto.PropertiesChange).FirstOrDefault();
            // Get mappID
            if (rightChange != null)
            {
                mappID = this.GetFunctionMappingID(functionPermissionDto.FunctionCode, rightChange.OperID);
                if (functionPermissionDto.PropertiesChange == "All")
                {
                    isRight = functionPermissionDto.All;
                }
                if (functionPermissionDto.PropertiesChange == "Add")
                {
                    isRight = functionPermissionDto.Add;
                }
                if (functionPermissionDto.PropertiesChange == "Close")
                {
                    isRight = functionPermissionDto.Close;
                }
                if (functionPermissionDto.PropertiesChange == "Delete")
                {
                    isRight = functionPermissionDto.Delete;
                }

                if (functionPermissionDto.PropertiesChange == "Edit")
                {
                    isRight = functionPermissionDto.Edit;
                }
                if (functionPermissionDto.PropertiesChange == "Export")
                {
                    isRight = functionPermissionDto.Export;
                }

                if (functionPermissionDto.PropertiesChange == "Import")
                {
                    isRight = functionPermissionDto.Import;
                }
                if (functionPermissionDto.PropertiesChange == "Lock")
                {
                    isRight = functionPermissionDto.Lock;
                }
                if (functionPermissionDto.PropertiesChange == "Open")
                {
                    isRight = functionPermissionDto.Open;
                }
                if (functionPermissionDto.PropertiesChange == "Print")
                {
                    isRight = functionPermissionDto.Print;
                }
                if (functionPermissionDto.PropertiesChange == "View")
                {
                    isRight = functionPermissionDto.View;
                }

                if (isRight)
                {
                    // Insert ms_permissionassign
                    this.InsertMs_Permissionsassign(new ms_permissionsassign() { MappingID = mappID, GroupCode = functionPermissionDto.GroupCode });
                }
                else
                {
                    // Delete ms_permissionassign
                    this.DeleteMs_Permissionsassign(new ms_permissionsassign() { MappingID = mappID, GroupCode = functionPermissionDto.GroupCode });
                }
            }
        }

        #endregion Function Permission methods

        #region Sys_ Function Mapping

        private sy_functionmapping GetFunctionMapping(int mappingID)
        {
            return new BaseDao().sy_functionmapping.Where(c => c.ID == mappingID).FirstOrDefault();
        }

        private IQueryable<ms_permissionsassign> GetExsitingFunctionPermission(string groupCode)
        {
            return new BaseDao().ms_permissionsassign.Where(c => c.GroupCode == groupCode).AsQueryable();
        }

        private int GetFunctionMappingID(string functionCode, string operasID)
        {
            BaseDao context = new BaseDao();
            sy_functionmapping functionMapping = context.sy_functionmapping.Where(c => c.OperID == operasID && c.FunctionID == functionCode).FirstOrDefault();
            if (functionMapping != null)
            {
                return functionMapping.ID;
            }
            return 0;
        }

        private int InsertSys_functionMapping(sy_functionmapping insertDto)
        {
            int mappID = 0;
            using (BaseDao context = new BaseDao())
            {
                sy_functionmapping newFunctionMapping = new sy_functionmapping()
                {
                    OperID = insertDto.OperID,
                    FunctionID = insertDto.FunctionID
                };
                context.sy_functionmapping.AddObject(newFunctionMapping);
                mappID = context.Saves();
            }
            return mappID;
        }

        private int DeleteSys_functionMapping(sy_functionmapping deleteSyS_functionmapping)
        {
            int mappID = 0;
            using (BaseDao context = new BaseDao())
            {
                sy_functionmapping deletesy_functionmapping = context.sy_functionmapping.FirstOrDefault(c => c.OperID == deleteSyS_functionmapping.OperID && c.FunctionID == deleteSyS_functionmapping.FunctionID);
                mappID = deleteSyS_functionmapping.ID;
                if (deletesy_functionmapping != null)
                {
                    context.sy_functionmapping.DeleteObject(deletesy_functionmapping);
                    mappID = context.Saves();
                }
            }
            return mappID;
        }

        #endregion Sys_ Function Mapping

        #region Function business logic

        private List<sy_operas> GetListOfRights()
        {
            return new BaseDao().sy_operas.ToList();
        }

        #endregion Function business logic

        #region Ms_Permission Assign

        private IEnumerable<ms_permissionsassign> IsGroupCodeRightAcsess(string groupCode, int mappingID)
        {
            BaseDao context = new BaseDao();

            return context.ms_permissionsassign.Where(c => c.GroupCode == groupCode).AsQueryable();
        }

        private int InsertMs_Permissionsassign(ms_permissionsassign insertDto)
        {
            int mappID = 0;
            using (BaseDao context = new BaseDao())
            {
                ms_permissionsassign newMs_permissionsassign = new ms_permissionsassign()
                {
                    MappingID = insertDto.MappingID,
                    GroupCode = insertDto.GroupCode,
                    SystemData = string.Empty
                };
                context.ms_permissionsassign.AddObject(newMs_permissionsassign);
                mappID = context.Saves();
            }
            return mappID;
        }

        private void DeleteMs_Permissionsassign(ms_permissionsassign deleteSyS_functionmapping)
        {
            using (BaseDao context = new BaseDao())
            {
                ms_permissionsassign deletesy_functionmapping = context.ms_permissionsassign.Where(c => c.GroupCode == deleteSyS_functionmapping.GroupCode && c.MappingID == deleteSyS_functionmapping.MappingID).FirstOrDefault();

                if (deletesy_functionmapping != null)
                {
                    context.ms_permissionsassign.DeleteObject(deletesy_functionmapping);
                    context.Saves();
                }
            }
        }

        #endregion Ms_Permission Assign

        
    }
}