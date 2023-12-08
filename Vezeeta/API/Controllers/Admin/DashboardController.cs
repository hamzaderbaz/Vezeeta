using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Vezeeta.Core.Interfaces.UseCases;

namespace Vezeeta.API.PresentationLayer.Admin.Controllers
{
    [ApiController]
    [Route("api/admin/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardUseCase _dashboardUseCase;

        public DashboardController(IDashboardUseCase dashboardUseCase)
        {
            _dashboardUseCase = dashboardUseCase ?? throw new ArgumentNullException(nameof(dashboardUseCase));
        }

        [HttpGet("statistics")]
        public async Task<IActionResult> GetStatistics()
        {
            try
            {
                var numOfDoctors = await _dashboardUseCase.GetNumberOfDoctorsAsync();
                var numOfPatients = await _dashboardUseCase.GetNumberOfPatientsAsync();

                var statistics = new
                {
                    NumOfDoctors = numOfDoctors,
                    NumOfPatients = numOfPatients,
                };

                return Ok(statistics);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while fetching statistics.");
            }
            
        }

    }
}
