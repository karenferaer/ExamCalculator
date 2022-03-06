using Exam.Calculator.Services.Models;
using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class Multiply : IRequest<decimal>
    {
        public CalculatorRequest CalculatorRequest { get; set; }
        public Multiply(CalculatorRequest request)
        {
            CalculatorRequest = request;
        }
    }
}
