using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_ACH.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "You must select a customer.")]
        public int CustomerID { get; set; }
        public List<Customer> Customers { get; set; }
    }
}
