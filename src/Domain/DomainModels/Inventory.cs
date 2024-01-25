namespace Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public Product Product { get; private set; }
        public int StockRemaining { get; private set; }

        public Inventory() { }
    }
}