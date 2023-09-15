using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace House.Infrastructure.Data.Configurations;
public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> builder)
    {
       
        //builder.HasIndex(a => a.Id).IsUnique();

        builder.ToTable("Apartments");
        builder.HasKey(a => a.Id);
        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasIndex(e => e.OwnerId, "IX_Apartments_OwnerId");

        builder.HasOne(d => d.Owner).WithMany(p => p.Apartments)
               .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.NoAction)
               .HasConstraintName("FK_Apartments_Owner");

        builder.HasIndex(e => e.CityId, "IX_Apartments_CityId");

        builder.HasOne(d => d.City).WithMany(p => p.Apartments)
           .HasForeignKey(d => d.CityId)
         .OnDelete(DeleteBehavior.NoAction)
           .HasConstraintName("FK_Apartments_City");

        builder.HasIndex(e => e.CityId, "IX_Apartments_NeighborhoodId");

        builder.HasOne(d => d.Neighborhood).WithMany(p => p.Apartments)
           .HasForeignKey(d => d.NeighborhoodId)
         .OnDelete(DeleteBehavior.NoAction)
           .HasConstraintName("FK_Apartments_Neighborhood");

        //builder.Property(e => e.ApartmentNumber)
        //       .ValueGeneratedOnAdd();

    }
}
