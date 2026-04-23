using Home360.Domain.Entities;

namespace Home360.Application.DTOs
{
    public class MonthlyCartRequest
    {
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public decimal RequiredQty { get; set; }
        public bool IsPurchased { get; set; }
        public decimal Price { get; set; }
        public virtual GroceryItemRequest GroceryItem { get; set; }
    }
}
