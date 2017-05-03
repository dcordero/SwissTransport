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

        internal async Task<T> HttpGet<T>(String path, Dictionary<string, object> parameters) where T : class
        {
            var url = path + QueryString(parameters);
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

        #region Private

        private String QueryString(Dictionary<string, object> parameters)
        {
            var queryString = new List<String>();
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                if (parameter.Value == null) continue;

                var listOfObjects = parameter.Value as List<string>;
                if (listOfObjects != null)
                {
                    foreach (object value in listOfObjects) {
                        queryString.Add(parameter.Key + "[]=" + value);
                    }
                }
                else
                {
                    queryString.Add(parameter.Key + "=" + parameter.Value);
                }
            }

            return "?" + String.Join("&", queryString);
        }

        #endregion
    }
}
