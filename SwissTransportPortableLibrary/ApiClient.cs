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


        internal async Task<T> HttpGet<T>(String basePath, Dictionary<string, string> parameters) where T : class
        {
            var urlBuilder = new UriBuilder(basePath);

            /*
            var urlParameters = HttpUtility.ParseQueryString(string.Empty);
            foreach(KeyValuePair<string, string> parameter in parameters)
            {
                urlParameters[parameter.Key] = parameter.Value;
            }
            */
            urlBuilder.Query = ""; //urlParameters.ToString();

            HttpResponseMessage response = await httpClient.GetAsync(urlBuilder.Uri);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }

            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
