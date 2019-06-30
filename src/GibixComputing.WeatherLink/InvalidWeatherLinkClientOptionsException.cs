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
    public class InvalidWeatherLinkClientOptionsException : WeatherLinkException
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
        /// with a specified error message and a reference to the inner exception that is the cause of this
        /// exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="options">The options data that failed to parse.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidWeatherLinkClientOptionsException(string message, WeatherLinkClientOptions options, Exception innerException) : base(message, innerException)
        {
            Options = options;
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
                Address = info.GetString($"{nameof(InvalidWeatherLinkClientOptionsException)}.{nameof(Options)}.{nameof(Options.Address)}"),
                Port = (int)info.GetValue($"{nameof(InvalidWeatherLinkClientOptionsException)}.{nameof(Options)}.{nameof(Options.Port)}", typeof(int))
            };

            Options = options;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info is null)
                throw new ArgumentNullException(nameof(info));

            var options = Options ?? new WeatherLinkClientOptions();

            info.AddValue(
                $"{nameof(InvalidWeatherLinkClientOptionsException)}.{nameof(Options)}.{nameof(Options.Address)}",
                options.Address);
            info.AddValue(
                $"{nameof(InvalidWeatherLinkClientOptionsException)}.{nameof(Options)}.{nameof(Options.Port)}",
                options.Port);

            base.GetObjectData(info, context);
        }
    }
}
