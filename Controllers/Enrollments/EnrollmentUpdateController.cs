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
    [Route("api/enrollments")]
    public class EnrollmentUpdateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentUpdateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Enrollment enrollment)
        {
            var enrollmentFound = await _enrollmentRepository.CheckExistence(id);
            if (enrollmentFound == false)
            {
                return NotFound();
            }
            else
            {
                enrollment.Id = id;
                await _enrollmentRepository.Update(enrollment);
                return Ok(new { message = "enrollment updated successfully" });
            }
        }

    }
}