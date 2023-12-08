using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Entities;
using Vezeeta.Core.Interfaces.Services;

namespace Vezeeta.API.PresentationLayer.Doctors.Controllers
{
    [ApiController]
    [Route("api/doctors/settings")]
    public class SettingController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public SettingController(IDoctorService doctorService)
        {
            _doctorService = doctorService ?? throw new ArgumentNullException(nameof(doctorService));
        }

        [HttpPost]
        public async Task<IActionResult> AddAppointment(DoctorAppointmentRequestModel model)
        {
            try
            {
                var isSuccess = await _doctorService.AddAppointmentAsync(model);
                if (isSuccess)
                    return Ok("Appointment added successfully");
                else
                    return BadRequest("Failed to add appointment");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding appointment.");
            }

        }

        [HttpPut("{appointmentId}")]
        public async Task<IActionResult> UpdateAppointment(int appointmentId, DoctorAppointmentRequestModel model)
        {
            try
            {
                var isSuccess = await _doctorService.UpdateAppointmentAsync(appointmentId, model);
                if (isSuccess)
                    return Ok("Appointment updated successfully");
                else
                    return NotFound("Appointment not found");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating appointment.");
            }

        }

        [HttpDelete("{appointmentId}")]
        public async Task<IActionResult> DeleteAppointment(int appointmentId)
        {
            try
            {
                var isSuccess = await _doctorService.DeleteAppointmentAsync(appointmentId);
                if (isSuccess)
                    return Ok("Appointment deleted successfully");
                else
                    return NotFound("Appointment not found");
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting appointment.");
            }
            
        }


    }

    public class DoctorAppointmentRequestModel
    {
        // example
        public int DoctorId { get; set; }
        public List<DayModel> Days { get; set; }

    }

    public class DayModel
    {
        // example
        public int DayOfWeek { get; set; }
        public List<string> TimeSlots { get; set; }

    }
}
