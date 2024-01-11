using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web.Models;


namespace web.Models
{

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is DateTime))
            {
                return new ValidationResult("Neveljaven datum.");
            }

            DateTime submittedDate = (DateTime)value;
            DateTime today = DateTime.Today;

            if (submittedDate.Date < today)
            {
                return new ValidationResult("Datum mora biti današnji ali v prihodnosti.");
            }

            return ValidationResult.Success;
        }
    }
    public class Reservation
    {
        public int Id { get; set; }
        public int Guest_Id { get; set; }
        //public Guest Guest { get; set; }  // Navigation property to the Guest entity
        public int Room_Id { get; set; }
        [DataType(DataType.Date)]
        [FutureDate]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [FutureDate]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }
        public float TotalPrice { get; set; }
        public ApplicationUser? Owner { get; set; }
    }
}