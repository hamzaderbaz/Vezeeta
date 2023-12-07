using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors(int page = 1, int pageSize = 10, string search = "")
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctorsAsync(page, pageSize, search);
                return Ok(doctors);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching doctors.");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(id);
                if (doctor == null)
                    return NotFound();

                return Ok(doctor);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching the doctor.");
            }
            
        }


    }
}
