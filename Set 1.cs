// Set 1 - C# Fundamental Concepts Demonstration

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// Task 1: Employee Class with Constructor and Properties
// Extra Steps:
// - No extra packages needed; built-in C# functionality.
public class Employee
{
    public string Name { get; set; }
    public int ID { get; set; }
    public decimal Salary { get; set; }
    
    public Employee(string name, int id, decimal salary)
    {
        Name = name;
        ID = id;
        Salary = salary;
    }
    
    public void DisplayEmployee()
    {
        Console.WriteLine($"Employee: {Name}, ID: {ID}, Salary: {Salary}");
    }
}

// Task 2: Method Overriding Demonstration
// Extra Steps:
// - No extra packages needed; built-in C# functionality.
public class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing a shape.");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing a circle.");
    }
}

// Task 3: ASP.NET Core MVC Application - Greeting Form
// Extra Steps:
// - Create MVC Controller and View
// - Configure MVC services in Program.cs: `builder.Services.AddControllersWithViews();`
public class GreetingController : Controller
{
    [HttpGet]
    public IActionResult Index() => View();
    
    [HttpPost]
    public IActionResult Greet(string name)
    {
        return View("Greeting", name);
    }
}

// Task 3 Frontend (View - Greeting Form)
// Create a Razor view "Index.cshtml" under Views/Greeting/
/*
@{
    ViewData["Title"] = "Greeting Form";
}
<h2>Enter Your Name</h2>
<form method="post" action="/Greeting/Greet">
    <input type="text" name="name" required />
    <button type="submit">Submit</button>
</form>
*/

// Task 4: ADO.NET - Fetch Employee Records from SQL Server
// Extra Steps:
// - Ensure SQL Server is running and contains an "Employees" table.
// - Install ADO.NET package if needed: `dotnet add package System.Data.SqlClient`
public class DatabaseHelper
{
    private const string connectionString = "your_connection_string_here";
    
    public static void FetchEmployees()
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Name, ID, Salary FROM Employees", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                Console.WriteLine($"Employee: {reader["Name"]}, ID: {reader["ID"]}, Salary: {reader["Salary"]}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Task 1: Demonstrate Employee Class
        Employee emp = new Employee("John Doe", 101, 50000);
        emp.DisplayEmployee();
        
        // Task 2: Demonstrate Method Overriding
        Shape shape = new Shape();
        shape.Draw();
        
        Shape circle = new Circle();
        circle.Draw();
        
        // Task 4: Fetch Employee Records
        DatabaseHelper.FetchEmployees();
        
        Console.WriteLine("Set 1 Tasks Implemented.");
    }
}
