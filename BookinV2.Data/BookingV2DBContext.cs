using BookinV2.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookinV2.Data
{
    public class BookingV2DBContext : IdentityDbContext<ApplicationUser>
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
