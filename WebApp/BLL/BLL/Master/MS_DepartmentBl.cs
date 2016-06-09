using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Master;
using Ivs.Models.Master;

namespace Ivs.BLL.Master
{
    public class MS_DepartmentBl: IService
    {
        /// <summary>
        /// Search Data in MS_Department table
        /// </summary>
        /// <param name="IModel">
        /// Dto of Department form
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in Department table
        /// </param>
        /// <returns>
        /// 0: Update successful
        /// 1: Access denied, login to database fail(invalid username, invalid password)
        /// 2: Invalid host, cannot find server(host) that set in app config file
        /// 3: Invalid database, cannot find database that set in DbConfig file
        /// 4: Lost connection, cannot connect to database because lost connection
        /// 5: Duplicate key: insert Primary Key or Unique Key that already exist in database
        /// 6: Forgeign key not exist: insert a foreign key that not exist in primary key
        /// 7: Foreign Key Violation: Foreign Key Violation (delete primary key that is foreign key in other table)
        /// 8: Data not found: Delete or Update data that not exist in database
        /// 9: Exception occured: other exception
        /// </returns>
        public int SearchData(IModel searchDto, out List<IModel> lstResult)
        {
            MS_DepartmentDao dao = new MS_DepartmentDao();
            MS_DepartmentModel dto = (MS_DepartmentModel)searchDto;
            return dao.SelectData(dto, out lstResult);
        }

        public int SearchData(int id, out IModel modelResult)
        {
            MS_DepartmentDao dao = new MS_DepartmentDao();
            return dao.SelectData(id, out modelResult);
        }

        /// <summary>
        /// Update Department data to Database
        /// </summary>
        /// <param name="updateDto">
        /// object that contains data to update 
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int UpdateData(IModel updateDto)
        {
            MS_DepartmentDao dao = new MS_DepartmentDao();
            MS_DepartmentModel dto = (MS_DepartmentModel)updateDto;
            return dao.UpdateData(dto);
        }

        /// <summary>
        /// Insert Department data to Database
        /// </summary>
        /// <param name="insertDto">
        /// object that contains data to insert 
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertData(IModel insertDto)
        {
            MS_DepartmentDao dao = new MS_DepartmentDao();
            MS_DepartmentModel dto = (MS_DepartmentModel)insertDto;
            return dao.InsertData(dto);
        }

        /// <summary>
        /// Delete Department data from Database
        /// </summary>
        /// <param name="ListDto">
        /// list object that contains data to delete
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DeleteData(List<int> listDto)
        {
            MS_DepartmentDao dao = new MS_DepartmentDao();
            return dao.DeleteData(listDto);
        }
    }
}
