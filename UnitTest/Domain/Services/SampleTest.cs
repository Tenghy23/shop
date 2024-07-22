namespace UnitTest.Domain.Services
{
    public class SampleTest
    {
        private readonly IProductDomainService _productDomainService = A.Fake<IProductDomainService>();
        private readonly IProductRepository _productRepository = A.Fake<IProductRepository>();
        private readonly IInventoryRepository _inventoryRepository = A.Fake<IInventoryRepository>();

        public SampleTest() 
        {
            _productDomainService = new ProductDomainService(_productRepository, _inventoryRepository);
        }



        [Fact]
        public async Task MockProduct()
        {
            // Arrange
            var sourceForm = "";

            // Act
            // sample method in domain service
            A.CallTo(() => _productRepository.GetProductByIdAsync(Guid.Empty));
            var test = _productRepository.GetProductByIdAsync(Guid.Empty); // call the actual method here


            // Assert
            Assert.True(sourceForm.Equals(sourceForm));
        }

        [Theory]
        [InlineData("test","test2","test3","test4")]
        [InlineData("test","test5","test6","test7")]
        [InlineData("test","test8","test9","test0")]
        public async Task MockProduct2(string value1, string value2, string value3, string value4)
        {
            // Arrange
            var sourceForm = "";
            var sourceFormList = new List<string>();
            sourceFormList.Add(sourceForm);

            // Act
            // sample method in domain service
            A.CallTo(() => _productRepository.GetProductByIdAsync(Guid.Empty));
            var test = _productRepository.GetProductByIdAsync(Guid.Empty); // call the actual method here

            // Assert
            Assert.True(sourceFormList.FirstOrDefault().Equals(sourceForm));
            Assert.Contains(sourceForm, sourceFormList);
        }
    }
}
