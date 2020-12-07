using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InventoryMS.Domain;

namespace InventoryMS.ApplicationServices
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProductDetailsById(string productId);

        Task<Status> AddProduct(ProductDto product);

        Task<Status> UpdateProduct(ProductDto productDto);

    }
}
