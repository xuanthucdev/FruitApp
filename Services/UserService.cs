using ProjectDotNet.Models;

namespace ProjectDotNet.Services
{
    public interface UserService
    {
        Task<User> LoginAsync(string email, string password);
        Task<bool> RegisterAsync(User user);
    }
}
