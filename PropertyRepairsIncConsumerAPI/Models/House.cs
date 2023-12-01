namespace PropertyRepairsIncConsumerAPI.Models
{
    public class House
    {
        public int Id { get; set; }
        public string FriendlyName { get; set; }
        public string PropertyOwnerDetail { get; set; }
        public string Location { get; set; }
        public DateTime? DateOfAgreement { get; set; }
        public string TypeOfProperty { get; set; }

        public List<Repair> Repairs { get; set; }
    }
}
