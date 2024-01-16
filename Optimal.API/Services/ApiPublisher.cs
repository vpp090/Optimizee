using MassTransit;
using Optimal.API.Contracts;
using Optimal.API.Entities;
using OptimalPackage.Events;
using OptimalPackage.Models;
using OptimalPackage.Requests;
using ServiceResponseR;
using SpecMapperR;
using System.Net;

namespace Optimal.API.Services
{
    public class ApiPublisher : IApiPublisher
    {
        private ISpecialMapper _mapper;
        private IPublishEndpoint _publishEndpoint;
        private ILogger<ApiPublisher> _logger;

        public ApiPublisher(ISpecialMapper mapper, IPublishEndpoint endpoint, ILogger<ApiPublisher> logger)
        {
            _mapper = mapper;
            _publishEndpoint = endpoint;
            _logger = logger;
        }

        public async Task<ServiceResponse<BaseResponse>> SendAsync(IntroRequest request)
        {
            try
            {
                var eventMessage = new OptimalEvent
                {
                    Request = _mapper.MapProperties<IntroRequest, OptimalRequest>(request)
                };

                await _publishEndpoint.Publish(eventMessage);

                return new ServiceResponse<BaseResponse>(new BaseResponse());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ServiceResponse<BaseResponse>(HttpStatusCode.BadRequest.ToString(), ex.Message);
            }
           
        }

        public async Task<ServiceResponse<BaseResponse>> SendAsync(SubTopicsRequest request)
        {
            try
            {
                var eventMessage = new CrossrefEvent
                {
                    Request = _mapper.MapProperties<SubTopicsRequest, CrossrefRequest>(request)
                };

                await _publishEndpoint.Publish(eventMessage);

                return new ServiceResponse<BaseResponse>(new BaseResponse());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                return new ServiceResponse<BaseResponse>(HttpStatusCode.BadRequest.ToString(), ex.Message);
            }
        }
    }
}
