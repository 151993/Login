using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using InventoryMS.Common;

namespace InventoryMS.Domain
{
    [Table("Product")]
    public class Product: CommonFields
    {
        [Key]
        public string ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Product() { }

        public void AddProduct(Product product)
        {
            ProductId =string.IsNullOrEmpty(product.ProductId) ? ProductId.GenerateGuid() : product.ProductId;
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            CreatedDate = DateTime.Now.Date;
            CreatedBy = "Admin";
            // UpdatedDate = string.IsNullOrEmpty(product.ProductId) ? DateTime.Now.Date : System.DBNull ;
        }

        public void UpdateProduct(ProductDto product)
        {
            Name = product.Name;
            Price = product.Price;
            Quantity = product.Quantity;
            UpdatedDate = DateTime.Now.Date;
            UpdatedBy = "Admin";
        }

    }


}
