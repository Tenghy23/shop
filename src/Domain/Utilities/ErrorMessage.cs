namespace Domain.Utilities
{
    public class ErrorMessage
    {
        internal string FunctionName { get; private set; }
        public string Message { get; private set; }
        private readonly StackTrace _stackTrace = new StackTrace();

        public ErrorMessage(string functionName, string message) 
        {
            FunctionName = _stackTrace.GetFrame(1)!.GetMethod()!.Name;
            Message = message;
        }
    }

    public static class ErrorModelHelper 
    {
        public static Dictionary<string, List<string>> Serialize(IEnumerable<ErrorMessage>errors)
        {
            var customErrors = new Dictionary<string, List<string>>();
            foreach (var error in errors)
            {
                var key = error.FunctionName;
                if (customErrors.ContainsKey(key))
                {
                    customErrors[key].Add(error.Message);
                }
                else
                {
                    customErrors.Add(key, new List<string> { error.Message });
                }
            }
            return customErrors;
        }
        public static List<string> SerializeToStringList(IEnumerable<ErrorMessage> errors)
        {
            var customErrors = new List<string>();
            foreach (var error in errors)
            {
                if (string.IsNullOrEmpty(error.FunctionName))
                {
                    customErrors.Add(error.FunctionName + ": " + error.Message);
                }
                else
                {
                    customErrors.Add(error.Message);
                }
            }
            return customErrors;
        }

    }
}
