using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMS.Domain
{
    public class ProductDto: CommonFields
    {
        public string ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
