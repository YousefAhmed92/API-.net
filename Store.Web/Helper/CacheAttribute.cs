using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;  // Add this for JSON serialization/deserialization
using Store.Services.Services.CacheService;
using System.Text;
using System.Threading.Tasks;

namespace Store.Web.Helper
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _timeToLiveInSeconds;

        public CacheAttribute(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
            var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            // Try to get cached response
            var cachedResponse = await _cacheService.GetCacheResponseAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedResponse))
            {
                // If cache hit, deserialize the cached response and return it
                var contentResult = new ContentResult
                {
                    Content = cachedResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            // Proceed with the action if no cache is found
            var executedContext = await next();

            if (executedContext.Result is OkObjectResult response)
            {
                // Serialize the response value into JSON and store it in the cache
                var serializedResponse = JsonConvert.SerializeObject(response.Value);

                await _cacheService.SetCacheResponseAsync(cacheKey, serializedResponse, TimeSpan.FromSeconds(_timeToLiveInSeconds));
            }
        }

        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {
            var cacheKey = new StringBuilder($"{request.Path}");

            foreach (var (key, value) in request.Query)
            {
                cacheKey.Append($"|{key}-{value}");
            }

            return cacheKey.ToString();
        }
    }
}
