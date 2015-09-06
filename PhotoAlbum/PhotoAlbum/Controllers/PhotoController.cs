using PhotoAlbum.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.Controllers {
    public class PhotoController : Controller {

        private PhotoService _service;

        public PhotoController(PhotoService service) {
            _service = service;
        }

        public ActionResult UploadPhotos(string id) {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhotos(HttpPostedFileBase file, PhotoDTO photo) {
            //var extension = file.FileName.Substring(file.ToString().IndexOf("."));
            
            var fileName = Path.Combine(("/Uploads"), (DateTime.Now.Ticks.ToString() + file.FileName));
            file.SaveAs(fileName);
            _service.AddPhoto(photo, fileName);


            return RedirectToAction("Index", "Albums");
        }
    }
}