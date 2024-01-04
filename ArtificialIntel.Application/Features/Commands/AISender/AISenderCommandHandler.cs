using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtificialIntel.Application.Features.Commands.AISender
{
    public class AISenderCommandHandler : IRequestHandler<AISenderCommand, int>
    {
        private readonly ILogger<AISenderCommandHandler> _logger;
       
        public AISenderCommandHandler(ILogger<AISenderCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task<int> Handle(AISenderCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
