using MassTransit;
using MassTransit.Mediator;
using OptimalPackage.Events;

namespace ArtificialIntel.API.Consumers
{
    public class IntroRequestConsumer : IConsumer<OptimalEvent>
    {
        private readonly IMediator _mediator;

        public IntroRequestConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OptimalEvent> context)
        {
            throw new NotImplementedException();
        }
    }
}
