using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneApp.Data
{
    public class Context : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Phonebook> Phonebooks { get; set; }

        public Context()
            : base("name=DefaultConnection")
        {
        }

    }
}