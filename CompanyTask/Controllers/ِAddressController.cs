using CompanyTask.Models;
using CompanyTask.Repositories;
using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }
            private readonly GoogleLocationService _locationService;

            [HttpPost]
        public async Task<IActionResult> GreateAsync([FromForm] Addressdto addressdto)
        {
            var Address = new Address()
            {
                CityName = addressdto.CityName,
                RegionName = addressdto.RegionName,
                PostalCode = addressdto.PostalCode,

            };
            await _context.addresses.AddAsync(Address);
            _context.SaveChanges();
            return Ok(Address);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var Address = await _context.addresses.ToListAsync();
            return Ok(Address);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByAddressId(int id, AddressRepository addressRepository)
        {
            var Address = await addressRepository.GetByAddressId(id);
            if (User == null)
            {
                return BadRequest($"There is no Address with this Id : {id}");
            }
            return Ok(Address);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] int id, [FromQuery] Addressdto dto, [FromRoute] AddressRepository addressRepository)
        {
            var Address = new Address()
            {
                CityName = dto.CityName,
                RegionName = dto.RegionName,
                PostalCode = dto.PostalCode,
            };
            int result = await addressRepository.UpdateAddress(id, Address);
            if (result > 0)
            {
                return Ok(Address);
            }
            return BadRequest("SomeThing Wrong !");
        }
    }
}
