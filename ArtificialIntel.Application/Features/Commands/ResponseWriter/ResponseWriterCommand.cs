using ArtificialIntel.Application.Entities;
using App.Domain.Entities;
using MediatR;


namespace ArtificialIntel.Application.Features.Commands.ResponseWriter
{
    public class ResponseWriterCommand : IRequest<bool>
    {
        public IEnumerable<CrossrefResponse> Result { get; set; }

        public string RequestId { get; set; }

        public string SubTopic { get; set; }
    }
}
