using PhoneApp.Data;
using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneApp.Controllers
{
    public class EntryController : Controller
    {
        private Context _context;

        public EntryController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var entries = _context.Entries.ToList();

            return View(entries);
        }

        public ActionResult Details(int id)
        {
            var entry = _context.Entries
                .SingleOrDefault(e => e.Id == id);

            if (entry == null)
            {
                return View("EntryForm");
            }
            return View(entry);
        }

        public ActionResult EntryForm()
        {
            var entry = new Entry();

            return View("EntryForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Entry entry)
        {
            if (!ModelState.IsValid)
                return View("EntryForm");

            if(entry.Id != 0)
                _context.Entries.Add(entry);
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Entry");
        }

        public ActionResult Edit(int id)
        {
            var entryInDb = _context.Entries
                .SingleOrDefault(e => e.Id == id);

            if (entryInDb == null)
                return HttpNotFound();

            return RedirectToAction("EntryForm");
        }

        public ActionResult Delete(int id)
        {
            var entry = _context.Entries
                .SingleOrDefault(e => e.Id == id);

            if (entry == null)
                return HttpNotFound();

            _context.Entries.Remove(entry);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}