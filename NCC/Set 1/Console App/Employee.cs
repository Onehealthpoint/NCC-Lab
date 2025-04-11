using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set1
{
    class Employee
    {
        // Properties
        public string Name { get; set; }
        public int ID { get; set; }
        public decimal Salary { get; set; }

        // Constructor
        public Employee(string name, int id, decimal salary)
        {
            Name = name;
            ID = id;
            Salary = salary;
        }

        // Method to display employee details
        public void DisplayDetails()
        {
            Console.WriteLine($"Employee: {Name}, ID: {ID}, Salary: {Salary:C}");
        }
    }

    class EmployeeDemo
    {
        public static void Run()
        {
            Console.WriteLine("--- Employee Class Demonstration ---\n");

            Employee emp = new Employee("John Doe", 12345, 55000.00m);
           
            Console.WriteLine("On constructor call:");
            emp.DisplayDetails();

            emp.Name = "Jane Smith";
            emp.Salary = 80000m;

            Console.WriteLine("\nAfter property updates:");
            emp.DisplayDetails();

            Console.WriteLine("\n--- End of Employee Class Demonstration ---");
        }

    }
}
