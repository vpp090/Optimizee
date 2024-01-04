namespace ArtificialIntel.Repos.Entities
{
    public class WorskpaceEntity
    {
        public string Topic { get; set; }
        public List<string> SubTopics { get; set; }
        public List<Author> Authors { get; set; }
        public List<Discussion> Discussions { get; set; }
        public List<Material> Materials { get; set; }
        
    }
}
