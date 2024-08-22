using Infrastructure;

namespace Application.Services
{
    public class MockDataService : IMockDataService
    {
        private readonly IMockDataDomainService _mockDataDomainService;
        private readonly StoreDbContext _storeDbContext;

        public MockDataService(
            IMockDataDomainService mockDataDomainService,
            StoreDbContext storeDbContext
            )
        {
            _mockDataDomainService = mockDataDomainService;
            _storeDbContext = storeDbContext;
        }

        public async Task<string> MockProductsAndInventory(int count)
        {
            if (count > 1000000)
            {
                return "Only provide Input count < 1000000 records, no data is seeded";
            }
            else
            {
                var executionStrategy = _storeDbContext.Database.CreateExecutionStrategy();
                var result = await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _storeDbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        return await _mockDataDomainService.MockProductsInventoryDiscount(count);
                    }
                });
                return result;
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
                var executionStrategy = _storeDbContext.Database.CreateExecutionStrategy();
                var result = await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _storeDbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        return await _mockDataDomainService.MockCategory(count);
                    }
                });
                return result;
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
                var executionStrategy = _storeDbContext.Database.CreateExecutionStrategy();
                var result = await executionStrategy.ExecuteAsync(async () =>
                {
                    using (var transaction = _storeDbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                    {
                        return await _mockDataDomainService.MockAddress(count);
                    }
                });
                return result;
            }
        }
    }
}
