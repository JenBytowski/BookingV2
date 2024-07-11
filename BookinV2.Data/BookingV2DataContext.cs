using BookinV2.Data.Entities;
using BookinV2.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookinV2.Data
{
    public class BookingV2DataContext : IBookinV2DataContext
    {
        private readonly BookingV2DBContext _db;

        public BookingV2DataContext(BookingV2DBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void Create<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            _db.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> Get<TEntity>() where TEntity : BaseEntity
        {
            return _db.Set<TEntity>().AsQueryable();
        }

        public Task SubmitChangesAsync(CancellationToken token)
        {
            return _db.SaveChangesAsync(token);
        }
    }
}
