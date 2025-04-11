using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace set3_Q1Q3
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public double Grade { get; set; }
    }

    public static class LinqDemo
    {
        public static void Run()
        {
            Console.WriteLine("LINQ with Student Grades ");

            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Ram", Course = "Maths", Grade = 85.5 },
                new Student { Id = 2, Name = "Jit", Course = "CSIT", Grade = 92.3 },
                new Student { Id = 3, Name = "Charan", Course = "Maths", Grade = 78.9 },
                new Student { Id = 4, Name = "Dipa", Course = "CSIT", Grade = 88.1 },
                new Student { Id = 5, Name = "Karan", Course = "CSIT", Grade = 95.7 }
            };

            // Filter students with grade >= 85
            var highAchievers = students.Where(s => s.Grade >= 85)
                                       .OrderByDescending(s => s.Grade);

            Console.WriteLine("\nHigh Achievers (Grade >= 85):");
            foreach (var student in highAchievers)
            {
                Console.WriteLine($"{student.Name} - {student.Course}: {student.Grade}");
            }

            // Group by course and calculate average
            var courseAverages = students.GroupBy(s => s.Course)
                                       .Select(g => new
                                       {
                                           Course = g.Key,
                                           Average = g.Average(s => s.Grade)
                                       });

            Console.WriteLine("\nCourse Averages:");
            foreach (var course in courseAverages)
            {
                Console.WriteLine($"{course.Course}: {course.Average:F2}");
            }
        }
    }
}
