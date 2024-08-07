using ProjectDotNet.Models;
using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Database;
namespace ProjectDotNet.Services
{
    public class UserServiceImpl : UserService
    {
        private readonly MyDBContext _context;
        public UserServiceImpl(MyDBContext context) {
            _context = context;
        }
        public async Task<User> LoginAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.email == email && u.password == password);
        }

        public async Task<bool> RegisterAsync(User user)
        {
           _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
