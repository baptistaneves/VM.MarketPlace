namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly IMongoCollection<TEntity> _collection;

    public GenericRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<TEntity>(collectionName);
    }

    public virtual async Task InsertOnceAsync(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public virtual async Task ReplaceOnceAsync(TEntity entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public virtual async Task UpdateFieldAsync(Guid id, string fieldName, object newValue)
    {
        var filter = Builders<TEntity>.Filter.Eq("_id", id); 
        var update = Builders<TEntity>.Update.Set(fieldName, newValue);

        await _collection.UpdateOneAsync(filter, update);
    }

    public virtual async Task DeleteOnceAsync(Guid id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public virtual async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _collection.Find(x => x.Id == id).SingleOrDefaultAsync();
    }

    public virtual async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> filterExpression)
    {
        return await _collection.Find(filterExpression).ToListAsync();
    }

}
