using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class AddAsync : IRequestHandler<Add, decimal>
    {
        public Task<decimal> Handle(Add request, CancellationToken cancellationToken)
        {
            var sum = request.CalculatorRequest.FirstNumber + request.CalculatorRequest.SecondNumber;
            return Task.FromResult(sum);
        }
    }
}
