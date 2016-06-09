using System;
using System.Collections.Generic;
using System.Data;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Systems;

namespace Ivs.BLL.Systems
{
    public class SYS_GroupListBL : IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        public int SearchData(IDto selectDto, out System.Data.DataTable dtResult)
        {
            //Do Something
            dtResult = null;
            return 0;
        }

        #region Search Function InGroup belond UserName

        public int SelectFunction(out DataTable dtResult)
        {
            SYS_GroupListDAO dao = new SYS_GroupListDAO();
            return dao.SelectFunction(out dtResult);
        }

        #endregion Search Function InGroup belond UserName

        public int InsertData(IDto insertDto)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(IDto updateDto)
        {
            throw new NotImplementedException();
        }

        public int DeleteData(List<IDto> listDeleteData)
        {
            //Do Something
            return 0;
        }
    }
}