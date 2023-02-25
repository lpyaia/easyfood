using Easyfood.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class MenuItemMap : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("Item");

            builder.Property(mi => mi.Name)
                   .HasMaxLength(50);

            builder.Property(mi => mi.Description)
                   .HasMaxLength(200);

            builder.Property(mi => mi.Image);

            builder.OwnsOne(mi => mi.Price, p =>
            {
                p.Property(m => m.Value).HasColumnName("Value").HasPrecision(18, 2);
                p.Property(m => m.Currency).HasColumnName("Currency");
            });
        }
    }
}