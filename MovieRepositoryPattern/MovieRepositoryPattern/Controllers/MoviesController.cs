using MovieRepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRepositoryPattern.Controllers
{
    public class MoviesController : Controller
    {
        private IGenericRepository _repo;

        public MoviesController(GenericRepository repo)
        {
            _repo = repo;
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(_repo.Query<Movie>().ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            
            return View(_repo.Find<Movie>(id));
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                _repo.Add<Movie>(movie);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.Find<Movie>(id));
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                movie.Id = id;
                var dbMove = _repo.Find<Movie>(id);
                dbMove.Name = movie.Name;
                dbMove.ReleaseDate = movie.ReleaseDate;
                dbMove.Director = movie.Director;
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.Find<Movie>(id));
        }

        // POST: Movies/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        { 
            try
            {
                _repo.Delete<Movie>(id);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
