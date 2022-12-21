using DriveFileMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DriveFileMVC.Controllers
{
    public class WebApiController : ApiController
    {
        DriveFile_DBEntities db = new DriveFile_DBEntities();

        [Route("webapi/files")]
        [HttpGet]
        public IHttpActionResult getFiles()
        {
            var data = db.Tbl_Files.ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);

        }

    }
}
