using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Customer.Create;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/customer-document")]
    public class CustomerDocumentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerDocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateCustomerDocument([FromBody] CreateCustomerCommand command)
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
