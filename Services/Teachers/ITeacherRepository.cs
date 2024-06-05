using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;

namespace api_school.Services.Teachers
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAll();
        Task<Teacher?> GetById(int id);
        Task Add(Teacher teacher);
        Task Update(Teacher teacher);
        Task<bool> CheckExistence(int id);
    }
}