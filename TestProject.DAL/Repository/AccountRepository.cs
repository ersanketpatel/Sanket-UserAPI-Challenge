using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestProject.WebAPI.Repository
{
    public class AccountRepository : IAccountRepository
    {
        ALTIMETRIKContext _context;

        public AccountRepository(ALTIMETRIKContext _db)
        {
            _context = _db;
        }

        public async Task<decimal> CreateAccount(Account account)
        {
            if (_context != null)
            {
                await _context.Account.AddAsync(account);
                await _context.SaveChangesAsync();

                return account.AccountId;
            }

            return 0;
        }

        public async Task<List<AccountViewModel>> GetAccounts()
        {
            if (_context != null)
            {
                return await (from a in _context.Account
                              select new AccountViewModel
                              {
                                  AccountId = a.AccountId,
                                  AccountType = a.AccountType,
                                  UserId = a.UserId,
                              }).ToListAsync();
            }

            return null;
        }
    }
}
