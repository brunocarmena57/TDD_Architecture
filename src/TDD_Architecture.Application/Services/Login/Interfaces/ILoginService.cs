using TDD_Architecture.Application.Models.Http;

namespace TDD_Architecture.Application.Services.Login.Interfaces
{
    public interface ILoginService
    {
        Task<Result<string>> GetLogin(string email);
    }
}
