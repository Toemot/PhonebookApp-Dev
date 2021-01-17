using PhoneApp.Data;
using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneApp.Controllers.Api
{
    public class EntryController : ApiController
    {
        private Context _context;

        public EntryController()
        {
            _context = new Context();
        }

        public IHttpActionResult GetEntries()
        {
            return Ok(_context.Entries.ToList());
        }

        public IHttpActionResult GetEntry(int id)
        {
            var entry = _context.Entries
                .SingleOrDefault(e => e.Id == id);

            return Ok(entry);
        }

        [HttpPost]
        public IHttpActionResult AddEntry(Entry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            _context.Entries.Add(entry);
            _context.SaveChanges();

            return Created(new Uri
                (Request.RequestUri + "/" + entry.Id), entry);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntry(int id, Entry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var entryInDb = _context.Entries
                .SingleOrDefault(e => e.Id == id);

            if (entryInDb == null)
                return NotFound();

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEntry(int id)
        {
            var entry = _context.Entries
                .SingleOrDefault(e => e.Id == id);

            if (entry == null)
                return NotFound();

            _context.Entries.Remove(entry);
            _context.SaveChanges();
            return Ok();
        }
    }
}
