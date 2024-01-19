using ArtificialIntel.Repos.Contracts;
using App.Domain.Entities;
using MediatR;

namespace ArtificialIntel.Application.Features.Queries.ResponseReader
{
    public class WorkspaceListHandler : IRequestHandler<WorkspaceListQuery, IEnumerable<WorkspaceEntity>>
    {
        private readonly IOptimalRepo _repo;

        public WorkspaceListHandler(IOptimalRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<WorkspaceEntity>> Handle(WorkspaceListQuery request, CancellationToken cancellationToken)
        {
            var list = await _repo.GetAllWorkspaceEntities();

            return list;
        }
    }
}
