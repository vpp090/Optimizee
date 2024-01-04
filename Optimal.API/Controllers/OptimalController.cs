using Microsoft.AspNetCore.Mvc;
using Optimal.API.Contracts;
using Optimal.API.Entities;

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

        [HttpPost]
        public async Task<ActionResult> PostQuestions([FromBody] IntroRequest questions)
        {

            var result = await _apiSender.SendAsync(questions);

            if (result == null)
                return BadRequest();

            if (result.Error != null)
                return BadRequest(result.Error.ToString());

            return Ok(result);
        }
    }
}
