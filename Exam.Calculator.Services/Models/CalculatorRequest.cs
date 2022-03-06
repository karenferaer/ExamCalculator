using Exam.Calculator.Services.Enums;

namespace Exam.Calculator.Services.Models
{
    public class CalculatorRequest
    {
        public decimal FirstNumber { get; set; }
        public decimal SecondNumber { get; set; }
        public OperationType OperationType { get; set; }
    }
}
