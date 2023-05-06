using Easyfood.Domain.Entities.Orders;
using Easyfood.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.Items)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasOne(oi => oi.Item)
                   .WithMany()
                   .HasForeignKey(oi => oi.ItemId);

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.OwnsOne(oi => oi.TotalPrice, oi =>
            {
                oi.Property(oi1 => oi1.Value)
                  .HasColumnName("TotalPrice")
                  .IsRequired();

                oi.Property(oi1 => oi1.Currency)
                  .HasColumnName("Currency")
                  .HasDefaultValue(Currency.Reais);
            });

            builder.OwnsOne(oi => oi.UnitPrice, oi =>
            {
                oi.Property(oi1 => oi1.Value)
                  .HasColumnName("UnitPrice")
                  .IsRequired();

                oi.Property(oi1 => oi1.Currency)
                  .HasColumnName("Currency")
                  .HasDefaultValue(Currency.Reais);
            });
        }
    }
}