namespace Home360.Application.DTOs
{
    public class MonthlyCartResponse
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public decimal RequiredQty { get; set; }
        public bool IsPurchased { get; set; }
        public decimal Price { get; set; }
        public virtual GroceryItemResponse GroceryItem { get; set; }
    }
}
