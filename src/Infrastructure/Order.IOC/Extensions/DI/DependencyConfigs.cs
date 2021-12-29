using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Order.Persistence;

namespace Order.IOC.Extensions.DI
{
    public static class DependencyConfigs
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            //Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductTypeRepository, ProductTypeRepository>();

            //Services
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductTypeService, ProductTypeService>();
        }

        public static void RegisterValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreateOrderValidator>();
        }

        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("OrderContext")));
        }
    }
}
