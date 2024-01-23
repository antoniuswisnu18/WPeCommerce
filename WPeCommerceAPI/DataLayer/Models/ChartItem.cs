namespace WPeCommerceAPI.DataLayer.Models
{
    public class ChartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public decimal SubTotal => Quantity * Product.Price;

    }
}
