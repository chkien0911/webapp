using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivs.Core.Interface;
using System.Data;
using Ivs.DAL.Dao.Systems;
using Ivs.DTO.Systems;

namespace Ivs.BLL.Systems
{
    public class SYS_UserStateBl : IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        #region IBl Members

        /// <summary>
        /// Search Data in UserState table
        /// </summary>
        /// <param name="iDto">
        /// Dto of UserState form
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in UserState table
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
        public int SearchData(IDto searchDto, out DataTable dtResult)
        {
            SYS_UserStateDao dao = new SYS_UserStateDao();
            SYS_UserStateDto dto = (SYS_UserStateDto)searchDto;
            return dao.SelectData(dto, out dtResult);
        }

        public int SearchOnlineUsersData(string exeptUserCode, out DataTable dtResult)
        {
            SYS_UserStateDao dao = new SYS_UserStateDao();
            return dao.SelectOnlineUsersData(exeptUserCode,out dtResult);
        }

        /// <summary>
        /// Insert UserState data to Database
        /// </summary>
        /// <param name="insertDto">
        /// object that contains data to insert
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertData(IDto insertDto)
        {
            return 0;
        }

        /// <summary>
        /// Update UserState data to Database
        /// </summary>
        /// <param name="updateDto">
        /// object that contains data to update
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int UpdateData(IDto updateDto)
        {
            return 0;
        }

        /// <summary>
        /// Delete UserState data from Database
        /// </summary>
        /// <param name="ListDto">
        /// list object that contains data to delete
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DeleteData(List<IDto> listDto)
        {
            return 0;
        }

        #endregion IBl Members

        /// <summary>
        /// Disconnect UserState data from Database
        /// </summary>
        /// <param name="ListDto">
        /// list object that contains data to delete
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DisconnectData(List<IDto> listDto)
        {
            SYS_UserStateDao dao = new SYS_UserStateDao();
            List<int> listDisconnectData = new List<int>();
            foreach (SYS_UserStateDto dto in listDto)
            {
                listDisconnectData.Add(dto.ID);
            }
            return dao.DisconnectData(listDisconnectData);
        }

        public int SendMessage(string exeptUserCode, string message)
        {
            SYS_UserStateDao dao = new SYS_UserStateDao();
            return dao.SendMessage(exeptUserCode, message);
        }
    }
}
