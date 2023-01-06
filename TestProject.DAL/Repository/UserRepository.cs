using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestProject.Core.Models;
using TestProject.Core.ViewModel;

namespace TestProject.DAL.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ZIPPAYContext context, ILogger logger) : base(context, logger)
        {
        }
    }
}
