using Exam.Calculator.Services.Models;
using Exam.Calculator.Services.Validators;
using FluentValidation.TestHelper;
using System.Threading.Tasks;
using Xunit;

namespace Exam.Calculator.Services.UnitTest.Validators
{
    public class CalculatorRequestValidatorTests
    {
        private readonly CalculatorRequestValidator _calculateRequestValidator;

        public CalculatorRequestValidatorTests()
        {
            _calculateRequestValidator = new CalculatorRequestValidator();
        }

        [Fact]
        public async Task Validate_ShouldReturnIsValid_WhenRequestIsValid()
        {
            // Arrange
            var calculateRequest = new CalculatorRequest
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = Enums.OperationType.Add
            };

            // Act
            var result = await _calculateRequestValidator.TestValidateAsync(calculateRequest);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public async Task Validate_ShouldReturnIsValidFalse_WhenSecondNumberIsZeroAndOperationTypeIsDivide()
        {
            // Arrange
            var invalidCalculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 0,
                OperationType = Enums.OperationType.Divide
            };

            // Act
            var result = await _calculateRequestValidator.TestValidateAsync(invalidCalculateRequest);

            // Assert
            result.ShouldHaveValidationErrorFor(_ => _.SecondNumber).WithErrorMessage("Divide by zero is not allowed.");
        }

        [Fact]
        public async Task Validate_ShouldReturnIsValidFalse_WhenOperationTypeIsInvalid()
        {
            // Arrange
            var invalidCalculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 0,
                OperationType = (Enums.OperationType)10
            };

            // Act
            var result = await _calculateRequestValidator.TestValidateAsync(invalidCalculateRequest);

            // Assert
            result.ShouldHaveValidationErrorFor(_ => _.OperationType).WithErrorMessage("Operation type is invalid.");
        }
    }
}
