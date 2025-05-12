using BlogSys.DTO;
using BlogSys.Models;
using BlogSys.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace BlogSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;

        public UsersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                FullName = dto.FullName
            };
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO dto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            user.Username = dto.Username;
            user.Email = dto.Email;
            user.FullName = dto.FullName;
            
            if (id != user.UserId) return BadRequest();
            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return NotFound();
            _userRepository.Delete(user);
            await _userRepository.SaveChangesAsync();
            return NoContent();
        }
    }

}
