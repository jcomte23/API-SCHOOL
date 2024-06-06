using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;
using api_school.Services.Enrollments;
using api_school.Services.Students;
using Microsoft.AspNetCore.Mvc;

namespace api_school.Controllers.Students
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IEnrollmentRepository _enrollmentRepository;

        public StudentsController(IStudentRepository studentRepository, IEnrollmentRepository enrollmentRepository)
        {
            _studentRepository = studentRepository;
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _studentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _studentRepository.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpGet("{id}/enrollments")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetEnrollments(int id)
        {
            var enrollments = await _enrollmentRepository.GetAll();
            enrollments = enrollments.Where(e => e.StudentId == id).ToList();
            if (!enrollments.Any())
            {
                return NotFound(new { message = $"No enrollments found for student with ID {id}." });
            }
            return Ok(enrollments);
        }

        [HttpGet("{date}/birthday")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByBirthday(string date)
        {
            // Parse the date string to DateOnly
            if (!DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                return BadRequest("Invalid date format. Please use yyyy-MM-dd.");
            }

            var allStudents = await _studentRepository.GetAll();
            var studentsByDate = allStudents.Where(s => s.Birthdate == parsedDate).ToList();

            return Ok(studentsByDate);
        }

    }
}