using TDD_Architecture.Domain.Entities.Users;

namespace TDD_Architecture.Domain.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Put(User user);
        Task<User> Post(User user);
        Task<User> Delete(User user);
    }
}
