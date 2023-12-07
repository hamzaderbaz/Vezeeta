using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Patients.Controllers
{
    [ApiController]
    [Route("api/patients/cancel-booking")]
    public class CancelBookingController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public CancelBookingController(IPatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            try
            {
                var isCancelled = await _patientService.CancelBookingAsync(bookingId);
                if (isCancelled)
                    return Ok("Booking cancelled successfully");
                else
                    return NotFound("Booking not found");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while cancelling booking.");
            }
            
        }


    }
}
