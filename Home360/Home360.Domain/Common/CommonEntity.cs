namespace Home360.Domain
{
    public class CommonEntity
    {
        public bool IsActive { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
