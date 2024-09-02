namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class CommentsController : BaseController
{
    private readonly ICommentAppService _commentAppService;
    public CommentsController(INotifier notifier, ICommentAppService commentAppService) : base(notifier)
    {
        _commentAppService = commentAppService;
    }

    [HttpGet(ApiRoutes.Comment.GetAllCommentsByProductId)]
    [ValidateGuid("productId")]
    public async Task<ActionResult> GetAll(Guid productId)
    {
        return Response(await _commentAppService.GetAllCommentsByProductIdAsync(productId));
    }

    [HttpGet(ApiRoutes.Comment.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var comment = await _commentAppService.GetCommentByIdAsync(id);

        if (comment is null) return NotFound();

        return Response(comment);
    }

    [HttpPost(ApiRoutes.Comment.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateCommentRequest commentRequest)
    {
        await _commentAppService.AddCommentAsync(commentRequest);

        return Response();
    }

    [Authorize]
    [HttpDelete(ApiRoutes.Comment.Remove)]
    [ValidateGuid("id")]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _commentAppService.RemoveCommentAsync(id);

        return Response();
    }

}