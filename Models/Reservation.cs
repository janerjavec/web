using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace web.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Guest_Id { get; set; }
        public int Room_Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        public float TotalPrice { get; set; }
        public ApplicationUser? Owner { get; set; }
    }
}