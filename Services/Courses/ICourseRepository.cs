using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;

namespace api_school.Services.Courses
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course?> GetById(int id);
        Task Add(Course course);
        Task Update(Course course);
        Task<bool> CheckExistence(int id);
    }
}