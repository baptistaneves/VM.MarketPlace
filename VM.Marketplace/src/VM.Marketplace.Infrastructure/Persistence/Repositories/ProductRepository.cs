using VM.Marketplace.Domain.Filters;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private const string collectionName = "products";
    public ProductRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }

    public async Task<PagedResult<ProductDto>> GetAllProducts(ProductFilter filter)
    {
        var query = from product in _collection.AsQueryable()
                    join category in _collection.Database.GetCollection<Category>("categories").AsQueryable() on product.CategoryId equals category.Id into productCategoryJoin
                    join user in _collection.Database.GetCollection<User>("users").AsQueryable() on product.UserId equals user.Id into productUserJoin
                    from category in productCategoryJoin.DefaultIfEmpty()
                    from user in productUserJoin.DefaultIfEmpty()
                    select new { product, category, user };

        if (!string.IsNullOrEmpty(filter.SearchTerm))
        {
            query = query.Where(x => x.product.Name.Contains(filter.SearchTerm) ||
                                     x.product.Description.Contains(filter.SearchTerm) ||
                                     x.category.Description.Contains(filter.SearchTerm) ||
                                     x.user.FullName.Contains(filter.SearchTerm));
        }

        if (!string.IsNullOrEmpty(filter.Category))
        {
            query = query.Where(x => x.category.Description == filter.Category);
        }

        int totalItems = query.Count();

        int skip = (filter.PageNumber - 1) * filter.PageSize;

        var items = query
            .Skip(skip)
            .Take(filter.PageSize)
            .Select(x => new ProductDto
            {
                Id = x.product.Id,
                Description = x.product.Description,
                Name = x.product.Name,
                TechnicalSpecifications = x.product.TechnicalSpecifications,
                Price = x.product.Price,
                PromotionalPrice = x.product.PromotionalPrice,
                IsActive = x.product.IsActive,
                IsDeleted = x.product.IsDeleted,
                CategoryId = x.product.CategoryId,
                UserId = x.product.UserId,
                CategoryName = x.category.Description,
                IsUserVerified = x.user.IsVerified,
                UserFullName = x.user.FullName,
                IsMedicine = x.product.IsMedicine,
                ExpiryDate = x.product.ExpiryDate,
                MainPhoto = x.product.MainPhoto
            })
            .ToList();

        return new PagedResult<ProductDto>
        {
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber,
            TotalItems = totalItems,
            Items = items
        };
    }


    public async Task<PagedResult<ProductDto>> GetProductsByUser(ProductFilter filter)
    {
        var query = from product in _collection.AsQueryable()
                    join category in _collection.Database.GetCollection<Category>("categories").AsQueryable() on product.CategoryId equals category.Id into productCategoryJoin
                    join user in _collection.Database.GetCollection<User>("users").AsQueryable() on product.UserId equals user.Id into productUserJoin
                    from category in productCategoryJoin.DefaultIfEmpty()
                    from user in productUserJoin.DefaultIfEmpty()
                    select new { product, category, user };

        if (!string.IsNullOrEmpty(filter.SearchTerm))
        {
            query = query.Where(x => x.product.Name.Contains(filter.SearchTerm) ||
                                     x.product.Description.Contains(filter.SearchTerm) ||
                                     x.category.Description.Contains(filter.SearchTerm) ||
                                     x.user.FullName.Contains(filter.SearchTerm));
        }

        if (filter.UserId != Guid.Empty)
        {
            query = query.Where(x => x.user.Id == filter.UserId);
        }

        int totalItems = query.Count();

        int skip = (filter.PageNumber - 1) * filter.PageSize;

        var items = query
            .Skip(skip)
            .Take(filter.PageSize)
            .Select(x => new ProductDto
            {
                Id = x.product.Id,
                Description = x.product.Description,
                Name = x.product.Name,
                TechnicalSpecifications = x.product.TechnicalSpecifications,
                Price = x.product.Price,
                PromotionalPrice = x.product.PromotionalPrice,
                IsActive = x.product.IsActive,
                IsDeleted = x.product.IsDeleted,
                CategoryId = x.product.CategoryId,
                UserId = x.product.UserId,
                CategoryName = x.category.Description,
                UserFullName = x.user.FullName,
                IsUserVerified = x.user.IsVerified,
                IsMedicine = x.product.IsMedicine,
                ExpiryDate = x.product.ExpiryDate,
                MainPhoto = x.product.MainPhoto
            })
            .ToList();

        return new PagedResult<ProductDto>
        {
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber,
            TotalItems = totalItems,
            Items = items
        };
    }

    public async Task<ProductDto> GetProductById(Guid id)
    {
        var productCollection = _collection.AsQueryable();
        var categoryCollection = _collection.Database.GetCollection<Category>("categories").AsQueryable();
        var userCollection = _collection.Database.GetCollection<User>("users").AsQueryable();

        var query = from product in productCollection
                    join category in categoryCollection on product.CategoryId equals category.Id into productCategoryJoin
                    from category in productCategoryJoin.DefaultIfEmpty()
                    join user in userCollection on product.UserId equals user.Id into productUserJoin
                    from user in productUserJoin.DefaultIfEmpty()
                    where product.Id == id
                    select new ProductDto
                    {
                        Id = product.Id,
                        Description = product.Description,
                        Name = product.Name,
                        TechnicalSpecifications = product.TechnicalSpecifications,
                        Price = product.Price,
                        PromotionalPrice = product.PromotionalPrice,
                        IsActive = product.IsActive,
                        IsDeleted = product.IsDeleted,
                        CategoryId = product.CategoryId,
                        UserId = product.UserId,
                        CategoryName = category.Description,
                        UserFullName = user.FullName,
                        IsUserVerified = user.IsVerified,
                        PhoneNumber = user.PhoneNumber,
                        Email = user.Email,
                        Address = user.State + "-" + user.City + ", " + user.Address,
                        IsMedicine = product.IsMedicine,
                        ExpiryDate = product.ExpiryDate,
                        MainPhoto = product.MainPhoto
                    };

        var result = await Task.Run(() => query.FirstOrDefault());
        return result;
    }

}