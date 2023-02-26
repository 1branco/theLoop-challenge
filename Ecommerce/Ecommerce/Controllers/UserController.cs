using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService UserService;
        private readonly IMapper Mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/login")]
        public async Task<IActionResult> Login([FromBody] string username, [FromBody] string password)
        {
            try
            {
                var result = await UserService.Login(new Login() { UserName = "mor_2314", Password = "83r5^_" });
             
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[controller]/allusers")]
        public async Task<IActionResult> AllUsers([FromQuery] string sort = "asc")
        {
            try
            {
                var result = await UserService.GetAllUsers(sort);
                
                return View(Mapper.Map<IList<UserViewModel>>(result));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[controller]/{userId}")]
        public async Task<IActionResult> UserById(int userId)
        {
            try
            {
                var result = await UserService.GetUserById(userId);

                return View(Mapper.Map<UserViewModel>(result));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
