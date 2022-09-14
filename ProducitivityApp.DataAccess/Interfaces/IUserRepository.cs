using ProducitivityApp.DataAccess.IGenericRepository;
using ProductivityApp.Domain.Entities;
using ProductivityApp.Shared;

namespace ProducitivityApp.DataAccess.Interfaces
{
    public  interface IUserRepository:IGenericRepository<User>
    {

        Task<User> GetUserByUsername(string username);
        Task<bool> UserExists(string userName);  
    }
}
