using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Patients.Controllers
{
    [ApiController]
    [Route("api/patients/registration")]
    public class RegistrationController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public RegistrationController(IPatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(PatientRegistrationRequestModel model)
        {
            try
            {
                var isSuccess = await _patientService.RegisterPatientAsync(model);
                if (isSuccess)
                    return Ok("Patient registered successfully");
                else
                    return BadRequest("Failed to register patient");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while registering patient.");
            }

        }


    }

    public class PatientRegistrationRequestModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
