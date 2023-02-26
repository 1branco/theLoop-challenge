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
    public class CartController : Controller
    {
        private readonly ICartService CartService;
        private readonly IMapper Mapper;
        
        public CartController(ICartService cartService, IMapper mapper)
        {
            CartService = cartService;
            Mapper = mapper;
        }

        [HttpGet]
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


        [HttpGet]
        [Route("[controller]/user/{userId}")]
        public async Task<IActionResult> CartByUserId(int userId)
        {
            try
            {
                var result = await CartService.GetCartByUserId(userId);

                return View(Mapper.Map<IList<CartViewModel>>(result));
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpGet]
        public IActionResult NewCart(int userId, List<ProductViewModel> products)
        {
            try
            {
                var mappedProducts = Mapper.Map<IList<Product>>(products);

                var result = CartService.CreateNewCart(userId, mappedProducts);
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]
        public IActionResult AddToCart(int productId)
        {
            try
            {
                //var result = CartService.(cartId);
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut]
        [Route("[controller]/{cartId}")]
        public IActionResult UpdateCart(IList<Product> products)
        {
            try
            {
                Cart cart = new Cart();

                var result = CartService.UpdateCart(cart);
                return View(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
