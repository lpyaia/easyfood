using Easyfood.Domain.Entities.Orders;
using Easyfood.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(o => o.Customer)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Partner)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(o => o.PartnerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.OwnsOne(o => o.TotalOrder, o =>
            {
                o.Property(o1 => o1.Value)
                 .HasColumnName("TotalOrder")
                 .HasPrecision(18, 2)
                 .IsRequired();

                o.Property(o1 => o1.Currency)
                 .HasColumnName("Currency")
                 .HasDefaultValue(Currency.Reais);
            });

            builder.Property(o => o.OrderNumber)
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}