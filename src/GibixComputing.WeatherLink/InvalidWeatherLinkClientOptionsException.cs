// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using System;
using System.Runtime.Serialization;

namespace GibixComputing.WeatherLink
{
    /// <summary>
    /// Represents an error while parsing options provided in a <see cref="WeatherLinkClientOptions"/> instance.
    /// </summary>
    [Serializable]
    internal class InvalidWeatherLinkClientOptionsException : WeatherLinkException
    {
        /// <summary>
        /// Contains the options object that failed parsing, if available.
        /// </summary>
        public WeatherLinkClientOptions? Options { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWeatherLinkClientOptionsException"/> class.
        /// </summary>
        public InvalidWeatherLinkClientOptionsException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWeatherLinkClientOptionsException"/> class
        /// with the specified error message and associated option data.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="options">The options data that failed to parse.</param>
        public InvalidWeatherLinkClientOptionsException(string message, WeatherLinkClientOptions options) : base(message)
        {
            Options = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidWeatherLinkClientOptionsException"/> class
        /// with a specified error message and a reference to the inner exception that is the cause of this
        /// exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidWeatherLinkClientOptionsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherLinkException"/> class with serialized data.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data about the exception
        /// being thrown.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or
        /// destination.
        /// </param>
        /// <exception cref="ArgumentNullException">The <paramref name="info"/> parameter is null.</exception>
        /// <exception cref="SerializationException">
        /// The class name is null or <see cref="Exception.HResult"/> is zero (0).
        /// </exception>
        protected InvalidWeatherLinkClientOptionsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            var options = new WeatherLinkClientOptions
            {
                IPAddress = info.GetString("options.IPAddress"),
                Port = info.GetValue("options.Port", typeof(int?)) as int? ?? 0
            };

            Options = options;
        }
    }
}
