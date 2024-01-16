using Microsoft.AspNetCore.Mvc;
using Optimal.API.Contracts;
using Optimal.API.Entities;
using OptimalPackage.Models;
using System.Net;

namespace Optimal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimalController : BaseApiController
    {
        private readonly IApiPublisher _apiPublisher;
        
        public OptimalController(IApiPublisher publisher)
        {
            _apiPublisher = publisher;
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
