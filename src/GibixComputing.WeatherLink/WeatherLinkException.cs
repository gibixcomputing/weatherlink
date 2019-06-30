// Copyright (c) Gibix Computing, LLC. All rights reserved.
// Licensed under AGPLv3. See LICENSE in the project root for license information.

using System;
using System.Runtime.Serialization;

namespace GibixComputing.WeatherLink
{
    /// <summary>
    /// Represents the base class used for exceptions thrown by the WeatherLink library.
    /// </summary>
    [Serializable]
    public class WeatherLinkException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherLinkException"/> class.
        /// </summary>
        public WeatherLinkException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherLinkException"/> class with a specified
        /// error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public WeatherLinkException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherLinkException"/> class with a specified
        /// error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public WeatherLinkException(string message, Exception? innerException) : base(message, innerException)
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
        protected WeatherLinkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
