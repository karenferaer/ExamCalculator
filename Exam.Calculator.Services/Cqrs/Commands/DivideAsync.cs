using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class DivideAsync : IRequestHandler<Divide, decimal>
    {
        public Task<decimal> Handle(Divide request, CancellationToken cancellationToken)
        {
            var quotient = request.CalculatorRequest.FirstNumber / request.CalculatorRequest.SecondNumber;
            return Task.FromResult(Math.Round(quotient, 2));
        }
    }
}
