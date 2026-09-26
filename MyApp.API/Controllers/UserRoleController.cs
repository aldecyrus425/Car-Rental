using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.UserRole.Create;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/user-role")]
    public class UserRoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserRoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult CreateUserRole([FromBody] CreateUserRoleCommand command)
        {
            var result = _mediator.Send(command).Result;
            if (result.isSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
