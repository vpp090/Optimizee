using ArtificialIntel.Repos.Contracts;
using ArtificialIntel.Repos.Data;
using ArtificialIntel.Repos.Entities;
using MongoDB.Driver;

namespace ArtificialIntel.Repos.Repositories
{
    public class OptimalRepository : IOptimalRepo
    {
        private readonly IResponseContext _context;

        public OptimalRepository(IResponseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkspaceEntity>> GetAllWorkspaceEntities()
        {
            var result = await _context.WorkspaceEntities
                                .Find(w => true)
                                .ToListAsync();
            return result;
        }

        public async Task<Author> GetAuthor(string wId, string aId)
        {
            var workspace = await _context.WorkspaceEntities
                                    .Find(w => w.Id == wId)
                                    .FirstOrDefaultAsync();
            
            return workspace.Authors.FirstOrDefault(a => a.Id == aId);
        }

        public async Task<Discussion> GetDiscussion(string wId, string dId)
        {
            var workspace = await _context.WorkspaceEntities
                                    .Find(w => w.Id == wId)
                                    .FirstOrDefaultAsync();

            return workspace.Discussions.FirstOrDefault(d => d.Id == dId);
        }

        public async Task<Material> GetMaterial(string wId, string mId)
        {
            var workspace = await _context.WorkspaceEntities
                                    .Find(w => w.Id == wId)
                                    .FirstOrDefaultAsync();

            return workspace.Materials.FirstOrDefault(m => m.Id == mId);
        }

        public async Task<WorkspaceEntity> GetWorkspaceEntity(string id)
        {
            return await _context.WorkspaceEntities.Find(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveWorkspaceEntity(WorkspaceEntity workspaceEntity)
        {
            throw new NotImplementedException();
        }
    }
}
