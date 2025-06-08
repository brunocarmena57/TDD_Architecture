using TDD_Architecture.Domain.Entities.Base;
using TDD_Architecture.Domain.Entities.Products;
using TDD_Architecture.Domain.Entities.Users;

namespace TDD_Architecture.Domain.Entities.Sales
{
    public class Sale : EntityBase
    {
        public decimal TotalValue { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
