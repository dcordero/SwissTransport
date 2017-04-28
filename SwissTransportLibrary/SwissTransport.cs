using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SwissTransportLibrary
{
    public class SwissTransport
    {

        public async Task<List<Location>> GetLocations()
        {
            IEnumerable<Location> locations = Enumerable.Empty<Location>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("locations").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        locations = await Task.Run(() =>
                            JsonConvert.DeserializeObject<IEnumerable<Location>>(json)
                        ).ConfigureAwait(false);
                    }
                }
            }

			return locations.ToList();
		}

		private const string ApiBaseAddress = "http://transport.opendata.ch/v1/";
		private HttpClient CreateClient()
		{
			var httpClient = new HttpClient
			{
				BaseAddress = new Uri(ApiBaseAddress)
			};

			httpClient.DefaultRequestHeaders.Accept.Clear();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			return httpClient;
		}
    }
}
