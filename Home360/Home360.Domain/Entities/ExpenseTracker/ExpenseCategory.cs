namespace Home360.Domain.Entities
{
    public class ExpenseCategory : CommonEntity
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryCode { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryCode { get; set; }

        public virtual User User { get; set; }
        public virtual ExpenseCategory? ParentCategory { get; set; }
        public virtual ICollection<ExpenseCategory> SubCategories { get; set; } = new List<ExpenseCategory>();
        public virtual ICollection<ExpenseTypes> ExpenseTypes { get; set; } = new List<ExpenseTypes>();
        public virtual ICollection<ExpenseTransaction> ExpenseTransactions { get; set; } = new List<ExpenseTransaction>();
    }
}
