using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Core.Models;
using TestProject.Core.ViewModel;

namespace TestProject.DAL.Repository
{
    public interface IAccountRepository
    {
        Task<decimal> CreateAccount(Account account);

        Task<List<AccountViewModel>> GetAccounts();
    }
}
