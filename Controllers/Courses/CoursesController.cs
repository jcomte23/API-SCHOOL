using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;
using api_school.Services.Courses;
using Microsoft.AspNetCore.Mvc;

namespace api_school.Controllers.Courses
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await _courseRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseRepository.GetById(id);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }
    }
}