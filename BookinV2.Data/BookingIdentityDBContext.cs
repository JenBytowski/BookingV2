using BookinV2.Data.Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookinV2.Data
{
    public class BookingIdentityDBContext : IdentityDbContext<ApplicationUser>
    {
        public BookingIdentityDBContext(DbContextOptions<BookingIdentityDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
