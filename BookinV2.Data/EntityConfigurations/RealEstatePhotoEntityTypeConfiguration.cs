using BookinV2.Data.Entities.RealEstateEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookinV2.Data.EntityConfigurations
{
    internal class RealEstatePhotoEntityTypeConfiguration : IEntityTypeConfiguration<RealEstatePhoto>
    {
        public void Configure(EntityTypeBuilder<RealEstatePhoto> builder)
        {
            builder.HasKey(rep => rep.Id);

            builder.Property(rep => rep.Photo)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasOne<RealEstateDto>()
                .WithMany()
                .HasForeignKey(rep => rep.RealEstateId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
