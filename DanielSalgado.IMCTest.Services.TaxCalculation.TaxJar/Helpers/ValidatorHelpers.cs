// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidatorHelpers.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the ValidatorHelpers type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// The validator helpers.
    /// </summary>
    public class ValidatorHelpers
    {
        /// <summary>
        /// The US zip regular expression validator.
        /// </summary>
        private const string UsZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";

        /// <summary>
        /// The ISO two letters regular expression.
        /// </summary>
        private const string IsoTwoLettersRegEx = @"^[A-Z]{2}$";

        /// <summary>
        /// The is US zip code.
        /// </summary>
        /// <param name="zipCode">
        /// The zip code.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsUsZipCode(string zipCode)
        {
            return Regex.Match(zipCode, UsZipRegEx).Success;
        }

        /// <summary>
        /// The is valid country.
        /// </summary>
        /// <param name="country">
        /// The country.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsValidCountry(string country)
        {
            return Regex.Match(country, IsoTwoLettersRegEx).Success;
        }
    }
}
