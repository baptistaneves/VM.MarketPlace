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

        RuleFor(x => x.VatNumber)
            .NotEmpty().WithMessage(UserErrorMessage.EmailNotValid);

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage(UserErrorMessage.PasswordIsRequired)
            .MinimumLength(6).WithMessage(UserErrorMessage.PasswordMinLength);
    }
}

internal class CreateSellerUserFromDashboardValidation : AbstractValidator<CreateSellerUserFromDashboardRequest>
{
    public CreateSellerUserFromDashboardValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.DeliveryAddress)
            .NotEmpty().WithMessage(UserErrorMessage.DeliveryAddressIsRequired);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired);

        RuleFor(x => x.Bank)
            .NotEmpty().WithMessage(UserErrorMessage.BankIsRequired);

        RuleFor(x => x.AccountHolder)
            .NotEmpty().WithMessage(UserErrorMessage.AccountHolderIsRequired);

        RuleFor(x => x.AccountNumber)
           .NotEmpty().WithMessage(UserErrorMessage.AccountNumberIsRequired);

        RuleFor(x => x.Iban)
           .NotEmpty().WithMessage(UserErrorMessage.IbanIsRequired);

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

internal class UpdateSellerUserFromDashboardValidation : AbstractValidator<CreateSellerUserFromDashboardRequest>
{
    public UpdateSellerUserFromDashboardValidation()
    {
        RuleFor(x => x.Id)
          .NotEqual(Guid.Empty).WithMessage(UserErrorMessage.IdNotValid);

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired)
            .MinimumLength(3).WithMessage(UserErrorMessage.FullNameMinLength);

        RuleFor(x => x.DeliveryAddress)
            .NotEmpty().WithMessage(UserErrorMessage.DeliveryAddressIsRequired);

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage(UserErrorMessage.FullNameIsRequired);

        RuleFor(x => x.Bank)
            .NotEmpty().WithMessage(UserErrorMessage.BankIsRequired);

        RuleFor(x => x.AccountHolder)
            .NotEmpty().WithMessage(UserErrorMessage.AccountHolderIsRequired);

        RuleFor(x => x.AccountNumber)
           .NotEmpty().WithMessage(UserErrorMessage.AccountNumberIsRequired);

        RuleFor(x => x.Iban)
           .NotEmpty().WithMessage(UserErrorMessage.IbanIsRequired);

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