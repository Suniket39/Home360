namespace Home360.Domain.Entities
{
    public class GroceryItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemUnit { get; set; } //Kg, Nos, Ltr
        public string ItemDescription { get; set; } = string.Empty;
        public string Status { get; set; }

        public virtual ICollection<GroceryInventory> GroceryInventories { get; set; }
        public virtual ICollection<MonthlyCart> MonthlyCart { get; set; }
    }
}
