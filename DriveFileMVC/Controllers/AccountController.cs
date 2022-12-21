using DriveFileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DriveFile.Controllers
{
    public class AccountController : Controller
    {
        DriveFile_DBEntities db = new DriveFile_DBEntities();

        public ActionResult Index(string mail)
        {
            var personid = db.Tbl_Account.Where(o => o.Mail == mail).ToList();
            return View(personid);
        }
    }
}