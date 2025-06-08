using TDD_Architecture.Domain.Entities.Base;

namespace TDD_Architecture.Domain.Entities.Products
{
    public class ProductType : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Product> Product { get; set; }

        public ProductType()
        {
            Product = new HashSet<Product>();
        }
    }
}
