using Microsoft.AspNetCore.Mvc;
using Optimal.API.Contracts;
using Optimal.API.Entities;
using OptimalPackage.Models;
using ServiceResponseR;
using System.Net;

namespace Optimal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimalController : BaseApiController
    {
        private readonly IApiPublisher _apiPublisher;
        private readonly IRedisRepo _redisRepo;
        
        public OptimalController(IApiPublisher publisher, IRedisRepo redisRepo)
        {
            _apiPublisher = publisher;
            _redisRepo = redisRepo;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ServiceResponseR.ServiceResponse<BaseResponse>>> SendOptimalRequest([FromBody] IntroRequest request)
        {

            var result = await _apiPublisher.SendAsync(request);

            return HandleResult(result);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ServiceResponseR.ServiceResponse<BaseResponse>>> SendCrossrefRequest([FromBody]SubTopicsRequest request)
        {
            var result = await _apiPublisher.SendAsync(request);

            return HandleResult(result);
        }
    }
}
