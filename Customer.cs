using System;

namespace CafeOrderManagementSystem
{
    public class Customer
    {
        public string Name { get; set; }
        public string PhoneNumber { get; private set; }

        public Customer(string name, string phoneNumber)
        {
            Name = name;
            SetPhoneNumber(phoneNumber);
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                PhoneNumber = phoneNumber;
            }
        }
        public override string ToString()
        {
            return Name + " - " + PhoneNumber;
        }
    }
}


