namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    private const string collectionName = "comments";
    public CommentRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
    public async Task<IEnumerable<Comment>> GetAllCommentsByProductIdAsync(Guid productId)
    {
        return await _collection.Find(x => x.ProductId == productId).ToListAsync();

    }

}