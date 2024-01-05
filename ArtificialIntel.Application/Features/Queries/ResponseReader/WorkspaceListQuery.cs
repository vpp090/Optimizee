using ArtificialIntel.Repos.Entities;
using MediatR;

namespace ArtificialIntel.Application.Features.Queries.ResponseReader
{
    public class WorkspaceListQuery : IRequest<IEnumerable<WorkspaceEntity>>
    {
        
    }
}
