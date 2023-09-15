using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace House.Infrastructure.Data.Configurations;
public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("Contracts");
        builder.HasKey(a => a.Id);

        builder.HasIndex(e => e.OwnerId, "IX_Contracts_OwnerId");

        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.HasOne(d => d.Owner).WithMany(p => p.Contracts)
               .HasForeignKey(d => d.OwnerId)
               .OnDelete(DeleteBehavior.NoAction)
               //.OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Contracts_Owner");

        //builder.HasIndex(e => e.ApartmentId, "IX_Contracts_ApartmentId");

        //builder.HasOne(d => d.Apartment).WithMany(p => p.Contracts)
        //   .HasForeignKey(d => d.ApartmentId)
        //   //.OnDelete(DeleteBehavior.Cascade)
        //   .HasConstraintName("FK_Contracts_Apartment");
    }
}
