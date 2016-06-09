using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Ivs.Core.Interface
{
    public interface IController
    {
        ActionResult Index(int? page);

        ActionResult Index(int? page, string sortColumn, string sortOrder, IModel model);

        ActionResult Add();

        ActionResult Add(IModel model);

        ActionResult Copy(int id);

        ActionResult Copy(IModel model);

        ActionResult Edit(int id);

        ActionResult Edit(IModel model);

        ActionResult Detail(int id);

        ActionResult Delete(List<int> lstId);
    }
}
