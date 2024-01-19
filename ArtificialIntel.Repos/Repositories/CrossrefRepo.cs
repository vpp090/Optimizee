using ArtificialIntel.Repos.Contracts;
 using ArtificialIntel.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace ArtificialIntel.Repos.Repositories
{
    public class CrossrefRepo : ICrossrefRepo
    {
        private readonly IDistributedCache _cache;

        public CrossrefRepo(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SaveAuthorToRedis(IEnumerable<Author> authors, string subTopic, string requestId)
        {
            string serializedAuthors = JsonConvert.SerializeObject(authors);

            var cacheKey = $"authors_{subTopic}_{requestId}";

            await _cache.SetStringAsync(cacheKey, serializedAuthors);
        }

        public async Task SaveMaterialToRedis(IEnumerable<Material> materials, string subTopic, string requestId)
        {
            string serializedMaterials = JsonConvert.SerializeObject(materials);

            var cacheKey = $"materials_{subTopic}_{requestId}";

            await _cache.SetStringAsync(cacheKey, serializedMaterials);
        }
    }
}
