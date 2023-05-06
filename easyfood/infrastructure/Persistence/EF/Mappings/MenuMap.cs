using Easyfood.Domain.Entities.Partners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(p => p.Partner)
                .WithOne(p => p.Menu)
                .HasForeignKey<Menu>(m => m.PartnerId);
        }
    }
}