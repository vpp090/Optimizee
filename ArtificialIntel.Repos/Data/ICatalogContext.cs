using ArtificialIntel.Repos.Entities;
using MongoDB.Driver;

namespace ArtificialIntel.Repos.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<WorskpaceEntity> WorkspaceEntities { get; }
    }
}
