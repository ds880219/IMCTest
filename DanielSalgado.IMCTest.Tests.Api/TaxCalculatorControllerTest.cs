// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxCalculatorControllerTest.cs" company="Daniel Salgado">
//   This product is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the Tests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Tests.Api
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using DanielSalgado.IMCTest.Api;
    using DanielSalgado.IMCTest.Api.Controllers;
    using DanielSalgado.IMCTest.Api.Domain;
    using DanielSalgado.IMCTest.Services.TaxCalculation.Interfaces;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Service;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    using Moq;

    using Ninject;
    using Ninject.MockingKernel.Moq;

    using NUnit.Framework;

    using Order = DanielSalgado.IMCTest.Services.TaxCalculation.Model.Order;

    public class TaxCalculatorControllerTest
    {
        /// <summary>
        /// The moq kernel.
        /// </summary>
        private MoqMockingKernel moqKernel = new MoqMockingKernel();

        /// <summary>
        /// The setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            var calculatorServiceMock = this.moqKernel.GetMock<ITaxCalculatorService>();
            calculatorServiceMock.Setup(m => m.GetTaxForOrder(It.IsAny<Order>())).Returns(Task.FromResult<decimal>(27));

            var fakeResolver = new Mock<Startup.ServiceResolver>();
            fakeResolver.Setup(x => x(It.IsAny<CustomerType>())).Returns(calculatorServiceMock.Object);

            this.moqKernel.Bind<TaxCalculatorController>().ToSelf()
                .WithConstructorArgument("mapper", this.moqKernel.GetMock<IMapper>().Object)
                .WithConstructorArgument("logger", this.moqKernel.GetMock<ILogger<TaxCalculatorController>>().Object)
                .WithConstructorArgument("serviceResolver", fakeResolver.Object);
        }

        /// <summary>
        /// The return ok status code with tax amount to collect.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Test]
        public async Task ReturnOkStatusCodeWithTaxAmountToCollect()
        {
            // Arrange
            var requestData = new CalculateOrderTaxRequest
                                  {
                                      Customer = new Customer
                                                     {
                                                         CustomerType = CustomerType.B2B,
                                                     },
                                      Order = new IMCTest.Api.Domain.Order()
                                  };

            // Get concrete implementation of class under test
            var controller = this.moqKernel.Get<TaxCalculatorController>();
            
            // Act
            var response = await controller.PostCalculateOrderTax(requestData);
            
            // Assert
            Assert.IsInstanceOf<OkObjectResult>(response);
        }
    }
}