using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.DAL.Dao.Master;
using Ivs.Models.Common;
using Ivs.Core.Interface;

namespace Ivs.DAL.Dao.Common
{
    public class CommonDao : BaseDao
    {
        /// <summary>
        /// Get system date
        /// </summary>
        /// <param name="systemDate"></param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int GetSystemDate(out DateTime systemDate)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    systemDate = context.GetDateTimeByEntityQuery();
                }
            }
            catch (Exception ex)
            {
                systemDate = DateTime.Now;
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Get system date
        /// </summary>
        /// <returns>
        /// systemDate: Search successful
        /// </returns>
        public static DateTime GetSystemDate()
        {
            DateTime systemDate = new DateTime();

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    systemDate = context.GetDateTimeByEntityQuery();
                }
            }
            catch (Exception ex)
            {
                systemDate = DateTime.Now;
            }

            return systemDate;
        }

        /// <summary>
        /// Update user's skin
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="skin"></param>
        /// <returns></returns>
        public int UpdateUserSkin(string userCode, string skin)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_users user = context.ms_users.FirstOrDefault(us => us.Code == userCode);
                    if (user != null)
                    {
                        user.UserSkin = skin;

                        //Save
                        context.Saves();
                    }
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }

        public int SelectUserSkinData(string userCode, out string skin)
        {
            //dtResult = new DataTable();
            int returnCode = CommonData.DbReturnCode.Succeed;
            skin = CommonData.StringEmpty;
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_users user = context.ms_users.FirstOrDefault(us => us.Code == userCode);
                    if (user != null)
                    {
                        skin = user.UserSkin;
                    }
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }
            return returnCode;
        }

        public int SelectCommonData(Models.Common.SYS_CommonModel selectDto, out List<IModel> lstResult)
        {
            lstResult = new List<IModel>();
            int returnCode = 0;
            using (BaseDao context = new BaseDao())
            {
                IQueryable<sy_commons> lstItemGroup = context.sy_commons.AsQueryable();

                #region Search Condition

                //Filter by Code
                if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                {
                    lstItemGroup = lstItemGroup.Where(ig => ig.Code.Equals(selectDto.Code));

                    if (!selectDto.Code.Equals(CommonData.Code.Language))
                    {
                        //Filter by Language
                        lstItemGroup = lstItemGroup.Where(ig => ig.LangID.Contains(selectDto.LangId));
                    }
                }

                //Filter by Key
                if (!CommonMethod.IsNullOrEmpty(selectDto.Key))
                {
                    lstItemGroup = lstItemGroup.Where(ig => ig.Key.Equals(selectDto.Key));
                }

                #endregion Search Condition

                #region Search data

                try
                {
                    lstResult = lstItemGroup.Select(ig => new SYS_CommonModel
                    {
                        Code = ig.Code,
                        Key = ig.Key,
                        LangId = ig.LangID,
                        Value = ig.Value,
                    })
                    .ToList()
                    .Cast<IModel>()
                    .ToList();
                }
                catch (Exception ex)
                {
                    returnCode = this.ProcessDbException(ex);
                }

                #endregion Search data
            }

            return returnCode;
        }
    }
}