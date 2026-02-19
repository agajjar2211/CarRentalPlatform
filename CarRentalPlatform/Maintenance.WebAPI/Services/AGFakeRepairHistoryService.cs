using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public class AGFakeRepairHistoryService : AGIRepairHistoryService
    {
        public AGRepairHistoryDto AddRepair(AGRepairHistoryDto repair)
        {
            return new AGRepairHistoryDto
            {
                Id = new Random().Next(1000, 9999),
                VehicleId = repair.VehicleId,
                RepairDate = repair.RepairDate,
                Description = repair.Description,
                Cost = repair.Cost,
                PerformedBy = repair.PerformedBy
            };

        }

        public List<AGRepairHistoryDto> GetByVehicleId(int vehicleId)
        {
            return new List<AGRepairHistoryDto>
            {
                new AGRepairHistoryDto
                {
                    Id = 1,
                    VehicleId = vehicleId,
                    RepairDate = DateTime.Now.AddDays(-10),
                    Description = "Oil change",
                    Cost = 89.99m,
                    PerformedBy = "Quick Lube"
                },
                new AGRepairHistoryDto
                {
                    Id = 2,
                    VehicleId = vehicleId,
                    RepairDate = DateTime.Now.AddDays(-40),
                    Description = "Brake pad replacement",
                    Cost = 350.00m,
                    PerformedBy = "Auto Repair Pro"
                }
            };
        }
    }
}
