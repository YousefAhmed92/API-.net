namespace Store.Repo.Basket.Models
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public int? DeliveryMethod { get; set; }
        public decimal ShippingPrice { get; set; }
        public List<BasketItem> basketItems { get; set; } = new List<BasketItem>();
    }
}