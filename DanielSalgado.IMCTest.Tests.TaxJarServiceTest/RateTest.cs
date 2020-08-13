// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RateTest.cs" company="Daniel Salgado">
//   This product is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Tests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Tests.TaxJarServiceTest
{
    using System.Net;
    using System.Threading.Tasks;

    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Core;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Exceptions;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model;

    using NUnit.Framework;

    /// <summary>
    /// The rate test.
    /// </summary>
    public class RateTest
    {
        /// <summary>
        /// The api client.
        /// </summary>
        private TaxJarApiClient apiClient;

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.apiClient = new TaxJarApiClient("5da2f821eee4035db4771edab942a4cc");
        }

        /// <summary>
        /// The getting rates for address.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Test]
        public async Task GettingRatesForAddress()
        {
            var response = await this.apiClient.GetRateForAddressAsync(new TaxJarAddress { Zip = "33015" });
            Assert.AreEqual("HIALEAH", response.Rate.City);
            Assert.AreEqual("MIAMI-DADE", response.Rate.County);
            Assert.AreEqual("FL", response.Rate.State);
            Assert.AreEqual(0.06, response.Rate.StateRate);
            Assert.AreEqual(0.01, response.Rate.CountyRate);
            Assert.AreEqual(0.07, response.Rate.CombinedRate);
        }

        /// <summary>
        /// The getting invalid parameters.
        /// </summary>
        [Test]
        public void GettingInvalidParameters()
        {
            var ex = Assert.ThrowsAsync<TaxJarGetRateGeneralException>(async () => await this.apiClient.GetRateForAddressAsync(new TaxJarAddress()));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(ex.ErrorCode, Is.EqualTo(TaxJarGetRateErrorType.InvalidParameters));
        }

        /// <summary>
        /// The getting invalid zip code.
        /// </summary>
        [Test]
        public void GettingInvalidZipCode()
        {
            var ex = Assert.ThrowsAsync<TaxJarGetRateGeneralException>(async () => await this.apiClient.GetRateForAddressAsync(new TaxJarAddress { Zip = "4366776576576" }));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(ex.ErrorCode, Is.EqualTo(TaxJarGetRateErrorType.InvalidZipCode));
        }
    }
}