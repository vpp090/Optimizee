using ArtificialIntel.Application.Entities;
using ArtificialIntel.Services.Contracts;
using MediatR;
using Newtonsoft.Json;

namespace ArtificialIntel.Application.Features.Commands.CrossrefSender
{
    public class CrossrefSenderCommandHandler : IRequestHandler<CrossrefSenderCommand, IEnumerable<string>>
    {
        private readonly ICrossrefService _service;
        private readonly IHttpClientFactory _clientFactory;

        public CrossrefSenderCommandHandler(ICrossrefService service, IHttpClientFactory clientFactory)
        {
            _service = service;
           _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<string>> Handle(CrossrefSenderCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.SendRequestToCrossref(request.SubTopics, request.Rows, request.Offset, _clientFactory);

            return result;
        }
    }
}
