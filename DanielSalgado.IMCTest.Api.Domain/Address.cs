// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Address type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Api.Domain
{
    /// <summary>
    /// The address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public string Country { get; set; } = "US";

        /// <summary>
        /// Gets or sets the zip.
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }
    }
}
