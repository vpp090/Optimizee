using Optimal.API.Entities;
using ServiceResponseR;

namespace Optimal.API.Contracts
{
    public interface IApiSender
    {
        Task<ServiceResponse<BaseResponse>> SendAsync(IntroRequest request);
    }
}
