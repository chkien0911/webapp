using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.DTO.Common;
using System.Data;
using Ivs.DAL.EFModels;
using Ivs.Core.Common;

namespace Ivs.DAL.Dao.Systems
{
    public class SYS_CommonDao : BaseDao
    {
        public int SelectCommonData(SYS_CommonDto selectDto, out DataTable dtResult)
        {
            dtResult = new DataTable();
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
                    IEnumerable<SYS_CommonDto> lstResult = lstItemGroup.Select(ig => new SYS_CommonDto
                    {
                        Code = ig.Code,
                        Key = ig.Key,
                        LangId = ig.LangID,
                        Value = ig.Value,
                    });
                    dtResult = base.ToDataTable(lstResult);
                }
                catch (Exception ex)
                {
                    returnCode = this.ProcessDbException(ex);
                }

                #endregion Search data
            }

            return returnCode;
        }

        public IQueryable<sy_commons> GetCommonsByCode(string code)
        {
            return new BaseDao().sy_commons.Where(c => c.Code == code).AsQueryable();
        }


        /// <summary>
        /// Select commondata with by keys
        /// </summary>
        /// <param name="selectDto"></param>
        /// <param name="dtResult"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public int SelectCommonData(SYS_CommonDto selectDto, out DataTable dtResult,string keys)
        {
            string[] arrayKey =null;
            if(!string.IsNullOrEmpty(keys))
                arrayKey=keys.Split(",".ToCharArray());
            dtResult = new DataTable();
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
                    IEnumerable<SYS_CommonDto> lstResult = lstItemGroup.ToList().Where(o => string.IsNullOrEmpty(keys) || arrayKey.Contains(o.Key)).Select(ig => new SYS_CommonDto
                    {
                        Code = ig.Code,
                        Key = ig.Key,
                        LangId = ig.LangID,
                        Value = ig.Value,
                    });
                    dtResult = base.ToDataTable(lstResult);
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
