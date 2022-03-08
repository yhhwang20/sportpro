using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_ACH.Controllers
{
    public class IncidentController : Controller
    {
        private SportingContext context;
        private List<Customer> customers;
        private List<Product> products;
        private List<Technician> technicians;

        public IncidentController(SportingContext ctx)
        {
            context = ctx;
            customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            products = context.Products.OrderBy(p => p.Name).ToList();
            technicians = context.Technicians.OrderBy(t => t.Name).ToList();
        }

        [HttpGet]
        public IActionResult List(string filter = "all")
        {
            var model = new IncidentListViewModel
            {
                Filter = filter
            };
            DateTime defualtDate = new DateTime(1, 1, 1, 0, 0, 0);
            IQueryable<Incident> query = context.Incidents;
            if (model.Filter == "unassigned")
                query = query.Where(
                    i => i.Technician == null);
            if (model.Filter == "open")
                query = query.Where(
                    i => i.DateClosed.CompareTo(defualtDate) == 0);
            model.Incidents = query.OrderBy(i => i.DateOpened).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new IncidentViewModel
            {
                Customers = customers,
                Products = products,
                Technicians = technicians,
                CurrentIncident = new Incident(),
                Operation = "Add"
            };

            return View("Edit", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = new IncidentViewModel
            {
                Customers = customers,
                Products = products,
                Technicians = technicians,
                CurrentIncident = context.Incidents
                    .Include(i => i.Customer)
                    .Include(i => i.Product)
                    .Include(i => i.Technician)
                    .FirstOrDefault(i => i.IncidentID == id),
                Operation = "Edit"
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Incident incident = context.Incidents
                .FirstOrDefault(i => i.IncidentID == id);

            return View(incident);
        }

        [HttpPost]
        public IActionResult Edit(IncidentViewModel data)
        {
            if (ModelState.IsValid)
            {
               
                if (data.Operation == "Add")
                {
                    context.Incidents.Add(data.CurrentIncident);
                }
                else
                {
                    context.Incidents.Update(data.CurrentIncident);
                }
                context.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
