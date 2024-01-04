using MediatR;

namespace ArtificialIntel.Application.Features.Commands.AISender
{
    public class AISenderCommand : IRequest<int>
    {
        public string Topic { get; set; }
        public List<string> Questions { get; set; }

        public List<string> KeyWords { get; set; }
    }
}
