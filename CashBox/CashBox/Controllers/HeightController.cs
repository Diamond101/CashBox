using CashBox.Filters;
using CashBoxLogic;
using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashBox.Controllers
{
    [AuthorizedCashBoxUsers]
    public class HeightController : Controller
    {
        private readonly HeightLogic _heightLogic = new HeightLogic();
        public ActionResult Index()
        {
            var height = _heightLogic.GetHeight();
            return View(height);
        }

        [HttpPost]
        public JsonResult _LoadEdit(int id)
        {
            Height height = _heightLogic.FindHeightById(id);
            return Json(height, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Edit(Height height)   
        {
            _heightLogic.UpdateHeight(height);
            var heightList = _heightLogic.GetHeight();
            return PartialView("_list", heightList);
        }

        public PartialViewResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Create(Height height)
        {
            _heightLogic.AddHeight(height);
            var heightList = _heightLogic.GetHeight();
            return PartialView("_list", heightList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Delete(int id)
        {
            _heightLogic.DeleteHeight(id);
            var heightList = _heightLogic.GetHeight();
            return PartialView("_list", heightList);
        }
    }
}