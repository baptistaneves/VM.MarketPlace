namespace VM.Marketplace.Domain.Entities;

public class ProductPhoto
{
    public Guid ProductId { get; private set; }
    public string Url { get; private set; }

    //EF Rel.
    public Product Product { get; private set; }
}
