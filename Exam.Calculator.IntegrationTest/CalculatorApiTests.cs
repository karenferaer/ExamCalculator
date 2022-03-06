using Exam.Calculator.Services.Models;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exam.Calculator.IntegrationTest
{
    public class CalculatorApiTests : IClassFixture<CalculatorApiFixture>
    {
        private readonly HttpClient _client;

        public CalculatorApiTests(CalculatorApiFixture calculatorApiFixture)
        {
            _client = calculatorApiFixture.HttpClient;
        }

        [Fact]
        public async Task Calculate_ShouldReturnOkResponse()
        {
            // Arrange
            var request = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = Services.Enums.OperationType.Add
            };
            string requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Calculator", content);

            // Assert
            response.EnsureSuccessStatusCode();
            var contentString = await response.Content.ReadAsStringAsync();
            var contentObject = JsonConvert.DeserializeObject<decimal>(contentString);
            contentObject.Should().Be(3);
        }

        [Fact]
        public async Task Calculate_ShouldReturnBadRequestResponse_WhenRequestIsInvalid()
        {
            // Arrange
            var request = new CalculatorRequest()
            {
                FirstNumber = 1,
                SecondNumber = 2,
                OperationType = (Services.Enums.OperationType)10
            };
            string requestJson = JsonConvert.SerializeObject(request);
            var content = new StringContent(requestJson, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/Calculator", content);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}
