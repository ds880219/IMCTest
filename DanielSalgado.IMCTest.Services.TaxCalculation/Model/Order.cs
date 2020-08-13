// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.Model
{
    /// <summary>
    /// The order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the from address.
        /// </summary>
        public Address FromAddress { get; set; }

        /// <summary>
        /// Gets or sets the to address.
        /// </summary>
        public Address ToAddress { get; set; }

        /// <summary>
        /// Gets or sets the total cost.
        /// </summary>
        public decimal TotalCost { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost.
        /// </summary>
        public decimal ShippingCost { get; set; }
    }
}
