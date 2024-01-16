using ArtificialIntel.Application.Entities;
using ArtificialIntel.Application.Features.Commands.CrossrefSender;
using ArtificialIntel.Application.Features.Commands.ResponseWriter;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using OptimalPackage.Events;
using OptimalPackage.Models;
using SpecMapperR;

namespace ArtificialIntel.API.Consumers
{
    public class CrossrefRequestConsumer : IConsumer<CrossrefEvent>
    {
        private readonly IMediator _mediator;
        private readonly ISpecialMapper _mapper;
        private readonly ILogger<CrossrefRequestConsumer> _logger;

        public CrossrefRequestConsumer(IMediator mediator, 
                                       ISpecialMapper mapper, 
                                       ILogger<CrossrefRequestConsumer> logger) 
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<CrossrefEvent> context)
        {

            var request = context.Message.Request;

            var command = _mapper.MapProperties<CrossrefRequest, CrossrefSenderCommand>(request);

            var result = await _mediator.Send(command);

            var deserializedResult = result.Select(JsonConvert.DeserializeObject<CrossrefResponse>);
           
            var writeCommand = new ResponseWriterCommand { Result = result };

            //await _mediator.Send(writeCommand);
        }
    }
}
