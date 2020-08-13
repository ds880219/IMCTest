// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Daniel Salgado">
//   This product is property of Daniel Salgado
// </copyright>
// <summary>
//   The customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Api.Domain
{
    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the customer type.
        /// </summary>
        public CustomerType CustomerType { get; set; }
    }

    /// <summary>
    /// The customer type.
    /// </summary>
    public enum CustomerType
    {
        /// <summary>
        /// The b 2 b.
        /// </summary>
        B2B = 1,

        /// <summary>
        /// The regular.
        /// </summary>
        Regular = 2
    }
}
