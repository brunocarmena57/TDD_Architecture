using TDD_Architecture.Domain.Entities.Users;

namespace TDD_Architecture.Domain.Interfaces.Users
{
    public interface IUserAddressRepository
    {
        Task<IEnumerable<UserAddress>> GetAll();
        Task<UserAddress> GetById(int id);
        Task<UserAddress> Put(UserAddress address);
        Task<UserAddress> Post(UserAddress address);
        Task<UserAddress> Delete(UserAddress address);
    }
}
