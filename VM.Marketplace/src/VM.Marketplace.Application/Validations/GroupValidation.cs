namespace VM.Marketplace.Application.Validations;

internal class CreateGroupRequestValidation : AbstractValidator<CreateGroupRequest>
{
    public CreateGroupRequestValidation()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(GroupErrorMessage.DescriptionIsRequired)
            .MinimumLength(3).WithMessage(GroupErrorMessage.DescriptionMinLength);
    }
}

internal class UpdateGroupRequestValidation : AbstractValidator<UpdateGroupRequest>
{
    public UpdateGroupRequestValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(GroupErrorMessage.DescriptionIdNotValid);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(GroupErrorMessage.DescriptionIsRequired)
            .MinimumLength(3).WithMessage(GroupErrorMessage.DescriptionMinLength);
    }
}