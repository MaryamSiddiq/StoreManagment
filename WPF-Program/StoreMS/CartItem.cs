using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreMS
{
    public class CartItem
    {
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public CartItem(string itemName, decimal price, int quantity)
        {
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
            Total = price * quantity;
        }
    }
}
