using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using users_demo.Models;

namespace users_demo.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserById(int id);
        Task<List<User>> GetAllUsers();
        //TODO: Async CreateUser?
        bool CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
