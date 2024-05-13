namespace CompanyTask.Interfaces
{
    public interface IAddress
    {
        Task<int> addAddress(Address address);
        Task <List<Address>> GetAll();
        Task<int> getbyAddressId(int id);
        Task<int> UpdateAddress(int id, Address address);



    }
}
