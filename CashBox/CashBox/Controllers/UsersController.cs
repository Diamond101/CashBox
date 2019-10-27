using CashBox.Filters;
using CashBoxLogic;
using CashBoxModel;
using CashBoxModel.SecurityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CashBox.Controllers
{
    [AuthorizedCashBoxUsers]
    public class UsersController : Controller
    {
        private readonly UsersLogic _usersLogic = new UsersLogic();
        public ActionResult Index()
        {
            var users = _usersLogic.GetUsers();
            return View(users);
        }

        [HttpPost]
        public JsonResult _LoadEdit(int id)
        {
            Users user = _usersLogic.FindUserById(id);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Edit(Users user)
        {
            if (!String.IsNullOrEmpty(user.Password))
            {
                string encryptedPassword = new SecurityLayer().Encrypt(user.Password);
                user.Password = encryptedPassword;
            }

            _usersLogic.UpdateUser(user);
            var users = _usersLogic.GetUsers();
            return PartialView("_list", users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Create(Users user)
        {
            _usersLogic.AddUser(user);
            var users = _usersLogic.GetUsers();
            return PartialView("_list", users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult _Delete(int id)
        {
            _usersLogic.DeleteUser(id);
            var users = _usersLogic.GetUsers();
            return PartialView("_list", users);
        }
    }
}