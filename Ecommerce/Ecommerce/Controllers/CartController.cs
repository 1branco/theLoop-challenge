using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Services;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService CartService;
        private readonly IProductService ProductService;
        private readonly IMapper Mapper;
        
        public CartController(ICartService cartService,IProductService productService,
            IMapper mapper)
        {
            CartService = cartService;
            Mapper = mapper;
            ProductService= productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string startDate = "", 
                                                [FromQuery] string endDate = "",
                                                [FromQuery] string sort = "asc")
        {
            try
            {
                var result = await CartService.GetAllCarts(startDate, endDate, sort);

                return View(Mapper.Map<IList<CartViewModel>>(result));
            }
            catch(Exception) 
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[controller]/{cartId}")]
        public async Task<IActionResult> CartById(int cartId)
        {
            try
            {
                var result = await CartService.GetCart(cartId);
                return View(Mapper.Map<CartViewModel>(result));
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

        [HttpPost]
        public async Task<IActionResult> NewCart(Cart cart)
        {
            try
            {
                var result = await CartService.CreateNewCart(new Cart());

                return View(Mapper.Map<CartViewModel>(result));
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        [Route("[controller]/updatecart")]
        public async Task<IActionResult> UpdateCart(int productId)
        {
            try
            {
                var cartId = Request.Cookies["CartId"];

                var cart = await CartService.GetCart(int.Parse(cartId));

                if(cart.Products == null)
                {
                    cart.Products = new List<CartProduct>();
                }

                cart.Products.Add(new CartProduct() { ProductId = productId, Quantity = 1});
                
                var result = await CartService.UpdateCart(cart);
                
                return View(new CartViewModel() { 
                                Date = cart.Date, 
                                UserId = cart.UserId, 
                                Products =  result.Products});
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
