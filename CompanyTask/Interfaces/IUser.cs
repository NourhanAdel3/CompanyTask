namespace CompanyTask.Interfaces
{
    public interface IUser
    {
        Task<List<User>> getall(); 
        Task<User> GetById (int id);
        Task<int> addUser (User user);
        Task<int> update(int id,User user);
    }
}
