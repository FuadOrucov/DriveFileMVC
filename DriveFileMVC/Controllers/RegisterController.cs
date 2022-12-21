using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DriveFileMVC.Models;

namespace DriveFile.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private DriveFile_DBEntities db = new DriveFile_DBEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Account tbl_Account)
        {
            if (ModelState.IsValid)
            {
                tbl_Account.RegDate = DateTime.Now;
                db.Tbl_Account.Add(tbl_Account);
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            return View(tbl_Account);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
