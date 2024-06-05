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
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeachersController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
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
    }
}