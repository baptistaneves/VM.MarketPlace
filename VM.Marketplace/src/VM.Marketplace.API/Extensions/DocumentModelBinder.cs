using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace VM.Marketplace.API.Extensions;

public class DocumentModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true
        };

        var product = JsonSerializer.Deserialize<CreateProductRequest>(bindingContext.ValueProvider.GetValue("product").FirstOrDefault(), serializeOptions);
        product.ImageFile = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

        bindingContext.Result = ModelBindingResult.Success(product);
        return Task.CompletedTask;
    }
}

public class CreateCategoryModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true
        };

        var category = JsonSerializer.Deserialize<CreateCategoryRequest>(bindingContext.ValueProvider.GetValue("category").FirstOrDefault(), serializeOptions);
        category.ImageFile = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

        bindingContext.Result = ModelBindingResult.Success(category);
        return Task.CompletedTask;
    }
}

public class UpdateCategoryModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var serializeOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true
        };

        var category = JsonSerializer.Deserialize<UpdateCategoryRequest>(bindingContext.ValueProvider.GetValue("category").FirstOrDefault(), serializeOptions);
        category.ImageFile = bindingContext.ActionContext.HttpContext.Request.Form.Files.FirstOrDefault();

        bindingContext.Result = ModelBindingResult.Success(category);
        return Task.CompletedTask;
    }
}
