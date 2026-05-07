namespace Home360.Application.DTOs
{
    public class BillRequest : CommonEntityModel
    {
        public int BillId { get; set; }
        public string BillName { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public DateTime DueDate { get; set; }
        public string BillingCycle { get; set; } //( Monthly/ Quarterly / yearly )
        public bool IsRecurring { get; set; }
        public int ReminderDaysBefore { get; set; }
        public string Status { get; set; }  // Pending / Paid
        public int UserId { get; set; }
    }
}
