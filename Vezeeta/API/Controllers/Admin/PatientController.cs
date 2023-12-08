using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/patients")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients(int page = 1, int pageSize = 10, string search = "")
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync(page, pageSize, search);
                return Ok(patients);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching patients.");
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);
                if (patient == null)
                    return NotFound();

                return Ok(patient);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching the patient.");
            }

        }


    }
}
