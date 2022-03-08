using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_ACH.Controllers
{
    public class TechIncidentController : Controller
    {
        private SportingContext context;

        public TechIncidentController(SportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = new TechIncidentViewModel
            {
                Technicians = context.Technicians.OrderBy(t => t.Name).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Get(TechIncidentViewModel data)
        {
            if (ModelState.IsValid)
            {
                var session = new Session(HttpContext.Session);
                session.SetTechnicianID(data.TechnicianID);

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Get");
            }
        }

        [HttpGet]
        public IActionResult List()
        {
            var session = new Session(HttpContext.Session);
            int techID = session.GetTechnicianID();

            List<Incident> incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .Where(i => i.TechnicianID == techID)
                .OrderBy(i => i.DateOpened).ToList();

            if (incidents.Count < 1)
            {
                TempData["incMsg"] = "There are no open incidents.";
            }
            else
            {
                TempData["incMsg"] = "Assigned/Open Incidents";
            }

            var technician = context.Technicians.FirstOrDefault(t => t.TechnicianID == techID);
            ViewBag.Technician = technician.Name;

            return View(incidents);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Incident incident = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .Include(i => i.Technician)
                .FirstOrDefault(i => i.IncidentID == id);

            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                context.Incidents.Update(incident);
                context.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return View(incident);
            }
        }
    }
}
