using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateCommentRequest
{
    [Required(ErrorMessage = CommentsErrorMessage.TextIsRequired)]
    public string Text { get; set; }

    [Required(ErrorMessage = CommentsErrorMessage.ProductIdIsRequired)]
    public Guid ProductId { get; set; }

    [Required(ErrorMessage = CommentsErrorMessage.UserNameIsRequired)]
    public string UserName { get; set; }

    [Required(ErrorMessage = CommentsErrorMessage.UserEmailIsRequired)]
    public string UserEmail { get; set; }

    public string UserPhoneNumber { get; set; }
}