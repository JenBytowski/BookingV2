using BookinV2.Data.Entities.RealEstateEntities;
using BookinV2.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace BookinV2.Data
{
    public class BookingV2DBContext : DbContext
    {
        public BookingV2DBContext(DbContextOptions<BookingV2DBContext> options)
            : base(options)
        {
        }

        public DbSet<Advertisement>? Advertisements { get; set; }

        public DbSet<RealEstateDto>? RealEstates { get; set; }

        public DbSet<RealEstatePhoto>? RealEstatePhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RealEstateEntityTypeConfiguration());
            builder.ApplyConfiguration(new RealEstatePhotoEntityTypeConfiguration());
            builder.ApplyConfiguration(new AdvertisementEntityTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
