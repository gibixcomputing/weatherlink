// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GibixComputing.WeatherLink.Validators;

namespace GibixComputing.WeatherLink
{
    public class WeatherLinkClient
    {
        private static readonly Lazy<WeatherLinkClientOptionsValidator> s_optionsValidator =
            new Lazy<WeatherLinkClientOptionsValidator>();

        private readonly IPEndPoint _endPoint;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherLinkClient"/> class.
        /// </summary>
        /// <param name="options">Contains the options necessary to configure the instance.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="options"/> is null.</exception>
        /// <exception cref="InvalidWeatherLinkClientOptionsException">
        /// Thrown if there was an error parsing the data in <paramref name="options"/>.
        /// </exception>
        public WeatherLinkClient(WeatherLinkClientOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            var result = s_optionsValidator.Value.Validate(options);
            if (!result.IsValid)
            {
                var errors = new FluentValidation.ValidationException(result.Errors);
                throw new InvalidWeatherLinkClientOptionsException("Invalid options provided. See validation errors.", options, errors);
            }

            var (address, port) = options;
            _endPoint = new IPEndPoint(address, port);
        }
    }
}
