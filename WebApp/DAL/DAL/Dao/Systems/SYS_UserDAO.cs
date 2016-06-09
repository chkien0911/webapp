using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DAL.EFModels;
using Ivs.DTO.Master;
using Ivs.DTO.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_UserDAO : Ivs.DAL.Dao.BaseDao
    {
        /// <summary>
        /// Search Data for Combobox in Employee table
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_users table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectDataForCombobox(out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    IQueryable<ms_employees> emp = context.ms_employees.AsQueryable();

                    #region Search data

                    IEnumerable<MS_EmployeeDto> lstResult = emp.Select(ig => new MS_EmployeeDto
                    {
                        Code = ig.Code,
                        Name = ig.Name,
                    });

                    dtResult = base.ToDataTable(lstResult);

                    #endregion Search data
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }

        #region Search

        public int SelectData(SYS_UserDetailDTO selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    //Search in ms_groupsassign table
                    IQueryable<ms_groupsassign> groupsassign = context.ms_groupsassign.AsQueryable();
                    //if (!CommonMethod.IsNullOrEmpty(selectDto.UserName))
                    //{
                    //    groupsassign = groupsassign.Where(ga => ga.UserCode.Contains(selectDto.UserName));
                    //}

                    //if (!CommonMethod.IsNullOrEmpty(selectDto.FullName))
                    //{
                    //    groupsassign = groupsassign.Where(ga => ga.GroupCode.Equals(selectDto.GroupCode));
                    //}

                    //Search in ms_users table
                    IQueryable<ms_users> user = context.ms_users.AsQueryable();
                    if (!CommonMethod.IsNullOrEmpty(selectDto.UserName))
                    {
                        user = user.Where(u => u.Code.Contains(selectDto.UserName) && u.DisplayName.Contains(selectDto.FullName));
                    }

                    //Search in ms_usergroups table
                    IQueryable<ms_usergroups> groupuser = context.ms_usergroups.AsQueryable();
                    if (!CommonMethod.IsNullOrEmpty(selectDto.GroupCode))
                    {
                        groupuser = groupuser.Where(ug => ug.Code.Equals(selectDto.GroupCode));
                    }

                    var query = user.Where(c => c.Code.Contains(selectDto.UserName) && c.DisplayName.Contains(selectDto.FullName));

                    //Join User, UserGroup, GroupAssign
                    var result = from u in query
                                 select new
                                 {
                                     ID = u.ID,
                                     UserName = u.Code,
                                     FullName = u.DisplayName,
                                     Password = u.Password,
                                     Status = u.Status,
                                     Profile = u.Profile,
                                     SystemData = u.SystemData
                                 };
                    dtResult = base.ToDataTable(result);
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }

        public int SelectGroupbyUser(string userCode, out IList<SYS_UserGroupDTO> GroupDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            GroupDto = new List<SYS_UserGroupDTO>();
            try
            {
                BaseDao context = new BaseDao();

                GroupDto = (from ga in ms_groupsassign.Where(ga => ga.UserCode.Equals(userCode))
                            join u in ms_users on ga.UserCode equals u.Code
                            join gu in ms_usergroups on ga.GroupCode equals gu.Code
                            select new SYS_UserGroupDTO
                            {
                                Code = ga.GroupCode,
                                Name1 = gu.Name1,
                                Name2 = gu.Name2,
                                Name3 = gu.Name3
                            }).ToList();
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        #endregion Search

        #region Insert

        public int InsertData(SYS_UserDetailDTO insertUserDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    context.BeginTransaction();

                    #region Insert data to User Table

                    //table user
                    ms_users _users = new ms_users();
                    _users.Code = insertUserDto.UserName;
                    _users.DisplayName = insertUserDto.FullName;
                    _users.Password = insertUserDto.Password;
                    _users.Profile = insertUserDto.Profile;
                    _users.Status = insertUserDto.Status;
                    _users.SystemData = "0";

                    //Add user
                    context.ms_users.AddObject(_users);
                    //Save to database
                    //returnCode = context.Saves();
                    returnCode = context.Saves(CommonData.FunctionGr.SY_Users, CommonData.Action.Insert,
                        new { _users.Code, _users.DisplayName, _users.Password, _users.Profile, _users.Status, _users.SystemData },
                        typeof(ms_users).Name);

                    if (returnCode != CommonData.DbReturnCode.Succeed)
                    {
                        context.Rollback();
                        return returnCode;
                    }

                    #endregion Insert data to User Table

                    #region Insert data to GroupAssign Table

                    ms_groupsassign _groupsassign = null;
                    foreach (var item in insertUserDto.UserGroups)
                    {
                        _groupsassign = new ms_groupsassign();
                        _groupsassign.UserCode = insertUserDto.UserName;
                        _groupsassign.GroupCode = item.Code;
                        _groupsassign.SystemData = "0";
                        context.ms_groupsassign.AddObject(_groupsassign);
                        returnCode = context.Saves();
                    }

                    if (returnCode != CommonData.DbReturnCode.Succeed)
                    {
                        context.Rollback();
                        return returnCode;
                    }

                    //Commit to database
                    if (returnCode == CommonData.DbReturnCode.Succeed)
                    {
                        context.Commit();
                    }

                    #endregion Insert data to GroupAssign Table
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        #endregion Insert

        #region Update

        public int UpdateData(SYS_UserDetailDTO _UserUpdateDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    context.BeginTransaction();

                    #region Update User

                    ms_users _users = context.ms_users.FirstOrDefault(u => u.ID.Equals(_UserUpdateDto.ID));
                    if (_users != null)
                    {
                        _users.ID = _UserUpdateDto.ID;
                        _users.Code = _UserUpdateDto.UserName;
                        _users.DisplayName = _UserUpdateDto.FullName;
                        _users.Status = _UserUpdateDto.Status;
                        _users.Password = _UserUpdateDto.Password;

                        //Save to database
                        //returnCode = context.Saves();
                        returnCode = context.Saves(CommonData.FunctionGr.SY_Users, CommonData.Action.Update,
                            new { _users.Code, _users.DisplayName, _users.Status },
                            typeof(ms_users).Name);

                        //Check if error occur
                        if (returnCode != CommonData.DbReturnCode.Succeed)
                        {
                            context.Rollback();
                            return returnCode;
                        }
                    }
                    else
                    {
                        returnCode = CommonData.DbReturnCode.DataNotFound;
                    }

                    #endregion Update User

                    #region Delete GroupAssign

                    var _groupsassign = context.ms_groupsassign.AsQueryable();
                    _groupsassign = _groupsassign.Where(ga => ga.UserCode.Equals(_UserUpdateDto.UserName));
                    foreach (var ga in _groupsassign)
                    {
                        context.DeleteObject(ga);
                    }

                    #endregion Delete GroupAssign

                    #region Insert data to GroupAssign Table

                    ms_groupsassign groupsassign = null;
                    foreach (var item in _UserUpdateDto.UserGroups)
                    {
                        groupsassign = new ms_groupsassign();
                        groupsassign.UserCode = _UserUpdateDto.UserName;
                        groupsassign.GroupCode = item.Code;
                        groupsassign.SystemData = "0";
                        context.ms_groupsassign.AddObject(groupsassign);
                        returnCode = context.Saves();
                    }

                    if (returnCode != CommonData.DbReturnCode.Succeed)
                    {
                        context.Rollback();
                        return returnCode;
                    }

                    //Commit to database
                    if (returnCode == CommonData.DbReturnCode.Succeed)
                    {
                        context.Commit();
                    }

                    #endregion Insert data to GroupAssign Table
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        #endregion Update

        #region Delete

        public int DeleteData(List<IDto> listDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    context.BeginTransaction();
                    foreach (SYS_UserDetailDTO _UserDeleteDto in listDto)
                    {
                        #region Delete GroupAssign

                        var _groupsassign = context.ms_groupsassign.AsQueryable();
                        _groupsassign = _groupsassign.Where(ga => ga.UserCode.Equals(_UserDeleteDto.UserName));
                        foreach (var ga in _groupsassign)
                        {
                            context.DeleteObject(ga);
                            context.Saves();
                        }

                        if (returnCode != CommonData.DbReturnCode.Succeed)
                        {
                            context.Rollback();
                            return returnCode;
                        }

                        #endregion Delete GroupAssign

                        #region Delete User

                        var _user = context.ms_users.FirstOrDefault(u => u.Code.Equals(_UserDeleteDto.UserName));
                        //_user = _user.Where(u => u.Code.Equals(_UserDeleteDto.UserName));
                        if (returnCode == CommonData.DbReturnCode.Succeed)
                        {
                            context.DeleteObject(_user);
                            //context.Saves();
                            returnCode = context.Saves(CommonData.FunctionGr.SY_Users, CommonData.Action.Delete,
                                new { _user.Code, _user.DisplayName },
                                typeof(ms_users).Name);
                        }
                        if (returnCode != CommonData.DbReturnCode.Succeed)
                        {
                            context.Rollback();
                            return returnCode;
                        }
                    }
                    //Commit to database
                    if (returnCode == CommonData.DbReturnCode.Succeed)
                    {
                        context.Commit();
                    }

                        #endregion Delete User
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        #endregion Delete

        /// <summary>
        /// Check exist Profile
        /// </summary>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_users table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public bool IsExistProfile(string code, string profile)
        {
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    if (this.ms_users.Any(us => us.Profile.Equals(profile)))
                    {
                        if (this.ms_users.Any(u => u.Code.Equals(code) && u.Profile.Equals(profile)))
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
            }
            return false;
        }

        public SYS_UserDetailDTO GetUserInfo(string userCode)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            SYS_UserDetailDTO userDto = new SYS_UserDetailDTO();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_users user = context.ms_users.Where(c => c.Code == userCode).FirstOrDefault();
                    if (user != null)
                    {
                        userDto.ID = user.ID;
                        userDto.FullName = user.DisplayName;
                        userDto.UserName = user.Code;
                        userDto.Status = user.Status;
                    }
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return userDto;
        }

        /// <summary>
        /// Get informations of user
        /// </summary>
        /// <param name="selectDto"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public int SelectUsersData(SYS_UserDetailDTO selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    IQueryable<ms_users> _users = context.ms_users.Where(u => u.Code == selectDto.UserName);

                    #region Search data

                    IEnumerable<SYS_UserDetailDTO> lstResult = _users.Select(ig => new SYS_UserDetailDTO
                    {
                        UserName = ig.Code,
                        DisplayName = ig.DisplayName,
                    });

                    dtResult = base.ToDataTable(lstResult);

                    #endregion Search data
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }
    }
}