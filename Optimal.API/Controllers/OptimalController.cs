using Microsoft.AspNetCore.Mvc;
using Optimal.API.Contracts;
using Optimal.API.Entities;
using OptimalPackage.Requests;
using System.Net;

namespace Optimal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimalController : ControllerBase
    {
        private readonly IApiSender _apiSender;
        
        public OptimalController(IApiSender apiSender)
        {
            _apiSender = apiSender;
        }

        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ServiceResponse<BaseResponse>>> SendOptimalRequest([FromBody] IntroRequest request)
        {

            var result = await _apiSender.SendAsync(request);

            if (result == null)
                return BadRequest();

            if (result.Error != null)
                return BadRequest(result.Error.ToString());

            return Ok(result);
        }
    }
}
