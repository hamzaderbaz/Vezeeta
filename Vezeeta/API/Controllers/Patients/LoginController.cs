using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Patients.Controllers
{
    [ApiController]
    [Route("api/patients/login")]
    public class LoginController : ControllerBase
    {
        private readonly IPatientAuthService _patientAuthService;

        public LoginController(IPatientAuthService patientAuthService)
        {
            _patientAuthService = patientAuthService ?? throw new ArgumentNullException(nameof(patientAuthService));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] PatientLoginRequestModel model)
        {
            try
            {
                var isLoginSuccessful = await _patientAuthService.PatientLoginAsync(model.Email, model.Password);
                if (isLoginSuccessful)
                    return Ok("Login successful");
                else
                    return Unauthorized("Invalid credentials");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred during login.");
            }
            
        }


    }

    public class PatientLoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
