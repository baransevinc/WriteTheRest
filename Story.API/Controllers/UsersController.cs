using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Story.Application.Abstract;
using Story.Data.Dto.User;

namespace Story.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(short id)
        {
            var result = await _userService.GetById(id);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(CreateUserDto createUserDto)
        {
            var result = await _userService.AddUser(createUserDto);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
                return BadRequest("UpdateUserDto cannot be null.");

            var result = await _userService.UpdateUser(updateUserDto);
            if (result == null)
                return NotFound("User not found.");

            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(short id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var result = await _userService.DeleteUser(id);
            if (result == null)
                return NotFound("User not found.");

            return Ok(result);
        }
    }
}