using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    public class OrderItem
    {
        public OrderItem(string description, decimal price, int amount)
        {
            Description = description;
            Price = price;
            Amount = amount;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }

    }
}
