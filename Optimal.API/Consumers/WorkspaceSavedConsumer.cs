using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Optimal.API.Constants;
using Optimal.API.Contracts;
using Optimal.API.SignalR;
using OptimalPackage.Events;

namespace Optimal.API.Consumers
{
    public class WorkspaceSavedConsumer : IConsumer<WorkspaceSavedEvent>
    {
        private readonly IRedisRepo _repo;
        private readonly IHubContext<DataHub> _hubContext;

        public WorkspaceSavedConsumer(IRedisRepo repo, 
                                      IHubContext<DataHub> hubContext)
        {
            _repo = repo;
            _hubContext = hubContext;
        }

        public async Task Consume(ConsumeContext<WorkspaceSavedEvent> context)
        {
            try
            {
                if (!context.Message.WorkspaceSavedRequest.DataSaved)
                    throw new DataMisalignedException("Data_not_saved");

                var authors = await _repo.GetDataFromRedisAsync(context.Message.WorkspaceSavedRequest.AuthorsKey);

                var materials = await _repo.GetDataFromRedisAsync(context.Message.WorkspaceSavedRequest.MaterialsKey);

                await _hubContext.Clients.All.SendAsync(OptimalConstants.SignalRMethod, authors, materials);
            }
            catch (Exception ex)
            {
                //log exception here
            }
        }
    }
}
