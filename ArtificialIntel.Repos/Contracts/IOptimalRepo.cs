using ArtificialIntel.Domain.Entities;

namespace ArtificialIntel.Repos.Contracts
{
    public interface IOptimalRepo
    {
        Task<WorkspaceEntity> GetWorkspaceEntity(string id);
        Task<IEnumerable<WorkspaceEntity>> GetAllWorkspaceEntities();

        Task<Author> GetAuthor(string wId, string aid);
        Task<Discussion> GetDiscussion(string wId, string dId);
        Task<Material> GetMaterial(string wId, string mId);
    }
}
