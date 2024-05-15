namespace VM.Marketplace.Application.Validations;

public class CreateRoleValidation : AbstractValidator<RoleRequest>
{
    public CreateRoleValidation()
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage(RoleErrorMessage.NameIsRequired)
           .MinimumLength(3).WithMessage(RoleErrorMessage.NameMinLength);
    }
}

public class UpdateRoleValidation : AbstractValidator<RoleRequest>
{
    public UpdateRoleValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(RoleErrorMessage.IdNotValid);

        RuleFor(x => x.Name)
           .NotEmpty().WithMessage(RoleErrorMessage.NameIsRequired)
           .MinimumLength(3).WithMessage(RoleErrorMessage.NameMinLength);
    }
}
