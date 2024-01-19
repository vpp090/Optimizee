using MassTransit;
using Microsoft.Extensions.Caching.Distributed;
using OptimalPackage.Events;

namespace Optimal.API.Consumers
{
    public class WorkspaceSavedConsumer : IConsumer<WorkspaceSavedEvent>
    {
        private readonly IDistributedCache _cache;

        public WorkspaceSavedConsumer(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task Consume(ConsumeContext<WorkspaceSavedEvent> context)
        {
            if (!context.Message.WorkspaceSavedRequest.DataSaved)
                throw new DataMisalignedException("Data_not_saved");
            

        }
    }
}
