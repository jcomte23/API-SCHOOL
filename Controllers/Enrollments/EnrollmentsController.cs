using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_school.Models;
using api_school.Services.Enrollments;
using Microsoft.AspNetCore.Mvc;

namespace api_school.Controllers.Enrollments
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentsController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Enrollment>> GetEnrollments()
        {
            return await _enrollmentRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id)
        {
            var enrollment = await _enrollmentRepository.GetById(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return Ok(enrollment);
        }

        [HttpGet("{date}/date")]
        public async Task<ActionResult<IEnumerable<Enrollment>>> GetAppointmentsByDate(string date)
        {
            // Parse the date string to DateOnly
            if (!DateOnly.TryParse(date, out DateOnly parsedDate))
            {
                return BadRequest("Invalid date format. Please use yyyy-MM-dd.");
            }

            var allEnrollments = await _enrollmentRepository.GetAll();
            var enrollmentsByDate = allEnrollments.Where(e => e.Date == parsedDate).ToList();

            return Ok(enrollmentsByDate);
        }
    }
}