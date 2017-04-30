using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SwissTransportPortableLibrary
{
	public class SwissTransport
    {
		private const string ApiBaseAddress = "http://transport.opendata.ch/v1/";

		protected HttpClient ApiClient { get; private set; }

        public SwissTransport() {
            ApiClient = CreateClient();
        }

		#region Public

		public async Task<ListOfLocations> GetLocations(string locationName)
        {
            return await HttpGet<ListOfLocations>(String.Format("locations?query={0}", locationName));
        }

        public async Task<ListOfLocations> GetStationBoard(string stationId)
        {
            return await HttpGet<ListOfLocations>(String.Format("stationboard?station={0}", stationId));
        }

        #endregion


        #region Private

        private HttpClient CreateClient()
        {
            HttpClient apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(ApiBaseAddress);

            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return apiClient;
        }


		public async Task<T> HttpGet<T>(String path) where T : class
		{
			HttpResponseMessage response = await ApiClient.GetAsync(path);
			var responseContent = await response.Content.ReadAsStringAsync();

			if (!response.IsSuccessStatusCode)
			{
                throw new Exception();
			}

			return JsonConvert.DeserializeObject<T>(responseContent);
		}

        #endregion
    }
}
