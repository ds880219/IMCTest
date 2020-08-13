// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxCalculatorController.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxCalculatorController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using DanielSalgado.IMCTest.Api.Domain;
    using DanielSalgado.IMCTest.Services.TaxCalculation.Interfaces;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Order = DanielSalgado.IMCTest.Services.TaxCalculation.Model.Order;

    [ApiController]
    [Route("/api/taxes/")]
    [Produces("application/json")]
    public class TaxCalculatorController : ControllerBase
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<TaxCalculatorController> logger;

        /// <summary>
        /// The mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// The service resolver.
        /// </summary>
        public Startup.ServiceResolver serviceResolver { get; set; }

        public TaxCalculatorController()
        {
        }

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IMapper mapper, Startup.ServiceResolver serviceResolver)
        {
            this.mapper = mapper;
            this.serviceResolver = serviceResolver;
            this.logger = logger;
        }

        /// <summary>
        /// The post calculate order tax.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        [Route("api/taxes/order/calculate")]
        [ProducesResponseType(typeof(decimal), 200)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<IActionResult> PostCalculateOrderTax(CalculateOrderTaxRequest request)
        {
            try
            {
                // get calculator implementation base on the customer type
                var calculatorService = this.serviceResolver(request.Customer.CustomerType);

                // mapping request to service model
                var serviceOrder = this.mapper.Map<Order>(request.Order);

                var tax = await calculatorService.GetTaxForOrder(serviceOrder);

                return this.Ok(tax);
            }
            catch (Exception e)
            {
                return this.StatusCode(500, e.Message);
            }
            
        }
    }
}
