using Optimal.API.Entities;

namespace Optimal.API.Contracts
{
    public interface IApiSender
    {
        Task<ServiceResponse<BaseResponse>> SendAsync(IntroRequest request);
    }
}
