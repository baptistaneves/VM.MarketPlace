using VM.Marketplace.API.Options;
using VM.Marketplace.API.Registers.Interfaces;

namespace VM.Marketplace.API.Registers;

public class SwaggerRegister : IWebApplicationBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();

        builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}