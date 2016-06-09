using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Configuration;
using Ivs.Core.Web.Controllers;
using Ivs.BLL.Master;
using Ivs.Models.Master;
using Ivs.Core.Interface;
using Ivs.Core.Common;

namespace WebApp.Controllers.Master
{
    public class DepartmentController : BaseController, Ivs.Core.Interface.IController
    {
        #region Override properties

        protected override string FunctionGrp
        {
            get
            {
                return CommonData.FunctionGr.MS_Departments;
            }
        }
        protected override Ivs.Core.Interface.IService Bl
        {
            get
            {
                return new MS_DepartmentBl();
            }
        }

        private MS_DepartmentModel _model = new MS_DepartmentModel();
        protected override IModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = (MS_DepartmentModel)value;
            }
        }

        protected override string PartialViewName
        {
            get
            {
                string partialViewName = "DepartmentPartial";
                return partialViewName;
            }
        }

        #endregion

        #region Actions

        #region Index
        //
        // GET: /Department/
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(int? page)
        {
            return base.BaseIndex(page);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(int? page, string sortColumn, string sortOrder, IModel model)
        {
            return base.BaseIndex(page, sortColumn, sortOrder, model);
        }

        #endregion

        #region Add

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            return base.BaseAdd();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(IModel model)
        {
            return base.BaseAdd(model);
        }

        #endregion

        #region Copy

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Copy(int id)
        {
            return base.BaseCopy(id);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Copy(IModel model)
        {
            return base.BaseCopy(model);
        }

        #endregion

        #region Edit

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            return base.BaseEdit(id);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(IModel model)
        {
            return base.BaseEdit(model);
        }

        #endregion

        #region Detail

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Detail(int id)
        {
            return base.BaseDetail(id);
        }

        #endregion

        #region Delete

        [AcceptVerbs(HttpVerbs.Delete)]
        public ActionResult Delete(List<int> lstId)
        {
            return base.BaseDelete(lstId);
        }

        #endregion

        #endregion

        #region Override methods

        protected override void SetSearchControlData()
        {
            base.SetSearchControlData();
        }

        protected override void SetEditControlData()
        {
            base.SetEditControlData();

            #region Set model's data for View

            //MS_DepartmentModel model = (MS_DepartmentModel)this.Model;
            //switch (base.Mode)
            //{
            //    case CommonData.Mode.View:
            //        break;
            //    case CommonData.Mode.Edit:
            //        break;
            //    case CommonData.Mode.Copy:
            //        model.Code = CommonData.StringEmpty;
            //        break;
            //    case CommonData.Mode.New:
            //        break;
            //    default:
            //        break;
            //}

            #endregion

            #region Set datasource for dopdownlist if any
            //ViewBag.Source = ...
            #endregion
        }

        #endregion
    }
}
