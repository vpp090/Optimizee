using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace App.Domain.Entities
{
    public class WorkspaceEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Topic { get; set; }
        public List<string> SubTopics { get; set; }
        public List<Author> Authors { get; set; }
        public List<Discussion> Discussions { get; set; }
        public List<Material> Materials { get; set; }
        
    }
}
