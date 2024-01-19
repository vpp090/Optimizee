using MediatR;

namespace ArtificialIntel.Application.Features.Commands.CrossrefSender
{
    public class CrossrefSenderCommand : IRequest<IEnumerable<string>>
    {
        public List<string> SubTopics { get; set; }

        public int Rows { get; set; }

        public int Offset { get; set; }

        public string RequestId { get; set; }
    }
}
