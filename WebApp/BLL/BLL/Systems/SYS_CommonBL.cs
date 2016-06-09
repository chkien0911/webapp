using System;
using System.Collections.Generic;
using System.Linq;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Systems;
using Ivs.DAL.EFModels;
using Ivs.DTO.Common;

namespace Ivs.BLL.Systems
{
    public class SYS_CommonBLL : IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        #region Properties

        private SYS_ChangePasswordDao dao = new SYS_ChangePasswordDao();

        #endregion Properties

        #region IBl Members

        public int SearchData(IDto selectDto, out System.Data.DataTable dtResult)
        {
            return dao.SearchData(selectDto, out dtResult);
        }

        public int InsertData(IDto insertDto)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(IDto updateDto)
        {
            return dao.UpdatePassword(updateDto);
        }

        public int DeleteData(List<IDto> deleteData)
        {
            throw new NotImplementedException();
        }

        #endregion IBl Members

        public IEnumerable<SYS_CommonDto> GetCommonData(string code)
        {
            IQueryable<sy_commons> query = new SYS_CommonDao().GetCommonsByCode(code);
            IEnumerable<SYS_CommonDto> lstResult = query.Select(ig => new SYS_CommonDto
            {
                Code = ig.Code,
                Key = ig.Key,
                LangId = ig.LangID,
                Value = ig.Value,
            });

            return lstResult;
        }
    }
}