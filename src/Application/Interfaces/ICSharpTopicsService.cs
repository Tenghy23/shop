namespace Application.Interfaces
{
    public interface ICSharpTopicsService
    {
        Task<string> StreamWriteIntoTxtFile();
        Task<string> StreamWriteIntoExcelFile();
    }
}
