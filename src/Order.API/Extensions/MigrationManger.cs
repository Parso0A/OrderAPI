using Microsoft.EntityFrameworkCore;
using Order.Persistence;

namespace Order.API.Extensions
{
    public static class MigrationManger
    {
        public static void ApplyPendingMigrations(this IServiceCollection services)
        {
            using var scope = services.BuildServiceProvider();
            using var dbContext = scope.GetRequiredService<OrderDbContext>();
            if(dbContext.Database.GetPendingMigrations().Any())
                dbContext.Database.Migrate();
        }
    }
}
