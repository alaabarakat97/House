using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using House.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace House.Infrastructure.Data.Configurations;
public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(e => e.Id).ValueGeneratedNever();

        builder.Property(e=>e.LicenseId).IsUnicode(true); 
    }
}
