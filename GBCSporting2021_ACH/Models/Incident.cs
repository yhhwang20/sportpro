using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_ACH.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }

        [Required(ErrorMessage = "Please select a customer.")]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; }

        [Required(ErrorMessage = "Please select a product.")]
        public int ProductID { get; set; }

        public Product Product { get; set; }

        public int? TechnicianID { get; set; }

        public Technician Technician { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        public DateTime DateOpened { get; set; }
        public DateTime DateClosed { get; set; }
    }
}
