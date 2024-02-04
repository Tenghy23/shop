namespace Application.Helpers
{
    public static class ExceptionHandlingHelper
    {
        public static IActionResult ReturnNonSuccessResponse(string _logFormat, ILogger _logger, Exception ex, string methodName)
        {
            if (ex is NotFoundException)
            {
                _logger.LogWarning(_logFormat, $"{nameof(ex)} {ex.Message}", methodName);
                return new NotFoundObjectResult(new ErrorModel(StatusCodes.Status400BadRequest, "no records found"));
            }
            else
            {
                _logger.LogError(_logFormat, $"{nameof(ex)} {ex.Message}", methodName);
                if (ex.InnerException is not null)
                {
                    _logger.LogError(_logFormat, $"Inner Exception: {ex.InnerException}", methodName);
                }
            }
            return new ObjectResult(new ErrorModel(StatusCodes.Status500InternalServerError, ex.Message));
        }
    }
}
