using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Enums;

namespace Product.Data.Entities
{
    public class Category
    {
        public Category(CategoryEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public Category() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public static implicit operator Category(CategoryEnum @enum) => new Category(@enum);

        public static implicit operator CategoryEnum(Category category) => (CategoryEnum)category.Id;

    }
}
