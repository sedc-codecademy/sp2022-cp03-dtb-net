using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductivityApp.Domain.Entities;
using ProductivityApp.Dtos.UserDtos;
using ProductivityApp.Services.Interfaces;
using ProductivityApp.Shared;
using ProductivityApp.Shared.ServerExceptions;

namespace ProductivityApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterUserDto request)
        {
            var response = await _userService.Register(
                new User { UserName = request.UserName, FullName = request.FullName }, request.Password
                );

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(LoginUserDto request)
        {
            var response = await _userService.LogIn(request.UserName, request.Password);


            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("getAll")]

        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> Get()
        {
            try
            {
                return Ok(await _userService.GetAllUsers());
            }
            catch (InternalServerException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<UserDto>>> GetSingle(int id)
        {
            try
            {
                return Ok(await _userService.GetUserById(id));
            }
            catch (InternalServerException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<UserDto>>>> Delete(int id)
        {
            try
            {
                var response = await _userService.DeleteUser(id);
                if (response.Data == null)
                {
                    return NotFound(response);
                }

                return Ok(response);
            }
            catch (InternalServerException e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
