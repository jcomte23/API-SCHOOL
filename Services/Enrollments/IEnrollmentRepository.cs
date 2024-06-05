using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;

namespace api_school.Services.Enrollments
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment?> GetById(int id);
        Task Add(Enrollment enrollment);
        Task Update(Enrollment enrollment);
        Task<bool> CheckExistence(int id);
    }
}