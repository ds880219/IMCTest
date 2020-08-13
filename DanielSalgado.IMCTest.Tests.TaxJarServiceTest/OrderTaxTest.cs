// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderTaxTest.cs" company="Daniel Salgado">
//   This product is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the OrderTaxTest type.
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
    /// The order tax test.
    /// </summary>
    public class OrderTaxTest
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
        public async Task GettingTaxForOrder()
        {
            var model = new TaxJarOrder
                            {
                                FromCountry = "US",
                                FromZip = "07001",
                                FromState = "NJ",
                                ToCountry = "US",
                                ToZip = "07446",
                                ToState = "NJ",
                                Amount = 400.00m,
                                Shipping = 7.5m,
                            };
            var response = await this.apiClient.GetTaxForOrderAsync(model);
            Assert.AreEqual(27, response.Tax.AmountToCollect);
        }

        /// <summary>
        /// The getting invalid parameters.
        /// </summary>
        [Test]
        public void GettingInvalidParameters()
        {
            var ex = Assert.ThrowsAsync<TaxJarGetOrderTaxGeneralException>(async () => await this.apiClient.GetTaxForOrderAsync(new TaxJarOrder()));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            Assert.That(ex.ErrorCode, Is.EqualTo(TaxJarGetOrderTaxErrorType.InvalidParameters));
        }

        /// <summary>
        /// The getting invalid zip code.
        /// </summary>
        [Test]
        public void GettingNotAcceptable()
        {
            var model = new TaxJarOrder
                            {
                                FromCountry = "USA",
                                FromZip = "07001",
                                FromState = "NJ",
                                ToCountry = "USA",
                                ToZip = "07446",
                                ToState = "NJ",
                                Amount = 400.00m,
                                Shipping = 7.5m,
                            };
            var ex = Assert.ThrowsAsync<TaxJarGetOrderTaxGeneralException>(async () => await this.apiClient.GetTaxForOrderAsync(model));
            Assert.That(ex.StatusCode, Is.EqualTo(HttpStatusCode.NotAcceptable));
            Assert.That(ex.ErrorCode, Is.EqualTo(TaxJarGetOrderTaxErrorType.InvalidParameters));
        }
    }
}
