using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public interface AGIRepairHistoryService
    {
        List<AGRepairHistoryDto> GetByVehicleId(int vehicleId);
    }
}
