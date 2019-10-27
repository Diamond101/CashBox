using CashBox.Models;
using CashBoxLogic;
using CashBoxModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashBox.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersLogic _usersLogic = new UsersLogic();
        private readonly PeopleLogic _peopleLogic = new PeopleLogic();
        private readonly HeightLogic _heightLogic = new HeightLogic();
        private readonly WeightLogic _weightLogic = new WeightLogic();
        public ActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUser user)
        {
            var response = _usersLogic.LoginUser(user.Username, user.Password);
            if (response)
            {               
                return RedirectToAction("Dashboard");
            }           
            ViewBag.Message = "Failed";
            return View(user);
        }
        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        public ActionResult Dashboard()
        {
            var Deleted = new PeopleLogic().CountDeleted();
            var NewMember = new PeopleLogic().CountNewMember();            
            var total = new PeopleLogic().CountTotal();

            var DeletedWeight = new WeightLogic().CountDeleted();
            var NewWeight = new WeightLogic().CountNewWeight();
            var totalWeight = new WeightLogic().CountTotal();

            var DeletedHeight = new HeightLogic().CountDeleted();
            var NewHeight = new HeightLogic().CountNewHeight();
            var totalHeight = new HeightLogic().CountTotal();

            ViewBag.Deleted = Deleted;
            ViewBag.NewMember = NewMember;            
            ViewBag.Total = total;

            ViewBag.DeletedWeight = DeletedWeight;
            ViewBag.NewWeight = NewWeight;
            ViewBag.TotalWeight = totalWeight;

            ViewBag.DeletedHeight = DeletedHeight;
            ViewBag.NewHeight = NewHeight;
            ViewBag.TotalHeight = totalHeight;

            ViewBag.Delete = ((double)Deleted / total) * 100;
            ViewBag.NewMembe = ((double)NewMember / total) * 100;

            ViewBag.DeletedWeightPercent = ((double)DeletedWeight / totalWeight) * 100;
            ViewBag.NewWeightPercent = ((double)NewWeight / totalWeight) * 100;

            ViewBag.DeletedHeightPercent = ((double)DeletedHeight / totalHeight) * 100;
            ViewBag.NewHeightPercent = ((double)NewHeight / totalHeight) * 100;
            return View();
        }
    }
}