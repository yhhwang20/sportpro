using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GBCSporting2021_ACH.Controllers
{
    public class ProductController : Controller
    {
        private SportingContext context { get; set; }

        public ProductController(SportingContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult List()
        {
            var products = context.Products
                 .OrderBy(p => p.DateReleased).ToList();

            return View(products);
        }

        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";

            return View("Edit", new Product());
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";

            var product = context.Products
                .FirstOrDefault(p => p.ProductID == id);

            return View(product);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var product = context.Products
                .FirstOrDefault(p => p.ProductID == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            string action = (product.ProductID == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    context.Products.Add(product);
                }
                else
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();

                TempData["message"] = $"{product.Name} was {action.ToLower()}ed.";

                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = action;

                return View(product);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product product)
        {
            TempData["message"] = $"{product.Name} was deleted.";
            context.Products.Remove(product);
            context.SaveChanges();

            return RedirectToAction("List", "Product");
        }
    }
}
