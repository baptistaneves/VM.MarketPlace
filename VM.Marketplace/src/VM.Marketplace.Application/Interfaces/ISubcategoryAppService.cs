namespace VM.Marketplace.Application.Interfaces;

public interface ISubcategoryAppService
{
    Task AddSubcategoryAsync(CreateSubcategoryRequest subcategoryRequest);
    Task UpdateSubcategoryAsync(UpdateSubcategoryRequest subcategoryRequest);
    Task RemoveSubcategoryAsync(Guid id);
    Task<Subcategory> GetSubcategoryByIdAsync(Guid id);
    Task<IEnumerable<Subcategory>> GetAllSubcategoriesAsync();
}
