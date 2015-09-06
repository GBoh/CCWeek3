using PhotoAlbum.Models;
using PhotoAlbum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.Controllers
{
    public class AlbumsController : Controller
    {
        private AlbumService _service;

        public AlbumsController(AlbumService service) {
            _service = service;
        }
        
        // GET: Albums
        public ActionResult Index()
        {
            return View(_service.ListAlbums());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(AlbumDTO album)
        {
            try
            {
                // TODO: Add insert logic here
                _service.AddAlbum(album);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Display(string id, AlbumDTO album)
        {
            AlbumDisplayViewModel vm = new AlbumDisplayViewModel();
            vm.Photos = _service.ListPhotos(album);
            vm.Title = id;
            return View(vm);
        }

        // POST: Albums/Edit/5
        //[HttpPost]
        //public ActionResult Display(string id, AlbumDTO album)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
