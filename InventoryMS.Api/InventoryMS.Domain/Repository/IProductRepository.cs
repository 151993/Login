using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMS.Domain
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();

        Product GetProductDetailsById(string productId);

        Task<Product> AddProduct(Product product);

        Task<Product> UpdateProduct(Product product);

    }
}
