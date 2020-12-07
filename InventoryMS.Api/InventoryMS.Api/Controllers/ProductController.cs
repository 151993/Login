using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryMS.ApplicationServices;
using InventoryMS.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryMS.Api.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get all product list starting from displaying with latest one.
        /// </summary>
        /// <returns>list of products</returns>
        [HttpGet]
        [ActionName("GetAllProduct")]
        public IEnumerable<ProductDto> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        /// <summary>
        /// Get product details for unique product.
        /// </summary>
        /// <param name="productId">product Id</param>
        /// <returns>product details</returns>
        [HttpGet]
        [ActionName("GetProductById")]
        public ProductDto GetProductById(string productId)
        {
            return _productService.GetProductDetailsById(productId);
        }

        /// <summary>
        /// Create new product and save in database.
        /// </summary>
        /// <param name="product">product object dto</param>
        /// <returns>status of product details added message</returns>
        [HttpPost]
        [ActionName("SaveProduct")]
        public async Task<ActionResult<Status>> AddProduct([FromBody] ProductDto product)
        {
            if (ModelState.IsValid)
            {
                Status status = await _productService.AddProduct(product);
                return status;
            }

            return BadRequest("Bad request");
        }

        /// <summary>
        /// Update product by product id.
        /// </summary>
        /// <param name="productDto">Product object dto</param>
        /// <returns>status of product details updated</returns>
        [HttpPut]
        [ActionName("UpdateProduct")]
        public async Task<ActionResult<Status>> UpdateProduct([FromBody] ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                return await _productService.UpdateProduct(productDto);
            }
            return BadRequest("Bad request");
        }
    }
}
