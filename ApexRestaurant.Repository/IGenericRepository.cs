using System.Linq;

namespace ApexRestaurant.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        IQueryable<T> Query();
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}