using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace House.Infrastructure.Data.Configurations;
public class NeighborhoodConfiguration : IEntityTypeConfiguration<Neighborhood>
{
    public void Configure(EntityTypeBuilder<Neighborhood> builder)
    {
        builder.ToTable("Neighborhoods");

        builder.HasKey(a => a.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasIndex(e => e.CityId, "IX_Neighborhoods_CityId");

        builder.HasOne(d => d.City).WithMany(p => p.Neighborhoods)
           .HasForeignKey(d => d.CityId)
           .OnDelete(DeleteBehavior.Cascade)
           .HasConstraintName("FK_Neighborhoods_City");

        builder.Property(e => e.LicenseId).IsUnicode(true);

    }
}
