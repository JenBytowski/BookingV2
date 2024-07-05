using BookinV2.Data.Entities;

namespace BookinV2.Data.Interfaces
{
    public interface IBookinV2DataContext
    { 
        IQueryable<TEntity> Get<TEntity>()
            where TEntity : BaseEntity;

        void Create<TEntity>(TEntity entity)
            where TEntity : BaseEntity;

        Task SubmitChangesAsync<TEntity>(CancellationToken token);
    }
}
