namespace VM.Marketplace.Domain.Filters;

public abstract class BaseFilter
{
    private const int _maxItemsPerPage = 20;
    private int itemsPerPage = 10;

    public int PageNumber { get; set; } = 1;
    public int PageSize
    {
        get => itemsPerPage;
        set => itemsPerPage = (value > _maxItemsPerPage) ? _maxItemsPerPage : value;
    }
}