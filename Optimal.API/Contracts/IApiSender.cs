using Optimal.API.Entities;

namespace Optimal.API.Contracts
{
    public interface IApiSender
    {
        Task<ServiceResponse<WorkspaceResponse>> SendAsync(IntroRequest request);
    }
}
