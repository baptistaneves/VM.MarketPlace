namespace VM.Marketplace.Application.Services;

public class CategoryAppService : BaseAppService, ICategoryAppService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryAppService(INotifier notifier, ICategoryRepository categoryRepository) : base(notifier)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task AddCategoryAsync(CreateCategoryRequest categoryRequest)
    {
        if (!Validate(new CreateCategoryValidation(), categoryRequest)) return;

        if (_categoryRepository.FilterAsync(x => x.Description == categoryRequest.Description).Result.Any())
        {
            Notify(CategoryErrorMessage.CategoryAlreadyExists);
            return;
        }

        await _categoryRepository.InsertOnceAsync(new Category(categoryRequest.Description, categoryRequest.ImageUrl));
    }

    public async Task<string> UpdateCategoryAsync(UpdateCategoryRequest categoryRequest)
    {
        var category = await _categoryRepository.GetByIdAsync(categoryRequest.Id);

        var oldImageUrl = category.ImageUrl;

        if (category is null)
        {
            Notify(CategoryErrorMessage.CategoryNotFound);
            return string.Empty;
        }

        if (!Validate(new UpdateCategoryValidation(), categoryRequest)) return string.Empty;

        if (_categoryRepository
            .FilterAsync(x => x.Description == categoryRequest.Description && x.Id != categoryRequest.Id).Result.Any())
        {
            Notify(CategoryErrorMessage.CategoryAlreadyExists);
            return string.Empty;
        }

        category.Update(categoryRequest.Description, categoryRequest.ImageUrl);

        await _categoryRepository.ReplaceOnceAsync(category);

        return oldImageUrl;
    }

    public async Task RemoveCategoryAsync(Guid id)
    {
        if (!_categoryRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(CategoryErrorMessage.CategoryNotFound);
            return;
        }

        await _categoryRepository.DeleteOnceAsync(id);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(Guid id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }
}