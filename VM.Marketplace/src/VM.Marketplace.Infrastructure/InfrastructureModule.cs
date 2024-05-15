using AspNetCore.Identity.MongoDbCore.Extensions;
using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
using VM.Marketplace.Infrastructure.Identity.Extensions;
using VM.Marketplace.Infrastructure.Identity.Models;

namespace VM.Marketplace.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddMongo()
            .AddMongoDbIdentity()
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddMongo(this IServiceCollection services)
    {
        services.AddSingleton<MongoDbOptions>(sp => {
            var configuration = sp.GetService<IConfiguration>();
            var options = new MongoDbOptions();

            configuration.GetSection("Mongo").Bind(options);

            return options;
        });

        services.AddSingleton<IMongoClient>(sp => {
            var options = sp.GetService<MongoDbOptions>();

            var client = new MongoClient(options.ConnectionString);
            var db = client.GetDatabase(options.Database);

            return client;
        });

        services.AddTransient(sp => {
            BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

            var options = sp.GetService<MongoDbOptions>();
            var mongoClient = sp.GetService<IMongoClient>();

            var db = mongoClient.GetDatabase(options.Database);

            return db;
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
        services.AddScoped<IStateRepository, StateRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IDeliveryAddressRepository, DeliveryAddressRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        return services;
    }

    public static IServiceCollection AddMongoDbIdentity(this IServiceCollection services)
    {
        var mongoDbIdentityConfig = new MongoDbIdentityConfiguration
        {
            MongoDbSettings = new MongoDbSettings
            {
                ConnectionString = "mongodb://localhost:27017",
                DatabaseName = "marketplaceDB"
            },

            IdentityOptionsAction = options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireLowercase = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;

                options.User.RequireUniqueEmail = true;

            }

        };

        services.ConfigureMongoDbIdentity<ApplicationUser, ApplicationRole, Guid>(mongoDbIdentityConfig)
        .AddErrorDescriber<IdentityPortugueseMessages>()
        .AddUserManager<UserManager<ApplicationUser>>()
        .AddSignInManager<SignInManager<ApplicationUser>>()
        .AddRoleManager<RoleManager<ApplicationRole>>()
        .AddDefaultTokenProviders();

        return services;
    }
}
