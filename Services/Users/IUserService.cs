using ZNSTLibrary.Authentication;
using ZNSTLibrary.Data.Models;

namespace ZNSTLibrary.Data.Services.Users
{
    public interface IUserService
    {
        Task<UserSession> CreateUserAsync(User user);
        Task<UserSession> AuthenticateUser(string email, string password);
    }
}
