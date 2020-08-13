// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarAddress.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarAddress type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar address.
    /// </summary>
    public class TaxJarAddress : TaxJarBaseAddress
    {
        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        [JsonProperty("street")]
        public string Street { get; set; }
    }
}
