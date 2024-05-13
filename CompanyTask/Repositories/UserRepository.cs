namespace CompanyTask.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddUser(User user)
        {
            await _context.users.AddAsync(user);
            int result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.users.ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.users.FindAsync(id);
        }
        public async Task<int> Update(int id, User user)
        {
            User user1 = await GetById(id);
            if (user == null)
            {
                return -1;
            }
            else
            {
                user1.Name = user.Name;
                user1.E_Mail = user.E_Mail;
                user1.PhoneNumber = user.PhoneNumber;
                user1.PasswordHash = user.PasswordHash;
                user1.AddressId = user.Id;
            }
            var result = _context.SaveChanges();
            return result;
        }

       
    }
}
