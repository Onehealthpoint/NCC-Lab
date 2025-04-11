using System.Collections.Generic;
using Set2_API.Models;

namespace Set2_API.Services
{
    public interface IStudentService
    {
        List<StudentModel> GetAllStudents();
    }

    public class StudentService : IStudentService
    {
        private List<StudentModel> _students = new List<StudentModel>
        {
            new StudentModel { Id = 1, Name = "Hari Ram", Grade = "A" },
            new StudentModel { Id = 2, Name = "Jin Pun", Grade = "B" },
            new StudentModel { Id = 3, Name = "Sani Rai", Grade = "C" }
        };
        public List<StudentModel> GetAllStudents()
        {
            return _students;
        }
    }
}
