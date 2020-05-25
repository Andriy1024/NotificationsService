using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain;

namespace NotificationService.Persistence
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("Order", ApplicationDbContext.SchemaName);

            builder.HasKey(t => t.Id);

            builder.Ignore(t => t.DomainEvents);

            builder.Property(t => t.BuyerEmail)
                .HasMaxLength(100);

            builder.Property(t => t.BuyerName)
                .HasMaxLength(100);

            builder.Property(t => t.City)
                .HasMaxLength(100);

            builder.Property(t => t.Adress)
                .HasMaxLength(100);

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GetUtcDate()")
                .ValueGeneratedOnAdd();
        }
    }
}
