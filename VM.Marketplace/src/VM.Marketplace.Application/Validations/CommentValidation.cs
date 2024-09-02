namespace VM.Marketplace.Application.Validations;

internal class CreateCommentValidation : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentValidation()
    {
        RuleFor(x => x.Text)
           .NotEmpty().WithMessage(CommentsErrorMessage.TextIsRequired);

        RuleFor(x => x.UserName)
           .NotEmpty().WithMessage(CommentsErrorMessage.UserNameIsRequired);

        RuleFor(x => x.UserEmail)
           .NotEmpty().WithMessage(CommentsErrorMessage.UserEmailIsRequired);

        RuleFor(x => x.ProductId)
          .NotEqual(Guid.Empty).WithMessage(CommentsErrorMessage.ProductIdIsRequired);
    }
}
