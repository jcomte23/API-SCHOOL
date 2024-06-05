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
    public class CourseUpdateController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CourseUpdateController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Course course)
        {
            var courseFound = await _courseRepository.CheckExistence(id);
            if (courseFound == false)
            {
                return NotFound();
            }
            else
            {
                course.Id = id;
                await _courseRepository.Update(course);
                return Ok(new { message = "course updated successfully" });
            }
        }
    }
}