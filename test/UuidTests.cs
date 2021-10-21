using Xunit;
using System;
using FluentAssertions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Uuid.Models;
using Uuid.Tests.Setup;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Uuid.Tests
{
    public class UuidTests : TestingCaseFixture<TestingStartup>
    {

        public async Task<string> GetSequence(string sequence)
        {
            
            var response = await Client.GetAsync($"/api/Uuid/GetSequence/{sequence}");
            var outputValue = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            return outputValue;

        }

        [Fact(DisplayName = "Test Case 01")]
        public async Task GetSequence_SingleDigitArray61592_ShouldReturn159()
        {
            // Arrange
            var sequence = "6 1 5 9 2";

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("1 5 9");

        }
        [Fact(DisplayName = "Test Case 02")]
        public async Task GetSequence_MultipleDigitsArray_ShouldReturn6Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase2.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("1710 2461 9288 10195 10431 12485");

        }
        
        [Fact(DisplayName = "Test Case 03")]
        public async Task GetSequence_MultipleDigitsArray_ShouldReturn8Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase3.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("10298 10897 12291 15037 18446 23435 25333 27266");

        }

        [Fact(DisplayName = "Test Case 04")]
        public async Task GetSequence04_MultipleDigitsArray_ShouldReturn4Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase4.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("3862 16353 22813 28735");

        }

        [Fact(DisplayName = "Test Case 05")]
        public async Task GetSequence05_MultipleDigitsArray_ShouldReturn4Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase5.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("11084 11970 24975 30922");

        }

        [Fact(DisplayName = "Test Case 06")]
        public async Task GetSequence06_MultipleDigitsArray_ShouldReturn4Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase6.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("3808 3908 10386 19306");

        }

        [Fact(DisplayName = "Test Case 07")]
        public async Task GetSequence07_MultipleDigitsArray_ShouldReturn6Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase7.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("125 1841 5882 18464 28317 31497");

        }

        [Fact(DisplayName = "Test Case 08")]
        public async Task GetSequence08_MultipleDigitsArray_ShouldReturn6Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase8.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("9139 17687 25106 26202 27592 30937");

        }

        [Fact(DisplayName = "Test Case 09")]
        public async Task GetSequence09_MultipleDigitsArray_ShouldReturn8Numbers()
        {
            // Arrange
            string sequence = File.ReadAllText("TestCase9.txt");

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("918 1089 5133 7725 18035 24605 26716 27095");

        }
        
        [Fact(DisplayName = "Test Case 10")]
        public async Task GetSequence10_MultipleDigitsArray_ShouldReturn3Numbers()
        {
            // Arrange
            var sequence = "6 2 4 6 1 5 9 2";

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("2 4 6");

        }

        [Fact(DisplayName = "Test Case 11")]
        public async Task GetSequence11_MultipleDigitsArray_ShouldReturn3Numbers()
        {
            // Arrange
            var sequence = "6 2 4 3 1 5 9";

            // Act
            var outputValue = await GetSequence(sequence);

            // Assert
            outputValue.Should().Be("1 5 9");

        }
    }
}
