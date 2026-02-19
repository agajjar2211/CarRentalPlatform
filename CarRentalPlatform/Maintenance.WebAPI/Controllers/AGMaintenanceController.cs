using Microsoft.AspNetCore.Mvc;
using Maintenance.WebAPI.Services;

namespace Maintenance.WebAPI.Controllers
{
    [ApiController]
    [Route("api/maintenance")]
    public class AGMaintenanceController : ControllerBase
    {
        private readonly AGIRepairHistoryService _service;

        public AGMaintenanceController(AGIRepairHistoryService service)
        {
            _service = service;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public IActionResult GetRepairHistory(int vehicleId)
        {
            var history = _service.GetByVehicleId(vehicleId);
            return Ok(history);
        }
    }
}