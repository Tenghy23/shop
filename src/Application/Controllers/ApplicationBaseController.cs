namespace Application.Controllers
{
    public class ApplicationBaseController : Controller
    {
        protected readonly ILogger _logger;

        private string LogFormat
        {
            get => "Message: { Message }, Application.Class: " + GetType().Name + ".Method: { Method }";
        }

        protected IActionResult InvalidResponse(Exception ex, [CallerMemberName] string caller = "")
        {
            return ExceptionHandlingHelper.ReturnNonSuccessResponse(LogFormat, _logger, ex, caller);
        }
    }
}
