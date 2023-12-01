
using PropertyRepairsIncCommon.DTOs;

namespace PropertyRepairsIncConsumerAPI.Services
{
    public interface IRepairService
    {
        Task ReadAndStoreRepairMessages();
        Task<IEnumerable<RepairDto>> GetAll();
        Task<IEnumerable<RepairDto>> GetRepairForSpecificHouse(int houseId);
        Task StoreNewRepair(RepairDto repairDto);
    }
}