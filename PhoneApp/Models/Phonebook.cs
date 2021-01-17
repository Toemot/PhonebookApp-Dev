using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneApp.Models
{
    public class Phonebook
    {
        public Phonebook()
        {
            Entries = new List<Entry>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}