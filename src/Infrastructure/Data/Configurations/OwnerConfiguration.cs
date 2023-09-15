using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace House.Infrastructure.Data.Configurations;
public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owners");

        builder.HasKey(a => a.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasIndex(e => e.CityId, "IX_Owners_CityId");

        builder.HasOne(d => d.City).WithMany(p => p.Owners)
           .HasForeignKey(d => d.CityId)
           .OnDelete(DeleteBehavior.Cascade)
           .HasConstraintName("FK_Owners_City");
    }
}
