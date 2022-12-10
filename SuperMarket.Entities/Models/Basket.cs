namespace SuperMarket.Entities.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
    }
}