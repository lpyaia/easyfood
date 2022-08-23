﻿using Easyfood.Partners.Domain.Entities;
using Easyfood.Partners.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Easyfood.Partners.Infrastructure.Persistence.EF.Mappings
{
    public class MerchantMap : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.ToTable("Merchant");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.CompanyCategory)
                   .HasMaxLength(100);

            builder.Property(m => m.CompanyDescription)
                   .HasMaxLength(250);

            var tagsValueComparer = new ValueComparer<List<Tag>>(
                (c1, c2) => c1 != null && c2 != null && c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c);

            builder.Property(m => m.Tags)
                   .HasConversion(
                        c => string.Join(',', c),
                        c => c.Split(',', StringSplitOptions.RemoveEmptyEntries)
                              .Select(s => Enum.Parse(typeof(Tag), s))
                              .Cast<Tag>()
                              .ToList())
                   .Metadata.SetValueComparer(tagsValueComparer);

            builder.HasOne(m => m.Menu)
                .WithMany()
                .HasForeignKey(m => m.MenuId);

            builder.HasOne(m => m.Owner)
                   .WithMany(o => o.Merchants)
                   .HasForeignKey(m => m.OwnerId);

            builder.OwnsOne(m => m.Address, nav =>
            {
                nav.Property(a => a.Street).HasColumnName("Street").HasMaxLength(250);
                nav.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
                nav.Property(a => a.State).HasColumnName("State").HasMaxLength(100);
                nav.Property(a => a.ZipCode).HasColumnName("ZipCode").HasMaxLength(9);
                nav.Property(a => a.Country).HasColumnName("Country").HasMaxLength(100);
            });
        }
    }
}