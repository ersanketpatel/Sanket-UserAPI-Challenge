using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.DAL.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetByID(long id);
        Task<IEnumerable<T>> GetAll();
        Task<bool> Add(T entity);
    }
}
