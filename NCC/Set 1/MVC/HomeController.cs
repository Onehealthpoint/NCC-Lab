using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Set1_MVC.Models;

namespace Set1_MVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Greetings(GreetingModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Greetings = $"Hello, {model.Name}!";
                return View(model);
            }
            return View("Index");
        }
    }
}
