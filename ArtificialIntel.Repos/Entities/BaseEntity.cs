using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtificialIntel.Repos.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }
    }
}
