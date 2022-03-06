using Exam.Calculator.Services.Cqrs.Commands;
using Exam.Calculator.Services.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exam.Calculator.Services.UnitTest.Cqrs.Commands
{
    public class AddAsyncTests
    {
        private readonly AddAsync _addAsync;

        public AddAsyncTests()
        {
            _addAsync = new AddAsync();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 0)]
        [InlineData(1, -1, 0)]
        [InlineData(-1, -1, -2)]
        [InlineData(1.01, 1.02, 2.03)]
        public async Task Handle_ShouldReturnSum_WhenInputsAreValid(decimal firstNumber, decimal secondNumber, decimal sum)
        { 
            // Arrange
            var calculateRequest = new CalculatorRequest 
            { 
                FirstNumber = firstNumber, 
                SecondNumber = secondNumber, 
                OperationType = Enums.OperationType.Add 
            };
            var request = new Add(calculateRequest);

            // Act
            var response = await _addAsync.Handle(request, default);

            // Assert
            response.Should().Be(sum);
        }

    }
}
