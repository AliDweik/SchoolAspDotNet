using School.Models.AuthModels;

namespace School.Services
{
    public interface IAuthService
    {
        Task<User> Register(User user, string passwrord);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
