using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using set4_StateManagement.Models;

namespace set4_StateManagement.Controllers
{
    public class UserPreferencesController : Controller
    {
        public IActionResult Index()
        {
            // Retrieve preferences from session
            var preferences = HttpContext.Session.GetString("UserPreferences");
            var model = !string.IsNullOrEmpty(preferences)
                ? JsonSerializer.Deserialize<UserPreferences>(preferences)
                : new UserPreferences();

            return View(model);
        }

        [HttpPost]
        public IActionResult SavePreferences(UserPreferences preferences)
        {
            // Store preferences in session
            HttpContext.Session.SetString("UserPreferences",
                JsonSerializer.Serialize(preferences));

            TempData["Message"] = "Preferences saved successfully!";
            return RedirectToAction("Index");
        }
    }
}
