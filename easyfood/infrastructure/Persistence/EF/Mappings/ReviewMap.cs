﻿using Easyfood.Domain.Entities.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Infrastructure.Persistence.EF.Mappings
{
    public class ReviewMap : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.HasOne(r => r.Partner)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.PartnerId);

            builder.Property(r => r.Opinion)
                   .HasMaxLength(250);

            builder.HasOne(r => r.Customer)
                   .WithMany(c => c.Reviews)
                   .HasForeignKey(r => r.CustomerId);

            builder.OwnsOne(x => x.Rating, x =>
            {
                x.Property(y => y.Value)
                 .HasColumnName("Rating")
                 .HasPrecision(18, 2)
                 .IsRequired();
            });
        }
    }
}