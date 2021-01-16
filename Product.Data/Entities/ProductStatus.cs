using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Enums;

namespace Product.Data.Entities
{
    public class ProductStatus
    {
        public ProductStatus(ProductStatusEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
        }

        public ProductStatus() { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public static implicit operator ProductStatus(ProductStatusEnum @enum) => new ProductStatus(@enum);

        public static implicit operator ProductStatusEnum(ProductStatus productStatus) => (ProductStatusEnum)productStatus.Id;
    }
}
