// Set 2 - C# Advanced Concepts Demonstration

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

// Task 1: Demonstrating Async and Await
// Extra Steps:
// - Ensure the file "sample.txt" exists in the project directory.
// - No extra packages are needed; System.IO is included in .NET by default.
class AsyncDemo
{
    public static async Task ReadFileAsync(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        string content = await reader.ReadToEndAsync();
        Console.WriteLine("File Content:");
        Console.WriteLine(content);
    }
}

// Task 2: ASP.NET Core MVC Controller returning JSON response
// Extra Steps:
// - Install ASP.NET Core MVC if not already installed: `dotnet add package Microsoft.AspNetCore.Mvc`
// - Ensure the controller is registered in the Startup.cs or Program.cs file.
public class ProductsController : Controller
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new List<object>
        {
            new { Id = 1, Name = "Laptop", Price = 1000 },
            new { Id = 2, Name = "Phone", Price = 500 },
            new { Id = 3, Name = "Tablet", Price = 300 }
        };
        return Json(products);
    }
}

// Task 3: Basic ASP.NET Core Web API with Dependency Injection
// Extra Steps:
// - Install ASP.NET Core Web API dependencies: `dotnet add package Microsoft.AspNetCore.Mvc.Core`
// - Register the StudentService in Program.cs: `builder.Services.AddScoped<IStudentService, StudentService>();`
public interface IStudentService
{
    List<string> GetStudents();
}

public class StudentService : IStudentService
{
    public List<string> GetStudents()
    {
        return new List<string> { "Alice", "Bob", "Charlie" };
    }
}

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;
    
    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_studentService.GetStudents());
    }
}

// Task 4: Role-Based Authorization in ASP.NET Core MVC
// Extra Steps:
// - Install authentication and authorization middleware: `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer`
// - Configure authentication in Program.cs:
//   `builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();`
// - Ensure role-based policies are set up in the authorization configuration.
//   Example in Program.cs:
//   `builder.Services.AddAuthorization(options => { options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin")); });`
// - Apply the policy to the controller or actions using `[Authorize(Policy = "AdminOnly")]`
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult SecureAction()
    {
        return Content("Only Admins can access this action.");
    }
}

class Program
{
    static async Task Main()
    {
        // Task 1: Async File Read Demonstration
        await AsyncDemo.ReadFileAsync("sample.txt");
        
        Console.WriteLine("Set 2 Tasks Implemented.");
    }
}
