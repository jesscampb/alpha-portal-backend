namespace Presentation.Extensions.Middlewares;

public class DefaultApiKeyMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;
    private const string APIKEY_HEADER_NAME = "X-API-KEY";
    private readonly string _apiKey = String.Empty;

    public DefaultApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
        _apiKey = _configuration["ApiKeys:Default"]!;
    }
}
