using Easyfood.Domain.Entities;
using Easyfood.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class OwnerMap : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.OwnsOne(x => x.FirstName, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("FirstName")
                 .HasMaxLength(Name.MAX_LENGTH)
                 .IsRequired();
            });

            builder.OwnsOne(x => x.LastName, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("LastName")
                 .HasMaxLength(Name.MAX_LENGTH)
                 .IsRequired();
            });
        }
    }
}