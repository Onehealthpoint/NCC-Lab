using Microsoft.AspNetCore.Mvc;
using set4_JQuery.Models;

namespace set4_JQuery.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View(new ContactForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Submit(ContactForm model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            TempData["Success"] = "Your message has been sent successfully!";
            return RedirectToAction("Index");
        }
    }
}
