// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarServiceMapperProfile.cs" company="Daniel Salgado">
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
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model;

    /// <summary>
    /// The tax jar service mapper profile.
    /// </summary>
    public class TaxJarServiceMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaxJarServiceMapperProfile"/> class.
        /// </summary>
        public TaxJarServiceMapperProfile()
        {
            this.CreateRatesAddressMappings();
            this.CreateTaxOrderMappings();
        }

        /// <summary>
        /// The create rates address mappings.
        /// </summary>
        private void CreateRatesAddressMappings()
        {
            this.CreateMap<Address, TaxJarAddress>();
        }

        /// <summary>
        /// The create tax order mappings.
        /// </summary>
        private void CreateTaxOrderMappings()
        {
            this.CreateMap<Order, TaxJarOrder>()
                .ForMember(dest => dest.ToZip, opt => opt.MapFrom(src => src.ToAddress.Zip))
                .ForMember(dest => dest.ToCountry, opt => opt.MapFrom(src => src.ToAddress.Country))
                .ForMember(dest => dest.ToState, opt => opt.MapFrom(src => src.ToAddress.State))
                .ForMember(dest => dest.ToCity, opt => opt.MapFrom(src => src.ToAddress.City))
                .ForMember(dest => dest.ToStreet, opt => opt.MapFrom(src => src.ToAddress.Street))
                .ForMember(dest => dest.FromZip, opt => opt.MapFrom(src => src.FromAddress.Zip))
                .ForMember(dest => dest.FromCountry, opt => opt.MapFrom(src => src.FromAddress.Country))
                .ForMember(dest => dest.FromState, opt => opt.MapFrom(src => src.FromAddress.State))
                .ForMember(dest => dest.FromCity, opt => opt.MapFrom(src => src.FromAddress.City))
                .ForMember(dest => dest.FromStreet, opt => opt.MapFrom(src => src.FromAddress.Street))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.TotalCost))
                .ForMember(dest => dest.Shipping, opt => opt.MapFrom(src => src.ShippingCost));
        }
    }
}
