using Adp.Eai.Domain.Models;
using Adp.Eai.Domain.ViewModels;
using Adp.Eai.Service.Interfaces;
using Adp.Eai.Service.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.Contracts;
using System.Net.Http.Json;
using System.Security.AccessControl;
using System.Text.Json;

namespace Adp.Eai.Service.Services
{
    public class CalculationService : GenericService<Calculation>, ICalculationService
    {
        private static IConfiguration _configuration;
        private static string? BaseAddress => _configuration.GetSection("ExternalAPI:BaseAddress").Value;
        private static string? GetCalculationAddress => _configuration.GetSection("ExternalAPI:Get").Value;
        private static string? PostCalculationAddress => _configuration.GetSection("ExternalAPI:Post").Value;

        private readonly IHttpClientFactory _httpClientFactory;

        public CalculationService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Calculation?> CalculationResultAsync()
        {
            var calculation = (Calculation?)new ApiClientFactory(_httpClientFactory).GetAsync<Calculation>($"{BaseAddress}/{GetCalculationAddress}").Result;

            if (calculation != null)
            {
                calculation.Result = await Calculator.PerformCalculation(calculation.Operation, calculation.Left, calculation.Right);
                calculation.PostResult = new ApiClientFactory(_httpClientFactory).PostAsync<CalculationVM, string>($"{BaseAddress}/{PostCalculationAddress}", new CalculationVM
                {
                    Id = calculation.Id,
                    Result = calculation.Result
                }).Result;

                return calculation;
            }
            else
                return null;
        }
    }
}