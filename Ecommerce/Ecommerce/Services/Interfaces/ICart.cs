using Ecommerce.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface ICartService
    {
        Task<IList<Cart>> GetAllCarts();

        Task<Cart> GetCart(int cartId);

        Task<Cart> UpdateCart(Cart cart);

        Task<Cart> CreateNewCart(int userId, IList<Product> products);

        Task<IList<Cart>> GetCartByUserId(int userId);
    }
}
