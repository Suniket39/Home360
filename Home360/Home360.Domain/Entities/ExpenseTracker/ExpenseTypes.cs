namespace Home360.Domain.Entities
{
    public class ExpenseTypes
    {
        public int ExpenseTypeId { get; set; }
        public required string ExpenseTypeName { get; set; }
        public required string ExpenseTypeCode { get; set; }
        public string? ExpenseTypeDescription { get; set; }
        public int ExpenseCategoryId { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual ICollection<ExpenseTransaction> ExpenseTransactions { get; set; }
    }
}
