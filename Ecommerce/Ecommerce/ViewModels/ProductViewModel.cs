using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Ecommerce.ViewModels
{
    public class ProductViewModel
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public Rating Rating { get; set; }
    }
}
