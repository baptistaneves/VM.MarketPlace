using VM.Marketplace.API.Registers.Interfaces;
using VM.Marketplace.Domain.Notifications;
using VM.Marketplace.Domain.Notifications.Interfaces;

namespace VM.Marketplace.API.Registers;

public class DependencyInjectionResgistrar : IWebApplicationBuilderRegister
{
    public void RegisterServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<INotifier, Notifier>();
    }
}
