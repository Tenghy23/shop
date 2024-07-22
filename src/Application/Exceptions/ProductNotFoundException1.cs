namespace Application.Exceptions
{
    public class ProductNotFoundException1 : BaseException
    {
        public ProductNotFoundException1(Guid id)
            : base($"product with id {id} not found", HttpStatusCode.NotFound)
        {
        }
    }
}
