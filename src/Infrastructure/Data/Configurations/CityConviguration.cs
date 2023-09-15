using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace House.Infrastructure.Data.Configurations;
public class CityConviguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.ToTable("Cities");

        builder.HasKey(a => a.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasIndex(e => e.RegionId, "IX_Cities_RegionId");

        builder.HasOne(d => d.Region).WithMany(p => p.Cities)
           .HasForeignKey(d => d.RegionId)
           .OnDelete(DeleteBehavior.Cascade)
           .HasConstraintName("FK_Cities_Region");

        builder.Property(e => e.LicenseId).IsUnicode(true);
    }
}
