using Optimal.API.Contracts;
using Optimal.API.Entities;

namespace Optimal.API.Services
{
    public class ApiSender : IApiSender
    {
        public async Task<ServiceResponse<WorkspaceResponse>> SendAsync(IntroRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
