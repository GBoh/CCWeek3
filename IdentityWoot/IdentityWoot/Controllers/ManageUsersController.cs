﻿using IdentityWoot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityWoot.Controllers {
    public class ManageUsersController : Controller {
        private IRepository _repo;

        public ManageUsersController(IRepository repo) {
            _repo = repo;
        }

        // GET: ManageUsers
        //[Authorize(Roles = "Admin")]
        public ActionResult Index() {
            return View(_repo.Query<ApplicationUser>().OrderBy(a => a.FirstName).ToList());
        }

        // GET: ManageUsers/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: ManageUsers/Create
        public ActionResult Create() {
            return View();
        }

        // POST: ManageUsers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: ManageUsers/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: ManageUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: ManageUsers/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: ManageUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }
    }
}
