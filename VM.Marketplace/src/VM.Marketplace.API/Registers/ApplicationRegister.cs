using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.FileProviders;
using VM.Marketplace.API.Middleware;
using VM.Marketplace.API.Registers.Interfaces;

namespace VM.Marketplace.API.Registers;

public class ApplicationRegister : IWebApplicationRegister
{
    public void RegisterPipelineComponents(WebApplication app)
    {
        app.ConfigureExceptionHandler(app.Environment);

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.ApiVersion.ToString());
            }
        });

        app.UseHttpsRedirection();

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(app.Environment.ContentRootPath, "wwwroot", "Categories")),
            RequestPath = "/Categories"
        });

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(app.Environment.ContentRootPath, "wwwroot", "Products")),
            RequestPath = "/Products"
        });

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(app.Environment.ContentRootPath, "wwwroot", "Licenses")),
            RequestPath = "/Licenses"
        });

        app.UseCors("AllowLocalhost4200");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
    }
}
