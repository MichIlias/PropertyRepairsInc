using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRepairsIncCommon.DTOs
{
    public class RepairDto
    {
        public int Id { get; set; }
        //public int HouseId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Address { get; set; }
        public string TypeOfRepair { get; set; }
        public string ShortDescription { get; set; }
    }
}
