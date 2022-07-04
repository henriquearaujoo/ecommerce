namespace ECommerce.Test
{
    public class OrderTest
    {
        [Fact]
        public void ShouldNotCreateAnOrderWithInvalidCPF()
        {
            var cpf = "12345643223";
            Assert.Throws<ArgumentException>(() => new Order(cpf));
        }

        [Fact]
        public void ShouldCreateAnOrderWith3Items()
        {
            var order = new Order("98317873234");
            order.AddItem("item 1", (decimal)2.0, 2);
            order.AddItem("item 2", (decimal)4.0, 3);
            order.AddItem("item 3", (decimal)7.0, 5);
            Assert.Equal(3, order.Items.Count);
        }

        [Fact]
        public void ShouldCreateAnOrderWithCoupon()
        {
            var order = new Order("98317873234");
            order.AddItem("item 1", (decimal)2.0, 2);
            order.AddItem("item 2", (decimal)4.0, 3);
            order.AddItem("item 3", (decimal)7.0, 5);
            Assert.Equal(51, order.Total);
            order.ApplyDiscountCoupon("TESTE");
            Assert.Equal((decimal)48.45, order.TotalWithDiscount);
        }
    }
}