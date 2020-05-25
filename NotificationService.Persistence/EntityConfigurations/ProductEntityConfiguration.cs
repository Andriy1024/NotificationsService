using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationService.Domain;

namespace NotificationService.Persistence
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Product", ApplicationDbContext.SchemaName);

            builder.HasKey(t => t.Id);

            builder.Ignore(t => t.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(120);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            builder.Property(t => t.Unit)
                .HasMaxLength(15);

            builder.HasMany(t => t.Orders)
                .WithOne(t => t.Product)
                .HasForeignKey(t => t.ProductId);

            builder.HasData(new[] 
            {
                new ProductEntity()
                {
                    Id = 1,
                    Cost = 800,
                    Unit = "$",
                    Name = "IPhone 11",
                    Description = "Apple on September 10, 2019, unveiled the iPhone 11, its new flagship $699 smartphone that offers a range of powerful features at an affordable price tag. Sold alongside the more expensive iPhone 11 Pro and the iPhone 11 Pro Max, the iPhone 11 is going to be the iPhone perfect for most people."
                },
                new ProductEntity()
                {
                    Id = 2, 
                    Cost = 1300,
                    Unit = "$",
                    Name = "Xiaomi Mi Notebook Pro",
                    Description = "Xiaomi notebooks are still considered a rarity in Europe and have to be imported from Asia. Not having the opportunity of looking at the device beforehand at your trusted local store, plus the additional effort of making warranty claims etc., makes it all the more important to read reviews of imported products before making your final decision. Notebookcheck has therefore decided that after reviewing the Intel Core i5-8250U version, we will now also take a look at the model with the stronger Intel Core i7-8550U. In this review, we have focused mainly on the device's performance and its differences to the other model that we have already tested."
                },
                new ProductEntity()
                {
                    Id = 3,
                    Cost = 400,
                    Unit = "$",
                    Name = "PlayStation 4",
                    Description = "The PlayStation 4 (officially abbreviated as PS4) is an eighth-generation home video game console developed by Sony Computer Entertainment. Announced as the successor to the PlayStation 3 in February 2013, it was launched on November 15 in North America, November 29 in Europe, South America and Australia, and on February 22, 2014 in Japan. It's the 4th best-selling console of all time. It competes with Microsoft's Xbox One and Nintendo's Wii U and Switch."
                },
            });
        }
    }
}
