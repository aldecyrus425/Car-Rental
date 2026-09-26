using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Features.Customer.Create;

namespace MyApp.API.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerCommand command)
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
