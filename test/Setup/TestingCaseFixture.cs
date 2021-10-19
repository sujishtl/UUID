using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;

namespace Uuid.Tests.Setup
{
    public class TestingCaseFixture<TStartup> : IDisposable where TStartup : class
    {
        private readonly TestingWebApplicationFactory<TStartup> _factory;
        protected readonly HttpClient Client;
        

        public TestingCaseFixture()
        {
            // constructs the testing server with the HostBuilder configuration
            _factory = new TestingWebApplicationFactory<TStartup>();

            // Create an HttpClient to send requests to the TestServer
            Client = _factory.CreateClient();

        }

        public void Dispose()
        {
            Client?.Dispose();

        }
    }
}
