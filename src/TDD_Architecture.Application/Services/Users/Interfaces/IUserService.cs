using TDD_Architecture.Application.Models.Http;
using TDD_Architecture.Application.ViewModels.Users;

namespace TDD_Architecture.Application.Services.Users.Interfaces
{
    public interface IUserService
    {
        Task<Result<IEnumerable<UserViewModel>>> GetAll();
        Task<Result<UserViewModel>> GetById(int id);
        Task<Result<UserViewModel>> Put(UserViewModel user);
        Task<Result<UserViewModel>> Post(UserViewModel user);
        Task<Result<UserViewModel>> Delete(int userId);
    }
}
