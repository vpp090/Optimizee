using ArtificialIntel.Application.Features.Commands.AISender;
using MassTransit;
using OptimalPackage.Events;
using OptimalPackage.Requests;
using SpecMapperR;

namespace ArtificialIntel.API.Consumers
{
    public class IntroRequestConsumer : IConsumer<OptimalEvent>
    {
        private readonly MediatR.IMediator _mediator;
        private readonly ISpecialMapper _mapper;
        private readonly ILogger<IntroRequestConsumer> _logger;

        public IntroRequestConsumer(MediatR.IMediator mediator, 
                                    ISpecialMapper mapper, 
                                    ILogger<IntroRequestConsumer> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<OptimalEvent> context)
        {
            try
            {
                _logger.LogInformation(context.Message.Request.ToString());

                var command = _mapper.MapProperties<OptimalRequest, AISenderCommand>(context.Message.Request);

                //var response = await _mediator.Send(command);
                //await _mediator.Send(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
