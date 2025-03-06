// Set 3 - C# Advanced Concepts Demonstration

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

// Task 1: Demonstrating Delegates and Events
// Extra Steps:
// - No extra packages needed; built-in C# functionality.
public delegate void UserLoggedInHandler(string username);

public class UserLoginSystem
{
    public event UserLoggedInHandler UserLoggedIn;

    public void Login(string username)
    {
        Console.WriteLine($"User {username} logged in.");
        UserLoggedIn?.Invoke(username);
    }
}

// Task 2: ASP.NET Core application using Entity Framework Core
// Extra Steps:
// - Install Entity Framework Core: `dotnet add package Microsoft.EntityFrameworkCore`
// - Configure database context in Program.cs: `builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("your_connection_string"));`
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}

[ApiController]
[Route("api/products")]
public class ProductsApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProductsApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(await _context.Products.ToListAsync());
    }
}

// Task 3: Demonstrating LINQ Queries
// Extra Steps:
// - No extra packages needed; LINQ is built into C#.
public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}

public class LINQDemo
{
    public static void FilterStudents()
    {
        var students = new List<Student>
        {
            new Student { Name = "Alice", Grade = 85 },
            new Student { Name = "Bob", Grade = 90 },
            new Student { Name = "Charlie", Grade = 75 }
        };

        var highAchievers = students.Where(s => s.Grade > 80).ToList();
        Console.WriteLine("High Achieving Students:");
        highAchievers.ForEach(s => Console.WriteLine(s.Name));
    }
}

// Task 4: Securing ASP.NET Core Web API with JWT Authentication
// Extra Steps:
// - Install JWT authentication middleware: `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer`
// - Configure authentication in Program.cs:
//   `builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();`
// - Add `[Authorize]` attribute to protect API endpoints.
[Authorize]
[ApiController]
[Route("api/protected")]
public class ProtectedApiController : ControllerBase
{
    [HttpGet]
    public IActionResult GetSecureData()
    {
        return Ok("This is a protected API endpoint");
    }
}

class Program
{
    static void Main()
    {
        // Task 1: Demonstrating Delegates and Events
        UserLoginSystem loginSystem = new UserLoginSystem();
        loginSystem.UserLoggedIn += username => Console.WriteLine($"Event triggered: {username} logged in.");
        loginSystem.Login("JohnDoe");
        
        // Task 3: LINQ Query Demonstration
        LINQDemo.FilterStudents();
        
        Console.WriteLine("Set 3 Tasks Implemented.");
    }
}
