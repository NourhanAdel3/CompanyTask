namespace CompanyTask.Dtos
{
    public class Userdto

    {
        [MaxLength(100)]
        public string Name { get; set; }
        public String PhoneNumber { get; set; }
        public string E_Mail { get; set; }
        public String PasswordHash { get; set; }
        public int AddressId { get; set; }
    }
}
