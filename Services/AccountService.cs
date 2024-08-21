using ProjectDotNet.Models;
using Microsoft.EntityFrameworkCore;
using ProjectDotNet.Database;
namespace ProjectDotNet.Services
{
    public class AccountService 
    {
        private readonly MyDBContext _context;
        public AccountService(MyDBContext context) {
            _context = context;
        }
        public async Task<Account> LoginAsync(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<bool> RegisterAsync(Account user)
        {
           _context.Users.Add(user);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<Account>> GetAllAccountsAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<bool> DeleteAccountAsync(int id)
        {
            var account = await _context.Users.FindAsync(id);
            if (account == null)
            {
                return false; 
            }

            _context.Users.Remove(account);
            await _context.SaveChangesAsync();
            return true; 
        }
        public async Task<Account> GetAccountByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task UpdateAccountAsync(Account updatedAccount)
        {
            var existingAccount = await _context.Users.FindAsync(updatedAccount.Id);
            if (existingAccount != null)
            {
                existingAccount.Name = updatedAccount.Name;
                existingAccount.Phone = updatedAccount.Phone;
                existingAccount.Address = updatedAccount.Address;
                existingAccount.Role = updatedAccount.Role;

                _context.Users.Update(existingAccount);
                await _context.SaveChangesAsync();
            }
        }


    }

}
