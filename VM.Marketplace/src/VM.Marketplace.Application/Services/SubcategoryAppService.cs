using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Application.Services;

public class SubcategoryAppService : BaseAppService, ISubcategoryAppService
{
    private readonly ISubcategoryRepository _subcategoryRepository;
    public SubcategoryAppService(INotifier notifier, 
                                 ISubcategoryRepository subcategoryRepository) : base(notifier)
    {
        _subcategoryRepository = subcategoryRepository;
    }

    public async Task AddSubcategoryAsync(CreateSubcategoryRequest subcategoryRequest)
    {
        if (!Validate(new CreateSubcategoryValidation(), subcategoryRequest)) return;

        if (_subcategoryRepository.FilterAsync(x => x.Description == subcategoryRequest.Description).Result.Any())
        {
            Notify(SubcategoryErrorMessage.SubcategoryAlreadyExists);
            return;
        }

        await _subcategoryRepository.InsertOnceAsync(new Subcategory(subcategoryRequest.Description, subcategoryRequest.CategoryId));
    }

    public async Task<IEnumerable<Subcategory>> GetAllSubcategoriesAsync()
    {
        return await _subcategoryRepository.GetAllAsync();
    }

    public async Task<IEnumerable<SubcategoryDto>> GetSubcategoriesByCategoryId(Guid categoryId)
    {
        return await _subcategoryRepository.GetSubcategoriesByCategoryId(categoryId);
    }

    public async Task<Subcategory> GetSubcategoryByIdAsync(Guid id)
    {
        return await _subcategoryRepository.GetByIdAsync(id);
    }

    public async Task RemoveSubcategoryAsync(Guid id)
    {
        if (!_subcategoryRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(SubcategoryErrorMessage.SubcategoryNotFound);
            return;
        }

        await _subcategoryRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateSubcategoryAsync(UpdateSubcategoryRequest subcategoryRequest)
    {
        var subcategory = await _subcategoryRepository.GetByIdAsync(subcategoryRequest.Id);

        if (subcategory is null)
        {
            Notify(SubcategoryErrorMessage.SubcategoryNotFound);
            return;
        }

        if (!Validate(new UpdateSubcategoryValidation(), subcategoryRequest)) return;

        if (_subcategoryRepository
            .FilterAsync(x => x.Description == subcategoryRequest.Description && x.Id != subcategoryRequest.Id).Result.Any())
        {
            Notify(SubcategoryErrorMessage.SubcategoryAlreadyExists);
            return;
        }

        subcategory.Update(subcategoryRequest.Description, subcategoryRequest.CategoryId);

        await _subcategoryRepository.ReplaceOnceAsync(subcategory);
    }
}