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
        private readonly ILogger<OptimalController> _logger;
        
        public OptimalController(IApiPublisher publisher, 
                                 IRedisRepo redisRepo,
                                 ILogger<OptimalController> logger)
        {
            _apiPublisher = publisher;
            _redisRepo = redisRepo;
            _logger = logger;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ServiceResponse<BaseResponse>>> SendOptimalRequest([FromBody] IntroRequest request)
        {

            var result = await _apiPublisher.SendAsync(request);

            return HandleResult(result);
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ServiceResponse<BaseResponse>>> SendCrossrefRequest([FromBody]SubTopicsRequest request)
        {
            _logger.LogInformation(request.ToString());

            var result = await _apiPublisher.SendAsync(request);

            return HandleResult(result);
        }
    }
}
