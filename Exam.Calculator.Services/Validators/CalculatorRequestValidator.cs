using Exam.Calculator.Services.Models;
using FluentValidation;

namespace Exam.Calculator.Services.Validators
{
    public class CalculatorRequestValidator : AbstractValidator<CalculatorRequest>
    {
        public CalculatorRequestValidator()
        {
            RuleFor(_ => _.OperationType)
                .IsInEnum()
                .WithMessage("Operation type is invalid.");

            When(_ => _.OperationType == Enums.OperationType.Divide, () => 
            {
                RuleFor(_ => _.SecondNumber)
                 .NotEqual(0)
                 .WithMessage("Divide by zero is not allowed.");
            });
                
                
        }
    }
}
