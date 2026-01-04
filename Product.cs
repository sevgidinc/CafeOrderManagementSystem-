using System;

namespace CafeOrderManagementSystem
{
    public class Product
    {
        private decimal price;

        public string Name { get; set; }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value > 0)
                {
                    price = value;
                }
            }
        }

        public Product(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return Name + " (" + Price + " TL)";
        }
    }
}


