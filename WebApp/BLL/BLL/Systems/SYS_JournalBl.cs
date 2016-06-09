using System;
using System.Collections.Generic;

/* =========================================
 * Author: DDKhanh
 * Create Date: 2012/10/12
 ========================================= */

using System.Data;
using Ivs.Core.Common;
using Ivs.Core.Interface;
using Ivs.DAL.Dao.Systems;
using Ivs.DTO.Systems;

namespace Ivs.BLL.Systems
{
    public class SYS_JournalBl : IBl
    {
        public int SearchData(IDto searchDto, out List<IDto> lstResult)
        {
            lstResult = new List<IDto>();
            return 0;
        }

        #region IBl Members

        public int DeleteData(List<IDto> deleteData)
        {
            throw new System.NotImplementedException();
        }

        public int InsertData(IDto insertDto)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Search Data in Sy_SystemJournals table
        /// </summary>
        /// <param name="selectDto">
        /// Dto of MSSJ00Form
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in Sy_SystemJournals table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Error
        /// </returns>
        public int SearchData(IDto selectDto, out System.Data.DataTable dtResult)
        {
            SYS_JournalDao mSSJ00Dao = new SYS_JournalDao();
            SYS_JournalDto dto = (SYS_JournalDto)selectDto;

            int returnCode = CommonData.DbReturnCode.Succeed;

            returnCode = mSSJ00Dao.SelectData(dto, out dtResult);
            if (returnCode != CommonData.DbReturnCode.Succeed)
            {
                return returnCode;
            }

            if (dtResult.Rows.Count > 0)
            {
                System.Data.DataTable dtTemp1 = new System.Data.DataTable();
                returnCode = this.SearchDataDetail(dtResult.Rows[0][SYS_JournalKey.ID].ToString(), dtResult.Rows[dtResult.Rows.Count - 1][SYS_JournalKey.ID].ToString(), out dtTemp1);
                if (returnCode != CommonData.DbReturnCode.Succeed)
                {
                    return returnCode;
                }

                System.Data.DataTable dtDetail = new System.Data.DataTable();
                dtDetail.Columns.Add("ID", typeof(long));
                dtDetail.Columns.Add("Name", typeof(string));
                dtDetail.Columns.Add("Value", typeof(string));

                System.Data.DataTable dtTemp2 = new System.Data.DataTable();

                foreach (System.Data.DataRow r in dtResult.Rows)
                {
                    dtTemp2 = this.SearchDataDetail(r[SYS_JournalKey.ID].ToString(), dtTemp1);
                    foreach (System.Data.DataRow rTemp in dtTemp2.Rows)
                    {
                        for (int i = 1; i <= 100; i++)
                        {
                            if (rTemp[SYS_JournalKey.FieldName + i].ToString() != CommonData.StringEmpty)
                            {
                                dtDetail.Rows.Add(rTemp[SYS_JournalKey.ParentID], rTemp[SYS_JournalKey.FieldName + i], rTemp[SYS_JournalKey.FieldValue + i]);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }

                System.Data.DataSet dataSet = new System.Data.DataSet();
                dataSet.Tables.Add(dtResult);
                dataSet.Tables.Add(dtDetail);
                dataSet.Relations.Add(" ", dataSet.Tables[0].Columns[SYS_JournalKey.ID],
                    dataSet.Tables[1].Columns[SYS_JournalKey.ID]);
            }
            return returnCode;
        }

        public int SearchDataDetail(string minID, string maxID, out System.Data.DataTable dtResult)
        {
            SYS_JournalDao dao = new SYS_JournalDao();
            return dao.SelectDataDetail(!CommonMethod.IsNullOrEmpty(minID) ? int.Parse(minID) : new Nullable<int>(),
                !CommonMethod.IsNullOrEmpty(maxID) ? int.Parse(maxID) : new Nullable<int>(), out dtResult);
        }

        private DataTable SearchDataDetail(string ID, DataTable dtDetails)
        {
            DataTable dtResult = dtDetails.Clone();
            DataRow[] rows = dtDetails.Select(SYS_JournalKey.ParentID + " = '" + ID.ParseStrQuery() + "'");
            if (rows.Length > 0)
            {
                foreach (DataRow row in rows)
                {
                    dtResult.ImportRow(row);
                }
            }
            return dtResult;
        }

        public int UpdateData(IDto updateDto)
        {
            throw new System.NotImplementedException();
        }

        #endregion IBl Members
    }
}