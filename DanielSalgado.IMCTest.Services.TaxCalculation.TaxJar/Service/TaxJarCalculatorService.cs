// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarCalculatorService.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxCalculatorService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Service
{
    using System.Threading.Tasks;

    using AutoMapper;

    using DanielSalgado.IMCTest.Services.TaxCalculation.Interfaces;
    using DanielSalgado.IMCTest.Services.TaxCalculation.Model;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Core;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// The tax calculator service.
    /// </summary>
    public class TaxJarCalculatorService : ITaxCalculatorService
    {
        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The api client.
        /// </summary>
        private readonly TaxJarApiClient apiClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxJarCalculatorService"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The API Key.
        /// </param>
        /// <param name="mapper">
        /// The mapper.
        /// </param>
        public TaxJarCalculatorService(IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.apiClient = new TaxJarApiClient(configuration["ApiKey"]);
        }

        /// <summary>
        /// Get the tax rate for a location.
        /// </summary>
        /// <param name="address">
        /// The address with the location details.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>. total tax that needs to be collected.
        /// </returns>
        public async Task<decimal> GetTaxRateForLocation(Address address)
        {
            var taxJarAddress = this.mapper.Map<TaxJarAddress>(address);
            var response = await this.apiClient.GetRateForAddressAsync(taxJarAddress);
            return response.Rate.CombinedRate;
        }

        /// <summary>
        /// The get tax for order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="decimal"/>.
        /// </returns>
        public async Task<decimal> GetTaxForOrder(Order order)
        {
            var taxJarOrder = this.mapper.Map<TaxJarOrder>(order);
            var response = await this.apiClient.GetTaxForOrderAsync(taxJarOrder);
            return response.Tax.AmountToCollect;
        }
    }
}
