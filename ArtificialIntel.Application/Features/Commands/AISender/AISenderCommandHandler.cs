using ArtificialIntel.Repos.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtificialIntel.Application.Features.Commands.AISender
{
    public class AISenderCommandHandler : IRequestHandler<AISenderCommand, int>
    {
        private readonly ILogger<AISenderCommandHandler> _logger;
        private readonly IOptimalRepo _repo;
        public AISenderCommandHandler(ILogger<AISenderCommandHandler> logger, IOptimalRepo repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public Task<int> Handle(AISenderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
