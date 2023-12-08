using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Doctors.Controllers
{
    [ApiController]
    [Route("api/doctors/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings(int doctorId, int page = 1, int pageSize = 10, string search = "")
        {
            try
            {
                var bookings = await _bookingService.GetAllBookingsAsync(doctorId, page, pageSize, search);
                return Ok(bookings);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching bookings.");
            }
            
        }

        [HttpPost("{bookingId}/confirm")]
        public async Task<IActionResult> ConfirmBooking(int bookingId)
        {
            try
            {
                var isConfirmed = await _bookingService.ConfirmBookingAsync(bookingId);
                if (isConfirmed)
                    return Ok("Booking confirmed");
                else
                    return NotFound("Booking not found");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while confirming the booking.");
            }

        }


    }
}
