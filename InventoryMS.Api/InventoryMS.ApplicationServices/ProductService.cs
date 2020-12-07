using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper;
using InventoryMS.Domain;

namespace InventoryMS.ApplicationServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            IEnumerable<Product> products = _productRepository.GetAllProducts();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public ProductDto GetProductDetailsById(string productId)
        {
            try
            {
                Product product = _productRepository.GetProductDetailsById(productId);

                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Status> AddProduct(ProductDto productDto)
        {
            try
            {
                Status status = new Status();

                Product productData = _mapper.Map<Product>(productDto);
                CultureInfo cultures = new CultureInfo("en-US");
                productData.Price = Convert.ToDecimal(productData.Price.ToString(cultures));
                productData.AddProduct(productData);
                productData = await _productRepository.AddProduct(productData);
                if (productData != null)
                {
                    return status = new Status() { IsSuccess = true, SuccessMessage = "Data saved successfully" };
                }
                else
                {
                    return status = new Status() { IsSuccess = true, ErrorMessage = "Something went wrong" };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Status> UpdateProduct(ProductDto productDto)
        {
            try
            {
                Status status = new Status();
                Product product = _productRepository.GetProductDetailsById(productDto.ProductId);
                if (product != null)
                {
                    productDto.CreatedDate = product.CreatedDate;
                    product.UpdateProduct(productDto);
                    product = await _productRepository.UpdateProduct(product);

                    if (product != null)
                    {
                        return status = new Status() { IsSuccess = true, SuccessMessage = "Data updated successfully" };
                    }
                    else
                    {
                        return status = new Status() { IsSuccess = true, ErrorMessage = "Something went wrong" };
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
    }
}
