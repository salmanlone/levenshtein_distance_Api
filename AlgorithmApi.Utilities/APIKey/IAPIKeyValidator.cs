using Microsoft.AspNetCore.Http;

namespace AlgorithmApi.Utilities.APIKey
{
    public interface IAPIKeyValidator
    {
        bool ValidateAPIKey(HttpContext httpContext, string key);
    }
}