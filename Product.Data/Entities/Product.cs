using System.Collections.Generic;

namespace Product.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
