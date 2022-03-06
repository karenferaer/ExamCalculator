using Exam.Calculator.Services;
using Exam.Calculator.Services.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Calculator.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRequestFactory _requestFactory;

        public CalculatorController(
            IMediator mediator,
            IRequestFactory requestFactory)
        {
            _mediator = mediator;
            _requestFactory = requestFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Calculate([FromBody] CalculatorRequest request)
        {
            var calculateRequest = _requestFactory.CreateRequest(request);
            var response = await _mediator.Send(calculateRequest, default);
            return Ok(response);
        }
    }
}
