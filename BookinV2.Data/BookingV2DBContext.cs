using BookinV2.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookinV2.Data
{
    public class BookingV2DBContext : DbContext
    {
        public BookingV2DBContext(DbContextOptions<BookingV2DBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
