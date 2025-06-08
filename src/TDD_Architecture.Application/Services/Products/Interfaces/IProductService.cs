using TDD_Architecture.Application.Models.Http;
using TDD_Architecture.Application.ViewModels.Products;

namespace TDD_Architecture.Application.Services.Products.Interfaces
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductViewModel>>> GetAll();
        Task<Result<ProductViewModel>> GetById(int id);
        Task<Result<ProductViewModel>> Put(ProductViewModel product);
        Task<Result<ProductViewModel>> Post(ProductViewModel product);
        Task<Result<ProductViewModel>> Delete(int productId);
    }
}
