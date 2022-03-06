using Exam.Calculator.Services.Cqrs.Commands;
using Exam.Calculator.Services.Models;
using MediatR;

namespace Exam.Calculator.Services
{
    public class RequestFactory : IRequestFactory
    {
        public IRequest<decimal> CreateRequest(CalculatorRequest request)
        {
            return request.OperationType switch
            {
                Enums.OperationType.Add => new Add(request),
                Enums.OperationType.Subtract => new Subtract(request),
                Enums.OperationType.Multiply => new Multiply(request),
                Enums.OperationType.Divide => new Divide(request),
                _ => throw new InvalidOperationException("Operation not supported."),
            };
        }
    }
}
