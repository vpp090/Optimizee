using ArtificialIntel.Repos.Contracts;
using ArtificialIntel.Services.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtificialIntel.Application.Features.Commands.AISender
{
    public class AISenderCommandHandler : IRequestHandler<AISenderCommand, object>
    {
        private readonly ILogger<AISenderCommandHandler> _logger;
        private readonly IGptService _gptService;
        public AISenderCommandHandler(ILogger<AISenderCommandHandler> logger, IOptimalRepo repo, IGptService service)
        {
            _logger = logger;
            _gptService = service;
        }

        public async Task<object> Handle(AISenderCommand request, CancellationToken cancellationToken)
        {
            return default;
        }
    }
}
