using ArtificialIntel.Application.Entities;
using ArtificialIntel.Application.Features.Commands.CrossrefSender;
using ArtificialIntel.Application.Features.Commands.ResponseWriter;
using MassTransit;
using MassTransit.RabbitMqTransport;
using MediatR;
using Newtonsoft.Json;
using OptimalPackage.Events;
using OptimalPackage.Models;
using SpecMapperR;
using IPublisher = MassTransit.RabbitMqTransport.IPublisher;

namespace ArtificialIntel.API.Consumers
{
    public class CrossrefRequestConsumer : IConsumer<CrossrefEvent>
    {
        private readonly IMediator _mediator;
        private readonly ISpecialMapper _mapper;
        private readonly ILogger<CrossrefRequestConsumer> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public CrossrefRequestConsumer(IMediator mediator, 
                                       ISpecialMapper mapper, 
                                       ILogger<CrossrefRequestConsumer> logger,
                                       IPublishEndpoint publishEndpoint) 
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<CrossrefEvent> context)
        {
            var request = context.Message.Request;

            var command = _mapper.MapProperties<CrossrefRequest, CrossrefSenderCommand>(request);

            var result = await _mediator.Send(command);

            var deserializedResult = result.Select(JsonConvert.DeserializeObject<CrossrefResponse>);
           
            var writeCommand = new ResponseWriterCommand { Result = deserializedResult, 
                                                           RequestId = context.Message.Request.RequestId,
                                                           SubTopic = request.SubTopics.FirstOrDefault()
            };
            
            await _mediator.Send(writeCommand);

            var saved = new WorkspaceSavedRequest { DataSaved = true };

            await _publishEndpoint.Publish(saved);
        }
    }
}
