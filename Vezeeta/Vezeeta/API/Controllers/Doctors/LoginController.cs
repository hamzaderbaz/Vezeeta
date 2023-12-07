using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Doctors.Controllers
{
    [ApiController]
    [Route("api/doctors/login")]
    public class LoginController : ControllerBase
    {
        private readonly IDoctorAuthService _doctorAuthService;

        public LoginController(IDoctorAuthService doctorAuthService)
        {
            _doctorAuthService = doctorAuthService ?? throw new ArgumentNullException(nameof(doctorAuthService));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] DoctorLoginRequestModel model)
        {
            try
            {
                var isLoginSuccessful = await _doctorAuthService.DoctorLoginAsync(model.Email, model.Password);
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

    public class DoctorLoginRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
