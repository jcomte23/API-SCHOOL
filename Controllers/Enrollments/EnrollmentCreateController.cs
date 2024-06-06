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
    public class EnrollmentCreateController : ControllerBase
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentCreateController(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Enrollment enrollment)
        {
            await _enrollmentRepository.Add(enrollment);
            MailController Email = new MailController();
            Email.SendEmail("javiercombita2014@gmail.com");
            return Created($"api/enrollments/{enrollment.Id}", enrollment);
        }
    }
}