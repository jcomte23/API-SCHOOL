using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;
using api_school.Services.Teachers;
using Microsoft.AspNetCore.Mvc;

namespace api_school.Controllers.Teachers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherUpdateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherUpdateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Teacher teacher)
        {
            var teacherFound = await _teacherRepository.CheckExistence(id);
            if (teacherFound == false)
            {
                return NotFound();
            }
            else
            {
                teacher.Id = id;
                await _teacherRepository.Update(teacher);
                return Ok(new { message = "teacher updated successfully" });
            }
        }
    }
}