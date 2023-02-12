using Microsoft.Extensions.DependencyInjection;
using ApexRestaurant.Repository.RCustomer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApexRestaurant.Repository
{
    public static class RepositoryModule
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDbContext<RestaurantContext>(options => options.UseSqlServer(
                @"Server=KRISCHAL\SQLEXPRESS;Initial Catalog=ApexRestaurantDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)
            ));

            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}