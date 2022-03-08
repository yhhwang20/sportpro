using GBCSporting2021_ACH.Models;
using Microsoft.AspNetCore.Mvc;

namespace GBCSporting2021_ACH.Controllers
{
    public class ValidationController : Controller
    {
        private SportingContext context;
        public ValidationController(SportingContext ctx) => context = ctx;

        public JsonResult CheckEmail(string emailAddress)
        {
            string msg = Check.EmailExists(context, emailAddress);
            if (string.IsNullOrEmpty(msg)) {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else return Json(msg);
        }
    }
}