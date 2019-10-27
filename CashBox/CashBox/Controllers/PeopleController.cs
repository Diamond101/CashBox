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
    public class PeopleController : Controller 
    {
        private readonly WeightLogic _weightLogic = new WeightLogic();
        private readonly HairColorLogic _hairColorLogic = new HairColorLogic();
        private readonly HeightLogic _heightLogic = new HeightLogic();
        private readonly PeopleLogic _peopleLogic = new PeopleLogic();
        
        public ActionResult Index()
        //public JsonResult Index()
        {
            LoadWeight();
            ViewBag.Message = string.Empty; 
            LoadHeight();
            ViewBag.Message = string.Empty;
            LoadHairColor(); 
            ViewBag.Message = string.Empty;
            var people = _peopleLogic.GetPeople();
            return View(people);
            //return Json(people, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult LoadData()
        {
            var people = _peopleLogic.GetPeople();
            
            return Json(people, JsonRequestBehavior.AllowGet);
        }




        private void LoadWeight()
        {
            ViewBag.Weight = new SelectList(new WeightLogic().GetWeight(), "WeightValue", "WeightValue");
        }

        private void LoadHeight()
        {
            ViewBag.Height = new SelectList(new HeightLogic().GetHeight(), "HeightNumber", "HeightNumber");
        }

        private void LoadHairColor()
        {
            ViewBag.HairColor = new SelectList(new HairColorLogic().GetHairColour(), "Colour", "Colour");
        }

        [HttpPost]
        public JsonResult _LoadEdit(int id)
        {
            People people = _peopleLogic.FindPeopleById(id);
            return Json(people, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Edit(People people)
        {
        _peopleLogic.UpdatePeople(people);
            var peopleList = _peopleLogic.GetPeople();
            return PartialView("_list", peopleList);
        }

        public PartialViewResult _Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Create(People people)
        {
            _peopleLogic.AddPeople(people);
            var peopleList = _peopleLogic.GetPeople();
            return PartialView("_list", peopleList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Delete(int id)
        {
        _peopleLogic.DeletePeople(id);
            var List = _peopleLogic.GetPeople();
            return PartialView("_list", List);
        }
    }
}