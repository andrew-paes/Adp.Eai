using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Adp.Eai.Service.Utils
{
    public class ApiClientFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ApiClientFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<object?> GetAsync<T>(string? request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Clear();

                var resp = client.GetAsync(request).Result;

                if (resp.IsSuccessStatusCode)
                    if (resp.Content.Headers.ContentType?.MediaType == "application/json")
                        return await resp.Content.ReadFromJsonAsync<T>();
                    else
                        return await resp.Content.ReadAsStringAsync();
                else
                    throw new HttpRequestException(resp.ReasonPhrase, new ApplicationException(resp.Content.ReadAsStringAsync().Result), resp.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<object?> PostAsync<T, R>(string request, object content)
        {
            try
            {
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };

                string json = JsonSerializer.Serialize(content, typeof(T), serializeOptions);

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Clear();

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var resp = client.PostAsync(request, byteContent).Result;

                if (resp.IsSuccessStatusCode)
                    if (resp.Content.Headers.ContentType?.MediaType == "application/json")
                        return await resp.Content.ReadFromJsonAsync<R>();
                    else
                        return await resp.Content.ReadAsStringAsync();
                else
                    throw new HttpRequestException(resp.ReasonPhrase, new ApplicationException(resp.Content.ReadAsStringAsync().Result), resp.StatusCode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
