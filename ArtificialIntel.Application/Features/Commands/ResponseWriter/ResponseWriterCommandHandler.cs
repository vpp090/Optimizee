using ArtificialIntel.Repos.Contracts;
using MediatR;


namespace ArtificialIntel.Application.Features.Commands.ResponseWriter
{
    public class ResponseWriterCommandHandler : IRequestHandler<ResponseWriterCommand, int>
    {
        private readonly IOptimalRepo _repo;

        public ResponseWriterCommandHandler(IOptimalRepo repo)
        {
            _repo = repo;
        }

        public Task<int> Handle(ResponseWriterCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
