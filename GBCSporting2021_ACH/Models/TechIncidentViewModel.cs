using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_ACH.Models
{
    public class TechIncidentViewModel
    {
        [Required(ErrorMessage = "You must select a technician.")]
        public int TechnicianID { get; set; }

        public List<Technician> Technicians { get; set; }
    }
}
