using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class MultiplyAsync : IRequestHandler<Multiply, decimal>
    {
        public Task<decimal> Handle(Multiply request, CancellationToken cancellationToken)
        {
            var product = request.CalculatorRequest.FirstNumber * request.CalculatorRequest.SecondNumber;
            return Task.FromResult(Math.Round(product, 2));
        }
    }
}
