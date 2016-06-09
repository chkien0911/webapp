using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ivs.Core.Interface
{
    public interface IService
    {
        int SearchData(IModel searchDto, out List<IModel> lstResult);

        int SearchData(int id, out IModel modelResult);

        int UpdateData(IModel updateDto);

        int InsertData(IModel insertDto);

        int DeleteData(List<int> listDto);
    }
}
