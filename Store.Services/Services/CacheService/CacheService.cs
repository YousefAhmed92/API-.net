using StackExchange.Redis;
using System.Text.Json;

namespace Store.Services.Services.CacheService
{
    public class CacheService : ICacheService
    {
        //private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;
        public CacheService(IConnectionMultiplexer redis)
        {
            //_redis = redis;
            _database = redis.GetDatabase();
        }




        public async Task<string> GetCacheResponseAsync(string Key)
        {
            var CachedResponse = await _database.StringGetAsync(Key);

            if (CachedResponse.IsNullOrEmpty)
                return null;

            return CachedResponse.ToString();
            
        }

        public async Task SetCacheResponseAsync(string Key, string response, TimeSpan TimeToLive)
        {
            if (response == null)
                return;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            var json = JsonSerializer.Serialize(response, options);

            await _database.StringSetAsync(Key, json , TimeToLive);

        }
    }
}
