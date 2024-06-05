using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Data;
using api_school.Models;
using Microsoft.EntityFrameworkCore;

namespace api_school.Services.Enrollments
{
    public class EnrollmentRespository : IEnrollmentRepository
    {
        private readonly ApplicationDbContext _context;

        public EnrollmentRespository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistence(int id)
        {
            return await _context.Enrollments.AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _context.Enrollments.ToListAsync();
        }

        public async Task<Enrollment?> GetById(int id)
        {
            return await _context.Enrollments.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Enrollment enrollment)
        {
            _context.Entry(enrollment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}