using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices
            .GetService<IMediator>();  

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result is null)
            {
                return NotFound();
            }
            if (result.IsSuccsess && result.Value != null)
            {
                return Ok(result.Value);
            }
            if (result.IsSuccsess && result.Value is null)
            {
                return NotFound();
            }
            return BadRequest(result.Error);
        }
    }
}