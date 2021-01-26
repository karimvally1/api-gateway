namespace Product.Service.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Category[] Categories { get; set; }
    }
}
