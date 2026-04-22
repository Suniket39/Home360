namespace Home360.Domain.Entities
{
    public class GroceryInventory : CommonEntity
    {
        public int InventoryId { get; set; }
        public int ItemId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public virtual GroceryItem GroceryItem { get; set; }
    }
}
