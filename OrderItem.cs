using System;

namespace CafeOrderManagementSystem
{
    public class OrderItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            SetQuantity(quantity);
        }

        public void SetQuantity(int quantity)
        {
            if (quantity > 0)
            {
                Quantity = quantity;
            }
        }

        public decimal GetTotalPrice()
        {
            return Product.Price * Quantity;
        }
    }
}
