using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;
using api_school.Services.Courses;
using api_school.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace api_school.Controllers.Teachers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;

        public TeachersController(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Teacher>> GetTeachers()
        {
            return await _teacherRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _teacherRepository.GetById(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpGet("{id}/courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByTeacherId(int id)
        {
            var allCourses = await _courseRepository.GetAll();
            var teacherCourses = allCourses.Where(c => c.TeacherId == id).ToList();
            if (!teacherCourses.Any())
            {
                return NotFound(new { message = $"No courses found for teacher with ID {id}." });
            }
            return Ok(teacherCourses);
        }
    }
}