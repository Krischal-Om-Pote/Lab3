using System.Collections.Generic;
namespace ApexRestaurant.Services
{
    public interface IGenericService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}