using Ecommerce.Models;
using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService UserService;

        public UserController(IUserService userService)
        {
            UserService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("[controller]/login")]
        public async Task<IActionResult> Login()
        {
            try
            {
                var result = await UserService.Login(new Login() { UserName = "mor_2314", Password = "83r5^_" });
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            try
            {
                var result = await UserService.GetAllUsers();
                return View();
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
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
