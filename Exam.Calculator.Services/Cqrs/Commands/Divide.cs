using Exam.Calculator.Services.Models;
using MediatR;

namespace Exam.Calculator.Services.Cqrs.Commands
{
    public class Divide : IRequest<decimal>
    {
        public CalculatorRequest CalculatorRequest { get; set; }
        public Divide(CalculatorRequest request)
        {
            CalculatorRequest = request;
        }
    }
}
