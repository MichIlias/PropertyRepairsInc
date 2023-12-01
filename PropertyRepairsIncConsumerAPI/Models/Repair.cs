namespace PropertyRepairsIncConsumerAPI.Models
{
    public class Repair
    {
        public int Id { get; set; }
        public int HouseId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string Address { get; set; }
        public string TypeOfRepair { get; set; }
        public string ShortDescription { get; set; }

        public House House { get; set; }
    }
}
