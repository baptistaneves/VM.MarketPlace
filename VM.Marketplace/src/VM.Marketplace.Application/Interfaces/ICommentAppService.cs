namespace VM.Marketplace.Application.Interfaces;

public interface ICommentAppService
{
    Task AddCommentAsync(CreateCommentRequest commentRequest);
    Task RemoveCommentAsync(Guid id);
    Task<Comment> GetCommentByIdAsync(Guid id);
    Task<IEnumerable<Comment>> GetAllCommentsByProductIdAsync(Guid productId);
}