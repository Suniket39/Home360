namespace Home360.Application.DTOs
{
    public class GroceryInventoryRequest
    {
        public int InventoryId { get; set; }
        public int ItemId { get; set; }
        public decimal Amount { get; set; }
        public required string Status { get; set; }
        public string? Remarks { get; set; }
        public virtual GroceryItemRequest GroceryItem { get; set; }
    }
}
