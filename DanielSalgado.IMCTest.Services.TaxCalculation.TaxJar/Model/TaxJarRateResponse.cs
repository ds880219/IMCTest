// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarRateResponse.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarRateResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar rate response.
    /// </summary>
    public class TaxJarRateResponse
    {
        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        [JsonProperty("rate")]
        public TaxJarRate Rate { get; set; }
    }
}
