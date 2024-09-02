using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Domain.Repositories;

public interface ICommentRepository : IGenericRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllCommentsByProductIdAsync(Guid productId);
}