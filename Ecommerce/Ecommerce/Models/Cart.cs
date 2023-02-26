using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Ecommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public IList<CartProduct> Products { get; set; }
        public int __v { get; set; }
    }

    public class CartProduct
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
