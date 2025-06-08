using TDD_Architecture.Domain.Entities.Users;

namespace TDD_Architecture.Domain.Interfaces.Users
{
    public interface IUserContactRepository
    {
        Task<IEnumerable<UserContact>> GetAll();
        Task<UserContact> GetById(int id);
        Task<UserContact> GetByEmail(string email);
        Task<UserContact> Put(UserContact contact);
        Task<UserContact> Post(UserContact contact);
        Task<UserContact> Delete(UserContact contact);
    }
}
