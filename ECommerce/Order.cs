using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce
{
    public class Order
    {
        private readonly string cpf;
        private readonly List<OrderItem> items;
        private readonly List<Coupon> coupons;

        public Order(string cpf)
        {
            if (!CpfValidator.IsValid(cpf))
                throw new ArgumentException("Invalid CPF");

            this.cpf = cpf;
            items = new List<OrderItem>();
            coupons = new List<Coupon>() { new Coupon("TESTE", 5) };
        }

        public ImmutableList<OrderItem> Items 
        { 
            get 
            {
                return ImmutableList.CreateRange(items);
            } 
        }
        public decimal Total { get; private set; }
        public decimal TotalWithDiscount { get; private set; }

        public void AddItem(string description, decimal price, int amount)
        {
            items.Add(new OrderItem(description, price, amount));
            Total += price * amount;
            TotalWithDiscount = 0;
        }

        public void ApplyDiscountCoupon(string couponName)
        {
            var coupon = coupons.FirstOrDefault(o => o.Name == couponName);

            if (coupon is null)
                throw new ArgumentException("Coupon not found");

            TotalWithDiscount = Total - (Total * (decimal)(coupon.Percentage / 100));
        }
    }
}
