using ArtificialIntel.Repos.Contracts;
using ArtificialIntel.Repos.Entities;
using MediatR;


namespace ArtificialIntel.Application.Features.Commands.ResponseWriter
{
    public class ResponseWriterCommandHandler : IRequestHandler<ResponseWriterCommand, IEnumerable<WorkspaceEntity>>
    {
        private readonly IOptimalRepo _repo;

        public ResponseWriterCommandHandler(IOptimalRepo repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<WorkspaceEntity>> Handle(ResponseWriterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
