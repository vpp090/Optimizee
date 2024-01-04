namespace Optimal.API.Entities
{
    public class WorkspaceResponse
    {
        public string Topic { get; set; } 
        public List<string> Subtopics { get; set; }
        public List<string> Authors { get; set; }
    }
}
