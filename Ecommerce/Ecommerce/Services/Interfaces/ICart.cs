using Ecommerce.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface ICartService
    {
        Task<IList<Cart>> GetAllCarts();

        Task<Cart> GetCart(int Id);

        bool UpdateCart(Cart cart);

    }
}
