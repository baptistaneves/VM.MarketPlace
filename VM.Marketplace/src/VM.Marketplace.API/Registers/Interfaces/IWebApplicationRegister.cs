namespace VM.Marketplace.API.Registers.Interfaces;

public interface IWebApplicationRegister : IRegister
{
    void RegisterPipelineComponents(WebApplication app);
}
