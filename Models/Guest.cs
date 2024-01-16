using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using web.Models;

namespace web.Models
{
    public class Guest
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("FirstName")] // na bazi bo atribut FirstName
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column("LastName")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; } // Navigation property for reservations

        public Guest()
        {
            Reservations = new HashSet<Reservation>();
        }
    
    }
}