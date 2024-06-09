namespace Domain.AggregatesModel.IDiscountRepository
{
    public interface IDiscountRepository
    {
        Task SaveDataAsync(IEnumerable<Discount> discount);
    }
}