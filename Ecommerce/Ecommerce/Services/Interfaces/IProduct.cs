using Ecommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        Task<IList<Product>> GetAllProducts();
        Task<Product> GetProductById(int Id);


        Task<IList<Category>> GetAllCategories();
        Task<IList<Product>> GetProductsByCategory(string categoryName);

    }
}
