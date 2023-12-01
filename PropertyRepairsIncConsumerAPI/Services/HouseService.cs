using Microsoft.EntityFrameworkCore;
using PropertyRepairsIncCommon.DTOs;
using PropertyRepairsIncConsumerAPI.Data;
using PropertyRepairsIncConsumerAPI.Models;

namespace PropertyRepairsIncConsumerAPI.Services
{
    public class HouseService : IHouseService
    {
        private readonly PropertyRepairsDbContext _context;
        private readonly ILogger<HouseService> _logger;

        public HouseService(PropertyRepairsDbContext context, ILogger<HouseService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<HouseDto>> GetAllHouses()
        {
            _logger.LogInformation("Got a request to return all houses");
            List<House> list = await _context.Houses.ToListAsync();

            _logger.LogInformation("Have retreived {n} houses", list.Count);

            List<HouseDto> houses = new List<HouseDto>();
            foreach (House item in list)
            {
                houses.Add(item.ConvertToHouseDto());
            }

            return houses;
        }

        public async Task<HouseDto?> GetHouseByAddress(string address)
        {
            
            List<House> list = await _context.Houses.Where(h => h.Location == address).ToListAsync();

            if (list.Count > 0)
                return list[0].ConvertToHouseDto();
            else
                return null;
        }

        public async Task<IEnumerable<HouseDto>> GetHousesBy(HouseSearch houseSearch)
        {
            string location = houseSearch.Location;
            string typeOfProperty = houseSearch.TypeOfProperty;
            _logger.LogInformation("Got a request to return houses");
            List<House> list = await _context.Houses.ToListAsync();

            _logger.LogInformation("Have retreived {n} houses", list.Count);

            List<HouseDto> houses = new List<HouseDto>();
            foreach (House item in list)
            {
                if (!String.IsNullOrEmpty(location) && item.Location != location)
                    continue;
                if (!String.IsNullOrEmpty(typeOfProperty) && item.TypeOfProperty != typeOfProperty)
                    continue;
                houses.Add(item.ConvertToHouseDto());
            }

            return houses;
        }
    }
}
