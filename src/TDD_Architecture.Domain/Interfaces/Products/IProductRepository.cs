    using TDD_Architecture.Domain.Entities.Products;

namespace TDD_Architecture.Domain.Interfaces.Products
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Put(Product product);
        Task<Product> Post(Product product);
        Task<Product> Delete(Product product);
    }
}
