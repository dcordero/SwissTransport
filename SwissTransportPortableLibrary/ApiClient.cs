using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.IO;

namespace SwissTransportPortableLibrary
{
    class ApiClient
    {
        private const string ApiBaseAddress = "http://transport.opendata.ch/v1/";

        private JsonSerializer _serializer = new JsonSerializer();

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

        internal async Task<T> HttpGet<T>(String path, Dictionary<string, string> parameters) where T : class
        {
            var queryString = new List<String>();
            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                if (parameter.Value != null) queryString.Add(parameter.Key + "=" + parameter.Value);
            }
            var url = path + "?" + String.Join("&", queryString);

            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            using (var stream = await response.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                return _serializer.Deserialize<T>(json);
            }
        }
    }
}
