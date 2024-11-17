namespace VM.Marketplace.Domain.Filters;

public class ProductFilter : BaseFilter
{
    private string _searchTerm;
    private string _category;

    public Guid UserId { get; set; }

    public string SearchTerm
    {
        get => _searchTerm ?? string.Empty;
        set => _searchTerm = value;
    }
    public string Category
    {
        get => _category ?? string.Empty;
        set => _category = value;
    }
}
