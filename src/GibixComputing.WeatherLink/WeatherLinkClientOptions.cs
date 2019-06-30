// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

namespace GibixComputing.WeatherLink
{
    /// <summary>
    /// Options for configuring the <see cref="WeatherLinkClient"/>.
    /// </summary>
    public class WeatherLinkClientOptions
    {
        /// <summary>
        /// The IPv4 address of the WeatherLinkIP host.
        /// </summary>
        public string IPAddress { get; set; } = string.Empty;

        /// <summary>
        /// The port number the WeatherLinkIP host is listening on.
        /// </summary>
        public int Port { get; set; }
    }
}
