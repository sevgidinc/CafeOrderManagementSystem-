using System;
using System.Collections.Generic;

namespace CafeOrderManagementSystem
{
    public class Order
    {
        public Customer Customer { get; private set; }
        public DateTime OrderDate { get; private set; }

        private List<OrderItem> items;

        public Order(Customer customer)
        {
            Customer = customer;
            OrderDate = DateTime.Now;
            items = new List<OrderItem>();
        }

        public void AddItem(Product product, int quantity)
        {
            OrderItem item = new OrderItem(product, quantity);
            items.Add(item);
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;

            foreach (OrderItem item in items)
            {
                total += item.GetTotalPrice();
            }

            return total;
        }

        public List<OrderItem> GetItems()
        {
            return items;
        }
    }
}
