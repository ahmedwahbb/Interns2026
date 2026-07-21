using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NorthWaveConsole.Domain.Entities;

namespace NorthWaveConsole.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(o => o.CustomerType)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(o => o.Status)
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(o => o.Total)
                .HasColumnType("decimal(18,2)");

            builder.Property(o => o.FailureReason)
                .HasMaxLength(500);

            // خصائص محسوبة (computed) مش هتتخزن في الـ DB
            builder.Ignore(o => o.Subtotal);
            builder.Ignore(o => o.ItemsCount);

            // OrderItem بيتخزن كـ Owned Entity (جدول منفصل OrderItems، لكن بدون Repository مستقل)
            builder.OwnsMany(o => o.Items, itemBuilder =>
            {
                itemBuilder.ToTable("OrderItems");
                itemBuilder.WithOwner().HasForeignKey("OrderId");

                itemBuilder.Property<int>("Id");
                itemBuilder.HasKey("Id");

                itemBuilder.Property(i => i.ProductName)
                    .IsRequired()
                    .HasMaxLength(200);

                itemBuilder.Property(i => i.Price)
                    .HasColumnType("decimal(18,2)");

                itemBuilder.Property(i => i.Qty);
            });

            
            builder.Navigation(o => o.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
