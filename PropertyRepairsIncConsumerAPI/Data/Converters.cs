using PropertyRepairsIncCommon.DTOs;
using PropertyRepairsIncConsumerAPI.Models;
using System.Runtime.CompilerServices;

namespace PropertyRepairsIncConsumerAPI.Data
{
    public static class Converters
    {
        public static HouseDto ConvertToHouseDto(this House house)
        {
            return new HouseDto()
            {
                Id = house.Id,
                FriendlyName = house.FriendlyName,
                PropertyOwnerDetail = house.PropertyOwnerDetail,
                Location = house.Location,
                DateOfAgreement = house.DateOfAgreement,
                TypeOfProperty = house.TypeOfProperty,
            };
        }

        public static Repair ConvertToRepair(this RepairDto repairDto)
        {
            return new Repair()
            {
                Id = repairDto.Id,
                TimeStamp = repairDto.TimeStamp,
                CustomerName = repairDto.CustomerName,
                CustomerEmail = repairDto.CustomerEmail,
                Address = repairDto.Address,
                TypeOfRepair = repairDto.TypeOfRepair,
                ShortDescription = repairDto.ShortDescription
            };
        }

        public static RepairDto ConvertToRepairDto(this Repair repair)
        {
            return new RepairDto()
            {
                Id = repair.Id,
                TimeStamp = repair.TimeStamp,
                CustomerName = repair.CustomerName,
                CustomerEmail = repair.CustomerEmail,
                Address = repair.Address,
                TypeOfRepair = repair.TypeOfRepair,
                ShortDescription = repair.ShortDescription
            };
        }
    }
}
