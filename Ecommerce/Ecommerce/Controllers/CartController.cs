using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService CartService;
        
        public CartController(ICartService cartService)
        {
            CartService = cartService;
        }

        public IActionResult Index()
        {
            try
            {
                var result = CartService.GetAllCarts();
                return View(result);
            }
            catch(Exception) 
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[controller]/{cartId}")]
        public IActionResult CartById(int cartId)
        {
            try
            {
                var result = CartService.GetCart(cartId);
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
