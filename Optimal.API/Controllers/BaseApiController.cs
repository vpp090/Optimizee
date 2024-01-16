using Microsoft.AspNetCore.Mvc;
using Optimal.API.Entities;

namespace Optimal.API.Controllers
{
    public abstract class BaseApiController : ControllerBase
    {
        protected ActionResult HandleResult<T>(T result) where T : ServiceResponseR.ServiceResponse<BaseResponse>
        {
            if (result == null)
                return BadRequest();

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage?.ToString());

            return Ok(result);
        }
    }
}
