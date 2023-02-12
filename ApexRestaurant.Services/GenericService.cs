using System.Collections.Generic;
using System.Linq;
using ApexRestaurant.Repository;

namespace ApexRestaurant.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected GenericService(IGenericRepository<T> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        protected IGenericRepository<T> EntityRepository { get; }

        public async Task Insert(T entity)
        {
            await EntityRepository.Insert(entity);
        }

        public async Task Update(T entity)
        {
            await EntityRepository.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            // return EntityRepository.Query().ToList();
            return await EntityRepository.GetAll();
        }

        public async Task<T?> GetById(int id)
        {
            return await EntityRepository.GetById(id);
        }

        public async Task Delete(T entity)
        {
            await EntityRepository.Delete(entity);
        }

    }
}