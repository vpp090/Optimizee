using MassTransit;
using Optimal.API.Contracts;
using Optimal.API.Entities;
using OptimalPackage.Events;
using OptimalPackage.Requests;
using SpecMapperR;

namespace Optimal.API.Services
{
    public class ApiSender : IApiSender
    {
        private ISpecialMapper _mapper;
        private IPublishEndpoint _publishEndpoint;
        private ILogger<ApiSender> _logger;

        public ApiSender(ISpecialMapper mapper, IPublishEndpoint endpoint, ILogger<ApiSender> logger)
        {
            _mapper = mapper;
            _publishEndpoint = endpoint;
            _logger = logger;
        }

        public async Task<ServiceResponse<BaseResponse>> SendAsync(IntroRequest request)
        {
            try
            {
                var eventMessage = new OptimalEvent();

                eventMessage.Request = _mapper.MapProperties<IntroRequest, OptimalRequest>(request);

                await _publishEndpoint.Publish(eventMessage);

                return new ServiceResponse<BaseResponse>(new BaseResponse());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ServiceResponse<BaseResponse>(ex);
            }
           
        }
    }
}
