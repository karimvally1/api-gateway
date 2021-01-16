namespace Product.Interfaces.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProductStatus Status { get; set; }
    }
}
