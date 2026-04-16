namespace Home360.Application.DTOs
{
    public class GroceryItemRequest
    {
        public int ItemId { get; set; }
        public required string ItemName { get; set; }
        public required string ItemUnit { get; set; }
        public string ItemDescription { get; set; } = string.Empty;
        public required string Status { get; set; }
    }
}
