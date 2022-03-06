using Exam.Calculator.Services.Models;
using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class Add : IRequest<decimal>
    {
        public CalculatorRequest CalculatorRequest { get; set; }
        public Add(CalculatorRequest request)
        {
            CalculatorRequest = request;
        }
    }
}
