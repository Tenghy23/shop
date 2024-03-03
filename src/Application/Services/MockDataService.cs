namespace Application.Services
{
    public class MockDataService : IMockDataService
    {
        private readonly IMockDataDomainService _mockDataDomainService;

        public MockDataService(
            IMockDataDomainService mockDataDomainService
            ) 
        {
            _mockDataDomainService = mockDataDomainService;
        }

        public async Task<string> MockProductsAndInventory(int count)
        {
            if (count > 1000000)
            {
                return "Only provide Input count < 1000000 records, no data is seeded";
            } 
            else
            {
                return await _mockDataDomainService.MockProductsAndInventory(count);
            }
        }

        public async Task<string> MockCategory(int count)
        {
            if (count > 100000)
            {
                return "Only provide Input count < 100000 records, no data is seeded";
            }
            else
            {
                return await _mockDataDomainService.MockCategory(count);
            }
        }

        public async Task<string> MockAddress(int count)
        {
            if (count > 100000)
            {
                return "Only provide Input count < 100000 records, no data is seeded";
            }
            else
            {
                return await _mockDataDomainService.MockAddress(count);
            }
        }

    }
}
