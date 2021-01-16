namespace Product.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductStatus Status { get; set; }
    }
}
