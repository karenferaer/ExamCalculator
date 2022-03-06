using Exam.Calculator.Services.Cqrs.Commands;
using Exam.Calculator.Services.Models;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Exam.Calculator.Services.UnitTest.Cqrs.Commands
{
    public class DivideAsyncTests
    {
        private readonly DivideAsync _divideAsync;

        public DivideAsyncTests()
        {
            _divideAsync = new DivideAsync();
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(-1, -1, 1)]
        [InlineData(1.01, 1.01, 1.00)]
        public async Task Handle_ShouldReturnQuotient_WhenInputsAreValid(decimal firstNumber, decimal secondNumber, decimal quotient)
        {
            // Arrange
            var calculateRequest = new CalculatorRequest
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                OperationType = Enums.OperationType.Divide
            };
            var request = new Divide(calculateRequest);

            // Act
            var response = await _divideAsync.Handle(request, default);

            // Assert
            response.Should().Be(quotient);
        }
    }
}
