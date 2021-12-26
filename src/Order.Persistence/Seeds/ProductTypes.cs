namespace Order.Persistence.Seeds
{
    internal static class ProductTypes
    {
        internal static List<ProductType> ProductTypeList()
        {
            return new List<ProductType>()
            {
                new ProductType()
                {
                    Id = 1,
                    Name = "PhotoBook",
                    StackSize = 1,
                    Width = 1.9M,
                },
                new ProductType()
                {
                    Id = 2,
                    Name = "Calendar",
                    StackSize = 1,
                    Width = 1M,
                },
                new ProductType()
                {
                    Id = 3,
                    Name = "Canvas",
                    StackSize = 1,
                    Width = 1.6M,
                },
                new ProductType()
                {
                    Id = 4,
                    Name = "Cards",
                    StackSize = 1,
                    Width = 0.47M,
                },
                new ProductType()
                {
                    Id = 5,
                    Name = "Mug",
                    StackSize = 4,
                    Width = 9.4M,
                },
            };
        }
    }
}
