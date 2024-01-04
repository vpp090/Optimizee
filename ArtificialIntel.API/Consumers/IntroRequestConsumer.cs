using ArtificialIntel.Application.Features.Commands.AISender;
using MassTransit;
using MassTransit.Mediator;
using OptimalPackage.Events;
using OptimalPackage.Requests;
using SpecMapperR;

namespace ArtificialIntel.API.Consumers
{
    public class IntroRequestConsumer : IConsumer<OptimalEvent>
    {
        private readonly IMediator _mediator;
        private readonly ISpecialMapper _mapper;

        public IntroRequestConsumer(IMediator mediator, ISpecialMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Consume(ConsumeContext<OptimalEvent> context)
        {
            var command = _mapper.MapProperties<OptimalRequest, AISenderCommand>(context.Message.Request);

            await _mediator.Send(command);
        }
    }
}
