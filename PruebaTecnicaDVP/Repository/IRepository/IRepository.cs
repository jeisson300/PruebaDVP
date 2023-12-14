using PruebaTecnicaDVP.Model;
using System.Linq.Expressions;

namespace PruebaTecnicaDVP.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        Task CreateAsync(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>>? filter = null);

        Task<ICollection <T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task SaveAsync();
     }
}
