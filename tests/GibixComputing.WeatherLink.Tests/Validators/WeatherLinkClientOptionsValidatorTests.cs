// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using FluentAssertions;
using GibixComputing.WeatherLink.Validators;
using Xunit;

namespace GibixComputing.WeatherLink.Tests.Validators
{
    public class WeatherLinkClientOptionsValidatorTests
    {
        [Theory]
        [InlineData((string?)null)]
        [InlineData("")]
        [InlineData("127.0.0.1.1")]
        [InlineData(":::1")]
        [InlineData("[2001:db8:3]")]
        public void FailsWhenIPAddressIsInvalid(string address)
        {
            // Arrange.
            var options = new WeatherLinkClientOptions
            {
                Address = address,
                Port = 0
            };
            var sut = new WeatherLinkClientOptionsValidator();

            // Act.
            var result = sut.Validate(options);

            // Assert.
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.PropertyName == nameof(options.Address));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        [InlineData(65536)]
        public void FailsWhenTcpIpPortIsInvalid(int port)
        {
            // Arrange.
            var options = new WeatherLinkClientOptions
            {
                Address = "127.0.0.1",
                Port = port
            };
            var sut = new WeatherLinkClientOptionsValidator();

            // Act.
            var result = sut.Validate(options);

            // Assert.
            result.IsValid.Should().BeFalse();
            result.Errors.Should().Contain(error => error.PropertyName == nameof(options.Port));
        }

        [Theory]
        [InlineData("127.0.0.1")]
        [InlineData("::1")]
        [InlineData("[2001:db8::1]")]
        [InlineData("2001:db8:1:1:1:1:1:1")]
        public void SuccessfullyValidatesIPAddresses(string address)
        {
            // Arrange.
            var options = new WeatherLinkClientOptions
            {
                Address = address,
                Port = 15
            };
            var sut = new WeatherLinkClientOptionsValidator();

            // Act.
            var result = sut.Validate(options);

            // Assert.
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(65535)]
        [InlineData(15)]
        public void SuccessfullyValidatesTcpIpPorts(int port)
        {
            // Arrange.
            var options = new WeatherLinkClientOptions
            {
                Address = "127.0.0.1",
                Port = port
            };
            var sut = new WeatherLinkClientOptionsValidator();

            // Act.
            var result = sut.Validate(options);

            // Assert.
            result.IsValid.Should().BeTrue();
        }
    }
}
