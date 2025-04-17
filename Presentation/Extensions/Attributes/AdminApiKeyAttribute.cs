using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AdminApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var adminApiKey = configuration["ApiKeys:Admin"];

        if (!context.HttpContext.Request.Headers.TryGetValue("X-ADM-API-KEY", out var providedApiKey))
        {
            context.Result = new UnauthorizedObjectResult("Invalid API key or API key is missing.");
            return;
        }

        if (string.IsNullOrEmpty(adminApiKey) || !string.Equals(providedApiKey, adminApiKey))
        {
            context.Result = new UnauthorizedObjectResult("Invalid API key.");
            return;
        }

        await next();
    }
}
