using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSShoppingCart.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get { return Quantity * Price; } }
        public string Image { get; set; }

        public CartItem(Product product)
        {
            this.ProductId = product.Id;
            this.ProductName = product.Name;
            this.Price = product.Price;
            this.Quantity = 1;
            this.Image = product.Image;
        }
    }
}
