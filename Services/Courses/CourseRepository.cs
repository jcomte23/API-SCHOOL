using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Data;
using api_school.Models;
using Microsoft.EntityFrameworkCore;

namespace api_school.Services.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckExistence(int id)
        {
            return await _context.Courses.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.Include(c => c.Teacher).ToListAsync();
        }

        public async Task<Course?> GetById(int id)
        {
            return await _context.Courses.Include(c => c.Teacher).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}