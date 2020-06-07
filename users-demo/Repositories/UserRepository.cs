using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using users_demo.Models;

namespace users_demo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection Connection
        {
            get
            {
                var builder = new MySqlConnectionStringBuilder()
                {
                    UserID = "root",
                    Password = ";ZTdtnhns83DfdGAxdz6T]nRFbZf.2b(>g=8k^EbLM2i$ek3hXTod&vV(C264WbU",
                    Server = "127.0.0.1",
                    Database = "users_demo"
                };

                return new MySqlConnection(builder.ConnectionString);
            }
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT id, initials, name FROM users";

                connection.Open();
                var result = await connection.QueryAsync<User>(query);
                return result.AsList();
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT id, initials, name FROM users WHERE id = @id";

                connection.Open();
                var result = await connection.QueryAsync<User>(query, new { id = id });
                return result.FirstOrDefault();
            }
        }
    }
}
