using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace ApexRestaurant.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected RestaurantContext DbContext { get; set; }

        protected GenericRepository(RestaurantContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await DbContext.FindAsync<T>(id);
        }

        public IQueryable<T> Query()
        {
            return DbContext.Set<T>().AsQueryable();
        }

        public async Task Insert(T entity)
        {
            DbContext.Set<T>().Add(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}
