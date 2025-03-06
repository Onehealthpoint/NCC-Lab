// Set 4 - Advanced C# and ASP.NET Core Demonstration

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

// Task 1: Demonstrating Abstract Classes and Interfaces
// Extra Steps:
// - No extra packages needed; built-in C# functionality.
public abstract class BankAccount
{
    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}

public interface IInterestBearing
{
    void AddInterest();
}

public class SavingsAccount : BankAccount, IInterestBearing
{
    private decimal balance;
    private const decimal interestRate = 0.05m;
    
    public override void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited: {amount}, New Balance: {balance}");
    }

    public override void Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}, New Balance: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
    
    public void AddInterest()
    {
        balance += balance * interestRate;
        Console.WriteLine($"Interest added, New Balance: {balance}");
    }
}

// Task 2: ASP.NET Core MVC Application with Session State Management
// Extra Steps:
// - Install session middleware: `dotnet add package Microsoft.AspNetCore.Session`
// - Configure session in Program.cs:
//   `builder.Services.AddSession();`
//   `app.UseSession();`
public class SessionController : Controller
{
    public IActionResult SetPreference(string theme)
    {
        HttpContext.Session.SetString("Theme", theme);
        return Ok("Preference saved.");
    }

    public IActionResult GetPreference()
    {
        var theme = HttpContext.Session.GetString("Theme") ?? "Default";
        return Ok($"Selected Theme: {theme}");
    }
}

// Task 2 Frontend (View - Session Management)
// Create a Razor view "Session.cshtml" under Views/Session/
/*
@{
    ViewData["Title"] = "Session Management";
}
<h2>Session Management</h2>
<form method="post" action="/Session/SetPreference">
    <label>Choose Theme:</label>
    <input type="text" name="theme" required />
    <button type="submit">Save</button>
</form>
<a href="/Session/GetPreference">Get Preference</a>
*/

// Task 3: Client-Side Validation using jQuery
// Extra Steps:
// - Install jQuery if not included: `dotnet add package jQuery`
// - Include jQuery validation scripts in the view: `<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>`
public class ValidationModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid phone number.")]
    public string PhoneNumber { get; set; }
}

public class ValidationController : Controller
{
    public IActionResult Index() => View();
    
    [HttpPost]
    public IActionResult Validate(ValidationModel model)
    {
        if (ModelState.IsValid)
        {
            return Ok("Validation successful.");
        }
        return BadRequest(ModelState);
    }
}

// Task 3 Frontend (View - Validation Form)
// Create a Razor view "Validation.cshtml" under Views/Validation/
/*
@{
    ViewData["Title"] = "Validation Form";
}
<h2>Validation Form</h2>
<form id="validationForm" method="post" action="/Validation/Validate">
    <label>Email:</label>
    <input type="email" name="Email" required />
    <label>Phone Number:</label>
    <input type="text" name="PhoneNumber" required />
    <button type="submit">Submit</button>
</form>
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
<script>
    $("#validationForm").on("submit", function(event) {
        var phone = $("input[name='PhoneNumber']").val();
        var regex = /^\d{10}$/;
        if (!regex.test(phone)) {
            alert("Invalid phone number format.");
            event.preventDefault();
        }
    });
</script>
*/

// Task 4: Deploying ASP.NET Core Application to IIS/Kestrel
// Extra Steps:
// - Install IIS Hosting Bundle: Download from Microsoft site.
// - Configure Kestrel in Program.cs:
//   `builder.WebHost.UseKestrel();`
// - Publish the application: `dotnet publish -c Release -o ./publish`
// - Deploy to IIS: Copy `publish` folder to IIS site directory and configure IIS to host it.

class Program
{
    static void Main()
    {
        // Task 1: Demonstrate Abstract Class and Interface
        SavingsAccount account = new SavingsAccount();
        account.Deposit(1000);
        account.AddInterest();
        account.Withdraw(500);
        
        Console.WriteLine("Set 4 Tasks Implemented.");
    }
}
