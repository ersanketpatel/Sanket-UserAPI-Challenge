using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TestProject.Core.Models;

namespace TestProject.DAL.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ZIPPAYContext _context;
        private readonly ILogger _logger;

        public IAccountRepository AccountRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public UnitOfWork(ZIPPAYContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            AccountRepository = new AccountRepository(context, _logger);
            UserRepository = new UserRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }        
    }
}
