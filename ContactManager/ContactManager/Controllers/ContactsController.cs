using System;
using ContactManager.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private IRepository _repo;

        public ContactsController(Repository repo)
        {
            _repo = repo;
        }

        // GET: Contacts
        public ActionResult Index(int id = 0)
        {
            return View(_repo.Query<Contact>().ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.Find<Contact>(id));
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                // TODO: Add insert logic here
                _repo.Add<Contact>(contact);
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.Find<Contact>(id));
        }

        // POST: Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Contact contact)
        {
            try
            {
                // TODO: Add update logic here
                contact.Id = id;
                var dbContact = _repo.Find<Contact>(id);
                dbContact.FirstName = contact.FirstName;
                dbContact.LastName = contact.LastName;
                dbContact.Birthday = contact.Birthday;
                dbContact.PhoneNumber = contact.PhoneNumber;
                _repo.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.Find<Contact>(id));
        }

        // POST: Contacts/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteReally(int id)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.Delete<Contact>(id);
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
