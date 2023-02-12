using ApexRestaurant.Repository.Domain;

namespace ApexRestaurant.Repository.RCustomer
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        // User GetByEmail(string email);
    }
}