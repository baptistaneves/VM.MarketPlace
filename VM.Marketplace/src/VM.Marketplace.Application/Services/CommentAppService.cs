namespace VM.Marketplace.Application.Services;

public class CommentAppService : BaseAppService, ICommentAppService
{
    private readonly ICommentRepository _commentRepository;
    public CommentAppService(INotifier notifier, ICommentRepository commentRepository) : base(notifier)
    {
        _commentRepository = commentRepository;
    }

    public async Task AddCommentAsync(CreateCommentRequest commentRequest)
    {
        if (!Validate(new CreateCommentValidation(), commentRequest)) return;

        await _commentRepository.InsertOnceAsync(new Comment(commentRequest.Text, commentRequest.ProductId,
            commentRequest.UserName, commentRequest.UserEmail, commentRequest.UserPhoneNumber));
    }

    public async Task<IEnumerable<Comment>> GetAllCommentsByProductIdAsync(Guid productId)
    {
        return await _commentRepository.GetAllCommentsByProductIdAsync(productId);
    }

    public async Task<Comment> GetCommentByIdAsync(Guid id)
    {
        return await _commentRepository.GetByIdAsync(id);
    }

    public async Task RemoveCommentAsync(Guid id)
    {
        await _commentRepository.DeleteOnceAsync(id);
    }
}