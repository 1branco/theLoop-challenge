using Ecommerce.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface ICartService
    {
        Task<IList<Cart>> GetAllCarts(string startDate,
            string endDate,
            string sort);

        Task<Cart> GetCart(int cartId);

        Task<Cart> UpdateCart(Cart cart);

        Task<Cart> CreateNewCart(Cart cart);

        Task<IList<Cart>> GetCartByUserId(int userId);
    }
}
