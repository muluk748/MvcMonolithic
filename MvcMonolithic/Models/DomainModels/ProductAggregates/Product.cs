namespace MvcMonolithic.Models.DomainModels.ProductAggregates
{
    public class Product//a class of product .what information we need for a product.
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}

