using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_ACH.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Required.")]
        public int CountryID { get; set; }
        public Country Country { get; set; }

        [Required(ErrorMessage = "Required.")]
        [StringLength(51, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required.")]
        [StringLength(51, MinimumLength = 1)]
        public string LastName { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }

        [Required(ErrorMessage = "Required.")]
        [StringLength(51, MinimumLength = 1)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required.")]
        [StringLength(51, MinimumLength = 1)]
        public string City { get; set; }

        [Required(ErrorMessage = "Required.")]
        [StringLength(51, MinimumLength = 1)]
        public string State { get; set; }

        [Required(ErrorMessage = "Required.")]
        [StringLength(21, MinimumLength = 1)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [StringLength(51, MinimumLength = 1)]
        public string Email { get; set; }

        [RegularExpression(@"\(\d{3}\)\040\d{3}-\d{4}", ErrorMessage = "Phone number must be in (999) 999-9999 format.")]
        public string Phone { get; set; }

        public ICollection<Registration> Registrations { get; set; }

    }
}
