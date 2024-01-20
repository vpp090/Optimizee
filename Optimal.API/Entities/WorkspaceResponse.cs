using App.Domain.Entities;

namespace Optimal.API.Entities
{
    public class WorkspaceResponse
    {
        public IEnumerable<Author> Authors { get; set; }

        public IEnumerable<Material> Materials { get; set; }
    }
}
