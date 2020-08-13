// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalculateOrderTaxRequest.cs" company="Daniel Salgado">
//   This product is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the CalculateOrderTaxRequest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace DanielSalgado.IMCTest.Api.Domain
{
    /// <summary>
    /// The calculate order tax request.
    /// </summary>
    public class CalculateOrderTaxRequest
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public Customer Customer { get; set; }
    }
}
