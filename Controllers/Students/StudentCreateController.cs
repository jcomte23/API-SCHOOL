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
    public class StudentCreateController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentCreateController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            await _studentRepository.Add(student);
        
            return Created($"api/students/{student.Id}", student);
        }
    }
}