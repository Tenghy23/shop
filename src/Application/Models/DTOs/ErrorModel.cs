namespace Application.Models.DTOs
{
    [Serializable]
    public class ErrorModel : ISerializable
    {
        protected int Status { get; private set; }
        protected string Title { get; private set; }
        IEnumerable<ErrorMessage> ErrorMessages { get; set; }

        public ErrorModel(int status, string title, IEnumerable<ErrorMessage> errorMessages) 
        {
            Status = status;
            Title = title;
            ErrorMessages = errorMessages;
        }

        public ErrorModel(int status, string title):this(status, title, Enumerable.Empty<ErrorMessage>()) { }

        protected ErrorModel(SerializationInfo info, StreamingContext context) { }

        //void ISerializable GetObjectData(SerializationInfo info, StreamingContext context) 
        //{
        //    if (info == null) throw new ArgumentNullException("info");

        //    info.AddValue("Title", Title);
        //    info.AddValue("Status", Status);
        //    info.AddValue("TraceId", Activity.Current!.TraceId.ToString());
        //    info.AddValue("Errors", ErrorModelHelper.Serialize(ErrorMessages));
        //}

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
