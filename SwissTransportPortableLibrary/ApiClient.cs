using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SwissTransportPortableLibrary
{
    class ApiClient
    {
        private const string ApiBaseAddress = "http://transport.opendata.ch/v1/";

        private HttpClient httpClient { get; set; }

        internal ApiClient()
        {
            httpClient = CreateClient();
        }

        private HttpClient CreateClient()
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(ApiBaseAddress);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }


        internal async Task<T> HttpGet<T>(String path) where T : class
        {
            HttpResponseMessage response = await httpClient.GetAsync(path);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
