using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.Core.Models;
using TestProject.Core.ViewModel;

namespace TestProject.DAL.Repository
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
