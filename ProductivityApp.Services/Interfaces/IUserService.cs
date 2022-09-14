using ProductivityApp.Domain.Entities;
using ProductivityApp.Dtos.UserDtos;
using ProductivityApp.Shared;

namespace ProductivityApp.Services.Interfaces
{
    public  interface IUserService
    {
        Task<ServiceResponse<int>> Register(User user, string password);

        Task<ServiceResponse<string>> LogIn(string username, string password);
        Task<ServiceResponse<List<UserDto>>> GetAllUsers();

        Task<ServiceResponse<UserDto>> GetUserById(int id);

        Task<ServiceResponse<List<UserDto>>> DeleteUser(int id);
    }
}
