using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_ACH.Models
{
    public class Registration
    {
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        [Required(ErrorMessage = "You must choose a product.")]
        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
