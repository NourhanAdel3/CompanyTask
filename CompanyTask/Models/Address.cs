namespace CompanyTask.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        [MaxLength(100)]
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string PostalCode { get; set; }
        public List<User> UserId { get; set; }
    }
}
