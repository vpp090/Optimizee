using App.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace Optimal.API.SignalR
{
    public class DataHub : Hub
    {
        public async Task SendData(IEnumerable<Author> authors, IEnumerable<Material> materials)
        {
            var data = new { Authors = authors, Materials = materials };

            await Clients.All.SendAsync("ReceiveData", data);
        }
    }
}
