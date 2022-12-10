using SuperMarket.Entities.Enums;

namespace SuperMarket.Entities.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public decimal TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}