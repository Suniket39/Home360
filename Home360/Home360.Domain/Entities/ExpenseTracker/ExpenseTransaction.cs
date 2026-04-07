namespace Home360.Domain.Entities
{
    public class ExpenseTransaction : CommonEntity
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public required string ExpenseName { get; set; }
        public string? Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public required string TransactionType { get; set; } // Credit / Debit
        public required string TransactionMode { get; set; } // Cash / UPI / Card
        public int ExpenseCategoryId { get; set; }
        public int ExpenseCategoryTypeId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ExpenseCategory ExpenseCategory { get; set; }
        public virtual ExpenseTypes ExpenseCategoryType { get; set; }
    }
}
