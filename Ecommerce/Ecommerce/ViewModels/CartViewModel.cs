using Ecommerce.Models;
using System.Collections.Generic;

namespace Ecommerce.ViewModels
{
    public class CartViewModel
    {
        public int UserId { get; set; }
        public string Date { get; set; }
        public IList<CartProduct> Products { get; set; }
    }
}
