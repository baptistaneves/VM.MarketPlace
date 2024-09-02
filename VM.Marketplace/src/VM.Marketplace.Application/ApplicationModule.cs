namespace VM.Marketplace.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddServices();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGroupAppService, GroupAppService>();
        services.AddScoped<ICategoryAppService, CategoryAppService>();
        services.AddScoped<IUnitAppService, UnitAppService>();
        services.AddScoped<ISubcategoryAppService, SubcategoryAppService>();
        services.AddScoped<IStateAppService, StateAppService>();
        services.AddScoped<ICityAppService, CityAppService>();
        services.AddScoped<IAddressAppService, AddressAppService>();
        services.AddScoped<IDeliveryAddressAppService, DeliveryAddressAppService>();
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<IRoleAppService, RoleAppService>();
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<ICommentAppService, CommentAppService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}