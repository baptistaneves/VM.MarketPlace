using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using VM.Marketplace.Domain.Repositories;
using VM.Marketplace.Infrastructure.Persistence;
using VM.Marketplace.Infrastructure.Persistence.Repositories;

namespace VM.Marketplace.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services
            .AddMongo()
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

        return services;
    }
}
