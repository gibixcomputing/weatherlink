// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using System.Net;
using FluentValidation;

namespace GibixComputing.WeatherLink.Validators
{
    /// <summary>
    /// Validates the options provided in <see cref="WeatherLinkClientOptions"/>.
    /// </summary>
    internal class WeatherLinkClientOptionsValidator : AbstractValidator<WeatherLinkClientOptions>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherLinkClientOptionsValidator"/> class.
        /// </summary>
        public WeatherLinkClientOptionsValidator()
        {
            _ = RuleFor(o => o.Address)
                .Must(ip => IPAddress.TryParse(ip, out _))
                .WithMessage("{PropertyName} must be a valid IPv4/IPv6 IP address.")
                .WithSeverity(Severity.Error);

            _ = RuleFor(o => o.Port)
                .InclusiveBetween(0, 65535)
                .WithMessage("{PropertyName} must be a valid TCP/IP port number between 0 and 65535.")
                .WithSeverity(Severity.Error);
        }
    }
}
