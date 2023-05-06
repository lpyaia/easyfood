using Easyfood.Domain.Entities.Partners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class MenuItemMap : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable("MenuItem");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(mi => mi.ItemName)
                   .HasMaxLength(50);

            builder.Property(mi => mi.Description)
                   .HasMaxLength(200);

            builder.Property(mi => mi.Image);

            builder.OwnsOne(mi => mi.Price, p =>
            {
                p.Property(m => m.Value).HasColumnName("Value").HasPrecision(18, 2);
                p.Property(m => m.Currency).HasColumnName("Currency");
            });

            builder.HasOne(mi => mi.Menu)
                .WithMany(m => m.Items)
                .HasForeignKey(mi => mi.MenuId);
        }
    }
}