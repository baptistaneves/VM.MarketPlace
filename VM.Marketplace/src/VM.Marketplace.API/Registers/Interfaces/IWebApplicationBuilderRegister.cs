namespace VM.Marketplace.API.Registers.Interfaces;

public interface IWebApplicationBuilderRegister : IRegister
{
    void RegisterServices(WebApplicationBuilder builder);
}