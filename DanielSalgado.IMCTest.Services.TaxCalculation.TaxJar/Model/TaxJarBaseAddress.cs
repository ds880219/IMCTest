// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarBaseAddress.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarBaseAddress type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar base address.
    /// </summary>
    public class TaxJarBaseAddress
    {
        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }
    }
}
