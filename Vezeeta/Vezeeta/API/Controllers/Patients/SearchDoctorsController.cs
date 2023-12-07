using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Patients.Controllers
{
    [ApiController]
    [Route("api/patients/search/doctors")]
    public class SearchDoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public SearchDoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        [HttpGet]
        public async Task<IActionResult> SearchDoctors(int page = 1, int pageSize = 10, string search = "", int timeId = 0, string discountCodeCoupon = "")
        {
            try
            {
                var doctors = await _doctorService.SearchDoctorsAsync(page, pageSize, search, timeId, discountCodeCoupon);
                return Ok(doctors);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while searching doctors.");
            }
            
        }


    }
}
