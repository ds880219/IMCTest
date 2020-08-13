// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarTaxResponse.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarTaxResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model
{
    using Newtonsoft.Json;

    /// <summary>
    /// The tax jar tax response.
    /// </summary>
    public class TaxJarTaxResponse
    {
        [JsonProperty("tax")]
        public TaxJarTax Tax { get; set; }
    }
}
