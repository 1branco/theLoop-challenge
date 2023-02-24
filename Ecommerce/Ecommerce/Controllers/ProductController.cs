﻿using Ecommerce.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        public ProductController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await ProductService.GetAllProducts();
            
                return View(products);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult ProductById(int id)
        {
            try
            {
                var product = ProductService.GetProductById(id);

                return View(product);
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> CategoriesList()
        {
            try
            {
                var product = await ProductService.GetAllCategories();

                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [Route("[controller]/bycategory/{categoryName}")]
        [HttpGet]
        public async Task<IActionResult> ProductsByCategory(string categoryName)
        {
            try
            {
                var product = await ProductService.GetProductsByCategory(categoryName);

                return View(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}