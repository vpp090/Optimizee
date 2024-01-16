using Optimal.API.Entities;
using ServiceResponseR;

namespace Optimal.API.Contracts
{
    public interface IApiPublisher
    {
        Task<ServiceResponse<BaseResponse>> SendAsync(IntroRequest request);

        Task<ServiceResponse<BaseResponse>> SendAsync(SubTopicsRequest request);
    }
}
