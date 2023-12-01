using PropertyRepairsIncCommon.DTOs;

namespace PropertyRepairsIncConsumerAPI.Services
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseDto>> GetAllHouses();

        Task<IEnumerable<HouseDto>> GetHousesBy(HouseSearch houseSearch);
    }
}