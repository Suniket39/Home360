namespace Home360.Domain.Entities
{
    public class GroceryItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemUnit { get; set; }
        public string ItemDescription { get; set; } = string.Empty;
        public string Status { get; set; }
    }
}
