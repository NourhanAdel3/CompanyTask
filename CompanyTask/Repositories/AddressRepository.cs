using Microsoft.EntityFrameworkCore;

namespace CompanyTask.Repositories
{
    public class AddressRepository
    {
        private readonly ApplicationDbContext _context;
        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAddress(Address address)
        {
            await _context.addresses.AddAsync(address);
            int result = await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<Address>> GetAll()
        {
            return await _context.addresses.ToListAsync();
        }
        public async Task<Address> GetByAddressId(int id)
        {
            return await _context.addresses.FindAsync(id);
        }
        public async Task<int> UpdateAddress(int id, Address address)
        {
            Address address1 = await GetByAddressId(id);
            if (address == null)
            {
                return -1;
            }
            else
            {
                address1.CityName = address1.CityName;
                address1.RegionName = address1.RegionName;
                address1.PostalCode = address1.PostalCode;
                address1.UserId = address1.UserId;
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}

