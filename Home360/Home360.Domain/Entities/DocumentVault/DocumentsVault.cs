namespace Home360.Domain.Entities.DocumentVault
{
    public class DocumentsVault : CommonEntity
    {
        public int DocumentId { get; set; }
        public string OriginalFileName { get; set; }
        public string StoredFileName { get; set; }
        public string RelativePath { get; set; }
        public string CategoryType { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
        public string DocumentDescription { get; set; } = string.Empty;
        public string DocumentVersion { get; set; } = string.Empty;
        public long FileSize { get; set; } // Size in bytes
        public DateTime? LastAccessedDate { get; set; } // Nullable, updated on access
        public bool IsArchived { get; set; } = false; // Default to not archived
        public string? Checksum { get; set; } // Optional, for file integrity
        public bool IsPublic { get; set; } = false; // Default to private
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
