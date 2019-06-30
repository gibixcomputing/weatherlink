// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using System;
using FluentAssertions;
using Xunit;

namespace GibixComputing.WeatherLink.Tests
{
    public class WeatherLinkClientConstructorTests
    {
        [Fact]
        public void ShouldSuccessfullyCreateWhenValid()
        {
            // Arrange.
            var options = new WeatherLinkClientOptions
            {
                Address = "127.0.0.1",
                Port = 0,
            };

            Action sut = () => new WeatherLinkClient(options);

            // Act & Assert.
            sut.Should().NotThrow();
        }

        [Theory]
        [InlineData("", 15)]
        [InlineData("127.0.0.1", int.MaxValue)]
        public void ShouldThrowWhenOptionsAreInvalid(string address, int port)
        {
            // Arrange.
            var options = new WeatherLinkClientOptions
            {
                Address = address,
                Port = port,
            };

            Action sut = () => new WeatherLinkClient(options);

            // Act & Assert.
            sut.Should().Throw<InvalidWeatherLinkClientOptionsException>();
        }

        [Fact]
        public void ShouldThrowWhenOptionsIsNull()
        {
            // Arrange.
            Action sut = () => new WeatherLinkClient(null!);

            // Act & Assert.
            sut.Should().Throw<ArgumentNullException>();
        }
    }
}
