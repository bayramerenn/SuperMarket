namespace SuperMarket.Core.Dtos
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string ProductType { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}