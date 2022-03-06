using Exam.Calculator.Services.Models;
using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class Subtract : IRequest<decimal>
    {
        public CalculatorRequest CalculatorRequest { get; set; }
        public Subtract(CalculatorRequest request)
        {
            CalculatorRequest = request;
        }
    }
}
