namespace ECommerce
{
    internal class Coupon
    {
        public Coupon(string name, double percentage)
        {
            Name = name;
            Percentage = percentage;
        }

        public string Name { get; set; }
        public double Percentage { get; set; }
    }
}