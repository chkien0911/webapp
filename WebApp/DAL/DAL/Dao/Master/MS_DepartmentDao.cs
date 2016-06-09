using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Ivs.Core.Common;
using Ivs.DAL.EFModels;
using Ivs.Core.Interface;
using Ivs.Models.Master;

namespace Ivs.DAL.Dao.Master
{
    public class MS_DepartmentDao : BaseDao
    {
        /// <summary>
        /// Search Data in ms_item table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), GroupCode
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_item table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(MS_DepartmentModel selectDto, out DataTable dtResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            dtResult = new DataTable();
            try
            {
                IQueryable<ms_departments> query = this.ms_departments.AsQueryable();

                #region Search Condition

                //Filter by Department Code
                if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                {
                    query = query.Where(d => d.Code.Contains(selectDto.Code));
                }

                //Filter by Department Name
                if (!CommonMethod.IsNullOrEmpty(selectDto.Name1))
                {
                    query = query.Where(d => d.Name1.Contains(selectDto.Name1));
                }

                if (!CommonMethod.IsNullOrEmpty(selectDto.Name2))
                {
                    query = query.Where(d => d.Name2.Contains(selectDto.Name2));
                }

                #endregion

                #region Search data

                var queryResult = from d in query
                                  select new MS_DepartmentModel
                                  {
                                      ID = d.ID,
                                      Code = d.Code,
                                      Name1 = d.Name1,
                                      Name2 = d.Name2,
                                      Name3 = d.Name3,
                                      Remark = d.Remark,
                                  };

                dtResult = base.ToDataTable(queryResult);

                #endregion

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Search Data in ms_item table
        /// </summary>
        /// <param name="selectDto">
        /// Dto that contains conditions: Code, Name(VN), Name(EN), Name(JP), GroupCode
        /// </param>
        /// <param name="dtResult">
        /// Out a Datatable that contains search result(all columns) in ms_item table
        /// </param>
        /// <returns>
        /// 0: Search successful
        /// others: Sql Exception
        /// </returns>
        public int SelectData(MS_DepartmentModel selectDto, out List<IModel> lstResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            lstResult = new List<IModel>();
            try
            {
                IQueryable<ms_departments> query = this.ms_departments.AsQueryable();

                #region Search Condition

                //Filter by Department Code
                if (!CommonMethod.IsNullOrEmpty(selectDto.Code))
                {
                    query = query.Where(d => d.Code.Contains(selectDto.Code));
                }

                //Filter by Department Name
                if (!CommonMethod.IsNullOrEmpty(selectDto.Name1))
                {
                    query = query.Where(d => d.Name1.Contains(selectDto.Name1));
                }

                if (!CommonMethod.IsNullOrEmpty(selectDto.Name2))
                {
                    query = query.Where(d => d.Name2.Contains(selectDto.Name2));
                }

                #endregion

                #region Search data

                lstResult = query.Select(ss => new MS_DepartmentModel
                    {
                        ID = ss.ID,
                        Code = ss.Code,
                        Name1 = ss.Name1,
                        Name2 = ss.Name2,
                        Name3 = ss.Name3,
                        Remark = ss.Remark,
                    })
                    .ToList()
                    .Cast<IModel>()
                    .ToList();

                #endregion

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }


        public int SelectData(int id, out IModel modelResult)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            modelResult = null;
            try
            {
                modelResult = this.ms_departments
                    .Select(ss => new MS_DepartmentModel
                    {
                        ID = ss.ID,
                        Code = ss.Code,
                        Name1 = ss.Name1,
                        Name2 = ss.Name2,
                        Name3 = ss.Name3,
                        Remark = ss.Remark,
                    })
                    .FirstOrDefault(ss => ss.ID == id);

            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Insert new Department
        /// </summary>
        /// <param name="insertDto">
        /// Dto that contains all Department data
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int InsertData(MS_DepartmentModel insertDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                ms_departments _departments = new ms_departments();
                _departments.Code = insertDto.Code;
                _departments.Name1 = insertDto.Name1;
                _departments.Name2 = insertDto.Name2;
                _departments.Name3 = insertDto.Name3;
                _departments.Remark = insertDto.Remark;
                //_departments.Insert_PIC = !CommonMethod.IsNullOrEmpty(insertDto.Insert_PIC) ? insertDto.Insert_PIC : string.Empty;

                //Create insert information
                //this.CreateInsertHistory(_departments, CommonData.FunctionGr.MS_Departments);

                //Add Factory
                this.ms_departments.AddObject(_departments);

                //Save to database
                returnCode = this.Saves(CommonData.FunctionGr.MS_Departments, CommonData.Action.Insert,
                         new
                         {
                             _departments.Code,
                             _departments.Name1,
                             _departments.Name2,
                             _departments.Name3,
                             _departments.Remark,

                         },
                         typeof(ms_departments).Name);

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Update Department
        /// </summary>
        /// <param name="updateDto">
        /// Dto that contains all Department data
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int UpdateData(MS_DepartmentModel updateDto)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;

            try
            {
                using (BaseDao context = new BaseDao())
                {
                    ms_departments _departments = context.ms_departments.FirstOrDefault(d => d.ID.Equals(updateDto.ID));
                    if (_departments != null)
                    {
                        _departments.Code = updateDto.Code;
                        _departments.Name1 = updateDto.Name1;
                        _departments.Name2 = updateDto.Name2;
                        _departments.Name3 = updateDto.Name3;
                        _departments.Remark = updateDto.Remark;
                        //_departments.Insert_PIC = !CommonMethod.IsNullOrEmpty(updateDto.Insert_PIC) ? updateDto.Insert_PIC : string.Empty;
                        //_departments.Update_PIC = !CommonMethod.IsNullOrEmpty(updateDto.Update_PIC) ? updateDto.Update_PIC : string.Empty;

                        //Create insert information
                        this.CreateUpdateHistory(_departments, CommonData.FunctionGr.MS_Departments);

                        //Save to database
                        returnCode = context.Saves(CommonData.FunctionGr.MS_Departments, CommonData.Action.Update,
                        new
                        {
                            _departments.Code,
                            _departments.Name1,
                            _departments.Name2,
                            _departments.Name3,
                            _departments.Remark,

                        },
                        typeof(ms_departments).Name);
                    }
                    else
                    {
                        returnCode = CommonData.DbReturnCode.DataNotFound;
                    }

                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

        /// <summary>
        /// Delete Department list
        /// </summary>
        /// <param name="listDeleteData">
        /// List that contains Department ID
        /// </param>
        /// <returns>
        /// 0: insert successful
        /// others: Sql Exception
        /// </returns>
        public int DeleteData(List<int> listDeleteData)
        {
            int returnCode = CommonData.DbReturnCode.Succeed;
            List<object> lstHis = new List<object>();
            try
            {
                using (BaseDao context = new BaseDao())
                {
                    foreach (int id in listDeleteData)
                    {
                        ms_departments _departments = context.ms_departments.FirstOrDefault(d => d.ID.Equals(id));
                        if (_departments != null)
                        {
                            //Delete object
                            context.ms_departments.DeleteObject(_departments);
                            lstHis.Add(new
                            {
                                _departments.Code,
                                _departments.Name1,
                                _departments.Name2,
                                _departments.Name3,
                                _departments.Remark,
                            });
                        }
                        else
                        {
                            return CommonData.DbReturnCode.DataNotFound;
                        }
                    }

                    //returnCode = context.Saves();
                    returnCode = context.Saves(CommonData.FunctionGr.MS_Departments, CommonData.Action.Delete, lstHis, typeof(ms_departments).Name);
                }
            }
            catch (Exception ex)
            {
                returnCode = this.ProcessDbException(ex);
            }

            return returnCode;
        }

    }
}
