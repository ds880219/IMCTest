// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarGetOrderTaxGeneralException.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarGetRateGeneralException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// The TaxJar get order tax general exception.
    /// </summary>
    public class TaxJarGetOrderTaxGeneralException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxJarGetOrderTaxGeneralException"/> class.
        /// </summary>
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="statusCode">
        /// The status Code.
        /// </param>
        public TaxJarGetOrderTaxGeneralException(TaxJarGetOrderTaxErrorType errorCode, string message, HttpStatusCode statusCode) : base(message)
        {
            this.ErrorCode = errorCode;
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        public TaxJarGetOrderTaxErrorType ErrorCode { get; }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }

    /// <summary>
    /// The TaxJar get order tax error type.
    /// </summary>
    public enum TaxJarGetOrderTaxErrorType
    {
        /// <summary>
        /// The invalid parameters.
        /// </summary>
        InvalidParameters = 1,
        
        /// <summary>
        /// The response not complete.
        /// </summary>
        ResponseNotComplete = 3,

        /// <summary>
        /// The unhandled error.
        /// </summary>
        UnhandledError = 4
    }
}
