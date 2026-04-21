namespace Home360.Domain.Entities
{
    public class MonthlyCart : CommonEntity
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public decimal RequiredQty { get; set; }
        public bool IsPurchased { get; set; }
        public decimal Price { get; set; }
        public virtual GroceryItem GroceryItem { get; set; }
    }
}