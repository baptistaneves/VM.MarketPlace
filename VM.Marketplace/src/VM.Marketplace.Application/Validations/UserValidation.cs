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

internal class UpdateAdminUserValidation : AbstractValidator<UpdateAdminUserRequest>
{
    public UpdateAdminUserValidation()
    {
        RuleFor(x => x.Id)
           .NotEqual(Guid.Empty).WithMessage(UserErrorMessage.IdNotValid);

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserErrorMessage.EmailIsRequired)
            .EmailAddress().WithMessage(UserErrorMessage.EmailNotValid);
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

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(UserErrorMessage.PhoneNumberIsRequired);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserErrorMessage.PasswordIsRequired)
            .MinimumLength(6).WithMessage(UserErrorMessage.PasswordMinLength);
    }
}

internal class UpdateSellerUserValidation : AbstractValidator<UpdateSellerUserRequest>
{
    public UpdateSellerUserValidation()
    {
        RuleFor(x => x.Id)
           .NotEqual(Guid.Empty).WithMessage(UserErrorMessage.IdNotValid);

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage(UserErrorMessage.EmailIsRequired)
            .EmailAddress().WithMessage(UserErrorMessage.EmailNotValid);

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage(UserErrorMessage.PhoneNumberIsRequired);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(UserErrorMessage.AddressIsRequired);

        RuleFor(x => x.City)
            .NotEmpty().WithMessage(UserErrorMessage.CityIsRequired);

        RuleFor(x => x.State)
            .NotEmpty().WithMessage(UserErrorMessage.StateIsRequired);
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