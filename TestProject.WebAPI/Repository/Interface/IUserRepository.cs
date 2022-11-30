using System.Collections.Generic;
using System.Threading.Tasks;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.ViewModel;

namespace TestProject.WebAPI.Repository
{
    public interface IUserRepository
    {
        Task<decimal> CreateUser(User user);
        Task<List<UserViewModel>> ListUsers();
        Task<UserViewModel> GetUser(decimal? userId);
    }
}
