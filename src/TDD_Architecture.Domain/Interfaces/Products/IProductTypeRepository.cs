using TDD_Architecture.Domain.Entities.Products;

namespace TDD_Architecture.Domain.Interfaces.Products
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<ProductType>> GetAll();
        Task<ProductType> GetById(int id);
        Task<ProductType> Put(ProductType product);
        Task<ProductType> Post(ProductType product);
        Task<ProductType> Delete(ProductType product);
    }
}
