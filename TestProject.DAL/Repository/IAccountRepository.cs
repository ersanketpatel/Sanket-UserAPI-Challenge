using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.ViewModel;

namespace TestProject.DAL.Repository
{
    public interface IAccountRepository
    {
        Task<decimal> CreateAccount(Account account);

        Task<List<AccountViewModel>> GetAccounts();
    }
}
