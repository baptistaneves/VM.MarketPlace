namespace VM.Marketplace.Domain.Dtos;

public class PagedResult<T>
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalItems { get; set; }
    public IEnumerable<T> Items { get; set; }
}
