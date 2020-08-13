// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarLineItem.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarLineItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar line item.
    /// </summary>
    public class TaxJarLineItem
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        [JsonProperty("product_identifier")]
        public string ProductIdentifier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product tax code.
        /// </summary>
        [JsonProperty("product_tax_code")]
        public string ProductTaxCode { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the discount.
        /// </summary>
        [JsonProperty("discount")]
        public decimal Discount { get; set; }

        /// <summary>
        /// Gets or sets the sales tax.
        /// </summary>
        [JsonProperty("sales_tax")]
        public decimal SalesTax { get; set; }
    }
}
