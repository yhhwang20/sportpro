using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GBCSporting2021_ACH.Controllers
{
    public class RegistrationController : Controller
    {
        private SportingContext context;

        public RegistrationController(SportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult GetCustomer()
        {
            var model = new RegistrationViewModel
            {
                Customers = context.Customers.OrderBy(c => c.FirstName).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult GetCustomer(RegistrationViewModel data)
        {
            if (ModelState.IsValid)
            {
                var session = new Session(HttpContext.Session);
                session.SetCustomerID(data.CustomerID);

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("GetCustomer");
            }
        }

        [HttpGet]
        public ViewResult List()
        {
            var session = new Session(HttpContext.Session);
            int custID = session.GetCustomerID();

            var model = new RegistrationProductViewModel
            {
                Registrations = context.Registrations
                .Include(r => r.Customer)
                .Include(r => r.Product)
                .Where(r => r.CustomerID == custID)
                .OrderBy(r => r.Product.Name).ToList(),

                Products = context.Products.OrderBy(p => p.Name).ToList(),
                CurrentCustomer = context.Customers.FirstOrDefault(c => c.CustomerID == custID),
                NewRegistration = new Registration()
            };

            if (model.Registrations.Count < 1)
            {
                TempData["regMsg"] = "There are no products registered.";
            }
            else
            {
                TempData["regMsg"] = "Registrations";
            }

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Register(RegistrationProductViewModel data)
        {
            if (ModelState.IsValid)
            {
                context.Registrations.Add(data.NewRegistration);
                context.SaveChanges();
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public ViewResult Delete(int cId, int pId)
        {
            var registration = context.Registrations.Where(r => r.ProductID == pId)
                                                    .Where(r => r.CustomerID == cId);
            return View(registration);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Registration registration)
        {
            context.Registrations.Remove(registration);
            context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
