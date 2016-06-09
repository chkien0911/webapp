using System.Collections.Generic;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Common;
using Ivs.DTO.Common;

namespace Ivs.BLL.Common
{
    public class CurrencyBl : IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        public IEnumerable<CurrencyDto> GetCurrencies()
        {
            return new CurrencyDao().GetAllCurrencies();
        }

        public int SearchData(IDto selectDto, out System.Data.DataTable dtResult)
        {
            dtResult = new System.Data.DataTable();
            return 0;
        }

        public int InsertData(IDto insertDto)
        {
            return 0;
        }

        public int UpdateData(IDto updateDto)
        {
            return 0;
        }

        public int DeleteData(List<IDto> listDto)
        {
            return 0;
        }
    }
}