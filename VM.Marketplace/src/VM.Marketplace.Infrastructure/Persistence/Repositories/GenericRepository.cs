using MongoDB.Driver;
using System.Linq.Expressions;
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Repositories;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
{
    private readonly IMongoCollection<TEntity> _collection;

    public GenericRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<TEntity>(collectionName);
    }

    public async Task InsertOnceAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task ReplaceOnceAsync(TEntity entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public async Task DeleteOnceAsync(Guid id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return await _collection.Find(filterExpression).ToListAsync();
    }

}
