using Exam.Calculator.Services.Cqrs.Commands;
using Exam.Calculator.Services.Models;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace Exam.Calculator.Services.UnitTest.Cqrs.Commands
{
    public class MutiplyAsyncTests
    {
        private readonly MultiplyAsync _multiplyAsync;

        public MutiplyAsyncTests()
        {
            _multiplyAsync = new MultiplyAsync();
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(-1, 1, -1)]
        [InlineData(-1, -1, 1)]
        [InlineData(-1, 0, 0)]
        [InlineData(1.01, 1.01, 1.02)]
        public async Task Handle_ShouldReturnProduct_WhenInputsAreValid(decimal firstNumber, decimal secondNumber, decimal product)
        {
            // Arrange
            var calculateRequest = new CalculatorRequest
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                OperationType = Enums.OperationType.Multiply
            };
            var request = new Multiply(calculateRequest);

            // Act
            var response = await _multiplyAsync.Handle(request, default);

            // Assert
            response.Should().Be(product);
        }

    }
}
