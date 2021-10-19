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
       

        [Fact(DisplayName = "Get longest increasing sequence1")]
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
        [Fact(DisplayName = "Get longest increasing sequence2")]
        public async Task GetSequence_MultipleDigitsArray61592_ShouldReturn6Numbers()
        {
            // Arrange
            var sequence = "923 11613 30483 19569 24201 13461 1189 30793 8848 16914 16053 21700 22116 3852 20909 5231 31469 3862 16353 22813 28735 4421 3618 32303 9932 31892 7823 22547 28888 11143 11695 3339 2094 11023 9661 27440 7186 24750 15427 24502 31606 23515 3563 29553 12145 22184 11409 28824 6636 10658 21404 5578 27807 14073 13967 31310 3132 4321 7643 1951 13289 24375 17912 11304";

            // Act
            var response = await Client.GetAsync($"/api/Uuid/GetSequence/{sequence}");

            var outputValue = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            outputValue.Should().Be("1710 2461 9288 10195 10431 12485");

        }
    }
}
