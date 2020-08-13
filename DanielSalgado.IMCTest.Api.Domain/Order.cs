// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Order.cs" company="Daniel Salgado">
//   This product is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Order type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Api.Domain
{
    /// <summary>
    /// The order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the sender address.
        /// </summary>
        public Address SenderAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        public Address ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost.
        /// </summary>
        public decimal ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the total cost.
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}
