using Home360.Domain.Entities.DocumentVault;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence.EntityConfiguration
{
    public class DocumentVaultConfiguration : IEntityTypeConfiguration<DocumentsVault>
    {
        public void Configure(EntityTypeBuilder<DocumentsVault> builder)
        {
            builder.HasKey(x => x.DocumentId);
            builder.Property(x => x.DocumentId).ValueGeneratedOnAdd();
            builder.Property(x => x.OriginalFileName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StoredFileName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.RelativePath).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CategoryType).IsRequired().HasMaxLength(30);
            builder.Property(x => x.ContentType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Extension).IsRequired().HasMaxLength(30);
            builder.Property(x => x.DocumentDescription).IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.DocumentVersion).IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.FileSize).IsRequired();
            builder.Property(x => x.LastAccessedDate).IsRequired(false);
            builder.Property(x => x.IsArchived).IsRequired(false);
            builder.Property(x => x.Checksum).IsRequired(false).HasMaxLength(64);
            builder.Property(x => x.IsPublic).IsRequired(false);

            builder.HasOne(x => x.User)
                   .WithMany()
                   .HasForeignKey(x => x.UserId)
                   .IsRequired();
        }
    }
}
