using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_ACH.Controllers
{
    public class TechnicianController : Controller
    {
        private SportingContext context { get; set; }

        public TechnicianController(SportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult List()
        {
            var technicians = context.Technicians
                 .OrderBy(t => t.Name).ToList();

            return View(technicians);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var technician = context.Technicians.FirstOrDefault(t => t.TechnicianID == id);

            return View(technician);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.FirstOrDefault(t => t.TechnicianID == id);

            return View(technician);
        }

        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            string action = (technician.TechnicianID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Technicians.Add(technician);
                }
                else
                {
                    context.Technicians.Update(technician);
                }
                context.SaveChanges();

                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = action;

                return View(technician);
            }
        }

        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();

            return RedirectToAction("List", "Technician");
        }
    }
}
