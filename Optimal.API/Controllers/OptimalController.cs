using Microsoft.AspNetCore.Mvc;
using Optimal.API.Entities;

namespace Optimal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptimalController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> PostQuestions([FromBody] IntroQuestions questions)
        {

            return Ok();
        }
    }
}
