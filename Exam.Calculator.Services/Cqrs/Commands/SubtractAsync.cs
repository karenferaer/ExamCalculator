using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class SubtractAsync : IRequestHandler<Subtract, decimal>
    {
        public Task<decimal> Handle(Subtract request, CancellationToken cancellationToken)
        {
            var difference = request.CalculatorRequest.FirstNumber - request.CalculatorRequest.SecondNumber;
            return Task.FromResult(difference);
        }
    }
}
