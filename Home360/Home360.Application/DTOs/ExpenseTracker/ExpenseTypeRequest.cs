namespace Home360.Application.DTOs
{
    public class ExpenseTypeRequest : CommonEntityModel
    {
        public int ExpenseTypeId { get; set; }
        public required string ExpenseTypeName { get; set; }
        public required string ExpenseTypeCode { get; set; }
        public string? ExpenseTypeDescription { get; set; }
        public required int ExpenseCategoryId { get; set; }
        public ExpenseCategoryRequest ExpenseCategory { get; set; }
    }
}
