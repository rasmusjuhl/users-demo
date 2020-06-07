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
    }
}
