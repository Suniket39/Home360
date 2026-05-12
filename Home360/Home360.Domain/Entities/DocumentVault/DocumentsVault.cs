namespace Home360.Domain.Entities.DocumentVault
{
    public class DocumentsVault : CommonEntity
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentDescription { get; set; } = string.Empty;
        public string DocumentVersion { get; set; }
        public string DocumentPath { get; set; }
    }
}
