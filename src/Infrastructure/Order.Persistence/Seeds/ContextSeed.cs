namespace Order.Persistence.Seeds
{
    internal static class ContextSeed
    {
        internal static void Seed(this ModelBuilder modelBuilder)
        {
            CreateProductTypes(modelBuilder);
        }

        private static void CreateProductTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductType>().HasData(ProductTypes.ProductTypeList());
        }
    }
}
