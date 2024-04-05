using System.Linq.Expressions;
using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Domain.Repositories;

public interface IGenericRepository<TEntity>  where TEntity : Entity
{
    Task InsertOnceAsync(TEntity entity);
    Task ReplaceOnceAsync(TEntity entity);
    Task DeleteOnceAsync(Guid id);
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> filterExpression);
}