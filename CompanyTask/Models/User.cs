using System.Collections.Specialized;
using System.Data;

namespace CompanyTask.Models
{
    public class User 
    {
        public int Id { get; set; }

       [MaxLength(100)]
        public string Name { get; set; }
        public String PhoneNumber { get; set; }
        public string E_Mail { get; set; }
        public String PasswordHash { get; set; }
        public int AddressId { get; set; }
       
    }
}
