using TDD_Architecture.Application.Models.Http;
using TDD_Architecture.Application.ViewModels.Sales;

namespace TDD_Architecture.Application.Services.Sales.Interfaces
{
    public interface ISaleService
    {
        Task<Result<IEnumerable<SaleViewModel>>> GetAll();
        Task<Result<SaleViewModel>> GetById(int id);
        Task<Result<SaleViewModel>> Put(SaleViewModel sale);
        Task<Result<SaleViewModel>> Post(SaleViewModel sale);
        Task<Result<SaleViewModel>> Delete(int saleId);
    }
}
