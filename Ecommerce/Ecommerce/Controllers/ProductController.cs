using AutoMapper;
using Ecommerce.Services.Interfaces;
using Ecommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService ProductService;
        private readonly IMapper Mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            ProductService = productService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] string sort = "asc",
                                               [FromQuery] int limit = 25)
        {
            try
            {
                var products = await ProductService.GetAllProducts(sort, limit);
                            
                return View(Mapper.Map<IList<ProductViewModel>>(products));
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<IActionResult> ProductById(int id)
        {
            try
            {
                var product = await ProductService.GetProductById(id);

                return View(Mapper.Map<ProductViewModel>(product));
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("[controller]/allcategories")]
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
