using Easyfood.Domain.Entities.Partners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class TagMap : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasMany(x => x.Partners)
                   .WithMany(x => x.Tags);
        }
    }
}