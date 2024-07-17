using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookinV2.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookinV2.Data.EntityConfigurations
{
    internal class RealEstateEntityTypeConfiguration : IEntityTypeConfiguration<RealEstate>
    {
        public void Configure(EntityTypeBuilder<RealEstate> builder)
        {
            builder.HasKey(re => re.Id);

            builder.Property(re => re.Address)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(re => re.Square)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(re => re.RoomCount)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
