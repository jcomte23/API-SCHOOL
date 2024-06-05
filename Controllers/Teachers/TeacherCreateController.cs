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
    public class TeacherCreateController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherCreateController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Teacher teacher)
        {
            await _teacherRepository.Add(teacher);

            return Created($"api/teachers/{teacher.Id}", teacher);
        }
    }
}