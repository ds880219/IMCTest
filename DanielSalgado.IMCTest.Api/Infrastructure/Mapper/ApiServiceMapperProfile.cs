// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiServiceMapperProfile.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarServiceMapperProfile type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Infrastructure.Mapper
{
    using AutoMapper;

    using DanielSalgado.IMCTest.Services.TaxCalculation.Model;

    /// <summary>
    /// The tax jar service mapper profile.
    /// </summary>
    public class ApiServiceMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiServiceMapperProfile"/> class.
        /// </summary>
        public ApiServiceMapperProfile()
        {
            this.CreateApiTaxOrderMappings();
        }

        /// <summary>
        /// The create tax order mappings.
        /// </summary>
        private void CreateApiTaxOrderMappings()
        {
            this.CreateMap<Api.Domain.Address, Address>();
            this.CreateMap<Api.Domain.Order, Order>()
                .ForMember(dest => dest.FromAddress, opt => opt.MapFrom(src => src.SenderAddress))
                .ForMember(dest => dest.ToAddress, opt => opt.MapFrom(src => src.ShippingAddress))
                .ForMember(dest => dest.TotalCost, opt => opt.MapFrom(src => src.TotalCost))
                .ForMember(dest => dest.ShippingCost, opt => opt.MapFrom(src => src.ShippingCost));
        }
    }
}
