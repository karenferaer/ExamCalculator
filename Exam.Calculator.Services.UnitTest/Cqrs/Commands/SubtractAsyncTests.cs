using Exam.Calculator.Services.Cqrs.Commands;
using Exam.Calculator.Services.Models;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Exam.Calculator.Services.UnitTest.Cqrs.Commands
{
    public class SubtractAsyncTests
    {
        private readonly SubtractAsync _subtractAsync;

        public SubtractAsyncTests()
        {
            _subtractAsync = new SubtractAsync();
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(-1, 1, -2)]
        [InlineData(1, -1, 2)]
        [InlineData(-1, -1, 0)]
        [InlineData(1.01, 1.01, 0.00)]
        public async Task Handle_ShouldReturnDifference_WhenInputsAreValid(decimal firstNumber, decimal secondNumber, decimal difference)
        {
            // Arrange
            var calculateRequest = new CalculatorRequest
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                OperationType = Enums.OperationType.Subtract
            };
            var request = new Subtract(calculateRequest);

            // Act
            var response = await _subtractAsync.Handle(request, default);

            // Assert
            response.Should().Be(difference);
        }
    }
}
