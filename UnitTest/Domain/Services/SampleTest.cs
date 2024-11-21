  using System.Linq.Expressions;

namespace UnitTest.Domain.Services
{
    public class SampleTest
    {
        private readonly IProductDomainService _productDomainService = A.Fake<IProductDomainService>();
        private readonly IProductRepository _productRepository = A.Fake<IProductRepository>();
        private readonly IInventoryRepository _inventoryRepository = A.Fake<IInventoryRepository>();

        public SampleTest() 
        {
        }

        [Fact]
        public async Task MockProduct()
        {
            // Arrange
            var inventoryId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var seed = new List<Product>() { new Product(inventoryId, categoryId, "test", "test", 1, (decimal?)1.0) };
            A.CallTo(() => _productRepository.RetrieveProductAsync(A<Expression<Func<Product, bool>>>.Ignored))
                .Returns(Task.FromResult<IEnumerable<Product>>(seed));

            // Act
            var result = await _productRepository.RetrieveProductAsync(x => x.CategoryId == categoryId);

            // Assert
            Assert.True(result.FirstOrDefault().Equals(seed.FirstOrDefault()));
        }

        [Theory]
        [InlineData("test","test2","test3","test4")]
        [InlineData("test","test5","test6","test7")]
        [InlineData("test","test8","test9","test0")]
        public async Task MockProduct2(string value1, string value2, string value3, string value4)
        {
            // to showcase InlineData only, test is actually the same
            // Arrange
            var inventoryId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var seed = new List<Product>() { new Product(inventoryId, categoryId, "test", "test", 1, (decimal?)1.0) };
            A.CallTo(() => _productRepository.RetrieveProductAsync(A<Expression<Func<Product, bool>>>.Ignored))
                .Returns(Task.FromResult<IEnumerable<Product>>(seed));

            // Act
            var result = await _productRepository.RetrieveProductAsync(x => x.CategoryId == categoryId);

            // Assert
            Assert.True(result.FirstOrDefault().Equals(seed.FirstOrDefault()));
        }
    }
}
