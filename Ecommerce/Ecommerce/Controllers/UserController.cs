using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService UserService;
        private readonly ICartService CartService;
        private readonly IMapper Mapper;

        public UserController(IUserService userService, ICartService cartService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
            CartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        [Route("[controller]/login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            try
            {
                var result = await UserService.Login(new Login() { username = login.username, password = login.password });

                var newCart = await CartService.GetCartByUserId(2);

                Response.Cookies.Append("CartId", newCart.OrderByDescending(x => x.Date).
                                                    First().Id.ToString());
                
                return RedirectToAction("Index","Product", null);
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
