using VM.Marketplace.API.Registers.Interfaces;
using VM.Marketplace.Infrastructure;
using VM.Marketplace.Application;

namespace VM.Marketplace.API.Registers;

public class ModulesRegister : IWebApplicationBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddInfrastructure();
        builder.Services.AddApplication();
    }
}
