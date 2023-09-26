using Adp.Eai.Domain.Models;
using Adp.Eai.Service.Interfaces;
using Adp.Eai.Service.Utils;
using System.Net.Http.Json;

namespace Adp.Eai.Service.Services
{
    public class CalculationService : GenericService<Calculation>, ICalculationService
    {
        private static readonly HttpClient _httpClient = new()
        {
            BaseAddress = new Uri("https://interview.adpeai.com"),
        };

        private static async Task<Calculation> GetCalculationAsync()
        {
            using HttpResponseMessage response = await _httpClient.GetAsync("api/v1/get-task");

            response.EnsureSuccessStatusCode();

            if (response.Content != null && response.Content.Headers.ContentType != null && response.Content.Headers.ContentType.MediaType != null && response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var contentStream = await response.Content.ReadAsStreamAsync();

                //return await JsonSerializer.DeserializeAsync<Calculation>(contentStream, new JsonSerializerOptions { IgnoreNullValues = true, PropertyNameCaseInsensitive = true });

                return await response.Content.ReadFromJsonAsync<Calculation>();
            }

            return null;
        }

        public async Task<Calculation> GetCalculationResultAsync()
        {
            Calculation calculation = await GetCalculationAsync();
            calculation.Result = await Calculator.PerformCalculation(calculation.Operation, calculation.Left, calculation.Right);

            return calculation;
        }
    }
}