using ArtificialIntel.Repos.Entities;
using MongoDB.Driver;

namespace ArtificialIntel.Repos.Data
{
    public interface IResponseContext
    {
        IMongoCollection<WorkspaceEntity> WorkspaceEntities { get; }
    }
}
