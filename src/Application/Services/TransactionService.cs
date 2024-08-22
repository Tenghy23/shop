using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly StoreDbContext _storeDbContext;
        //private readonly IIncomingRequestRepository _incomingRequestRepository;
        private const int DuplicatedPrimaryKeyErrorNumber = 2627;
        private readonly string _operationId = "88888888";
        private readonly string _requestId = "99999999";

        public TransactionService(
            StoreDbContext storeDbContext
            //IIncomingRequestRepository incomingRequestRepository
            )
        {
            _storeDbContext = storeDbContext;
            //_incomingRequestRepository = incomingRequestRepository;
        }

        public async Task TransactionScopeAsync(Func<IDbContextTransaction, Task> action) 
        {
            //await IdempotenceCheckAsync();

            var executionStrategy = _storeDbContext.Database.CreateExecutionStrategy();
            await executionStrategy.ExecuteAsync(async () =>
            {
                using (var transaction = _storeDbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        await action.Invoke(transaction);
                        await _storeDbContext.SaveChangesAsync();
                        await transaction.CommitAsync();
                    }
                    catch (Exception ex) 
                    {
                        await transaction.RollbackAsync();
                        throw new Exception($"Transaction Failure: {ex.Message}");
                    }
                }
            });
        }

        public async Task IdempotenceCheckAsync()
        {
            //_incomingRequestRepo.Add(new IncomingRequest(_operationId, Guid.Parse(_requestId)));

            try
            {
                //await _incomingRequestRepo.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (IsCausedByDuplicatedRequest(ex, _requestId))
                {
                    throw new Exception($"Idempotence Exception: {ex.Message}");
                }
            }
        }

        private static bool IsCausedByDuplicatedRequest(DbUpdateException ex, string requestId)
        {
            return ex.GetBaseException() is SqlException sqlException
                && sqlException.Number == DuplicatedPrimaryKeyErrorNumber
                && sqlException.Message.Contains(requestId);
        }
    }
}
