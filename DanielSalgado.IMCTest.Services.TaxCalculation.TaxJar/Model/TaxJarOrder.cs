// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarOrder.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarOrder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar order.
    /// </summary>
    public class TaxJarOrder
    {
        /// <summary>
        /// Gets or sets the from country.
        /// </summary>
        [JsonProperty("from_country")]
        public string FromCountry { get; set; }

        /// <summary>
        /// Gets or sets the from zip.
        /// </summary>
        [JsonProperty("from_zip")]
        public string FromZip { get; set; }

        /// <summary>
        /// Gets or sets the from state.
        /// </summary>
        [JsonProperty("from_state")]
        public string FromState { get; set; }

        /// <summary>
        /// Gets or sets the from city.
        /// </summary>
        [JsonProperty("from_city")]
        public string FromCity { get; set; }

        /// <summary>
        /// Gets or sets the from street.
        /// </summary>
        [JsonProperty("from_street")]
        public string FromStreet { get; set; }

        /// <summary>
        /// Gets or sets the to country.
        /// </summary>
        [JsonProperty("to_country")]
        public string ToCountry { get; set; }

        /// <summary>
        /// Gets or sets the to zip.
        /// </summary>
        [JsonProperty("to_zip")]
        public string ToZip { get; set; }

        /// <summary>
        /// Gets or sets the to state.
        /// </summary>
        [JsonProperty("to_state")]
        public string ToState { get; set; }

        /// <summary>
        /// Gets or sets the to city.
        /// </summary>
        [JsonProperty("to_city")]
        public string ToCity { get; set; }

        /// <summary>
        /// Gets or sets the to street.
        /// </summary>
        [JsonProperty("to_street")]
        public string ToStreet { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the shipping.
        /// </summary>
        [JsonProperty("shipping", NullValueHandling = NullValueHandling.Ignore)]
        public decimal Shipping { get; set; }

        /// <summary>
        /// Gets or sets the line items.
        /// </summary>
        [JsonProperty("line_items")]
        public List<TaxJarLineItem> LineItems { get; set; }
    }
}
