namespace CompanyTask.Dtos
{
    public class Addressdto
    {
        [MaxLength (100)]
        public string CityName { get; set; }
        public string RegionName { get; set; }
        public string PostalCode { get; set; }
        public int UserId { get; set; }    

    }
}
