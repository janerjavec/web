using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Guest
    {
        //[Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}