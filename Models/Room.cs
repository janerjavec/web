using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Room
    {
        public int Id { get; set; }

        public int NumberOfBeds { get; set; }
        public float Price { get; set; } // per night
        public string? Description { get; set; } // new/used , included breakfast...
    }
}