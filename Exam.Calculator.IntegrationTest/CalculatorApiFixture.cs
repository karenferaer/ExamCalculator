using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;

namespace Exam.Calculator.IntegrationTest
{
    public class CalculatorApiFixture
    {
        private readonly WebApplicationFactory<Program> _application;
        private readonly HttpClient _httpClient;

        public HttpClient HttpClient => _httpClient;

        public CalculatorApiFixture()
        {
            _application = new WebApplicationFactory<Program>();

            _httpClient = _application.CreateClient();
        }
    }
}
