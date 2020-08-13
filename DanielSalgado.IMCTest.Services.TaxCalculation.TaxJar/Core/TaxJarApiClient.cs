// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaxJarApiClient.cs" company="Daniel Salgado">
//   This code is property of Daniel Salgado
// </copyright>
// <summary>
//   Defines the TaxJarApiClient type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Core
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Exceptions;
    using DanielSalgado.IMCTest.Services.TaxCalculation.TaxJar.Model;

    using Newtonsoft.Json;

    using RestSharp;
    using RestSharp.Authenticators;

    /// <summary>
    /// The tax jar API client.
    /// </summary>
    public class TaxJarApiClient
    {
        /// <summary>
        /// The API key.
        /// </summary>
        private readonly string apiKey;

        /// <summary>
        /// The url.
        /// </summary>
        private const string Url = "https://api.taxjar.com/v2/";

        /// <summary>
        /// The rate service.
        /// </summary>
        private const string RateService = "rates";

        /// <summary>
        /// The tax service.
        /// </summary>
        private const string TaxService = "taxes";

        /// <summary>
        /// Initializes a new instance of the <see cref="TaxJarApiClient"/> class.
        /// </summary>
        /// <param name="apiKey">
        /// The API key.
        /// </param>
        public TaxJarApiClient(string apiKey)
        {
            this.apiKey = apiKey;
        }

        /// <summary>
        /// Get tax rate for an address.
        /// </summary>
        /// <param name="address">
        /// The address details.
        /// </param>
        /// <returns>
        /// The <see cref="TaxJarRateResponse"/> tax rate details.
        /// </returns>
        public async Task<TaxJarRateResponse> GetRateForAddressAsync(TaxJarAddress address)
        {
            try
            {
                if (address == null || string.IsNullOrEmpty(address.Zip))
                {
                    throw new TaxJarGetRateGeneralException(
                        TaxJarGetRateErrorType.InvalidParameters,
                        TaxJarGetRateErrorType.InvalidParameters.ToString(),
                        HttpStatusCode.BadRequest);
                }

                if (!ValidatorHelpers.IsUsZipCode(address.Zip))
                {
                    throw new TaxJarGetRateGeneralException(
                        TaxJarGetRateErrorType.InvalidZipCode,
                        TaxJarGetRateErrorType.InvalidZipCode.ToString(),
                        HttpStatusCode.BadRequest);
                }

                var client = new RestClient(Url) { Authenticator = new JwtAuthenticator(this.apiKey) };
                var request =
                    new RestRequest($"{RateService}/{address.Zip}")
                        {
                            Method = Method.GET, RequestFormat = DataFormat.Json
                        };

                if (!string.IsNullOrEmpty(address.City))
                {
                    request.AddQueryParameter("city", address.City);
                }

                if (!string.IsNullOrEmpty(address.State))
                {
                    request.AddQueryParameter("state", address.State);
                }

                if (!string.IsNullOrEmpty(address.Country))
                {
                    request.AddQueryParameter("country", address.Country);
                }

                if (!string.IsNullOrEmpty(address.Street))
                {
                    request.AddQueryParameter("street", address.Street);
                }

                var response = await client.ExecuteGetAsync(request);

                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    throw new TaxJarGetRateGeneralException(
                        TaxJarGetRateErrorType.ResponseNotComplete,
                        TaxJarGetRateErrorType.ResponseNotComplete.ToString(),
                        response.StatusCode);
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new TaxJarGetRateGeneralException(
                        TaxJarGetRateErrorType.ResponseNotComplete,
                        response.StatusCode.ToString(),
                        response.StatusCode);
                }

                var responseData = JsonConvert.DeserializeObject<TaxJarRateResponse>(response.Content);

                return responseData;
            }
            catch (TaxJarGetRateGeneralException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new TaxJarGetRateGeneralException(
                    TaxJarGetRateErrorType.UnhandledError,
                    exception.Message,
                    HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// The get tax for order.
        /// </summary>
        /// <param name="order">
        /// The order.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TaxJarTaxResponse> GetTaxForOrderAsync(TaxJarOrder order)
        {
            try
            {
                if (string.IsNullOrEmpty(order.ToCountry) || string.IsNullOrEmpty(order.ToState) || string.IsNullOrEmpty(order.ToZip)
                    || order.Shipping < 0)
                {
                    throw new TaxJarGetOrderTaxGeneralException(
                        TaxJarGetOrderTaxErrorType.InvalidParameters,
                        TaxJarGetOrderTaxErrorType.InvalidParameters.ToString(),
                        HttpStatusCode.BadRequest);
                }

                if (!ValidatorHelpers.IsValidCountry(order.ToCountry)
                    || (!string.IsNullOrEmpty(order.FromCountry) && !ValidatorHelpers.IsValidCountry(order.FromCountry))
                    || (!string.IsNullOrEmpty(order.ToZip) && !ValidatorHelpers.IsUsZipCode(order.ToZip))
                    || (!string.IsNullOrEmpty(order.FromZip) && !ValidatorHelpers.IsUsZipCode(order.FromZip)))
                {
                    throw new TaxJarGetOrderTaxGeneralException(
                        TaxJarGetOrderTaxErrorType.InvalidParameters,
                        TaxJarGetOrderTaxErrorType.InvalidParameters.ToString(),
                        HttpStatusCode.NotAcceptable);
                }

                var client = new RestClient(Url) { Authenticator = new JwtAuthenticator(this.apiKey) };
                var request =
                    new RestRequest(TaxService)
                        {
                            Method = Method.POST,
                            RequestFormat = DataFormat.Json
                        };
                request.AddJsonBody(JsonConvert.SerializeObject(order), "application/json");
                var response = await client.ExecutePostAsync(request);

                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    throw new TaxJarGetOrderTaxGeneralException(
                        TaxJarGetOrderTaxErrorType.ResponseNotComplete,
                        TaxJarGetOrderTaxErrorType.ResponseNotComplete.ToString(),
                        response.StatusCode);
                }

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new TaxJarGetOrderTaxGeneralException(TaxJarGetOrderTaxErrorType.ResponseNotComplete, response.StatusCode.ToString(), response.StatusCode);
                }

                var responseData = JsonConvert.DeserializeObject<TaxJarTaxResponse>(response.Content);

                return responseData;
            }
            catch (TaxJarGetOrderTaxGeneralException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new TaxJarGetOrderTaxGeneralException(
                    TaxJarGetOrderTaxErrorType.UnhandledError,
                    exception.Message,
                    HttpStatusCode.InternalServerError);
            }
        }
    }
}
