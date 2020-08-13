// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaxCalculatorService.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Class1 type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.Interfaces
{
    using System.Threading.Tasks;

    using DanielSalgado.IMCTest.Services.TaxCalculation.Model;

    /// <summary>
    /// The Tax Calculator Service interface.
    /// </summary>
    public interface ITaxCalculatorService
    {
        /// <summary>
        /// Get the tax rate for a location.
        /// </summary>
        /// <param name="address">
        /// The address with the location details.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>. total tax that needs to be collected.
        /// </returns>
        Task<decimal> GetTaxRateForLocation(Address address);

        /// <summary>
        /// The get tax for order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        Task<decimal> GetTaxForOrder(Order order);
    }
}
