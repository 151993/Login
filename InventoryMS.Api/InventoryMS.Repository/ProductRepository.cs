using InventoryMS.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InventoryMS.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly InventoryDBContext _dbcontext;

        public ProductRepository(InventoryDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _dbcontext.Products.ToList().OrderByDescending(x=>x.CreatedDate);
        }

        public Product GetProductDetailsById(string productId)
        {

            Product product = _dbcontext.Products.FirstOrDefault(p => p.ProductId.Equals(productId));

            return product;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _dbcontext.Products.Add(product);
            await _dbcontext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _dbcontext.Entry(product).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();

            return product;
        }
    }
}
