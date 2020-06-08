using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using users_demo.Models;
using users_demo.Repositories;

namespace users_demo.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _userRepository.GetAllUsers();

            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            var result = _userRepository.CreateUser(user);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, User user)
        {
            var existingUser = await _userRepository.GetUserById(id);

            if  (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Initials = user.Initials;
            existingUser.Name = user.Name;

            _userRepository.UpdateUser(existingUser);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var existingUser = await _userRepository.GetUserById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(id);

            return Ok();
        }
    }
}
