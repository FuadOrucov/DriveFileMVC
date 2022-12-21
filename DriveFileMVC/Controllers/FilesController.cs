using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using DriveFileMVC.Models;
namespace DriveFile.Controllers
{
    public class FilesController : Controller
    {
        DriveFile_DBEntities db = new DriveFile_DBEntities();


        public ActionResult Index(string mail)
        {

            var tbl_Files = db.Tbl_Files.Include(t => t.Tbl_Account);
            return View(tbl_Files.ToList());
        }

        //GET: web api get filess 
        public ActionResult getFiles()
        {
            IEnumerable<Tbl_Files> files = db.Tbl_Files.ToList();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44336/webapi/");

                var responseData = client.GetAsync("files");
                responseData.Wait();

                var result = responseData.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readData = result.Content.ReadAsAsync<IList<Tbl_Files>>();
                    readData.Wait();

                    files = readData.Result;
                }
                else //web api sent error response 
                {
                    files = Enumerable.Empty<Tbl_Files>();

                    ModelState.AddModelError(string.Empty, "Server error.");
                }
            }
            return View(files);
        }


        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Downloads/") + fileName;
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string mail, Tbl_Files tbl_Files)
        {
            try
            {
                if (mail != null)
                {
                    var accountList = db.Tbl_Account.Where(o => o.Mail == mail).FirstOrDefault();
                    var accountId = accountList.id;
                    if (accountId != null)
                    {
                        tbl_Files.AccountId = accountId;
                    }
                }

                if (Request.Files.Count > 0)
                {
                    string fileName = Path.GetFileName(Request.Files[0].FileName);
                    string path = "~/Downloads/" + fileName;
                    Request.Files[0].SaveAs(Server.MapPath(path));
                    tbl_Files.Attachment = "/Downloads/" + fileName;
                    tbl_Files.FileName = fileName;
                }
                tbl_Files.RegDate = DateTime.Now;
                db.Tbl_Files.Add(tbl_Files);
                db.SaveChanges();
                return RedirectToAction("Index", "Files");

            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Files tbl_Files = db.Tbl_Files.Find(id);
            if (tbl_Files == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Files);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            Tbl_Files tbl_Files = db.Tbl_Files.Find(id);
            string path = Request.MapPath(tbl_Files.Attachment);
            db.Tbl_Files.Remove(tbl_Files);

            if (db.SaveChanges() > 0)
            {

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                return RedirectToAction("Index");
            }
            return View();
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
