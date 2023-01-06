using System.Threading.Tasks;

namespace TestProject.DAL.Repository
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        IUserRepository UserRepository { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
