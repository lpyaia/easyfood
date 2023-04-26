using Easyfood.Domain.Entities;
using Easyfood.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
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

            builder.OwnsOne(x => x.Email, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("Email")
                 .HasMaxLength(Email.MAX_LENGTH)
                 .IsRequired();
            });

            builder.OwnsOne(x => x.UserName, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("UserName")
                 .HasMaxLength(UserName.MAX_LENGTH)
                 .IsRequired();
            });

            builder.Property(x => x.BirthDate)
                   .IsRequired();

            builder.Metadata
                   .FindNavigation(nameof(Customer.Reviews))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Metadata
                   .FindNavigation(nameof(Customer.CreditCards))!
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}