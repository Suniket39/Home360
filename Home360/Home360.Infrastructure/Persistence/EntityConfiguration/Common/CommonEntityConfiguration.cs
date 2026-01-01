using Home360.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Home360.Infrastructure.Persistence    
{
    public class CommonEntityConfiguration : IEntityTypeConfiguration<CommonEntity>
    {
        public void Configure(EntityTypeBuilder<CommonEntity> builder)
        {
            builder.Property(e => e.IsActive)
                .IsRequired();
            builder.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.CreatedDate)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(100);
            builder.Property(e => e.ModifiedDate);
        }
    }
}
