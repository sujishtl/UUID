using Xunit;
using System;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Uuid.Models;
using Uuid.Tests.Setup;
using Microsoft.AspNetCore.Mvc;

namespace Uuid.Tests
{
    public class UuidTests : TestingCaseFixture<TestingStartup>
    {
       

        [Fact(DisplayName = "Get longest increasing sequence")]
        public async Task GetSequence_SingleDigitArray61592_ShouldReturn159()
        {
            // Arrange
            var sequence = "6 1 5 9 2";

            // Act
            var response = await Client.GetAsync($"/api/Uuid/GetSequence/{sequence}");

            var outputValue = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            outputValue.Should().Be("1 5 9");

        }
    }
}
