using IdentityWoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityWoot.Controllers {
    public class HomeController : Controller {

        private IRepository _repo;

        public HomeController(IRepository repo) {
            _repo = repo;
        }

        public ActionResult Index() {
            //throw new Exception("oops");
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}