using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.DAL.EFModels;
using Ivs.Core.Common;
using System.Data;
using Ivs.DTO.Systems;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_UserStateDao : BaseDao
    {
        /// <summary>
        /// Search Data in ms_ItemGroup table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), Type
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_ItemGroup table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(SYS_UserStateDto selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_users> lstUsers = context.ms_users.AsQueryable();

                    #region Search Condition

                    //Filter by Code
                    if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                    {
                        lstUsers = lstUsers.Where(ig => ig.Code.Contains(selectDto.Code));
                    }

                    //Filter by IPAddress
                    if (!CommonMethod.IsNullOrEmpty(selectDto.IPAddress))
                    {
                        lstUsers = lstUsers.Where(ig => ig.IPAddress.Contains(selectDto.IPAddress));
                    }

                    //Filter by ComputerName
                    if (!CommonMethod.IsNullOrEmpty(selectDto.ComputerName))
                    {
                        lstUsers = lstUsers.Where(ig => ig.ComputerName.Contains(selectDto.ComputerName));
                    }

                    //Filter by UserState
                    if (!CommonMethod.IsNullOrEmpty(selectDto.LogonState))
                    {
                        lstUsers = lstUsers.Where(ig => ig.LogonState == selectDto.LogonState);
                        //if (selectDto.UserState == CommonData.UserState.Online)
                        //{
                        //    lstUsers = lstUsers.Where(ig => ig.IPAddress != CommonData.StringEmpty && ig.IPAddress != null);
                        //}
                        //else if (selectDto.UserState == CommonData.UserState.Offine)
                        //{
                        //    lstUsers = lstUsers.Where(ig => ig.IPAddress == CommonData.StringEmpty || ig.IPAddress == null);
                        //}
                    }

                    #endregion Search Condition

                    #region Search data

                    IEnumerable<SYS_UserStateDto> lstResult = lstUsers.Select(ig => new SYS_UserStateDto
                    {
                        ID = ig.ID,
                        Code = ig.Code,
                        DisplayName= ig.DisplayName,
                        IPAddress = ig.IPAddress,
                        ComputerName = ig.ComputerName,
                        LogonState = ig.LogonState,
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

        public int DisconnectData(List<int> listDisconnectData)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    foreach (var id in listDisconnectData)
                    {
                        ms_users user = context.ms_users.FirstOrDefault(ig => ig.ID.Equals(id));
                        if (user != null)
                        {
                            //Set null for IPAddress & ComputerName
                            user.IPAddress = CommonData.StringEmpty;
                            user.ComputerName = CommonData.StringEmpty;
                            user.LogonState = CommonData.LogonState.DisByAdmin;
                        }
                        else
                        {
                            return CommonData.DbReturnCode.DataNotFound;
                        }
                    }

                    //Save to database
                    returnCode = context.Saves();
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int SendMessage(string exeptUserCode, string message)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    IQueryable<ms_users> lstUsersOnline = context.ms_users.Where(us => us.LogonState == CommonData.LogonState.Online && us.Code != exeptUserCode);
                    foreach (var userOnline in lstUsersOnline)
                    {
                        userOnline.Message = message;
                    }

                    //Save to database
                    returnCode = context.Saves();
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        public int SelectOnlineUsersData(string exeptUserCode, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            using (BaseDao context = new BaseDao())
            {
                try
                {
                    IQueryable<ms_users> lstUsers = context.ms_users.AsQueryable();

                    #region Search Condition

                    //Filter by Code
                    if (!CommonMethod.IsNullOrEmpty(exeptUserCode))
                    {
                        lstUsers = lstUsers.Where(ig => ig.Code != exeptUserCode);
                    }

                    //Filter by UserState
                    lstUsers = lstUsers.Where(ig => ig.LogonState == CommonData.LogonState.Online);

                    #endregion Search Condition

                    #region Search data

                    IEnumerable<SYS_UserStateDto> lstResult = lstUsers.Select(ig => new SYS_UserStateDto
                    {
                        ID = ig.ID,
                        Code = ig.Code,
                        DisplayName = ig.DisplayName,
                        IPAddress = ig.IPAddress,
                        ComputerName = ig.ComputerName,
                        LogonState = ig.LogonState,
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
    }
}
