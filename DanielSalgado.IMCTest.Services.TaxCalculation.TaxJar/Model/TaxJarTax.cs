// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarTax.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarTax type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    // todo: we can create all the fields in this object to map the full TaxJar response, but the fact we just need amount to collect, I can used at this way.

    /// <summary>
    /// The tax jar tax.
    /// </summary>
    public class TaxJarTax
    {
        /// <summary>
        /// Gets or sets the order total amount.
        /// </summary>
        [JsonProperty("order_total_amount")]
        public decimal OrderTotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the shipping.
        /// </summary>
        [JsonProperty("shipping")]
        public decimal Shipping { get; set; }

        /// <summary>
        /// Gets or sets the taxable amount.
        /// </summary>
        [JsonProperty("taxable_amount")]
        public decimal TaxableAmount { get; set; }

        /// <summary>
        /// Gets or sets the amount to collect.
        /// </summary>
        [JsonProperty("amount_to_collect")]
        public decimal AmountToCollect { get; set; }

        /// <summary>
        /// Gets or sets the rate.
        /// </summary>
        [JsonProperty("rate")]
        public decimal Rate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether has nexus.
        /// </summary>
        [JsonProperty("has_nexus")]
        public bool HasNexus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether freight taxable.
        /// </summary>
        [JsonProperty("freight_taxable")]
        public bool FreightTaxable { get; set; }

        /// <summary>
        /// Gets or sets the tax source.
        /// </summary>
        [JsonProperty("tax_source")]
        public string TaxSource { get; set; }

        /// <summary>
        /// Gets or sets the exemption type.
        /// </summary>
        [JsonProperty("exemption_type")]
        public string ExemptionType { get; set; }
    }
}
