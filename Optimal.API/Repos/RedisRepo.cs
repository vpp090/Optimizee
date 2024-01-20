using App.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Optimal.API.Contracts;

namespace Optimal.API.Repos
{
    public class RedisRepo : IRedisRepo
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<RedisRepo> _logger;

        public RedisRepo(IDistributedCache cache, ILogger<RedisRepo> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public async Task<string> GetDataFromRedisAsync(string key)
        {
            var json = await _cache.GetStringAsync(key);

            if (string.IsNullOrWhiteSpace(json))
                return null;

            return json;
        }
    }
}
