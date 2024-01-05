using ArtificialIntel.Repos.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ArtificialIntel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IntelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<WorkspaceEntity>>> GetAllWorkspaceEntities()
        {
            throw new NotImplementedException();
        }
    }
}
