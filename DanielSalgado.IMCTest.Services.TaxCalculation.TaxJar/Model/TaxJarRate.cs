// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarRate.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarRate type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar rate.
    /// </summary>
    public class TaxJarRate : TaxJarAddress
    {
        /// <summary>
        /// Gets or sets the state rate.
        /// </summary>
        [JsonProperty("state_rate")]
        public decimal StateRate { get; set; }

        /// <summary>
        /// Gets or sets the county.
        /// </summary>
        [JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        /// Gets or sets the county rate.
        /// </summary>
        [JsonProperty("county_rate")]
        public decimal CountyRate { get; set; }

        /// <summary>
        /// Gets or sets the city rate.
        /// </summary>
        [JsonProperty("city_rate")]
        public decimal CityRate { get; set; }

        /// <summary>
        /// Gets or sets the combined district rate.
        /// </summary>
        [JsonProperty("combined_district_rate")]
        public decimal CombinedDistrictRate { get; set; }

        /// <summary>
        /// Gets or sets the combined rate.
        /// </summary>
        [JsonProperty("combined_rate")]
        public decimal CombinedRate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether freight taxable.
        /// </summary>
        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }
    }
}
