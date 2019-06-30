// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GibixComputing.WeatherLink
{
    public class WeatherLinkClient
    {
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

            if (!IPAddress.TryParse(options.IPAddress, out var address))
                throw new InvalidWeatherLinkClientOptionsException("Invalid IP Address provided.", options);

            var port = options.Port;
            if (port < 0 || port > 65535)
                throw new InvalidWeatherLinkClientOptionsException("Invalid Port provided. Valid values are between 0 and 65535.", options);

            _endPoint = new IPEndPoint(address, port);
        }
    }
}
