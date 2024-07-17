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
    internal class AdvertisementEntityTypeConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(ad => ad.Id);

            builder.Property(ad => ad.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(ad => ad.Description)
                .IsRequired(false)
                .HasMaxLength(5000);

            builder.Property(ad => ad.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.HasOne(ad => ad.RealEstate)
                .WithMany() 
                .HasForeignKey(ad => ad.RealEstateId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
