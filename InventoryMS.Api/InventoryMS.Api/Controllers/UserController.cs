using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMS.ApplicationServices;
using InventoryMS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Login existing user using user name as email id and password.
        /// </summary>
        /// <param name="userName">credential username</param>
        /// <param name="password">credential password</param>
        /// <returns>Valid user or not</returns>
        [HttpGet]
        [ActionName("Login")]
        public Status Login(string userName, string password)
        {
            return _userService.Login(userName, password);
        }

        /// <summary>
        /// Sign up user. 
        /// if already exist user in to database doesn't allow to insert.
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns>exist user, save success message and failure message</returns>
        [HttpPost]
        [ActionName("AddUser")]
        public async Task<Status> AddUser(UserDto userDto)
        {
            Status status = await _userService.AddUser(userDto);
            return status;
        }

    }
}
