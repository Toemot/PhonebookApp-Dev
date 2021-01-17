using PhoneApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneApp.ViewModel
{
    public class PhonebookViewModel
    {
        public Phonebook Phonebooks { get; set; }
        public IEnumerable<Entry> Entries { get; set; }
    }
}