using PhoneApp.Data;
using PhoneApp.Models;
using PhoneApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PhoneApp.Controllers
{
    public class PhonebookController : Controller
    {
        private Context _context;

        public PhonebookController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var phonebooks = _context.Phonebooks
                .Include(p => p.Entries)
                .OrderBy(p => p.Id)
                .ToList();

            return View(phonebooks);
        }

        public ActionResult PhonebookForm()
        {
            var phonebook = new Phonebook();

            return View("PhonebookForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Phonebook phonebook)
        {
            if (phonebook.Id == 0)
            {
                _context.Phonebooks.Add(phonebook);
            }
            else
            {
                var phonebookInDb = _context.Phonebooks
                    .Single(p => p.Id == phonebook.Id);

                phonebookInDb.Name = phonebook.Name;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Phonebook");
        }

        public ActionResult Edit(int id)
        {
            var phonebookInDb = _context.Phonebooks
                .SingleOrDefault(p => p.Id == id);

            if (phonebookInDb == null)
            {
                return HttpNotFound();
            }
            var phonebook = new Phonebook();

            return View("PhonebookForm", phonebook);
        }
    }
}