
namespace Order.Test.Unit.Services
{
    public class OrderServiceTest
    {
        [Fact]
        public async Task CreateAsync_NullRequest_ShouldReturnEmptyId()
        {
            //Arrange
            CreateOrderRequest request = null;
            var mockValidator = new CreateOrderValidator();
            var mockRepo = new Mock<IOrderRepository>();
            var sut = new OrderService(mockValidator, mockRepo.Object);

            //Act
            var result = await sut.CreateAsync(request, new System.Threading.CancellationToken(false));

            //Assert
            Assert.Equal(Guid.Empty, result);
        }

        [Fact]
        public async Task CreateAsync_OrderWithEmptyItems_ShouldReturnEmptyId()
        {
            //Arrange
            var request = new CreateOrderRequest
            {
                Items = new List<OrderItemDto>()
            };
            var mockValidator = new CreateOrderValidator();
            var mockRepo = new Mock<IOrderRepository>();
            var sut = new OrderService(mockValidator, mockRepo.Object);

            //Act
            var result = await sut.CreateAsync(request, new System.Threading.CancellationToken(false));

            //Assert
            Assert.Equal(Guid.Empty, result);
        }

        [Fact]
        public async Task GetByIdAsync_EmptyIdentifier_ShouldThrowException()
        {
            CreateOrderRequest request = null;
            var mockValidator = new Mock<IValidator<CreateOrderRequest>>();
            var mockRepo = new Mock<IOrderRepository>();
            var sut = new OrderService(mockValidator.Object, mockRepo.Object);

            await Assert.ThrowsAsync<ArgumentException>(() => sut.GetByIdAsync(Guid.Empty, new System.Threading.CancellationToken(false)));
        }
    }
}
