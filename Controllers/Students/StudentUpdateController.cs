using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;
using api_school.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace api_school.Controllers.Students
{
    [ApiController]
    [Route("api/students")]
    public class StudentUpdateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentUpdateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Student student)
        {
            var studentFound = await _studentRepository.CheckExistence(id);
            if (studentFound == false)
            {
                return NotFound();
            }
            else
            {
                student.Id = id;
                await _studentRepository.Update(student);
                return Ok(new { message = "student updated successfully" });
            }
        }
    }
}