using MediatR;

namespace ArtificialIntel.Application.Features.Commands.AISender
{
    public class AISenderCommand : IRequest<object>
    {
        public string Topic { get; set; }
    }
}
