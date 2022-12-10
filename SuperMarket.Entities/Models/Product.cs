namespace SuperMarket.Entities.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}