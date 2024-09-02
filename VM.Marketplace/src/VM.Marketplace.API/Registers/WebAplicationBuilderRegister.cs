using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using VM.Marketplace.API.Registers.Interfaces;

namespace VM.Marketplace.API.Registers;

public class WebAplicationBuilderRegister : IWebApplicationBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();

        builder.Services.Configure<FormOptions>(x => x.MultipartBodyLengthLimit = 5000000000);

        var apiVersioningBuilder = builder.Services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
            config.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        apiVersioningBuilder.AddVersionedApiExplorer(config =>
        {
            config.GroupNameFormat = "'v'VVV";
            config.SubstituteApiVersionInUrl = true;
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowLocalhost4200",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200", "http://localhost:4201")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
        });
    }
}