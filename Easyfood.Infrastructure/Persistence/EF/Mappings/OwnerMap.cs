using Easyfood.Partners.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Partners.Infrastructure.Persistence.EF.Mappings
{
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.Property(o => o.FirstName)
                   .HasMaxLength(50);

            builder.Property(o => o.LastName)
                   .HasMaxLength(50);
        }
    }
}