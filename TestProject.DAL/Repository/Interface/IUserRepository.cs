using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.Core.Models;
using TestProject.Core.ViewModel;

namespace TestProject.DAL.Repository
{
    public interface IUserRepository
    {
        Task<decimal> CreateUser(User user);
        Task<List<UserViewModel>> ListUsers();
        Task<UserViewModel> GetUser(decimal? userId);
    }
}
