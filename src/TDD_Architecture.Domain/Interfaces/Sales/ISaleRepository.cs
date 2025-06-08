using TDD_Architecture.Domain.Entities.Sales;

namespace TDD_Architecture.Domain.Interfaces.Sales
{
    public interface ISaleRepository
    {
        Task<IEnumerable<Sale>> GetAll();
        Task<Sale> GetById(int id);
        Task<Sale> Put(Sale sale);
        Task<Sale> Post(Sale sale);
        Task<Sale> Delete(Sale sale);
    }
}
