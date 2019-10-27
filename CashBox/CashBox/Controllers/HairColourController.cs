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
    public class HairColourController : Controller
    {
        private readonly HairColorLogic _hairColourLogic = new HairColorLogic();
        public ActionResult Index()
        {
            var hairColour = _hairColourLogic.GetHairColour();
            return View(hairColour);
        }

        [HttpPost]
        public JsonResult _LoadEdit(int id)
        {
            HairColour hairColour = _hairColourLogic.FindHairColourById(id);
            return Json(hairColour, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Edit(HairColour hairColour)
        {
            _hairColourLogic.UpdateHairColour(hairColour);
            var hair = _hairColourLogic.GetHairColour();
            return PartialView("_list", hair);
        }

        public PartialViewResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Create(HairColour hairColour)
        {
            _hairColourLogic.AddHairColour(hairColour);
            var hair = _hairColourLogic.GetHairColour();
            return PartialView("_list", hair);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Delete(int id)
        {
            _hairColourLogic.DeleteHairColour(id);
            var hairColourList = _hairColourLogic.GetHairColour();
            return PartialView("_list", hairColourList);
        }
    }
}