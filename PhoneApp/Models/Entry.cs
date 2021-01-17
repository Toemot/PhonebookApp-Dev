using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneApp.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage ="Phone Number must not be more than 10 digits")]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }

        public Phonebook Phonebook { get; set; }
    }
}