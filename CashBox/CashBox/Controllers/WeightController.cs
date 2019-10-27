using CashBoxLogic;
using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc; 

namespace CashBox.Controllers
{
    public class WeightController : Controller
    {
        private readonly WeightLogic _weightLogic = new WeightLogic();
        public ActionResult Index()
        {
            var weight = _weightLogic.GetWeight();
            return View(weight);
        }

        [HttpPost]
        public JsonResult _LoadEdit(int id)
        {
            Weight weight = _weightLogic.FindWeightById(id);
            return Json(weight, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Edit(Weight weight)
        {
            _weightLogic.UpdateWeight(weight);
            var weightList = _weightLogic.GetWeight();
            return PartialView("_list", weightList);
        }

        public PartialViewResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Create(Weight weight)
        {
            _weightLogic.AddWeight(weight);
            var weightList = _weightLogic.GetWeight();
            return PartialView("_list", weightList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Delete(int id)
        {
            _weightLogic.DeleteWeight(id);
            var weightList = _weightLogic.GetWeight();
            return PartialView("_list", weightList);
        }
    }
}