using Order.Domain.EntityConfigurations;
using Order.Persistence.Seeds;

namespace Order.Persistence
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderConfiguration).Assembly);

            modelBuilder.Seed();
        }

        public DbSet<Domain.Entities.Order> Orders { get; set;}

        public DbSet<OrderItem> OrderItems { get; set;}

        public DbSet<ProductType> ProductTypes { get; set;}
    }
}