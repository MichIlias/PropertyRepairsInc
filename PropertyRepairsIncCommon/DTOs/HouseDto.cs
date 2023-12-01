using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRepairsIncCommon.DTOs
{
    public class HouseDto
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }
        public string PropertyOwnerDetail { get; set; }
        public string Location { get; set; }
        public DateTime? DateOfAgreement { get; set; }
        public string TypeOfProperty { get; set; }
    }
}
