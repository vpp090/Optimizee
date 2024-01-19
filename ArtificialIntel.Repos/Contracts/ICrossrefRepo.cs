using ArtificialIntel.Domain.Entities;

namespace ArtificialIntel.Repos.Contracts
{
    public interface ICrossrefRepo
    {
        Task SaveMaterialToRedis(IEnumerable<Material> material, string subTopic, string requestId);
        Task SaveAuthorToRedis(IEnumerable<Author> author, string subTopic, string requestId);
    }
}
