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
    [Route("api/courses")]
    public class CourseCreateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseCreateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            await _courseRepository.Add(course);
            return Created($"api/courses/{course.Id}", course);
        }
    }
}