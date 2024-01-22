using MassTransit;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Optimal.API.Constants;
using Optimal.API.Contracts;
using Optimal.API.Entities;
using Optimal.API.SignalR;
using OptimalPackage.Events;

namespace Optimal.API.Consumers
{
    public class WorkspaceSavedConsumer : IConsumer<WorkspaceSavedEvent>
    {
        private readonly IRedisRepo _repo;
        private readonly IHubContext<DataHub> _hubContext;
        private readonly ILogger<WorkspaceSavedConsumer> _logger;

        public WorkspaceSavedConsumer(IRedisRepo repo, 
                                      IHubContext<DataHub> hubContext,
                                      ILogger<WorkspaceSavedConsumer> logger)
        {
            _repo = repo;
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<WorkspaceSavedEvent> context)
        {
            try
            {
                _logger.LogInformation("message_received_QQ");

                if (!context.Message.WorkspaceSavedRequest.DataSaved)
                    throw new DataMisalignedException("Data_not_saved");

                var authors = await _repo.GetDataFromRedisAsync(context.Message.WorkspaceSavedRequest.AuthorsKey);

                var materials = await _repo.GetDataFromRedisAsync(context.Message.WorkspaceSavedRequest.MaterialsKey);

                _logger.LogInformation(authors);
                _logger.LogInformation(materials);

                await _hubContext.Clients.All.SendAsync(OptimalConstants.SignalRMethod, 
                        new WorkspaceSavedResponse {  
                            Authors = authors, 
                            Materials = materials
                        });

                _logger.LogInformation("message_sent_QQ");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
