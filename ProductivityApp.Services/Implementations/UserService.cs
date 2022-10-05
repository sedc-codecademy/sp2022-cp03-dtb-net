using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProducitivityApp.DataAccess.Interfaces;
using ProductivityApp.Domain.Entities;
using ProductivityApp.Dtos.UserDtos;
using ProductivityApp.Mappers.UserMappers;
using ProductivityApp.Services.Interfaces;
using ProductivityApp.Shared;
using ProductivityApp.Shared.CustomUserExceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ProductivityApp.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AppSettings> _options;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> options)
        {
            _userRepository = userRepository;
            _options = options;
        }

        public async Task<ServiceResponse<string>> LogIn(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var userDb = await _userRepository.GetUserByUsername(username);

            if (userDb == null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if (!VerifyPasswordHash(password, userDb.PasswordHash, userDb.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password";
            }
            else
            {
                response.Data = CreateToken(userDb);
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();

            if(user.Password != user.ConfirmPassword)
            {
                throw new UserDataException("Passwords do not match! Please try again");
            }
            if (await _userRepository.UserExists(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.Add(user);

            response.Data = user.Id;
            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>

            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Role.ToString())
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding
                .UTF8.GetBytes(_options.Value.Token));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            }; // this object gets information needed to create the final token

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token); // final token 
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<List<UserDto>>();

            var usersDb = await _userRepository.GetAll();
            response.Data = usersDb.Select(u => u.ToUserDto()).ToList();
            return response;
        }

        public async Task<ServiceResponse<UserDto>> GetUserById(int id)
        {
            var response = new ServiceResponse<UserDto>();

            var userDb = await _userRepository.GetById(id);
            if (userDb != null)
            {
                response.Data = userDb.ToUserDto();
            }
            else
            {
                response.Success = false;
                response.Message = "Use not found!";
            }
            return response;
        }

        public async Task<ServiceResponse<List<UserDto>>> DeleteUser(int id)
        {
            ServiceResponse<List<UserDto>> response = new ServiceResponse<List<UserDto>>();

            User userDb = await _userRepository.GetById(id);
            if (userDb != null)
            {
                await _userRepository.Delete(userDb);
                var usersDb = await _userRepository.GetAll();
                response.Data = usersDb.Select(u => u.ToUserDto()).ToList();
            }
            else
            {
                response.Success = false;
                response.Message = "User not found!";
            }
            return response;

        }
    }
}
