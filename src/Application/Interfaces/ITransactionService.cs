using Microsoft.EntityFrameworkCore.Storage;

namespace Application.Interfaces
{
    public interface ITransactionService
    {
        Task TransactionScopeAsync(Func<IDbContextTransaction, Task> action);
        Task IdempotenceCheckAsync();
    }
}