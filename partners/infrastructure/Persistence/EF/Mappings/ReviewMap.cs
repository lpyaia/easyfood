using Easyfood.Partners.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Partners.Infrastructure.Persistence.EF.Mappings
{
    public class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.HasOne(r => r.Merchant)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.MerchantId);

            builder.Property(r => r.Opinion)
                   .HasMaxLength(250);

            builder.Property(r => r.UserName)
                   .HasMaxLength(100);

            builder.Property(r => r.Rating)
                   .HasPrecision(18, 2);
        }
    }
}