namespace VM.Marketplace.Application.Interfaces;

public interface ICategoryAppService
{
    Task AddCategoryAsync(CreateCategoryRequest categoryRequest);
    Task UpdateCategoryAsync(UpdateCategoryRequest groupRequest);
    Task RemoveCategoryAsync(Guid id);
    Task<Category> GetCategoryByIdAsync(Guid id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
}