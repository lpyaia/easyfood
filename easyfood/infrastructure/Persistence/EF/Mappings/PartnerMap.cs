using Easyfood.Domain.Entities.Partners;
using Easyfood.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class PartnerMap : IEntityTypeConfiguration<Partner>
    {
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.ToTable("Partner");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CompanyCategory)
                   .HasMaxLength(100);

            builder.Property(m => m.CompanyDescription)
                   .HasMaxLength(250);

            builder.Property(m => m.IsActive)
                   .IsRequired();

            builder.HasOne(m => m.Owner)
                   .WithMany(o => o.Partners)
                   .HasForeignKey(m => m.OwnerId);

            builder.OwnsOne(m => m.Address, addressNav =>
            {
                addressNav.Property(a => a.Street).HasColumnName("Street").HasMaxLength(250);
                addressNav.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
                addressNav.Property(a => a.State).HasColumnName("State").HasMaxLength(100);
                addressNav.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(9);
                addressNav.Property(a => a.Country).HasColumnName("Country").HasMaxLength(100);
                addressNav.OwnsOne(a => a.Location, locationNav =>
                {
                    locationNav.Property(l => l.Latitude).HasColumnName("Latitude").HasPrecision(18, 2);
                    locationNav.Property(l => l.Longitude).HasColumnName("Longitude").HasPrecision(18, 2);
                });
            });

            builder.OwnsOne(x => x.Score, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("Score")
                 .HasPrecision(18, 2)
                 .IsRequired();
            });

            builder.Metadata
               .FindNavigation(nameof(Partner.Orders))!
               .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}