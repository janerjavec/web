using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public string Location { get; set; }

        public string? Description { get; set; }

        public int Rating { get; set; }
    }
}