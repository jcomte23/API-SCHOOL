using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;

namespace api_school.Services.Students
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student?> GetById(int id);
        Task Add(Student student);
        Task Update(Student student);
        Task<bool> CheckExistence(int id);
    }
}