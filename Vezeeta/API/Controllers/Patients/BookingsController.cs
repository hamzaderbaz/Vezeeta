using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Patients.Controllers
{
    [ApiController]
    [Route("api/patients/bookings")]
    public class BookingsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public BookingsController(IPatientService patientService)
        {
            _patientService = patientService ?? throw new ArgumentNullException(nameof(patientService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            try
            {
                // get bookings for the logged-in patient
                var patientId = GetLoggedInPatientId(); 
                var bookings = await _patientService.GetBookingsForPatientAsync(patientId);
                

                var bookings = new [] { new Booking(), new Booking() }; 
                
                return Ok(bookings);

            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching bookings.");
            }

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
