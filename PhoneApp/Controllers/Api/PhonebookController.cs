using PhoneApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using PhoneApp.Models;

namespace PhoneApp.Controllers.Api
{
    public class PhonebookController : ApiController
    {
        private Context _context;

        public PhonebookController()
        {
            _context = new Context();
        }

        public IHttpActionResult GetPhonebooks()
        {
            return Ok(_context.Phonebooks
                .Include(p => p.Entries)
                .OrderBy(p => p.Id)
                .ToList());
        }

        public IHttpActionResult GetPhonebook(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IHttpActionResult AddPhonebook(Phonebook phonebook)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Phonebooks.Add(phonebook);
            _context.SaveChanges();

            return Created(new Uri
                (Request.RequestUri + "/" + phonebook.Id), phonebook);
        }

        [HttpPut]
        public IHttpActionResult UpdatePhonebook(int id, Phonebook phonebook)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var phonebookInDb = _context.Phonebooks
                .SingleOrDefault(p => p.Id == id);

            if (phonebookInDb == null)
                return NotFound();

            _context.SaveChanges();
            return Ok(phonebookInDb);
        }

        [HttpDelete]
        public IHttpActionResult DeletPhonebook(int id)
        {
            var phonebook = _context.Phonebooks
                .SingleOrDefault(p => p.Id == id);

            if (phonebook == null)
                return NotFound();

            _context.Phonebooks.Remove(phonebook);
            _context.SaveChanges();
            return Ok();
        }
    }
}
