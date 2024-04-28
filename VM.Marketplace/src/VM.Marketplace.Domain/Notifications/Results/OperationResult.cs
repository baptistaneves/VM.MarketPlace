namespace VM.Marketplace.Domain.Notifications.Results;

public class OperationResult<T>
{
    public T Payload { get; set; }
    public bool HasError { get; set; }
    public List<ErrorResult> Errors { get; set; } = new List<ErrorResult>();

    public void AddError(string message)
    {
        HandleError(message);
    }

    private void HandleError(string  message)
    {
        Errors.Add(new ErrorResult { Message = message });
        HasError = true;
    }
}