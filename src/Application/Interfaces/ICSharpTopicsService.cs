using Domain.AggregatesModel.OtherAggregate;

namespace Application.Interfaces
{
    public interface ICSharpTopicsService
    {
        Task<string> StreamWriteIntoTxtFile();
        Task<string> StreamReadFromTxtFile();
        Task<string> StreamWriteIntoExcelFile();
        Task<string> StreamReadFromExcelFile();
        Task<string> AwaitVsSynchronousAsync();
        Task<string> MultithreadingSharedListMutate();
        Task<Stock> FetchLiveStockPrices(string symbol);
    }
}
