using Exam.Calculator.Services.Cqrs.Commands;
using Exam.Calculator.Services.Models;
using FluentAssertions;
using System;
using Xunit;

namespace Exam.Calculator.Services.UnitTest
{
    public class RequestFactoryTests
    {
        private readonly RequestFactory _requestFactory;

        public RequestFactoryTests()
        {
            _requestFactory = new RequestFactory();
        }

        [Fact]
        public void CreateRequest_ShouldReturnAddRequest_WhenOperationTypeIsAdd()
        {
            // Arrange
            var calculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = Enums.OperationType.Add
            };

            // Act
            var result = _requestFactory.CreateRequest(calculateRequest);

            // Assert
            result.Should().BeOfType<Add>().Which.Should().Match<Add>(_ => _.CalculatorRequest.FirstNumber == calculateRequest.FirstNumber
                && _.CalculatorRequest.SecondNumber == calculateRequest.SecondNumber
                && _.CalculatorRequest.OperationType == calculateRequest.OperationType);
        }

        [Fact]
        public void CreateRequest_ShouldReturnSubtractRequest_WhenOperationTypeIsSubtract()
        {
            // Arrange
            var calculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = Enums.OperationType.Subtract
            };

            // Act
            var result = _requestFactory.CreateRequest(calculateRequest);

            // Assert
            result.Should().BeOfType<Subtract>().Which.Should().Match<Subtract>(_ => _.CalculatorRequest.FirstNumber == calculateRequest.FirstNumber
                && _.CalculatorRequest.SecondNumber == calculateRequest.SecondNumber
                && _.CalculatorRequest.OperationType == calculateRequest.OperationType);
        }

        [Fact]
        public void CreateRequest_ShouldReturnMultiplyRequest_WhenOperationTypeIsMultiply()
        {
            // Arrange
            var calculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = Enums.OperationType.Multiply
            };

            // Act
            var result = _requestFactory.CreateRequest(calculateRequest);

            // Assert
            result.Should().BeOfType<Multiply>().Which.Should().Match<Multiply>(_ => _.CalculatorRequest.FirstNumber == calculateRequest.FirstNumber
                && _.CalculatorRequest.SecondNumber == calculateRequest.SecondNumber
                && _.CalculatorRequest.OperationType == calculateRequest.OperationType);
        }

        [Fact]
        public void CreateRequest_ShouldReturnDivideRequest_WhenOperationTypeIsDivide()
        {
            // Arrange
            var calculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = Enums.OperationType.Divide
            };

            // Act
            var result = _requestFactory.CreateRequest(calculateRequest);

            // Assert
            result.Should().BeOfType<Divide>().Which.Should().Match<Divide>(_ => _.CalculatorRequest.FirstNumber == calculateRequest.FirstNumber
                && _.CalculatorRequest.SecondNumber == calculateRequest.SecondNumber
                && _.CalculatorRequest.OperationType == calculateRequest.OperationType);
        }

        [Fact]
        public void CreateRequest_ShouldThrowAnException_WhenOperationTypeIsNotValid()
        {
            // Arrange
            var calculateRequest = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = (Enums.OperationType)10
            };

            // Act
            var result = Record.Exception(() => _requestFactory.CreateRequest(calculateRequest));

            // Assert
            result.Should().BeOfType<InvalidOperationException>().Which.Message.Should().Be("Operation not supported.");
        }
    }
}
