using System.Collections.Generic;

namespace GBCSporting2021_ACH.Models
{
    public class RegistrationProductViewModel
    {
        public List<Registration> Registrations { get; set; }
        public List<Product> Products { get; set; }
        public Customer CurrentCustomer { get; set; }
        public Registration NewRegistration { get; set; }
    }
}
