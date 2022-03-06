using Exam.Calculator.Services.Models;
using MediatR;

namespace Exam.Calculator.Services
{
    public interface IRequestFactory
    {
        public IRequest<decimal> CreateRequest(CalculatorRequest request);
    }
}