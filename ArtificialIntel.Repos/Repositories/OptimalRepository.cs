using ArtificialIntel.Repos.Contracts;
using ArtificialIntel.Repos.Data;
 using App.Domain.Entities;
using MongoDB.Bson;
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
            var filter = Builders<WorkspaceEntity>.Filter.Eq(w => w.Id, wId);
            var match = new BsonDocument("$match", filter.ToBsonDocument());

            var unwind = new BsonDocument("$unwind", "$Authors");
            var matchAuthor = new BsonDocument("$match", new BsonDocument("Authors.Id", aId));

            var pipeline = new[] { match, unwind, matchAuthor };
            var authorResult = await _context.WorkspaceEntities
                                            .Aggregate<Author>(pipeline)
                                            .FirstOrDefaultAsync();

            return authorResult;
        }


        public async Task<Discussion> GetDiscussion(string wId, string dId)
        {
            var filter = Builders<WorkspaceEntity>.Filter.Eq(w => w.Id, wId);
            var match = new BsonDocument("$match", filter.ToBsonDocument());

            var unwind = new BsonDocument("$unwind", "$Discussions");
            var matchDiscussion = new BsonDocument("$match", new BsonDocument("Discussions.Id", dId));

            var pipeline = new[] { match, unwind, matchDiscussion };
            var discussionResult = await _context.WorkspaceEntities
                                                 .Aggregate<Discussion>(pipeline)
                                                 .FirstOrDefaultAsync();

            return discussionResult;
        }


        public async Task<Material> GetMaterial(string wId, string mId)
        {
            var filter = Builders<WorkspaceEntity>.Filter.Eq(w => w.Id, wId);
            var match = new BsonDocument("$match", filter.ToBsonDocument());

            var unwind = new BsonDocument("$unwind", "$Materials");
            var matchMaterial = new BsonDocument("$match", new BsonDocument("Materials.Id", mId));

            var pipeline = new[] { match, unwind, matchMaterial };
            var materialResult = await _context.WorkspaceEntities
                                               .Aggregate<Material>(pipeline)
                                               .FirstOrDefaultAsync();

            return materialResult;
        }


        public async Task<WorkspaceEntity> GetWorkspaceEntity(string id)
        {
            return await _context.WorkspaceEntities.Find(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveWorkspaceEntity(WorkspaceEntity workspaceEntity)
        {
            await _context.WorkspaceEntities.InsertOneAsync(workspaceEntity);

            return true;
        }
    }
}
