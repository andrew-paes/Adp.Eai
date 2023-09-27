using Adp.Eai.Domain.Models;
using Adp.Eai.Service.Interfaces;
using Adp.Eai.Service.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http.Json;

namespace Adp.Eai.Service.Services
{
    public class CalculationService : GenericService<Calculation>, ICalculationService
    {
        private static IConfiguration _configuration;
        private static string? BaseAddress => _configuration.GetSection("ExternalAPI:BaseAddress").Value;
        private static string? GetCalculationAddress => _configuration.GetSection("ExternalAPI:Get").Value;

        private readonly IHttpClientFactory _httpClientFactory;

        public CalculationService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        private async Task<T?> GetJsonStringAsync<T>(string? request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Clear();

                var resp = client.GetAsync(request).Result;

                if (resp.IsSuccessStatusCode)
                    return await resp.Content.ReadFromJsonAsync<T>();
                else
                    throw new HttpRequestException(resp.ReasonPhrase, new ApplicationException(resp.Content.ReadAsStringAsync().Result), resp.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Calculation?> GetCalculationResultAsync()
        {
            Calculation? calculation = GetJsonStringAsync<Calculation>($"{BaseAddress}/{GetCalculationAddress}").Result;

            if (calculation != null)
            {
                calculation.Result = await Calculator.PerformCalculation(calculation.Operation, calculation.Left, calculation.Right);

                return calculation;
            }
            else
                return null;
        }
    }
}