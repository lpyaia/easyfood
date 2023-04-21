using Easyfood.Domain.Entities;
using Easyfood.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class CreditCardMap : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.ToTable("CreditCard");

            builder.Property(x => x.Flag).IsRequired();

            builder.OwnsOne(x => x.Number, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("Number")
                 .IsRequired();
            });

            builder.OwnsOne(x => x.CVCCode, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("CVCCode")
                 .HasMaxLength(CreditCardCVCCode.LENGTH)
                 .IsRequired();
            });

            builder.OwnsOne(x => x.ExpDate, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("ExpDate")
                 .IsRequired();
            });

            builder.OwnsOne(x => x.CardholderFirstName, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("CardholderFirstName")
                 .HasMaxLength(Name.MAX_LENGTH)
                 .IsRequired();
            });

            builder.OwnsOne(x => x.CardholderLastName, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("CardholderLastName")
                 .HasMaxLength(Name.MAX_LENGTH)
                 .IsRequired();
            });

            builder.HasOne(cc => cc.Customer)
                   .WithMany(c => c.CreditCards)
                   .HasForeignKey(cc => cc.CustomerId);
        }
    }
}