namespace Application.Interfaces
{
    public interface ICSharpTopicsService
    {
        Task<string> StreamWriteIntoTxtFile();
        Task<string> StreamReadFromTxtFile();
        Task<string> StreamWriteIntoExcelFile();
        Task<string> StreamReadFromExcelFile();
        Task<string> AsyncParallelVsSynchronous();
        Task<string> MultithreadingSharedListMutate();
    }
}
