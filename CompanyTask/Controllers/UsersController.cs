using CompanyTask.Models;
using CompanyTask.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ConstrainedExecution;


namespace CompanyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        [HttpGet ("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var user = await _context.users.ToListAsync();
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, UserRepository userRepository)
        {
            var User = await userRepository.GetById(id);
            if (User == null)
            {
                return BadRequest($"There is no User with this Id : {id}");
            }
            return Ok(User);
        }

        [HttpPost]
        public async Task<IActionResult> GreateAsync([FromForm] Userdto userDto)
        {
            var User = new User()
            {
                Name = userDto.Name,
                PhoneNumber = userDto.PhoneNumber,
                E_Mail = userDto.E_Mail,
                PasswordHash = userDto.PasswordHash,
                AddressId = userDto.AddressId
            };
             await _context.users.AddAsync(User);
            _context.SaveChanges();
            return Ok(User);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody]int id, [FromQuery] Userdto dto, [FromRoute] UserRepository userRepository)
        {
            var user = new User()
            {
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                E_Mail = dto.E_Mail,
                PasswordHash = dto.PasswordHash,
                AddressId = dto.AddressId
            };
            int result = await userRepository.Update(id, user);
            if (result > 0)
            {
                return Ok(user);
            }
            return BadRequest("SomeThing Wrong !");
        }
    }

}
