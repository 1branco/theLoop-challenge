using System.Collections.Generic;

namespace Ecommerce.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Date { get; set; }
        public List<Product> Products { get; set; }
    }
}
