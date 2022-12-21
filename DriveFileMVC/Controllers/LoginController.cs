using DriveFileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace DriveFile.Controllers
{

    public class LoginController : Controller
    {
        DriveFile_DBEntities db = new DriveFile_DBEntities();
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(Tbl_Account account)
        {
            bool result = IsValid(account.Mail, account.Password);

            if (result)
            {
                FormsAuthentication.SetAuthCookie(account.Mail, false);
                return RedirectToAction("Index", "Files", new RouteValueDictionary(new { Controller = "Files", Action = "Create", mail = account.Mail }));
            }
            else
            {
                ViewBag.message = "Login Faild";
                return View();
            }
        }
        public bool IsValid(string mail, string password)
        {
            bool Isvalid = false;
            var user = db.Tbl_Account.FirstOrDefault(o => o.Mail == mail);
            if (user != null)
            {
                if (user.Password == password)
                {
                    Isvalid = true;
                }
            }
            return Isvalid;
        }


        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}