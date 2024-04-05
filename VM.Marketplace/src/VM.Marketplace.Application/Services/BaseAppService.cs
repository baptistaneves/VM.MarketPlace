
namespace VM.Marketplace.Application.Services;

public abstract class BaseAppService
{
    private readonly INotifier _notifier;
    public BaseAppService(INotifier notifier)
    {
        _notifier = notifier;
    }
    protected void Notify(string message)
    {
        _notifier.Handle(new Notification(message));
    }
    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }
    public bool Validate<TV, TEntity>(TV validator, TEntity entity) where TV : AbstractValidator<TEntity> where TEntity : class
    {
        var validatorResult = validator.Validate(entity);

        if (validatorResult.IsValid) return true;

        Notify(validatorResult);

        return false;
    }
}
