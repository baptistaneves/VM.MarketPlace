namespace VM.Marketplace.Application.Validations;

internal class CreateAdminUserValidation : AbstractValidator<CreateAdminUserRequest>
{
    public CreateAdminUserValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserErrorMessage.EmailIsRequired)
            .EmailAddress().WithMessage(UserErrorMessage.EmailNotValid);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserErrorMessage.PasswordIsRequired)
            .MinimumLength(6).WithMessage(UserErrorMessage.PasswordMinLength);
    }
}

internal class CreateCustomerUserValidation : AbstractValidator<CreateCustomerUserRequest>
{
    public CreateCustomerUserValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserErrorMessage.EmailIsRequired)
            .EmailAddress().WithMessage(UserErrorMessage.EmailNotValid);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserErrorMessage.PasswordIsRequired)
            .MinimumLength(6).WithMessage(UserErrorMessage.PasswordMinLength);
    }
}

internal class CreateSellerUserValidation : AbstractValidator<CreateSellerUserRequest>
{
    public CreateSellerUserValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserErrorMessage.EmailIsRequired)
            .EmailAddress().WithMessage(UserErrorMessage.EmailNotValid);

        RuleFor(x => x.VatNumber)
            .NotEmpty().WithMessage(UserErrorMessage.EmailNotValid);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserErrorMessage.PasswordIsRequired)
            .MinimumLength(6).WithMessage(UserErrorMessage.PasswordMinLength);
    }
}


internal class LoginValidation : AbstractValidator<LoginRequest>
{
    public LoginValidation()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserErrorMessage.EmailIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.EmailIsRequired);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserErrorMessage.PasswordIsRequired);
    }
}