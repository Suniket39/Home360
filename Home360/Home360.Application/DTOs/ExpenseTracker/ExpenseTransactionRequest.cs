namespace Home360.Application.DTOs
{
    public class ExpenseTransactionRequest : CommonEntityModel
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
    }
}
