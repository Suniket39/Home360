namespace Home360.Application.DTOs
{
    public class ExpenseCategoryRequest : CommonEntityModel
    {
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public required string CategoryName { get; set; }
        public required string CategoryCode { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryCode { get; set; }
    }
}
