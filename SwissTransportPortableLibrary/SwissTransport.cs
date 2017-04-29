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

		public async Task<List<Location>> GetLocations(string locationName = null)
        {
			List<Location> locations = new List<Location>();

			var url = "locations";
			if (locationName != null)
			{
				url += String.Format("?query={0}", locationName);
			}

            return await HttpGet<List<Location>>(url);
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

			//CheckIfJson(responseContent);

			var result = JsonConvert.DeserializeObject<T>(responseContent);

			return result;
		}

        #endregion
    }
}
