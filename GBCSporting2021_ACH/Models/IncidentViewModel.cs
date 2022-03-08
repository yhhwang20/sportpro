﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_ACH.Models
{
    public class IncidentViewModel
    {
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Technician> Technicians { get; set; }

        public Incident CurrentIncident { get; set; }

        public string Operation { get; set; }
    }
}
